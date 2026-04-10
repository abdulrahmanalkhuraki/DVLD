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
    public partial class FrmAddEditAppointment : Form
    {
        private clsTestAppointment appointment;
        private clsLocalDrivingLicenseApplication retakeApp;

        public FrmAddEditAppointment(int LocalDrivingLicenseApplicationID,int TestTypeID) // Add Mode
        {
            InitializeComponent();
            appointment = new clsTestAppointment();
            appointment.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            appointment.TestTypeID = TestTypeID;
            _ConfigureComponents(enMode.ADD);
        }

        public FrmAddEditAppointment(int AppointmentID) // Update Mode
        {
            InitializeComponent();
            appointment = clsTestAppointment.Find(AppointmentID);
            _ConfigureComponents(enMode.UPDATE);
        }

        #region Event Handlers
        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void btnSaveRecord_Click(object sender, EventArgs e)
        {
            if(appointment.IsForRetakeTest())
            {
                retakeApp.Save();
                appointment.LocalDrivingLicenseApplicationID = retakeApp.LocalDrivingLicenseApplicationID;
            }

            appointment.AppointmentDate = dtpDate.Value;
            appointment.PaidFees = Convert.ToDecimal(lblTotalFees.Text); // total Fees

            if(appointment.Save())
            {
                MessageBox.Show($"Appointment Has Been Set Successfully on {appointment.AppointmentDate.ToString("yyyy-MM-dd")}."
                    , "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Error With Saving Appointment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Helpers

        private void _ConfigureComponents(enMode Mode)
        {
            _LoadPicture();
            _LoadApplicationInformations();

            string title = string.Empty;
            switch (Mode)
            {
                case enMode.ADD:
                    {
                        title = "Schedule New Appointment";
                        lblTitle.Text = Text = title;

                        lblAppointmentLockedInformation.Visible = false;
                        dtpDate.Enabled = true;      
                        dtpDate.MinDate = DateTime.Now.AddDays(1);
                        dtpDate.Value = DateTime.Now.AddDays(1);
                        btnSaveRecord.Enabled = true;
                        gbRetakeTest.Enabled = appointment.IsForRetakeTest();
                        lblRetakeTestApplicationID.Text = "Unknown";
                        appointment.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
                    }
                    break;

                case enMode.UPDATE:
                    {
                        title = "Edit Appointment";
                        lblTitle.Text = Text = title;

                        dtpDate.MinDate = new DateTime(1950,1,1);
                        dtpDate.Value = appointment.AppointmentDate;

                        if (appointment.IsLocked)
                        {
                            dtpDate.Enabled = false;
                            lblAppointmentLockedInformation.Visible = true;
                            btnSaveRecord.Enabled = false;
                        }
                        else
                        {
                            dtpDate.Enabled = true;
                            dtpDate.Value = appointment.AppointmentDate;
                            lblAppointmentLockedInformation.Visible= false;
                            btnSaveRecord.Enabled = true;
                        }
                    }
                    break;
            }
        }

        private void _LoadPicture()
        {
            switch (appointment.TestTypeID)
            {
                case 1: pictureBox1.Image = Properties.Resources.icons8_vision__1_; break;
                case 2: pictureBox1.Image = Properties.Resources.icons8_writing_skills_100; break;
                case 3: pictureBox1.Image = Properties.Resources.icons8_driving_100; break;
                default: break;
            }
        }

        private void _LoadApplicationInformations()
        {
            clsLocalDrivingLicenseApplication app = clsLocalDrivingLicenseApplication.Find(appointment.LocalDrivingLicenseApplicationID);

            lblDrivingLicenseApplicationID.Text = app.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = clsLicenseClass.FindLicenseClass(app.LicenseClassID).ClassName;
            lblName.Text = clsPerson.FindPerson(app.PersonID).Fullname;
            lblTrials.Text = "0";
            lblFees.Text = clsTestType.FindTestType(appointment.TestTypeID).Fees.ToString("N2"); // test fees

            // Retake Test Section
            if (appointment.IsForRetakeTest())
            {
                retakeApp = new clsLocalDrivingLicenseApplication();

                // creating application with retake type id
                retakeApp.Mode = app.Mode;
                retakeApp.ApplicationID = app.ApplicationID;
                retakeApp.PersonID = app.PersonID;
                retakeApp.ApplicationDate = app.ApplicationDate;
                retakeApp.LastStatusDate = app.LastStatusDate;
                retakeApp.ApplicationStatus = app.ApplicationStatus;
                retakeApp.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
                retakeApp.ApplicationTypeID = 8;
                retakeApp.LicenseClassID = app.LicenseClassID;
                retakeApp.PaidFees = clsApplicationType.FindApplicationType(8).Fees;
                //retakeApp.Save();

                //appointment.LocalDrivingLicenseApplicationID = retakeApp.LocalDrivingLicenseApplicationID;

                //lblRetakeTestApplicationID.Text = retakeApp.LocalDrivingLicenseApplicationID.ToString();
                lblRetakeFees.Text = retakeApp.PaidFees.ToString("N2");
                lblTotalFees.Text = (clsTestType.FindTestType(appointment.TestTypeID).Fees + retakeApp.PaidFees).ToString("N2");
            }
            else
            {
                lblRetakeTestApplicationID.Text = "Unknown";
                lblRetakeFees.Text = "0";
                lblTotalFees.Text = "0";
            }

        }
        #endregion
    }
}
