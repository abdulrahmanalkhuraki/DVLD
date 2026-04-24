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
            if(MessageBox.Show("Are You Sure You Want To Save? After That You Can't Change Test Result!","Confirm",
                MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation) != DialogResult.Yes)
                { return; }


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
            lblFees.Text = clsTestType.FindTestType(appointment.TestTypeID).Fees.ToString("N2");
            lblTestID.Text = "Not Taken Yet";
            _LoadPicture();
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
    }
}
