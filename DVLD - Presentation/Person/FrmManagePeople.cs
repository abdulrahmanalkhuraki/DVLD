using DVLD___Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DVLD.Person
{
    public partial class FrmManagePeople : Form
    {
        public FrmManagePeople()
        {
            InitializeComponent();
        }

        #region Event Handelers
        private void FrmManagePeople_Load(object sender, EventArgs e)
        {
            _LoadPeople();
            cbFilterBy.SelectedIndex = 0;

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            /*
             * Items in cbFilterBy *
             index | property
               0   | select a filter
               1   | Person ID
               2   | National Number
               3   | First Name
               4   | Second Name
               5   | Third Name
               6   | Last Name
               7   | Gender
               8   | Phone
               9   | Email
               10  | Nationality Country
             
             */

            DataTable allPeople = clsPerson.GetAllPeople();
            dgvPeople.DataSource = allPeople;
            ConfigurePeopleGridView();

            int[] ItemsNeedsTextBox = { 1, 2, 3, 4, 5, 6, 8, 9 };
            int[] ItemsNeedsCombo = { 7, 10 };

            int CurrentSelectedIndex = (sender as ComboBox).SelectedIndex;

            if (ItemsNeedsTextBox.Contains(CurrentSelectedIndex))
            {
                tbUserInput.Clear();
                cbUserChoice.Visible = false;
                tbUserInput.Visible = true;
            }
            else if (ItemsNeedsCombo.Contains(CurrentSelectedIndex))
            {
                tbUserInput.Visible = false;
                cbUserChoice.Visible = true;

                if (CurrentSelectedIndex == 7)
                {
                    string[] genders = { "Male", "Female" };
                    cbUserChoice.Items.Clear();
                    cbUserChoice.Items.AddRange(genders);
                    cbUserChoice.SelectedIndex = 0;
                }
                else
                {
                    DataTable dtCountries = clsCountry.GetAllCountries();
                    List<string> Countries = new List<string>();
                    foreach (DataRow Country in dtCountries.Rows)
                    {
                        Countries.Add(Country["CountryName"].ToString());
                    }
                    cbUserChoice.Items.Clear();
                    cbUserChoice.Items.AddRange(Countries.ToArray());
                    cbUserChoice.SelectedIndex = 168;
                }
            }
            else
            {
                tbUserInput.Visible = false;
                cbUserChoice.Visible = false;
            }
        }

        private void cbUserChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex < 0 || cbUserChoice.SelectedIndex < 0)
                return;

            DataTable peopleData = clsPerson.GetAllPeople();
            DataRow[] filteredData = null;

            if (cbFilterBy.SelectedIndex == 7)
            {
                string gender = cbUserChoice.SelectedIndex == 0 ? "Male" : "Female";
                filteredData = peopleData.Select($"Gender = '{gender}'");
            }
            else if (cbFilterBy.SelectedIndex == 10)
            {
                string nationality = cbUserChoice.Text;
                filteredData = peopleData.Select($"Nationality = '{nationality}'");
            }

            UpdateDataGridView(peopleData, filteredData);
        }

        private void tbUserInput_TextChanged(object sender, EventArgs e)
        {
            /*
             * Items in cbFilterBy *
             index | property
               0   | select a filter
               1   | Person ID
               2   | National Number
               3   | First Name
               4   | Second Name
               5   | Third Name
               6   | Last Name
               7   | Gender
               8   | Phone
               9   | Email
               10  | Nationality Country

             */

            if (cbFilterBy.SelectedIndex < 0 || string.IsNullOrEmpty(tbUserInput.Text))
                return;

            int filterByIndex = cbFilterBy.SelectedIndex;

            DataTable peopleData = clsPerson.GetAllPeople();
            DataRow[] filteredData = null;


            switch (filterByIndex)
            {
                case 1:
                    {
                        filteredData = peopleData.Select($"[Person ID] = {Convert.ToInt16(tbUserInput.Text)}");
                    }
                    break;
                case 2:
                    {
                        filteredData = peopleData.Select($"[National Number] Like '{tbUserInput.Text}%'");
                    }
                    break;
                case 3:
                    {
                        filteredData = peopleData.Select($"Firstname Like '{tbUserInput.Text}%'");
                    }
                    break;
                case 4:
                    {
                        filteredData = peopleData.Select($"Secondname Like '{tbUserInput.Text}%'");
                    }
                    break;
                case 5:
                    {
                        filteredData = peopleData.Select($"Thirdname Like '{tbUserInput.Text}%'");
                    }
                    break;
                case 6:
                    {
                        filteredData = peopleData.Select($"Lastname Like '{tbUserInput.Text}%'");
                    }
                    break;
                case 8:
                    {
                        filteredData = peopleData.Select($"Phone Like '{tbUserInput.Text}%'");
                    }
                    break;
                case 9:
                    {
                        filteredData = peopleData.Select($"Email Like '{tbUserInput.Text}%'");
                    }
                    break;
            }
            UpdateDataGridView(peopleData, filteredData);

        }

        private void tbUserInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex != 1)
            {
                return;
            }


            if (!char.IsControl(e.KeyChar))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var SelectedRow = dgvPeople.SelectedRows[0];
            int SelectedPersonId = Convert.ToInt32(SelectedRow.Cells["Person ID"].Value);
            FrmPersonDetails frmPersonDetails = new FrmPersonDetails(SelectedPersonId);
            frmPersonDetails.ShowDialog();
        }

        private void btnClose_Click_1(object sender, EventArgs e) => Close();

        private void btnNew_Click(object sender, EventArgs e) => _AddNewPerson();

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e) => _AddNewPerson();

        private void btnDelete_Click(object sender, EventArgs e) => _DeletePerson();

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) => _DeletePerson();

        private void btnEdit_Click(object sender, EventArgs e) => _EditPersonInfo();

        private void editToolStripMenuItem_Click(object sender, EventArgs e) => _EditPersonInfo();

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is not implemented Yet.",
                    "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is not implemented Yet.",
            "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Helpers
        private void UpdateDataGridView(DataTable orignalData, DataRow[] filteredData)
        {
            if (filteredData != null && filteredData.Length > 0)
            {
                dgvPeople.DataSource = filteredData.CopyToDataTable();
            }
            else
            {
                DataTable dt = orignalData.Clone();
                dgvPeople.DataSource = dt;
            }
        }

        private void _LoadPeople()
        {
            DataTable people = clsPerson.GetAllPeople();
            lblRecordsCount.Text = people.Rows.Count.ToString("N0");
            dgvPeople.DataSource = people;
            ConfigurePeopleGridView();
        }

        private void ConfigurePeopleGridView()
        {
            // Basic DataGridView properties
            dgvPeople.AllowUserToAddRows = false;
            dgvPeople.AllowUserToDeleteRows = false;
            dgvPeople.ReadOnly = true;
            dgvPeople.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPeople.MultiSelect = false;
            dgvPeople.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; // Manual widths
            dgvPeople.RowHeadersVisible = false;
            dgvPeople.BackgroundColor = SystemColors.Window;
            dgvPeople.BorderStyle = BorderStyle.Fixed3D;
            dgvPeople.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPeople.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvPeople.EnableHeadersVisualStyles = false;

            // Set row height
            dgvPeople.RowTemplate.Height = 50;

            // Header style
            dgvPeople.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvPeople.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPeople.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvPeople.ColumnHeadersHeight = 40;

            // Rows style
            dgvPeople.RowsDefaultCellStyle.BackColor = Color.White;
            dgvPeople.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgvPeople.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvPeople.DefaultCellStyle.ForeColor = Color.Black;
            dgvPeople.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 73, 94);
            dgvPeople.DefaultCellStyle.SelectionForeColor = Color.White;

            // Configure each column if it exists
            if (dgvPeople.Columns.Count == 0) return;

            dgvPeople.DefaultCellStyle.Padding = new Padding(5);

            // Set friendly headers
            SetColumnHeader("Person ID", "ID");
            SetColumnHeader("Firstname", "First Name");
            SetColumnHeader("Secondname", "Second Name");
            SetColumnHeader("Thirdname", "Third Name");
            SetColumnHeader("Lastname", "Last Name");
            SetColumnHeader("National Number", "National No.");
            SetColumnHeader("Date Of Birth", "Date of Birth");
            SetColumnHeader("Gender", "Gender");
            SetColumnHeader("Nationality", "Nationality");
            SetColumnHeader("Address", "Address");

            // Optional columns (if present in DataTable)
            if (dgvPeople.Columns.Contains("Email"))
                SetColumnHeader("Email", "Email");
            if (dgvPeople.Columns.Contains("Phone"))
                SetColumnHeader("Phone", "Phone");

            // Set display order
            dgvPeople.Columns["Person ID"].DisplayIndex = 0;
            dgvPeople.Columns["Firstname"].DisplayIndex = 1;
            dgvPeople.Columns["Secondname"].DisplayIndex = 2;
            dgvPeople.Columns["Thirdname"].DisplayIndex = 3;
            dgvPeople.Columns["Lastname"].DisplayIndex = 4;

            int index = 5;
            if (dgvPeople.Columns.Contains("Email"))
                dgvPeople.Columns["Email"].DisplayIndex = index++;
            if (dgvPeople.Columns.Contains("Phone"))
                dgvPeople.Columns["Phone"].DisplayIndex = index++;

            dgvPeople.Columns["National Number"].DisplayIndex = index++;
            dgvPeople.Columns["Date Of Birth"].DisplayIndex = index++;
            dgvPeople.Columns["Gender"].DisplayIndex = index++;
            dgvPeople.Columns["Nationality"].DisplayIndex = index++;
            dgvPeople.Columns["Address"].DisplayIndex = index;

            // Set column widths
            dgvPeople.Columns["Person ID"].Width = 50;
            dgvPeople.Columns["Firstname"].Width = 80;
            dgvPeople.Columns["Secondname"].Width = 80;
            dgvPeople.Columns["Thirdname"].Width = 80;
            dgvPeople.Columns["Lastname"].Width = 100;

            if (dgvPeople.Columns.Contains("Email"))
                dgvPeople.Columns["Email"].Width = 150;
            if (dgvPeople.Columns.Contains("Phone"))
                dgvPeople.Columns["Phone"].Width = 100;

            dgvPeople.Columns["National Number"].Width = 100;
            dgvPeople.Columns["Date Of Birth"].Width = 90;
            dgvPeople.Columns["Gender"].Width = 60;
            dgvPeople.Columns["Nationality"].Width = 80;
            dgvPeople.Columns["Address"].Width = 157;

            // Format date column
            if (dgvPeople.Columns["Date Of Birth"] is DataGridViewColumn dobCol)
            {
                dobCol.DefaultCellStyle.Format = "yyyy-MM-dd";
                dobCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Center-align specific columns
            dgvPeople.Columns["Person ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPeople.Columns["Gender"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPeople.Columns["National Number"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (dgvPeople.Columns.Contains("Phone"))
                dgvPeople.Columns["Phone"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        // Helper to safely set header text
        private void SetColumnHeader(string columnName, string headerText)
        {
            if (dgvPeople.Columns.Contains(columnName))
                dgvPeople.Columns[columnName].HeaderText = headerText;
        }

        private void _DeletePerson()
        {
            var SelectedRow = dgvPeople.SelectedRows[0];
            int SelectedPersonId = Convert.ToInt32(SelectedRow.Cells["Person ID"].Value);

            if (MessageBox.Show("Are You Sure You Want To Delete This Person?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            {
                return;
            }

            string personImagePath = clsPerson.FindPerson(SelectedPersonId).ImagePath;

            if (!clsPerson.DeletePerson(SelectedPersonId))
            {
                MessageBox.Show("You Can't Delete this person Because it's releted to other things in the system.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _DeletePersonImage(personImagePath);
            MessageBox.Show("Person Was Deleted Successfully.",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _LoadPeople();
        }

        private void _DeletePersonImage(string personImagePath)
        {
            if (!string.IsNullOrEmpty(personImagePath) && File.Exists(personImagePath))
            {
                File.Delete(personImagePath);
            }
        }

        private void _AddNewPerson()
        {
            FrmAddEditPerson frm = new FrmAddEditPerson();
            frm.ShowDialog();
            _LoadPeople();
        }

        private void _EditPersonInfo()
        {
            var SelectedRow = dgvPeople.SelectedRows[0];
            int SelectedPersonId = Convert.ToInt32(SelectedRow.Cells["Person ID"].Value);

            FrmAddEditPerson frm = new FrmAddEditPerson(SelectedPersonId);
            frm.ShowDialog();
            _LoadPeople();
        }
        #endregion
    }
}
