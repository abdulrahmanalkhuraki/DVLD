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
    public partial class FrmScheduleVisionTestAppointment : Form
    {
        private clsLocalDrivingLicenseApplication app;

        public FrmScheduleVisionTestAppointment(int LocalDrivingLicenseApplication)
        {
            InitializeComponent();
            app = clsLocalDrivingLicenseApplication.Find(LocalDrivingLicenseApplication);
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void FrmScheduleVisionTestAppointment_Load(object sender, EventArgs e)
        {
            _LoadApplicationInfo();
        }

        private void _LoadApplicationInfo()
        {
            if (app == null)
            {
                return;
            }
            

            int highDeference = 150;
            gbRetakeTest.Visible = false;
            btnSaveRecord.Location = new Point(btnSaveRecord.Location.X, btnSaveRecord.Location.Y - highDeference);
            btnClose.Location = new Point(btnClose.Location.X, btnClose.Location.Y - highDeference);
            Size = new Size(this.Size.Width, this.Size.Height - highDeference);

            lblDrivingLicenseApplicationID.Text = app.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = clsLicenseClass.FindLicenseClass(app.LicenseClassID).ClassName;
            lblName.Text = clsPerson.FindPerson(app.PersonID).Fullname;
            lblTrials.Text = "0";
            dtpDate.MinDate = DateTime.Now.AddDays(1);
            dtpDate.Value = DateTime.Now.AddDays(1);
            lblFees.Text = app.PaidFees.ToString("N2");

            if (app.GetAllAppointments().Rows.Count != 0)
            {
                Size = new Size(this.Size.Width, this.Size.Height + highDeference);
                btnSaveRecord.Location = new Point(btnSaveRecord.Location.X, btnSaveRecord.Location.Y + highDeference);
                btnClose.Location = new Point(btnClose.Location.X, btnClose.Location.Y + highDeference);
                gbRetakeTest.Visible = true;

                lblRetakeTestApplicationID.Text = "Unknown";
                lblFees.Text = clsTestType.FindTestType(1).Fees.ToString("N2");

            }
        }
    }
}
