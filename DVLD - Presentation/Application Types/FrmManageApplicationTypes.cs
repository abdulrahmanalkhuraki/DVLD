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

namespace DVLD.Application_Types
{
    public partial class FrmManageApplicationTypes : Form
    {
        public FrmManageApplicationTypes()
        {
            InitializeComponent();
        }

        #region Event Handlers

        private void FrmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _LoadApplicationTypes();
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvApplicationTypes.SelectedRows.Count == 0) return;
            var SelectedRow = dgvApplicationTypes.SelectedRows[0];
            int SelectedApplicationTypeId = Convert.ToInt32(SelectedRow.Cells["ApplicationTypeID"].Value);

            FrmEditApplicationType frm = new FrmEditApplicationType(SelectedApplicationTypeId);
            frm.ShowDialog();
            _LoadApplicationTypes();
        }

        #endregion

        #region Helpers

        private void _LoadApplicationTypes()
        {
            DataTable ApplicationTypes = clsApplicationType.GetAllApplicationTypes();
            dgvApplicationTypes.DataSource = ApplicationTypes;
            lblRecordsCount.Text = ApplicationTypes.Rows.Count.ToString("N0");
            _ConfigureApplicationsTypeGridView();
        }

        private void _ConfigureApplicationsTypeGridView()
        {
            // Basic DataGridView properties
            dgvApplicationTypes.AllowUserToAddRows = false;
            dgvApplicationTypes.AllowUserToDeleteRows = false;
            dgvApplicationTypes.ReadOnly = true;
            dgvApplicationTypes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvApplicationTypes.MultiSelect = false;
            dgvApplicationTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; // Manual widths
            dgvApplicationTypes.RowHeadersVisible = false;
            dgvApplicationTypes.BackgroundColor = SystemColors.Window;
            dgvApplicationTypes.BorderStyle = BorderStyle.Fixed3D;
            dgvApplicationTypes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvApplicationTypes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvApplicationTypes.EnableHeadersVisualStyles = false;

            // Set row height
            //dgvApplicationTypes.RowTemplate.Height = 50;

            // Header style
            dgvApplicationTypes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvApplicationTypes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvApplicationTypes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvApplicationTypes.ColumnHeadersHeight = 40;

            // Rows style
            dgvApplicationTypes.RowsDefaultCellStyle.BackColor = Color.White;
            dgvApplicationTypes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgvApplicationTypes.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvApplicationTypes.DefaultCellStyle.ForeColor = Color.Black;
            dgvApplicationTypes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 73, 94);
            dgvApplicationTypes.DefaultCellStyle.SelectionForeColor = Color.White;

            // Configure each column if it exists
            if (dgvApplicationTypes.Columns.Count == 0) return;

            //dgvApplicationTypes.DefaultCellStyle.Padding = new Padding(5);

            // Set friendly headers
            _SetColumnHeader("ApplicationTypeID", "ID");
            _SetColumnHeader("ApplicationTypeTitle", "Title");
            _SetColumnHeader("ApplicationFees", "Fees");

            // Set display order
            dgvApplicationTypes.Columns["ApplicationTypeID"].DisplayIndex = 0;
            dgvApplicationTypes.Columns["ApplicationTypeTitle"].DisplayIndex = 1;
            dgvApplicationTypes.Columns["ApplicationFees"].DisplayIndex = 2;

            // Set column widths
            dgvApplicationTypes.Columns["ApplicationTypeID"].Width = 50;
            dgvApplicationTypes.Columns["ApplicationTypeTitle"].Width = 350;
            dgvApplicationTypes.Columns["ApplicationFees"].Width = 190;

            dgvApplicationTypes.Columns["ApplicationTypeID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvApplicationTypes.Columns["ApplicationFees"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Center-align specific columns
            dgvApplicationTypes.Columns["ApplicationTypeID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvApplicationTypes.Columns["ApplicationFees"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }

        private void _SetColumnHeader(string columnName, string headerText)
        {
            if (dgvApplicationTypes.Columns.Contains(columnName))
                dgvApplicationTypes.Columns[columnName].HeaderText = headerText;
        }

        #endregion


    }
}
