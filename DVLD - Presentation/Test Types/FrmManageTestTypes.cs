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

namespace DVLD.Test_Types
{
    public partial class FrmManageTestTypes : Form
    {
        public FrmManageTestTypes()
        {
            InitializeComponent();
        }

        #region Event Handlers

        private void FrmManageTestTypes_Load(object sender, EventArgs e)
        {
            _LoadTestTypes();
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvTestTypes.SelectedRows.Count == 0) return;
            var SelectedRow = dgvTestTypes.SelectedRows[0];
            int SelectedTestTypeId = Convert.ToInt32(SelectedRow.Cells["TestTypeID"].Value);

            FrmEditTestType frm = new FrmEditTestType(SelectedTestTypeId);
            frm.ShowDialog();
            _LoadTestTypes();
        }

        #endregion

        #region Helpers

        private void _LoadTestTypes()
        {
            DataTable TestTypes = clsTestType.GetAllTestTypes();
            dgvTestTypes.DataSource = TestTypes;
            lblRecordsCount.Text = TestTypes.Rows.Count.ToString("N0");
            _ConfigureTestTypesGridView();
        }

        private void _ConfigureTestTypesGridView()
        {
            // Basic DataGridView properties
            dgvTestTypes.AllowUserToAddRows = false;
            dgvTestTypes.AllowUserToDeleteRows = false;
            dgvTestTypes.ReadOnly = true;
            dgvTestTypes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTestTypes.MultiSelect = false;
            dgvTestTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvTestTypes.RowHeadersVisible = false;
            dgvTestTypes.BackgroundColor = SystemColors.Window;
            dgvTestTypes.BorderStyle = BorderStyle.Fixed3D;
            dgvTestTypes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTestTypes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvTestTypes.EnableHeadersVisualStyles = false;

            // Header style
            dgvTestTypes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvTestTypes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTestTypes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvTestTypes.ColumnHeadersHeight = 40;

            // Rows style
            dgvTestTypes.RowsDefaultCellStyle.BackColor = Color.White;
            dgvTestTypes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgvTestTypes.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvTestTypes.DefaultCellStyle.ForeColor = Color.Black;
            dgvTestTypes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 73, 94);
            dgvTestTypes.DefaultCellStyle.SelectionForeColor = Color.White;

            // Configure each column if it exists
            if (dgvTestTypes.Columns.Count == 0) return;

            // Set friendly headers
            _SetColumnHeader("TestTypeID", "ID");
            _SetColumnHeader("TestTypeTitle", "Title");
            _SetColumnHeader("TestTypeDescription", "Description");
            _SetColumnHeader("TestTypeFees", "Fees");

            // Set display order
            dgvTestTypes.Columns["TestTypeID"].DisplayIndex = 0;
            dgvTestTypes.Columns["TestTypeTitle"].DisplayIndex = 1;
            dgvTestTypes.Columns["TestTypeDescription"].DisplayIndex = 2;
            dgvTestTypes.Columns["TestTypeFees"].DisplayIndex = 3;

            // Set column widths
            dgvTestTypes.Columns["TestTypeID"].Width = 50;
            dgvTestTypes.Columns["TestTypeTitle"].Width = 170;
            dgvTestTypes.Columns["TestTypeDescription"].Width = 270;
            dgvTestTypes.Columns["TestTypeFees"].Width = 100;

            // Set header alignment
            dgvTestTypes.Columns["TestTypeID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTestTypes.Columns["TestTypeFees"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Center-align specific columns
            dgvTestTypes.Columns["TestTypeID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTestTypes.Columns["TestTypeFees"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void _SetColumnHeader(string columnName, string headerText)
        {
            if (dgvTestTypes.Columns.Contains(columnName))
                dgvTestTypes.Columns[columnName].HeaderText = headerText;
        }

        #endregion
    }
}