using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DVLD.Applications;
using DVLD.Drivers;
using DVLD.License;
using DVLD___Business;   // Adjust namespace to your business layer

namespace DVLD.InternationalLicense
{
    public partial class FrmManageInternationalLicenseApplications : Form
    {
        public FrmManageInternationalLicenseApplications()
        {
            InitializeComponent();
        }

        #region Event Handlers

        private void FrmManageInternationalLicenseApplications_Load(object sender, EventArgs e)
        {
            _LoadLicenses();
            cbFilterBy.Items.Clear();
            cbFilterBy.Items.AddRange(new string[]
            {
                "None",
                "Int.License ID",
                "Application ID",
                "Driver ID",
                "L.License ID"
            });
            cbFilterBy.SelectedIndex = 0;
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 0) // None
            {
                tbUserInput.Visible = false;
                _LoadLicenses();
            }
            else
            {
                tbUserInput.Visible = true;
                tbUserInput.Clear();
                // Apply numeric validation for ID fields
                if (cbFilterBy.SelectedIndex >= 1 && cbFilterBy.SelectedIndex <= 4)
                {
                    tbUserInput.KeyPress -= TbUserInput_KeyPress_NumericOnly;
                    tbUserInput.KeyPress += TbUserInput_KeyPress_NumericOnly;
                }
                else
                {
                    tbUserInput.KeyPress -= TbUserInput_KeyPress_NumericOnly;
                }
            }
        }

