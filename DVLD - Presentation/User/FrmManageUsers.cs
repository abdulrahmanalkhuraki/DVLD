using DVLD___Business;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DVLD.User
{
    public partial class FrmManageUsers : Form
    {
        public FrmManageUsers()
        {
            InitializeComponent();
        }

        #region Event Handlers

        private void FrmManageUsers_Load(object sender, EventArgs e)
        {
            _LoadUsers();
            cbFilterBy.Items.Clear();
            cbFilterBy.Items.AddRange(new string[] { "None", "User ID", "User Name", "Person ID", "Is Active" });
            cbFilterBy.SelectedIndex = 0;
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            int[] textBoxIndices = { 1, 2, 3 }; // User ID, User Name, Person ID
            int[] comboIndices = { 4 };         // Is Active

            int selected = cbFilterBy.SelectedIndex;

            if (textBoxIndices.Contains(selected))
            {
                tbUserInput.Clear();
                cbUserChoice.Visible = false;
                tbUserInput.Visible = true;

                if (selected == 1 || selected == 3) // Numeric only for IDs
                    tbUserInput.KeyPress += TbUserInput_KeyPress_NumericOnly;
                else
                    tbUserInput.KeyPress -= TbUserInput_KeyPress_NumericOnly;
            }
            else if (comboIndices.Contains(selected))
            {
                tbUserInput.Visible = false;
                cbUserChoice.Visible = true;
                cbUserChoice.Items.Clear();
                cbUserChoice.Items.AddRange(new string[] { "All" ,"Yes", "No" });
                cbUserChoice.SelectedIndex = 0;
            }
            else // None
            {
                tbUserInput.Visible = false;
                cbUserChoice.Visible = false;
                dgvUsers.DataSource = clsUser.GetAllUsers();
                _ConfigureDataGridView(); // Reapply configuration after data source reset
            }
        }

        private void cbUserChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex != 4 || cbUserChoice.SelectedIndex < 0)
                return;


            DataTable allUsers = clsUser.GetAllUsers();

            if(cbUserChoice.SelectedIndex == 0)
            {
                dgvUsers.DataSource = allUsers;
                _ConfigureDataGridView();
            }
            else
            {
                bool isActive = cbUserChoice.SelectedIndex == 1;
                DataRow[] filtered = allUsers.Select($"IsActive = {(isActive ? 1 : 0)}");
                _UpdateDataGridView(allUsers, filtered);
            }
        }

        private void tbUserInput_TextChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex < 0 || string.IsNullOrWhiteSpace(tbUserInput.Text))
                return;

            int filterIndex = cbFilterBy.SelectedIndex;
            DataTable allUsers = clsUser.GetAllUsers();
            DataRow[] filtered = null;

            switch (filterIndex)
            {
                case 1: // User ID
                    if (int.TryParse(tbUserInput.Text, out int uid))
                        filtered = allUsers.Select($"UserID = {uid}");
                    break;
                case 2: // User Name
                    filtered = allUsers.Select($"UserName LIKE '{tbUserInput.Text}%'");
                    break;
                case 3: // Person ID
                    if (int.TryParse(tbUserInput.Text, out int pid))
                        filtered = allUsers.Select($"PersonID = {pid}");
                    break;
            }

            _UpdateDataGridView(allUsers, filtered);
        }

        private void TbUserInput_KeyPress_NumericOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btnNew_Click(object sender, EventArgs e) => _AddNewUser();

        private void btnEdit_Click(object sender, EventArgs e) => _EditUser();

        private void btnDelete_Click(object sender, EventArgs e) => _DeleteUser();

        private void btnClose_Click(object sender, EventArgs e) => Close();

        #region Context Menu Strip Items
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0) return;
            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserID"].Value);
            FrmUserDetails frm = new FrmUserDetails(userId);
            frm.ShowDialog();
            if (frm.IsUserEdited())
            {
                _LoadUsers();
            }
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e) => _AddNewUser();

        private void editToolStripMenuItem_Click(object sender, EventArgs e) => _EditUser();

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) => _DeleteUser();

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet.", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet.", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0) return;
            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserID"].Value);
            FrmChangePassword frm = new FrmChangePassword(userId);
            frm.ShowDialog();
        }

        #endregion

        #endregion

        #region Helpers

        private void _LoadUsers()
        {
            DataTable dtUsers = clsUser.GetAllUsers();
            lblRecordsCount.Text = dtUsers.Rows.Count.ToString("N0");
            dgvUsers.DataSource = dtUsers;
            _ConfigureDataGridView();
        }

        private void _ConfigureDataGridView()
        {
            if (dgvUsers.Columns.Count == 0) return;

            // Basic settings
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.ReadOnly = true;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.MultiSelect = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.BackgroundColor = Color.White; // or Color.FromArgb(245, 245, 245)
            dgvUsers.BorderStyle = BorderStyle.Fixed3D;
            dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvUsers.EnableHeadersVisualStyles = false;


            // Header style - Purple
            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(103, 58, 183);  // Deep purple
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUsers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvUsers.ColumnHeadersHeight = 40;

            // Rows style - Soft purple alternating
            dgvUsers.RowsDefaultCellStyle.BackColor = Color.White;
            dgvUsers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(243, 239, 249);  // Light lavender
            dgvUsers.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvUsers.DefaultCellStyle.ForeColor = Color.FromArgb(33, 33, 33);
            dgvUsers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(81, 45, 168);  // Darker purple
            dgvUsers.DefaultCellStyle.SelectionForeColor = Color.White;

            // Set column headers and visibility
            _SetColumnHeader("UserID", "User ID");
            _SetColumnHeader("PersonID", "Person ID");
            _SetColumnHeader("FullName", "Full Name");
            _SetColumnHeader("UserName", "User Name");
            _SetColumnHeader("IsActive", "Active");

            // Set display order
            int index = 0;
            if (dgvUsers.Columns.Contains("UserID"))
                dgvUsers.Columns["UserID"].DisplayIndex = index++;
            if (dgvUsers.Columns.Contains("PersonID"))
                dgvUsers.Columns["PersonID"].DisplayIndex = index++;
            if (dgvUsers.Columns.Contains("FullName"))
                dgvUsers.Columns["FullName"].DisplayIndex = index++;
            if (dgvUsers.Columns.Contains("UserName"))
                dgvUsers.Columns["UserName"].DisplayIndex = index++;
            if (dgvUsers.Columns.Contains("IsActive"))
                dgvUsers.Columns["IsActive"].DisplayIndex = index++;

            // Set column widths
            if (dgvUsers.Columns.Contains("UserID"))
                dgvUsers.Columns["UserID"].Width = 157;
            if (dgvUsers.Columns.Contains("PersonID"))
                dgvUsers.Columns["PersonID"].Width = 177;
            if (dgvUsers.Columns.Contains("FullName"))
                dgvUsers.Columns["FullName"].Width = 377;
            if (dgvUsers.Columns.Contains("UserName"))
                dgvUsers.Columns["UserName"].Width = 257;
            if (dgvUsers.Columns.Contains("IsActive"))
                dgvUsers.Columns["IsActive"].Width = 157;

            // Center alignment for ID columns and IsActive
            if (dgvUsers.Columns.Contains("UserID"))
            {
                dgvUsers.Columns["UserID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvUsers.Columns["UserID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvUsers.Columns.Contains("PersonID"))
            {
                dgvUsers.Columns["PersonID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvUsers.Columns["PersonID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvUsers.Columns.Contains("IsActive"))
            {
                dgvUsers.Columns["IsActive"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvUsers.Columns["IsActive"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Convert IsActive column to checkbox
            if (dgvUsers.Columns.Contains("IsActive") && !(dgvUsers.Columns["IsActive"] is DataGridViewCheckBoxColumn))
            {
                DataGridViewColumn oldCol = dgvUsers.Columns["IsActive"];
                int colIndex = oldCol.Index;
                string headerText = oldCol.HeaderText;
                int width = oldCol.Width;
                bool visible = oldCol.Visible;

                // Create checkbox column with custom style
                DataGridViewCheckBoxColumn newCol = new DataGridViewCheckBoxColumn
                {
                    Name = "IsActive",
                    HeaderText = headerText,
                    Width = width,
                    Visible = visible,
                    DataPropertyName = "IsActive",
                    ReadOnly = true,
                    ThreeState = false,
                    CellTemplate = new DataGridViewCheckBoxCell
                    {
                        Style = new DataGridViewCellStyle
                        {
                            Alignment = DataGridViewContentAlignment.MiddleCenter,
                            BackColor = Color.White,
                            SelectionBackColor = Color.FromArgb(52, 152, 219)
                        }
                    }
                };

                dgvUsers.Columns.Remove(oldCol);
                dgvUsers.Columns.Insert(colIndex, newCol);
            }
        }

        private void _SetColumnHeader(string columnName, string headerText)
        {
            if (dgvUsers.Columns.Contains(columnName))
                dgvUsers.Columns[columnName].HeaderText = headerText;
        }

        private void _UpdateDataGridView(DataTable originalData, DataRow[] filteredRows)
        {
            if (filteredRows != null && filteredRows.Length > 0)
                dgvUsers.DataSource = filteredRows.CopyToDataTable();
            else
                dgvUsers.DataSource = originalData.Clone();
            lblRecordsCount.Text = dgvUsers.RowCount.ToString("N0");
            _ConfigureDataGridView(); 
        }

        private void _AddNewUser()
        {
            FrmAddEditUser frm = new FrmAddEditUser();
            frm.ShowDialog();
            _LoadUsers();
        }

        private void _EditUser()
        {
            if (dgvUsers.SelectedRows.Count == 0) return;
            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserID"].Value);
            FrmAddEditUser frm = new FrmAddEditUser(userId);
            frm.ShowDialog();
            _LoadUsers();
        }

        private void _DeleteUser()
        {
            if (dgvUsers.SelectedRows.Count == 0) return;
            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserID"].Value);

            if (MessageBox.Show("Are you sure you want to delete this user?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            if (!clsUser.DeleteUser(userId))
            {
                MessageBox.Show("This user cannot be deleted because it is linked to other records.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("User deleted successfully.", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            _LoadUsers();
        }

        #endregion

    }
}