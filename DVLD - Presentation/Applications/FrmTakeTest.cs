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
    public partial class FrmTakeTest : Form
    {
        private clsTestAppointment appointment;
        public FrmTakeTest(int AppointmentID)
        {
            InitializeComponent();
            appointment = clsTestAppointment.Find(AppointmentID);
        }

        private void btnSaveRecord_Click(object sender, EventArgs e)
        {
            clsTest test = new clsTest();
            test.TestAppointmentID = appointment.AppointmentID;
            test.TestResult = rbPass.Checked;

            if(!string.IsNullOrWhiteSpace(tbNotes.Text))
                test.Notes = tbNotes.Text;
            test.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;

            if (test.Save())
            {
                MessageBox.Show("Test Has Been Taken Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                appointment.IsLocked = true;
                appointment.Save();
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Error With Taking Test.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void FrmTakeTest_Load(object sender, EventArgs e)
        {
            _LoadApplicationInfo();
        }

        private void _LoadApplicationInfo()
        {
            clsLocalDrivingLicenseApplication app = clsLocalDrivingLicenseApplication.Find(appointment.LocalDrivingLicenseApplicationID);
            if (app == null)
            {
                return;
            }

            lblDrivingLicenseApplicationID.Text = app.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = clsLicenseClass.FindLicenseClass(app.LicenseClassID).ClassName;
            lblName.Text = clsPerson.FindPerson(app.PersonID).Fullname;
            lblTrials.Text = "0";
            lblDate.Text = appointment.AppointmentDate.ToString("yyyy-MM-dd");
            lblFees.Text = app.PaidFees.ToString("N2");
        }
    }
}
