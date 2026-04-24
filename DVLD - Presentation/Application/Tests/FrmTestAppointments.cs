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
    public partial class FrmTestAppointments : Form
    {
        private clsLocalDrivingLicenseApplication app;
        private clsTestType testType;

        public FrmTestAppointments(int LocalDrivingLicenseApplicationID,int TestTypeID)
        {
            InitializeComponent();
            app = clsLocalDrivingLicenseApplication.Find(LocalDrivingLicenseApplicationID);
            testType = clsTestType.FindTestType(TestTypeID);
        }

        #region Event Handlers

        private void FrmVisionTestAppointments_Load(object sender, EventArgs e)
        {
            _LoadApplication();
        }

        private void TakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 0) return;
            int AppointmentID = Convert.ToInt32(dgvAppointments.SelectedRows[0].Cells["TestAppointmentID"].Value);
            FrmTakeTest test = new FrmTakeTest(AppointmentID);
            test.ShowDialog();
            _LoadApplication();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 0) return;
            int AppointmentID = Convert.ToInt32(dgvAppointments.SelectedRows[0].Cells["TestAppointmentID"].Value);
            FrmAddEditAppointment frm = new FrmAddEditAppointment(AppointmentID);
            frm.ShowDialog();
            _LoadApplication();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                editToolStripMenuItem.Enabled = false;
                TakeTestToolStripMenuItem.Enabled = false;
                return;
            }

            int AppointmentID = Convert.ToInt32(dgvAppointments.SelectedRows[0].Cells["TestAppointmentID"].Value);

            if(clsTestAppointment.Find(AppointmentID).IsLocked)
                TakeTestToolStripMenuItem.Enabled = false;
            else
                TakeTestToolStripMenuItem.Enabled = true;

            editToolStripMenuItem.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (app.IsThereUnlockedAppointments(testType.ID))
            {
                MessageBox.Show("Person Already has an Active Appointment for this test, you can't Add new Appointment",
                    "Active Appointment Exists",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (app.IsTherePassedTest(testType.ID))
            {
                MessageBox.Show("Person Already has Passed the test, you can't Add new Appointment",
                    "Passed Test",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            
            FrmAddEditAppointment frm = new FrmAddEditAppointment(app.LocalDrivingLicenseApplicationID,testType.ID);
            frm.ShowDialog();
            _LoadApplication();
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
            _LoadPictureAndTitle();
            _LoadAppointments();
        }

        private void _LoadPictureAndTitle()
        {
            string testTypeTitle = string.Empty;

            switch (testType.ID)
            {
                case 1:
                    {
                        testTypeTitle = "Vision Test Appointments";
                        pbTestTypeIcon.Image = Properties.Resources.icons8_vision_100;
                    }break;
                case 2:
                    {
                        testTypeTitle = "Written Test Appointments";
                        pbTestTypeIcon.Image = Properties.Resources.icons8_writing_skills_100;
                    }
                    break;
                case 3:
                    {
                        testTypeTitle = "Street Test Appointments";
                        pbTestTypeIcon.Image = Properties.Resources.icons8_driving_100;
                    }
                    break;
            }

            Text = testTypeTitle;
            lblTitle.Text = testTypeTitle;
        }

        private void _LoadAppointments()
        {
            DataTable PersonAppointments = app.GetAllAppointments(testType.ID);
            

            lblRecordsCount.Text = PersonAppointments.Rows.Count.ToString("N0");

            if(PersonAppointments.Rows.Count > 0)
                dgvAppointments.DataSource = PersonAppointments;
            else
                dgvAppointments.DataSource = clsTestAppointment.GetAllAppointments().Clone();
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

            // Hide TestTypeID column
            if (dgvAppointments.Columns.Contains("TestTypeID"))
            {
                dgvAppointments.Columns["TestTypeID"].Visible = false;
            }

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
                dgvAppointments.Columns["TestAppointmentID"].Width = 95;
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

            // Format AppointmentDate as yyyy-MM-dd
            if (dgvAppointments.Columns.Contains("AppointmentDate"))
            {
                dgvAppointments.Columns["AppointmentDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
                dgvAppointments.Columns["AppointmentDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvAppointments.Columns["AppointmentDate"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
    }
}
