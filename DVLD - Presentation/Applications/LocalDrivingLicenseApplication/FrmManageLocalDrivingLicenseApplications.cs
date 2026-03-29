using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DVLD.Applications;
using DVLD___Business;

namespace DVLD.LocalDrivingLicenseApplication
{
    public partial class FrmManageLocalDrivingLicenseApplications : Form
    {
        public FrmManageLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        #region Event Handlers

        private void FrmManageLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            _LoadApplications();
            cbFilterBy.Items.Clear();
            cbFilterBy.Items.AddRange(new string[]
            {
                "None",
                "L.D.L Application ID",
                "National No",
                "Full Name",
                "Status"
            });
            cbFilterBy.SelectedIndex = 0;
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Indices for which we show a text box
            int[] textBoxIndices = { 1, 2, 3}; // L.D.L Application ID, National No, Full Name
            // Index for which we show a combo box
            int[] comboIndices = { 4 }; // status

            int selected = cbFilterBy.SelectedIndex;

            if (textBoxIndices.Contains(selected))
            {
                tbUserInput.Clear();
                cbUserChoice.Visible = false;
                tbUserInput.Visible = true;

                if (selected == 1) // L.D.L Application ID
                    tbUserInput.KeyPress += TbUserInput_KeyPress_NumericOnly;
                else
                    tbUserInput.KeyPress -= TbUserInput_KeyPress_NumericOnly;
            }
            else if (comboIndices.Contains(selected))
            {
                tbUserInput.Visible = false;
                cbUserChoice.Visible = true;
                cbUserChoice.Items.Clear();
                string[] statuses = { "New", "Canceled", "Completed" };
                cbUserChoice.Items.Add("All");
                cbUserChoice.Items.AddRange (statuses);
                cbUserChoice.SelectedIndex = 0;
            }
            else // None
            {
                tbUserInput.Visible = false;
                cbUserChoice.Visible = false;
                _LoadApplications();
            }
        }