        private void tbUserInput_TextChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex <= 0 || string.IsNullOrWhiteSpace(tbUserInput.Text))
            {
                _LoadLicenses();
                return;
            }

            DataTable allLicenses = clsInternationalLicense.GetAllInternationalLicesnes();
            DataRow[] filtered = null;

            switch (cbFilterBy.SelectedIndex)
            {
                case 1: // Int.License ID
                    if (int.TryParse(tbUserInput.Text, out int licenseId))
                        filtered = allLicenses.Select($"InternationalLicenseID = {licenseId}");
                    break;
                case 2: // Application ID
                    if (int.TryParse(tbUserInput.Text, out int appId))
                        filtered = allLicenses.Select($"ApplicationID = {appId}");
                    break;
                case 3: // Driver ID
                    if (int.TryParse(tbUserInput.Text, out int driverId))
                        filtered = allLicenses.Select($"DriverID = {driverId}");
                    break;
                case 4: // L.License ID (IssuedUsingLocalLicenseID)
                    if (int.TryParse(tbUserInput.Text, out int localLicenseId))
                        filtered = allLicenses.Select($"IssuedUsingLocalLicenseID = {localLicenseId}");
                    break;
            }

            _UpdateDataGridView(allLicenses, filtered);
        }

        private void TbUserInput_KeyPress_NumericOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e) => _AddNewInternationalLicense();

        private void btnClose_Click(object sender, EventArgs e) => Close();

        #region Context Menu Strip Items

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvInternationalLicenses.SelectedRows.Count == 0) return;
            int licenseId = Convert.ToInt32(dgvInternationalLicenses.SelectedRows[0].Cells["ApplicationID"].Value);
            FrmApplicationDetails frm = new FrmApplicationDetails(licenseId);
            frm.ShowDialog();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvInternationalLicenses.SelectedRows.Count == 0) return;
            int licenseId = Convert.ToInt32(dgvInternationalLicenses.SelectedRows[0].Cells["InternationalLicenseID"].Value);
            //FrmInternationalLicenseDetails frm = new FrmShowInternationalLicense(licenseId);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvInternationalLicenses.SelectedRows.Count == 0) return;
            int driverId = Convert.ToInt32(dgvInternationalLicenses.SelectedRows[0].Cells["DriverID"].Value);
            FrmDriverLicenseHistory frm = new FrmDriverLicenseHistory(driverId);
            frm.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool hasSelection = dgvInternationalLicenses.SelectedRows.Count > 0;
            showDetailsToolStripMenuItem.Enabled = hasSelection;
            showLicenseToolStripMenuItem.Enabled = hasSelection;
            showPersonLicenseHistoryToolStripMenuItem.Enabled = hasSelection;
        }

        #endregion

        #endregion

        #region Helpers

        private void _LoadLicenses()
        {
            DataTable dt = clsInternationalLicense.GetAllInternationalLicesnes();
            lblRecordsCount.Text = dt.Rows.Count.ToString("N0");
            dgvInternationalLicenses.DataSource = dt;
            _ConfigureDataGridView();
        }

        private void _ConfigureDataGridView()
        {
            if (dgvInternationalLicenses.Columns.Count == 0) return;

            // Basic settings
            dgvInternationalLicenses.AllowUserToAddRows = false;
            dgvInternationalLicenses.AllowUserToDeleteRows = false;
            dgvInternationalLicenses.ReadOnly = true;
            dgvInternationalLicenses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInternationalLicenses.MultiSelect = false;
            dgvInternationalLicenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvInternationalLicenses.RowHeadersVisible = false;
            dgvInternationalLicenses.BackgroundColor = Color.White;
            dgvInternationalLicenses.BorderStyle = BorderStyle.Fixed3D;
            dgvInternationalLicenses.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvInternationalLicenses.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvInternationalLicenses.EnableHeadersVisualStyles = false;

            // Header style – Red
            dgvInternationalLicenses.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(198, 40, 40);
            dgvInternationalLicenses.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvInternationalLicenses.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvInternationalLicenses.ColumnHeadersHeight = 40;

            // Rows style – Light red alternating
            dgvInternationalLicenses.RowsDefaultCellStyle.BackColor = Color.White;
            dgvInternationalLicenses.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 235, 238);
            dgvInternationalLicenses.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvInternationalLicenses.DefaultCellStyle.ForeColor = Color.FromArgb(33, 33, 33);
            dgvInternationalLicenses.DefaultCellStyle.SelectionBackColor = Color.FromArgb(183, 28, 28);
            dgvInternationalLicenses.DefaultCellStyle.SelectionForeColor = Color.White;

            // Set column headers and visibility
            _SetColumnHeader("InternationalLicenseID", "Int.License ID");
            _SetColumnHeader("ApplicationID", "Application ID");
            _SetColumnHeader("DriverID", "Driver ID");
            _SetColumnHeader("IssuedUsingLocalLicenseID", "L.License ID");
            _SetColumnHeader("IssueDate", "Issue Date");
            _SetColumnHeader("ExpirationDate", "Expiration Date");
            _SetColumnHeader("IsActive", "Is Active");
            if (dgvInternationalLicenses.Columns.Contains("CreatedByUserID"))
                dgvInternationalLicenses.Columns["CreatedByUserID"].Visible = false;

            // Set display order
            int index = 0;
            string[] order = { "InternationalLicenseID", "ApplicationID", "DriverID", "IssuedUsingLocalLicenseID",
                               "IssueDate", "ExpirationDate", "IsActive" };
            foreach (string col in order)
            {
                if (dgvInternationalLicenses.Columns.Contains(col))
                    dgvInternationalLicenses.Columns[col].DisplayIndex = index++;
            }

            // Set column widths
            if (dgvInternationalLicenses.Columns.Contains("InternationalLicenseID"))
                dgvInternationalLicenses.Columns["InternationalLicenseID"].Width = 120;
            if (dgvInternationalLicenses.Columns.Contains("ApplicationID"))
                dgvInternationalLicenses.Columns["ApplicationID"].Width = 120;
            if (dgvInternationalLicenses.Columns.Contains("DriverID"))
                dgvInternationalLicenses.Columns["DriverID"].Width = 100;
            if (dgvInternationalLicenses.Columns.Contains("IssuedUsingLocalLicenseID"))
                dgvInternationalLicenses.Columns["IssuedUsingLocalLicenseID"].Width = 100;
            if (dgvInternationalLicenses.Columns.Contains("IssueDate"))
                dgvInternationalLicenses.Columns["IssueDate"].Width = 120;
            if (dgvInternationalLicenses.Columns.Contains("ExpirationDate"))
                dgvInternationalLicenses.Columns["ExpirationDate"].Width = 120;
            if (dgvInternationalLicenses.Columns.Contains("IsActive"))
                dgvInternationalLicenses.Columns["IsActive"].Width = 80;

            // Center alignment for IDs, dates, and IsActive
            string[] centerColumns = { "InternationalLicenseID", "ApplicationID", "DriverID", "IssuedUsingLocalLicenseID",
                                       "IssueDate", "ExpirationDate", "IsActive" };
            foreach (string col in centerColumns)
            {
                if (dgvInternationalLicenses.Columns.Contains(col))
                {
                    dgvInternationalLicenses.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvInternationalLicenses.Columns[col].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        private void _SetColumnHeader(string columnName, string headerText)
        {
            if (dgvInternationalLicenses.Columns.Contains(columnName))
                dgvInternationalLicenses.Columns[columnName].HeaderText = headerText;
        }

        private void _UpdateDataGridView(DataTable originalData, DataRow[] filteredRows)
        {
            if (filteredRows != null && filteredRows.Length > 0)
                dgvInternationalLicenses.DataSource = filteredRows.CopyToDataTable();
            else
                dgvInternationalLicenses.DataSource = originalData.Clone();
            lblRecordsCount.Text = dgvInternationalLicenses.RowCount.ToString("N0");
            _ConfigureDataGridView();
        }

        private void _AddNewInternationalLicense()
        {
            FrmIssueInternationalLicesne frm = new FrmIssueInternationalLicesne();
            frm.ShowDialog();
            _LoadLicenses();
        }

        #endregion
    }
}