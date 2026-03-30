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

namespace DVLD.Applications
{
    public partial class FrmVisionTestAppointments : Form
    {
        private clsLocalDrivingLicenseApplication app;

        public FrmVisionTestAppointments(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            app = clsLocalDrivingLicenseApplication.Find(LocalDrivingLicenseApplicationID);
        }

        #region Event Handlers

        private void FrmVisionTestAppointments_Load(object sender, EventArgs e)
        {
            _LoadApplication();
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void btnNew_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Helpers
        private void _LoadApplication()
        {
            if (app == null)
            {
                return;
            }

            ctrlApplicationCard1.LoadApplication(app.LocalDrivingLicenseApplicationID);
            _LoadAppointments();
        }

        private void _LoadAppointments()
        {
            dgvAppointments.DataSource = app.GetAllAppointments();
            _ConfigureDataGridView();
        }

        private void _ConfigureDataGridView()
        {
            if (dgvAppointments.Columns.Count == 0) return;

            dgvAppointments.AllowUserToAddRows = false;
            dgvAppointments.AllowUserToDeleteRows = false;
            dgvAppointments.ReadOnly = true;
            dgvAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAppointments.MultiSelect = false;
            dgvAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvAppointments.RowHeadersVisible = false;
            dgvAppointments.BackgroundColor = Color.White;
            dgvAppointments.BorderStyle = BorderStyle.Fixed3D;
            dgvAppointments.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAppointments.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvAppointments.EnableHeadersVisualStyles = false;

            dgvAppointments.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvAppointments.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAppointments.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvAppointments.ColumnHeadersHeight = 40;

            dgvAppointments.RowsDefaultCellStyle.BackColor = Color.White;
            dgvAppointments.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgvAppointments.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvAppointments.DefaultCellStyle.ForeColor = Color.Black;
            dgvAppointments.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 73, 94);
            dgvAppointments.DefaultCellStyle.SelectionForeColor = Color.White;

            _SetColumnHeader("TestAppointmentID", "Appointment ID");
            _SetColumnHeader("AppointmentDate", "Appointment Date");
            _SetColumnHeader("PaidFees", "Paid Fees");
            _SetColumnHeader("IsLocked", "Is Locked");

            int index = 0;
            if (dgvAppointments.Columns.Contains("TestAppointmentID"))
                dgvAppointments.Columns["TestAppointmentID"].DisplayIndex = index++;
            if (dgvAppointments.Columns.Contains("AppointmentDate"))
                dgvAppointments.Columns["AppointmentDate"].DisplayIndex = index++;
            if (dgvAppointments.Columns.Contains("PaidFees"))
                dgvAppointments.Columns["PaidFees"].DisplayIndex = index++;
            if (dgvAppointments.Columns.Contains("IsLocked"))
                dgvAppointments.Columns["IsLocked"].DisplayIndex = index++;

            if (dgvAppointments.Columns.Contains("TestAppointmentID"))
                dgvAppointments.Columns["TestAppointmentID"].Width = 90;
            if (dgvAppointments.Columns.Contains("AppointmentDate"))
                dgvAppointments.Columns["AppointmentDate"].Width = 120;
            if (dgvAppointments.Columns.Contains("PaidFees"))
                dgvAppointments.Columns["PaidFees"].Width = 60;
            if (dgvAppointments.Columns.Contains("IsLocked"))
                dgvAppointments.Columns["IsLocked"].Width = 70;

            if (dgvAppointments.Columns.Contains("TestAppointmentID"))
            {
                dgvAppointments.Columns["TestAppointmentID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvAppointments.Columns["TestAppointmentID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvAppointments.Columns.Contains("PaidFees"))
            {
                dgvAppointments.Columns["PaidFees"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvAppointments.Columns["PaidFees"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvAppointments.Columns["PaidFees"].DefaultCellStyle.Format = "N2";
            }
            if (dgvAppointments.Columns.Contains("IsLocked"))
            {
                dgvAppointments.Columns["IsLocked"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvAppointments.Columns["IsLocked"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvAppointments.Columns.Contains("IsLocked") && !(dgvAppointments.Columns["IsLocked"] is DataGridViewCheckBoxColumn))
            {
                DataGridViewColumn oldCol = dgvAppointments.Columns["IsLocked"];
                int colIndex = oldCol.Index;
                string headerText = oldCol.HeaderText;
                int width = oldCol.Width;
                bool visible = oldCol.Visible;

                DataGridViewCheckBoxColumn newCol = new DataGridViewCheckBoxColumn
                {
                    Name = "IsLocked",
                    HeaderText = headerText,
                    Width = width,
                    Visible = visible,
                    DataPropertyName = "IsLocked",
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

                dgvAppointments.Columns.Remove(oldCol);
                dgvAppointments.Columns.Insert(colIndex, newCol);
            }
        }

        private void _SetColumnHeader(string columnName, string headerText)
        {
            if (dgvAppointments.Columns.Contains(columnName))
                dgvAppointments.Columns[columnName].HeaderText = headerText;
        }


        #endregion

        private void TakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 0) return;
            int AppointmentID = Convert.ToInt32(dgvAppointments.SelectedRows[0].Cells["AppointmentID"].Value);
            FrmTakeTest test = new FrmTakeTest(AppointmentID);
            test.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 0) return;
            int AppointmentID = Convert.ToInt32(dgvAppointments.SelectedRows[0].Cells["AppointmentID"].Value);
            FrmScheduleVisionTestAppointment frm = new FrmScheduleVisionTestAppointment(AppointmentID);
            frm.ShowDialog();
        }
    }
}
