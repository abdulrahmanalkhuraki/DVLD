using DVLD.Drivers;
using DVLD.Person;
using DVLD___Business;   // or your actual business namespace
using DVLD___Business.Utility;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DVLD.License.Detained_Licenses
{
    public partial class FrmManageDetainedLicenses : Form
    {
        public FrmManageDetainedLicenses()
        {
            InitializeComponent();
        }

        #region Event Handlers

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dgvDetainedLicenses.SelectedRows.Count == 0)
            {
                showDetailsToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = false;
                showLicenseHistoryToolStripMenuItem.Enabled = false;
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvDetainedLicenses.SelectedRows[0];
            int LicenseID = Convert.ToInt32(row.Cells["LicenseID"].Value);
            int driverId = clsLicense.FindLicense(LicenseID).DriverID;
            int personId = clsDriver.FindDriver(driverId).PersonId;
            FrmPersonDetails frm = new FrmPersonDetails(personId);
            frm.ShowDialog();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvDetainedLicenses.SelectedRows[0];
            int LicenseID = Convert.ToInt32(row.Cells["LicenseID"].Value);
            FrmLicenseDetails frm = new FrmLicenseDetails(LicenseID);
            frm.ShowDialog();
        }

        private void showLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvDetainedLicenses.SelectedRows[0];
            int LicenseID = Convert.ToInt32(row.Cells["LicenseID"].Value);
            int driverId = clsLicense.FindLicense(LicenseID).DriverID;
            FrmDriverLicenseHistory frm = new FrmDriverLicenseHistory(driverId);
            frm.ShowDialog();
        }

        private void FrmManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            string[] filterItems =
            {
                "None",
                "Detain ID",
                "License ID",
                "Detain Date",
                "Detain Date",
                "Fine Fees",
                "Fine Fees",
                "Is Released",
                "Release Date"
            };

            cbFilterBy.Items.Clear();
            cbFilterBy.Items.AddRange(filterItems);

            _LoadDetainedLicenses();
            cbFilterBy.SelectedIndex = 0;
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
             * Filter items:
             * 0 - None
             * 1 - Detain ID
             * 2 - License ID
             * 3 - Detain Date
             * 4 - Fine Fees
             * 5 - Is Released
             * 6 - Release Date
             */

            DataTable allData = clsDetainedLicense.GetAllDetainedLicenses();
            dgvDetainedLicenses.DataSource = allData;
            _ConfigureDataGridView();

            int selectedIndex = cbFilterBy.SelectedIndex;

            // For numeric fields (DetainID, LicenseID, FineFees) -> TextBox with numeric validation
            int[] numericFields = { 1, 2, 4 };
            // For date fields -> DateTimePicker
            int[] dateFields = { 3, 6 };
            // For boolean (IsReleased) -> ComboBox (Yes/No)
            bool isBooleanField = (selectedIndex == 5);

            if (numericFields.Contains(selectedIndex))
            {
                tbUserInput.Visible = true;
                cbUserChoice.Visible = false;
                dtpUserInput.Visible = false;
                tbUserInput.Clear();
                tbUserInput.Focus();
            }
            else if (dateFields.Contains(selectedIndex))
            {
                tbUserInput.Visible = false;
                cbUserChoice.Visible = false;
                dtpUserInput.Visible = true;
                dtpUserInput.Value = DateTime.Now;
            }
            else if (isBooleanField)
            {
                tbUserInput.Visible = false;
                dtpUserInput.Visible = false;
                cbUserChoice.Visible = true;
                cbUserChoice.Items.Clear();
                cbUserChoice.Items.AddRange(new[] { "All", "Released", "Not Released" });
                cbUserChoice.SelectedIndex = 0;
            }
            else
            {
                // None selected
                tbUserInput.Visible = false;
                cbUserChoice.Visible = false;
                dtpUserInput.Visible = false;
            }
        }

        private void tbUserInput_TextChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex <= 0 || string.IsNullOrEmpty(tbUserInput.Text))
                return;

            int filterIndex = cbFilterBy.SelectedIndex;
            DataTable allData = clsDetainedLicense.GetAllDetainedLicenses();
            DataRow[] filteredRows = null;

            switch (filterIndex)
            {
                case 1: // Detain ID
                    if (int.TryParse(tbUserInput.Text, out int detainId))
                        filteredRows = allData.Select($"DetainID = {detainId}");
                    break;
                case 2: // License ID
                    if (int.TryParse(tbUserInput.Text, out int licenseId))
                        filteredRows = allData.Select($"LicenseID = {licenseId}");
                    break;
                case 4: // Fine Fees
                    if (decimal.TryParse(tbUserInput.Text, out decimal fees))
                        filteredRows = allData.Select($"FineFees = {fees}");
                    break;
            }

            _UpdateDataGridView(allData, filteredRows);
        }

        private void tbUserInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            int filterIndex = cbFilterBy.SelectedIndex;
            // Allow digits and control keys for numeric fields
            if (filterIndex == 1 || filterIndex == 2 || filterIndex == 4)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    e.Handled = true;
                // Allow only one decimal point for Fine Fees
                if (filterIndex == 4 && e.KeyChar == '.' && tbUserInput.Text.Contains("."))
                    e.Handled = true;
            }
        }

        private void dtpUserInput_ValueChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex <= 0)
                return;

            int filterIndex = cbFilterBy.SelectedIndex;
            DataTable allData = clsDetainedLicense.GetAllDetainedLicenses();
            DataRow[] filteredRows = null;
            DateTime selectedDate = dtpUserInput.Value.Date;

            if (filterIndex == 3) // DetainDate
            {
                filteredRows = allData.Select($"DetainDate >= #{selectedDate:yyyy-MM-dd}# AND DetainDate < #{selectedDate.AddDays(1):yyyy-MM-dd}#");
            }
            else if (filterIndex == 6) // ReleaseDate (only if not null)
            {
                filteredRows = allData.Select($"ReleaseDate >= #{selectedDate:yyyy-MM-dd}# AND ReleaseDate < #{selectedDate.AddDays(1):yyyy-MM-dd}#");
            }

            _UpdateDataGridView(allData, filteredRows);
        }

        private void cbUserChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex != 5 || cbUserChoice.SelectedIndex < 0)
                return;

            DataTable allData = clsDetainedLicense.GetAllDetainedLicenses();
            DataRow[] filteredRows = null;

            string selected = cbUserChoice.Text;
            if (selected == "Released")
                filteredRows = allData.Select("IsReleased = 1");
            else if (selected == "Not Released")
                filteredRows = allData.Select("IsReleased = 0");
            // "All" -> filteredRows remains null (show all)

            _UpdateDataGridView(allData, filteredRows);
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            if (dgvDetainedLicenses.SelectedRows.Count == 0) return;

            DataGridViewRow row = dgvDetainedLicenses.SelectedRows[0];
            int LicenseID = Convert.ToInt32(row.Cells["LicenseID"].Value);
            bool isReleased = Convert.ToBoolean(row.Cells["IsReleased"].Value);

            if (!isReleased)
            {
                clsMessages.Error("This license Is already Detained.");
                return;
            }

            FrmDetainLicense frm = new FrmDetainLicense(LicenseID);
            frm.ShowDialog();

        }

        private void btnRelease_Click(object sender, EventArgs e) => _ReleaseDetainedLicense();

        #endregion

        #region Helper Methods

        private void _LoadDetainedLicenses()
        {
            DataTable dt = clsDetainedLicense.GetAllDetainedLicenses();
            dgvDetainedLicenses.DataSource = dt;
            lblRecordsCount.Text = dt.Rows.Count.ToString("N0");
            _ConfigureDataGridView();
        }

        private void _ConfigureDataGridView()
        {
            // Basic properties
            dgvDetainedLicenses.AllowUserToAddRows = false;
            dgvDetainedLicenses.AllowUserToDeleteRows = false;
            dgvDetainedLicenses.ReadOnly = true;
            dgvDetainedLicenses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetainedLicenses.MultiSelect = false;
            dgvDetainedLicenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvDetainedLicenses.RowHeadersVisible = false;
            dgvDetainedLicenses.BackgroundColor = SystemColors.Window;
            dgvDetainedLicenses.BorderStyle = BorderStyle.Fixed3D;
            dgvDetainedLicenses.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDetainedLicenses.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvDetainedLicenses.EnableHeadersVisualStyles = false;

            // Header style
            dgvDetainedLicenses.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94); // Dark slate blue
            dgvDetainedLicenses.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDetainedLicenses.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvDetainedLicenses.ColumnHeadersHeight = 40;

            // Rows style
            dgvDetainedLicenses.RowsDefaultCellStyle.BackColor = Color.White;
            dgvDetainedLicenses.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 245); // Very light gray-blue
            dgvDetainedLicenses.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvDetainedLicenses.DefaultCellStyle.ForeColor = Color.Black;

            // Selection style
            dgvDetainedLicenses.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 73, 94);
            dgvDetainedLicenses.DefaultCellStyle.SelectionForeColor = Color.White;

            if (dgvDetainedLicenses.Columns.Count == 0) return;

            // Set friendly headers
            SetColumnHeader("DetainID", "Detain ID");
            SetColumnHeader("LicenseID", "License ID");
            SetColumnHeader("DetainDate", "Detain Date");
            SetColumnHeader("FineFees", "Fine Fees");
            SetColumnHeader("CreatedByUserID", "Created By User");
            SetColumnHeader("IsReleased", "Released");
            SetColumnHeader("ReleaseDate", "Release Date");
            SetColumnHeader("ReleasedByUserID", "Released By User");
            SetColumnHeader("ReleaseApplicationID", "Release App. ID");

            // Set display order
            int order = 0;
            dgvDetainedLicenses.Columns["DetainID"].DisplayIndex = order++;
            dgvDetainedLicenses.Columns["LicenseID"].DisplayIndex = order++;
            dgvDetainedLicenses.Columns["DetainDate"].DisplayIndex = order++;
            dgvDetainedLicenses.Columns["FineFees"].DisplayIndex = order++;
            dgvDetainedLicenses.Columns["IsReleased"].DisplayIndex = order++;
            dgvDetainedLicenses.Columns["ReleaseDate"].DisplayIndex = order++;
            dgvDetainedLicenses.Columns["CreatedByUserID"].DisplayIndex = order++;
            dgvDetainedLicenses.Columns["ReleasedByUserID"].DisplayIndex = order++;
            dgvDetainedLicenses.Columns["ReleaseApplicationID"].DisplayIndex = order;

            // Set widths
            dgvDetainedLicenses.Columns["DetainID"].Width = 80;
            dgvDetainedLicenses.Columns["LicenseID"].Width = 80;
            dgvDetainedLicenses.Columns["DetainDate"].Width = 110;
            dgvDetainedLicenses.Columns["FineFees"].Width = 97;
            dgvDetainedLicenses.Columns["IsReleased"].Width = 70;
            dgvDetainedLicenses.Columns["ReleaseDate"].Width = 110;
            dgvDetainedLicenses.Columns["CreatedByUserID"].Width = 100;
            dgvDetainedLicenses.Columns["ReleasedByUserID"].Width = 100;
            dgvDetainedLicenses.Columns["ReleaseApplicationID"].Width = 100;

            // Center alignment for certain columns
            dgvDetainedLicenses.Columns["DetainID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetainedLicenses.Columns["LicenseID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetainedLicenses.Columns["FineFees"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetainedLicenses.Columns["IsReleased"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Format dates
            if (dgvDetainedLicenses.Columns["DetainDate"] is DataGridViewColumn detainDate)
                detainDate.DefaultCellStyle.Format = "yyyy-MM-dd";
            if (dgvDetainedLicenses.Columns["ReleaseDate"] is DataGridViewColumn releaseDate)
                releaseDate.DefaultCellStyle.Format = "yyyy-MM-dd";

            // Format boolean column to show "Yes"/"No"
            if (dgvDetainedLicenses.Columns["IsReleased"] is DataGridViewCheckBoxColumn)
            {
                // Already checkbox, keep as is
            }
            else if (dgvDetainedLicenses.Columns["IsReleased"] is DataGridViewTextBoxColumn)
            {
                // Customize cell formatting
                dgvDetainedLicenses.Columns["IsReleased"].DefaultCellStyle.Format = "Yes;No";
            }
        }

        private void SetColumnHeader(string columnName, string headerText)
        {
            if (dgvDetainedLicenses.Columns.Contains(columnName))
                dgvDetainedLicenses.Columns[columnName].HeaderText = headerText;
        }

        private void _UpdateDataGridView(DataTable originalData, DataRow[] filteredRows)
        {
            if (filteredRows != null && filteredRows.Length > 0)
                dgvDetainedLicenses.DataSource = filteredRows.CopyToDataTable();
            else if (filteredRows == null)
                dgvDetainedLicenses.DataSource = originalData;
            else
                dgvDetainedLicenses.DataSource = originalData.Clone();

            lblRecordsCount.Text = dgvDetainedLicenses.RowCount.ToString("N0");
            _ConfigureDataGridView();
        }

        private void _ReleaseDetainedLicense()
        {
            if (dgvDetainedLicenses.SelectedRows.Count == 0) return;

            DataGridViewRow row = dgvDetainedLicenses.SelectedRows[0];
            int LicenseID = Convert.ToInt32(row.Cells["LicenseID"].Value);
            bool isReleased = Convert.ToBoolean(row.Cells["IsReleased"].Value);

            if (isReleased)
            {
                clsMessages.Error("This license has already been released.");
                return;
            }

            FrmReleaseDetainedLicense frm = new FrmReleaseDetainedLicense(LicenseID);
            frm.ShowDialog();
        }


        #endregion
    }
}
