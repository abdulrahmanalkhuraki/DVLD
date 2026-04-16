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

            dgvLocal.DataSource = localLicenses;

            lblLocalRecordsCount.Text = localLicenses.Rows.Count
                .ToString(clsGlobalSettings.TablesRecordsCountFormat);

            _ConfigureDataGridView(dgvLocal);

            dgvInternational.DataSource = internationalLicenses;

            lblInternationalRecordsCount.Text = internationalLicenses.Rows.Count
                .ToString(clsGlobalSettings.TablesRecordsCountFormat);

            _ConfigureDataGridView(dgvInternational);
        }

        private void _ConfigureDataGridView(DataGridView dgv)
        {
            if (dgv.Columns.Count == 0) return;

            // Basic settings
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv.RowHeadersVisible = false;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.Fixed3D;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;

            // Header style - RED
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 0, 0); // Deep red
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 40;

            // Rows style - soft red alternating
            dgv.RowsDefaultCellStyle.BackColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 235, 238); // Light red/pink
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(33, 33, 33);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(153, 0, 0); // Dark red
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            // Grid lines subtle red tint
            dgv.GridColor = Color.FromArgb(255, 205, 210);

            // Set column headers
            _SetColumnHeader(dgv, "LicenseID", "Lic ID");
            _SetColumnHeader(dgv, "ApplicationID", "App ID");
            _SetColumnHeader(dgv, "ClassName", "Class Name");
            _SetColumnHeader(dgv, "IssueDate", "Issue Date");
            _SetColumnHeader(dgv, "ExpirationDate", "Expiration Date");
            _SetColumnHeader(dgv, "IsActive", "Active");

            // Set display order
            int index = 0;
            if (dgv.Columns.Contains("LicenseID"))
                dgv.Columns["LicenseID"].DisplayIndex = index++;
            if (dgv.Columns.Contains("ApplicationID"))
                dgv.Columns["ApplicationID"].DisplayIndex = index++;
            if (dgv.Columns.Contains("ClassName"))
                dgv.Columns["ClassName"].DisplayIndex = index++;
            if (dgv.Columns.Contains("IssueDate"))
                dgv.Columns["IssueDate"].DisplayIndex = index++;
            if (dgv.Columns.Contains("ExpirationDate"))
                dgv.Columns["ExpirationDate"].DisplayIndex = index++;
            if (dgv.Columns.Contains("IsActive"))
                dgv.Columns["IsActive"].DisplayIndex = index++;

            // Column widths
            if (dgv.Columns.Contains("LicenseID"))
                dgv.Columns["LicenseID"].Width = 157;
            if (dgv.Columns.Contains("ApplicationID"))
                dgv.Columns["ApplicationID"].Width = 177;
            if (dgv.Columns.Contains("ClassName"))
                dgv.Columns["ClassName"].Width = 377;
            if (dgv.Columns.Contains("IssueDate"))
                dgv.Columns["IssueDate"].Width = 257;
            if (dgv.Columns.Contains("ExpirationDate"))
                dgv.Columns["ExpirationDate"].Width = 257;
            if (dgv.Columns.Contains("IsActive"))
                dgv.Columns["IsActive"].Width = 157;

            // Center alignment
            if (dgv.Columns.Contains("LicenseID"))
            {
                dgv.Columns["LicenseID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["LicenseID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgv.Columns.Contains("ApplicationID"))
            {
                dgv.Columns["ApplicationID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["ApplicationID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgv.Columns.Contains("IsActive"))
            {
                dgv.Columns["IsActive"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["IsActive"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Convert IsActive column to checkbox
            if (dgv.Columns.Contains("IsActive") && !(dgv.Columns["IsActive"] is DataGridViewCheckBoxColumn))
            {
                DataGridViewColumn oldCol = dgv.Columns["IsActive"];
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

                dgv.Columns.Remove(oldCol);
                dgv.Columns.Insert(colIndex, newCol);
            }
        }

        private void _SetColumnHeader(DataGridView dgv,string columnName, string headerText)
        {
            if (dgv.Columns.Contains(columnName))
                dgv.Columns[columnName].HeaderText = headerText;
        }
    }
}