        private void cbUserChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex != 4 || cbUserChoice.SelectedIndex < 0)
                return;

            DataTable allApplications = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();

            if (cbUserChoice.SelectedIndex == 0)
            {
                _LoadApplications();
            }
            else
            {
                string selected = cbUserChoice.SelectedItem.ToString();
                DataRow[] filtered = allApplications.Select($"Status = '{selected}'");
                _UpdateDataGridView(allApplications, filtered);
            }
        }

        private void tbUserInput_TextChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex < 0 || string.IsNullOrWhiteSpace(tbUserInput.Text))
                return;

            int filterIndex = cbFilterBy.SelectedIndex;
            DataTable allApplications = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            DataRow[] filtered = null;

            switch (filterIndex)
            {
                case 1: // appID
                    if (int.TryParse(tbUserInput.Text, out int appID))
                        filtered = allApplications.Select($"LocalDrivingLicenseApplicationID = {appID}");
                    break;
                case 2: // National Number
                    filtered = allApplications.Select($"NationalNo LIKE '{tbUserInput.Text}%'");
                    break;
                case 3: // Full Name
                    filtered = allApplications.Select($"FullName LIKE '{tbUserInput.Text}%'");
                    break;
            }

            _UpdateDataGridView(allApplications, filtered);
        }

        private void TbUserInput_KeyPress_NumericOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btnNew_Click(object sender, EventArgs e) => _AddNewApplication();

        private void btnEdit_Click(object sender, EventArgs e) => _EditApplication();

        private void btnDelete_Click(object sender, EventArgs e) => _DeleteApplication();

        private void btnClose_Click(object sender, EventArgs e) => Close();

        #region Context Menu Strip Items
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvApplications.SelectedRows.Count == 0) return;
            int appId = Convert.ToInt32(dgvApplications.SelectedRows[0].Cells["LocalDrivingLicenseApplicationID"].Value);
            FrmApplicationDetails frm = new FrmApplicationDetails(appId);
            frm.ShowDialog();
        }

        private void addNewApplicationToolStripMenuItem_Click(object sender, EventArgs e) => _AddNewApplication();

        private void editToolStripMenuItem_Click(object sender, EventArgs e) => _EditApplication();

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) => _DeleteApplication();

        private void CancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvApplications.SelectedRows.Count == 0) return;

            if (MessageBox.Show("Are You Sure You Want To Cancel This Application?", "Confirm Cancel", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            int appId = Convert.ToInt32(dgvApplications.SelectedRows[0].Cells["LocalDrivingLicenseApplicationID"].Value);

            if (clsLocalDrivingLicenseApplication.Exists(appId)) // check if Local Driving License Application Exists
            {
                appId = clsLocalDrivingLicenseApplication.Find(appId).ApplicationID; // get the application ID from Local Driving License Application
            }

            if (clsApplication.Cancel(appId))
            {
                MessageBox.Show("The Application Has Been Canceled Successfully.", "Success", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                _LoadApplications();
            }
            else
            {
                MessageBox.Show("Something went wrong when Trying to cancel the application you selected.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion

        #endregion

        #region Helpers

        private void _LoadApplications()
        {
            DataTable dtApps = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            lblRecordsCount.Text = dtApps.Rows.Count.ToString("N0");
            dgvApplications.DataSource = dtApps;
            _ConfigureDataGridView();
        }

        private void _ConfigureDataGridView()
        {
            if (dgvApplications.Columns.Count == 0) return;

            // Basic settings
            dgvApplications.AllowUserToAddRows = false;
            dgvApplications.AllowUserToDeleteRows = false;
            dgvApplications.ReadOnly = true;
            dgvApplications.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvApplications.MultiSelect = false;
            dgvApplications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvApplications.RowHeadersVisible = false;
            dgvApplications.BackgroundColor = Color.White;
            dgvApplications.BorderStyle = BorderStyle.Fixed3D;
            dgvApplications.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvApplications.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvApplications.EnableHeadersVisualStyles = false;

            // Header style – Green
            dgvApplications.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 125, 50); // Dark green
            dgvApplications.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvApplications.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvApplications.ColumnHeadersHeight = 40;

            // Rows style – Light green alternating
            dgvApplications.RowsDefaultCellStyle.BackColor = Color.White;
            dgvApplications.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(232, 245, 233); // Light green
            dgvApplications.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvApplications.DefaultCellStyle.ForeColor = Color.FromArgb(33, 33, 33);
            dgvApplications.DefaultCellStyle.SelectionBackColor = Color.FromArgb(27, 94, 32); // Darker green
            dgvApplications.DefaultCellStyle.SelectionForeColor = Color.White;

            // Set column headers
            _SetColumnHeader("LocalDrivingLicenseApplicationID", "L.D.L Application ID");
            _SetColumnHeader("ClassName", "Class Name");
            _SetColumnHeader("NationalNo", "National No");
            _SetColumnHeader("FullName", "Full Name");
            _SetColumnHeader("ApplicationDate", "Application Date");
            _SetColumnHeader("PassedTestCount", "Passed Test Count");
            _SetColumnHeader("Status", "Status");

            // Set display order
            int index = 0;
            if (dgvApplications.Columns.Contains("LocalDrivingLicenseApplicationID"))
                dgvApplications.Columns["LocalDrivingLicenseApplicationID"].DisplayIndex = index++;
            if (dgvApplications.Columns.Contains("ClassName"))
                dgvApplications.Columns["ClassName"].DisplayIndex = index++;
            if (dgvApplications.Columns.Contains("NationalNo"))
                dgvApplications.Columns["NationalNo"].DisplayIndex = index++;
            if (dgvApplications.Columns.Contains("FullName"))
                dgvApplications.Columns["FullName"].DisplayIndex = index++;
            if (dgvApplications.Columns.Contains("ApplicationDate"))
                dgvApplications.Columns["ApplicationDate"].DisplayIndex = index++;
            if (dgvApplications.Columns.Contains("PassedTestCount"))
                dgvApplications.Columns["PassedTestCount"].DisplayIndex = index++;
            if (dgvApplications.Columns.Contains("Status"))
                dgvApplications.Columns["Status"].DisplayIndex = index++;

            // Set column widths
            if (dgvApplications.Columns.Contains("LocalDrivingLicenseApplicationID"))
                dgvApplications.Columns["LocalDrivingLicenseApplicationID"].Width = 130;
            if (dgvApplications.Columns.Contains("ClassName"))
                dgvApplications.Columns["ClassName"].Width = 200;
            if (dgvApplications.Columns.Contains("NationalNo"))
                dgvApplications.Columns["NationalNo"].Width = 130;
            if (dgvApplications.Columns.Contains("FullName"))
                dgvApplications.Columns["FullName"].Width = 280;
            if (dgvApplications.Columns.Contains("ApplicationDate"))
                dgvApplications.Columns["ApplicationDate"].Width = 130;
            if (dgvApplications.Columns.Contains("PassedTestCount"))
                dgvApplications.Columns["PassedTestCount"].Width = 110;
            if (dgvApplications.Columns.Contains("Status"))
                dgvApplications.Columns["Status"].Width = 150;

            // Center alignment for ID, Test Count, and Date columns
            if (dgvApplications.Columns.Contains("LocalDrivingLicenseApplicationID"))
            {
                dgvApplications.Columns["LocalDrivingLicenseApplicationID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvApplications.Columns["LocalDrivingLicenseApplicationID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvApplications.Columns.Contains("PassedTestCount"))
            {
                dgvApplications.Columns["PassedTestCount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvApplications.Columns["PassedTestCount"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvApplications.Columns.Contains("ApplicationDate"))
            {
                dgvApplications.Columns["ApplicationDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvApplications.Columns["ApplicationDate"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void _SetColumnHeader(string columnName, string headerText)
        {
            if (dgvApplications.Columns.Contains(columnName))
                dgvApplications.Columns[columnName].HeaderText = headerText;
        }

        private void _UpdateDataGridView(DataTable originalData, DataRow[] filteredRows)
        {
            if (filteredRows != null && filteredRows.Length > 0)
                dgvApplications.DataSource = filteredRows.CopyToDataTable();
            else
                dgvApplications.DataSource = originalData.Clone();
            lblRecordsCount.Text = dgvApplications.RowCount.ToString("N0");
            _ConfigureDataGridView();
        }

        private void _AddNewApplication()
        {
            FrmAddEditLocalDrivingLicenseApplication frm = new FrmAddEditLocalDrivingLicenseApplication();
            frm.ShowDialog();
            _LoadApplications();
        }

        private void _EditApplication()
        {
            if (dgvApplications.SelectedRows.Count == 0) return;
            int appId = Convert.ToInt32(dgvApplications.SelectedRows[0].Cells["LocalDrivingLicenseApplicationID"].Value);
            FrmAddEditLocalDrivingLicenseApplication frm = new FrmAddEditLocalDrivingLicenseApplication(appId);
            frm.ShowDialog();
            _LoadApplications();
        }

        private void _DeleteApplication()
        {
            if (dgvApplications.SelectedRows.Count == 0) return;
            int appId = Convert.ToInt32(dgvApplications.SelectedRows[0].Cells["LocalDrivingLicenseApplicationID"].Value);

            if (MessageBox.Show("Are you sure you want to delete this application?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            if (!clsLocalDrivingLicenseApplication.Delete(appId))
            {
                MessageBox.Show("This application cannot be deleted because it is linked to other records.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Application deleted successfully.", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            _LoadApplications();
        }

        #endregion

        private void writtenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}