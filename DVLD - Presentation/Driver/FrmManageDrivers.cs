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

namespace DVLD.Drivers
{
    public partial class FrmManageDrivers : Form
    {
        public FrmManageDrivers()
        {
            InitializeComponent();
        }

        private void FrmManageDrivers_Load(object sender, EventArgs e)
        {
            _LoadDrivers();
            cbFilterBy.Items.Clear();
            cbFilterBy.Items.AddRange(new string[]
            { 
                "None",
                "Driver Id",
                "Person Id",
                "National No.",
                "Full Name"
            });
            cbFilterBy.SelectedIndex = 0;
        }

        #region Events Handlers
        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 0)
            {
                tbUserInput.Clear();
                tbUserInput.Visible = false;
            }
            else
            {
                tbUserInput.Visible = true;
            }
        }

        private void tbUserInput_TextChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex < 0 || string.IsNullOrWhiteSpace(tbUserInput.Text))
                return;

            int filterIndex = cbFilterBy.SelectedIndex;
            DataTable allDrivers = clsDriver.GetAllDrivers();
            DataRow[] filtered = null;

            switch (filterIndex)
            {
                case 1: // Driver ID
                    if (int.TryParse(tbUserInput.Text, out int did))
                        filtered = allDrivers.Select($"DriverID = {did}");
                    break;
                case 2: // Person ID
                    if (int.TryParse(tbUserInput.Text, out int pid))
                        filtered = allDrivers.Select($"PersonID = {pid}");
                    break;
                case 3: // National No.
                    if (int.TryParse(tbUserInput.Text, out int Nnu))
                        filtered = allDrivers.Select($"NationalNo = {Nnu}");
                    break;
                case 4: // Full Name
                    filtered = allDrivers.Select($"FullName LIKE '{tbUserInput.Text}%'");
                    break;
                default: break;
            }

            _UpdateDataGridView(allDrivers, filtered);
        }


        #endregion

        #region Helpers
        private void _LoadDrivers()
        {
            DataTable Drivers = clsDriver.GetAllDrivers();

            lblRecordsCount.Text = Drivers.Rows.Count.ToString("N0");
            dgvDrivers.DataSource = Drivers;
            _ConfigureDataGridView();
        }

        private void _ConfigureDataGridView()
        {
            // Basic DataGridView properties
            dgvDrivers.AllowUserToAddRows = false;
            dgvDrivers.AllowUserToDeleteRows = false;
            dgvDrivers.ReadOnly = true;
            dgvDrivers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDrivers.MultiSelect = false;
            dgvDrivers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvDrivers.RowHeadersVisible = false;
            dgvDrivers.BackgroundColor = Color.FromArgb(255, 248, 240); // very light skin tone
            dgvDrivers.BorderStyle = BorderStyle.Fixed3D;
            dgvDrivers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDrivers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvDrivers.EnableHeadersVisualStyles = false;

            // Header style (warm brown)
            dgvDrivers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(141, 85, 36);
            dgvDrivers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDrivers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvDrivers.ColumnHeadersHeight = 40;

            // Rows style
            dgvDrivers.RowsDefaultCellStyle.BackColor = Color.FromArgb(255, 235, 205); // light beige
            dgvDrivers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(244, 194, 157); // slightly darker skin tone
            dgvDrivers.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvDrivers.DefaultCellStyle.ForeColor = Color.Black;

            // Selection color (deeper brown)
            dgvDrivers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(101, 67, 33);
            dgvDrivers.DefaultCellStyle.SelectionForeColor = Color.White;

            if (dgvDrivers.Columns.Count == 0) return;

            // Headers
            SetColumnHeader("DriverID", "Driver ID");
            SetColumnHeader("PersonID", "Person ID");
            SetColumnHeader("NationalNo", "National No.");
            SetColumnHeader("FullName", "Full Name");
            SetColumnHeader("CreatedDate", "Created Date");
            SetColumnHeader("NumberOfActiveLicenses", "Active Licenses");

            // Order
            dgvDrivers.Columns["DriverID"].DisplayIndex = 0;
            dgvDrivers.Columns["PersonID"].DisplayIndex = 1;
            dgvDrivers.Columns["FullName"].DisplayIndex = 2;
            dgvDrivers.Columns["NationalNo"].DisplayIndex = 3;
            dgvDrivers.Columns["NumberOfActiveLicenses"].DisplayIndex = 4;
            dgvDrivers.Columns["CreatedDate"].DisplayIndex = 5;

            // Widths
            dgvDrivers.Columns["DriverID"].Width = 100;
            dgvDrivers.Columns["PersonID"].Width = 100;
            dgvDrivers.Columns["FullName"].Width = 270;
            dgvDrivers.Columns["NationalNo"].Width = 150;
            dgvDrivers.Columns["NumberOfActiveLicenses"].Width = 150;
            dgvDrivers.Columns["CreatedDate"].Width = 150;

            // Date format
            if (dgvDrivers.Columns["CreatedDate"] is DataGridViewColumn dateCol)
            {
                dateCol.DefaultCellStyle.Format = "yyyy-MM-dd";
                dateCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Alignment
            dgvDrivers.Columns["DriverID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDrivers.Columns["PersonID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDrivers.Columns["NumberOfActiveLicenses"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDrivers.Columns["NationalNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void SetColumnHeader(string columnName, string headerText)
        {
            if (dgvDrivers.Columns.Contains(columnName))
                dgvDrivers.Columns[columnName].HeaderText = headerText;
        }

        private void _UpdateDataGridView(DataTable originalData, DataRow[] filteredRows)
        {
            if (filteredRows != null && filteredRows.Length > 0)
                dgvDrivers.DataSource = filteredRows.CopyToDataTable();
            else
                dgvDrivers.DataSource = originalData.Clone();
            lblRecordsCount.Text = dgvDrivers.RowCount.ToString("N0");
            _ConfigureDataGridView();
        }
        #endregion
    }
}

