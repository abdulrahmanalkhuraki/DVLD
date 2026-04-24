using DVLD___Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.License
{
    public partial class ctrlLicensesHistory : UserControl
    {
        public ctrlLicensesHistory()
        {
            InitializeComponent();
        }

        public void LoadLicenses(int DriverId)
        {
            clsDriver driver = clsDriver.FindDriver(DriverId);
            if (driver == null) return;

            DataTable localLicenses = driver.GetLocalDrivingLicenses();
            DataTable internationalLicenses = driver.GetInternationalDrivingLicenses();

            if (localLicenses.Rows.Count > 0)
            {
                dgvLocal.DataSource = localLicenses;
            }
            else
            {
                dgvLocal.DataSource = localLicenses.Clone();
            }

            lblLocalRecordsCount.Text = localLicenses.Rows.Count
                .ToString(clsGlobalSettings.TablesRecordsCountFormat);

            _ConfigureLocalLicensesDataGridView();

            if (internationalLicenses.Rows.Count > 0)
            {
                dgvInternational.DataSource = internationalLicenses;
            }
            else
            {
                dgvInternational.DataSource = internationalLicenses.Clone();

            }

            lblInternationalRecordsCount.Text = internationalLicenses.Rows.Count
                .ToString(clsGlobalSettings.TablesRecordsCountFormat);

            _ConfigureInternationalLicensesDataGridView();
        }

        private void _ConfigureInternationalLicensesDataGridView()
        {
            if (dgvInternational.Columns.Count == 0) return;

            // Basic settings
            dgvInternational.AllowUserToAddRows = false;
            dgvInternational.AllowUserToDeleteRows = false;
            dgvInternational.ReadOnly = true;
            dgvInternational.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInternational.MultiSelect = false;
            dgvInternational.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvInternational.RowHeadersVisible = false;
            dgvInternational.BackgroundColor = Color.White;
            dgvInternational.BorderStyle = BorderStyle.Fixed3D;
            dgvInternational.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvInternational.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvInternational.EnableHeadersVisualStyles = false;

            // Header style - RED
            dgvInternational.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(198, 40, 40);
            dgvInternational.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvInternational.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvInternational.ColumnHeadersHeight = 40;

            // Rows style - soft red alternating
            dgvInternational.RowsDefaultCellStyle.BackColor = Color.White;
            dgvInternational.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 235, 238);
            dgvInternational.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvInternational.DefaultCellStyle.ForeColor = Color.FromArgb(33, 33, 33);
            dgvInternational.DefaultCellStyle.SelectionBackColor = Color.FromArgb(183, 28, 28);
            dgvInternational.DefaultCellStyle.SelectionForeColor = Color.White;

            // Grid lines subtle red tint
            dgvInternational.GridColor = Color.FromArgb(255, 205, 210);

            // Set column headers
            _SetColumnHeader(dgvInternational,"InternationalLicenseID", "Int.License ID");
            _SetColumnHeader(dgvInternational,"ApplicationID", "Application ID");
            _SetColumnHeader(dgvInternational,"DriverID", "Driver ID");
            _SetColumnHeader(dgvInternational,"IssuedUsingLocalLicenseID", "L.License ID");
            _SetColumnHeader(dgvInternational,"IssueDate", "Issue Date");
            _SetColumnHeader(dgvInternational,"ExpirationDate", "Expiration Date");
            _SetColumnHeader(dgvInternational,"IsActive", "Active");

            // Set display order
            int index = 0;
            string[] order = { "InternationalLicenseID", "ApplicationID", "IssuedUsingLocalLicenseID",
                               "IssueDate", "ExpirationDate", "IsActive" };
            foreach (string col in order)
            {
                if (dgvInternational.Columns.Contains(col))
                    dgvInternational.Columns[col].DisplayIndex = index++;
            }

            // Set column widths
            if (dgvInternational.Columns.Contains("InternationalLicenseID"))
                dgvInternational.Columns["InternationalLicenseID"].Width = 80;
            if (dgvInternational.Columns.Contains("ApplicationID"))
                dgvInternational.Columns["ApplicationID"].Width = 100;
            if (dgvInternational.Columns.Contains("IssuedUsingLocalLicenseID"))
                dgvInternational.Columns["IssuedUsingLocalLicenseID"].Width = 80;
            if (dgvInternational.Columns.Contains("IssueDate"))
                dgvInternational.Columns["IssueDate"].Width = 125;
            if (dgvInternational.Columns.Contains("ExpirationDate"))
                dgvInternational.Columns["ExpirationDate"].Width = 125;
            if (dgvInternational.Columns.Contains("IsActive"))
                dgvInternational.Columns["IsActive"].Width = 60;

            // Center alignment for IDs, dates, and IsActive
            string[] centerColumns = { "InternationalLicenseID", "ApplicationID", "IssuedUsingLocalLicenseID",
                                       "IssueDate", "ExpirationDate", "IsActive" };
            foreach (string col in centerColumns)
            {
                if (dgvInternational.Columns.Contains(col))
                {
                    dgvInternational.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvInternational.Columns[col].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        private void _ConfigureLocalLicensesDataGridView()
        {
            if (dgvLocal.Columns.Count == 0) return;

            // Basic settings
            dgvLocal.AllowUserToAddRows = false;
            dgvLocal.AllowUserToDeleteRows = false;
            dgvLocal.ReadOnly = true;
            dgvLocal.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLocal.MultiSelect = false;
            dgvLocal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvLocal.RowHeadersVisible = false;
            dgvLocal.BackgroundColor = Color.White;
            dgvLocal.BorderStyle = BorderStyle.Fixed3D;
            dgvLocal.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvLocal.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvLocal.EnableHeadersVisualStyles = false;

            // Header style – Green
            dgvLocal.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 125, 50); // Dark green
            dgvLocal.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLocal.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvLocal.ColumnHeadersHeight = 40;

            // Rows style – Light green alternating
            dgvLocal.RowsDefaultCellStyle.BackColor = Color.White;
            dgvLocal.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(232, 245, 233); // Light green
            dgvLocal.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvLocal.DefaultCellStyle.ForeColor = Color.FromArgb(33, 33, 33);
            dgvLocal.DefaultCellStyle.SelectionBackColor = Color.FromArgb(27, 94, 32); // Darker green
            dgvLocal.DefaultCellStyle.SelectionForeColor = Color.White;

            // Set column headers
            _SetColumnHeader(dgvLocal, "LicenseID", "Lic ID");
            _SetColumnHeader(dgvLocal, "ApplicationID", "App ID");
            _SetColumnHeader(dgvLocal, "ClassName", "Class Name");
            _SetColumnHeader(dgvLocal, "IssueDate", "Issue Date");
            _SetColumnHeader(dgvLocal, "ExpirationDate", "Expiration Date");
            _SetColumnHeader(dgvLocal, "IsActive", "Active");

            // Set display order
            int index = 0;
            if (dgvLocal.Columns.Contains("LicenseID"))
                dgvLocal.Columns["LicenseID"].DisplayIndex = index++;
            if (dgvLocal.Columns.Contains("ApplicationID"))
                dgvLocal.Columns["ApplicationID"].DisplayIndex = index++;
            if (dgvLocal.Columns.Contains("ClassName"))
                dgvLocal.Columns["ClassName"].DisplayIndex = index++;
            if (dgvLocal.Columns.Contains("IssueDate"))
                dgvLocal.Columns["IssueDate"].DisplayIndex = index++;
            if (dgvLocal.Columns.Contains("ExpirationDate"))
                dgvLocal.Columns["ExpirationDate"].DisplayIndex = index++;
            if (dgvLocal.Columns.Contains("IsActive"))
                dgvLocal.Columns["IsActive"].DisplayIndex = index++;

            // Column widths
            if (dgvLocal.Columns.Contains("LicenseID"))
                dgvLocal.Columns["LicenseID"].Width = 40;
            if (dgvLocal.Columns.Contains("ApplicationID"))
                dgvLocal.Columns["ApplicationID"].Width = 40;
            if (dgvLocal.Columns.Contains("ClassName"))
                dgvLocal.Columns["ClassName"].Width = 200;
            if (dgvLocal.Columns.Contains("IssueDate"))
                dgvLocal.Columns["IssueDate"].Width = 115;
            if (dgvLocal.Columns.Contains("ExpirationDate"))
                dgvLocal.Columns["ExpirationDate"].Width = 115;
            if (dgvLocal.Columns.Contains("IsActive"))
                dgvLocal.Columns["IsActive"].Width = 60;

            // Center alignment
            if (dgvLocal.Columns.Contains("LicenseID"))
            {
                dgvLocal.Columns["LicenseID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvLocal.Columns["LicenseID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvLocal.Columns.Contains("ApplicationID"))
            {
                dgvLocal.Columns["ApplicationID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvLocal.Columns["ApplicationID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvLocal.Columns.Contains("IsActive"))
            {
                dgvLocal.Columns["IsActive"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvLocal.Columns["IsActive"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Convert IsActive column to checkbox
            if (dgvLocal.Columns.Contains("IsActive") && !(dgvLocal.Columns["IsActive"] is DataGridViewCheckBoxColumn))
            {
                DataGridViewColumn oldCol = dgvLocal.Columns["IsActive"];
                int colIndex = oldCol.Index;
                string headerText = oldCol.HeaderText;
                int width = oldCol.Width;
                bool visible = oldCol.Visible;

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
                            SelectionBackColor = Color.FromArgb(153, 0, 0)
                        }
                    }
                };

                dgvLocal.Columns.Remove(oldCol);
                dgvLocal.Columns.Insert(colIndex, newCol);
            }
        }

        private void _SetColumnHeader(DataGridView dgv,string columnName, string headerText)
        {
            if (dgv.Columns.Contains(columnName))
                dgv.Columns[columnName].HeaderText = headerText;
        }
    }
}
