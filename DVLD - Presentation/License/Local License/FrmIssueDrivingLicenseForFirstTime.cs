using DVLD___Business;
using DVLD___Business.Enums;
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
    public partial class FrmIssueDrivingLicenseForFirstTime : Form
    {
        private clsLocalDrivingLicenseApplication app;
        public FrmIssueDrivingLicenseForFirstTime(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            app = clsLocalDrivingLicenseApplication.Find(LocalDrivingLicenseApplicationID);
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void btnIssue_Click(object sender, EventArgs e)
        {
            // creating Driver
            clsDriver driver = new clsDriver();
            driver.PersonId = app.PersonID;
            driver.CreatedByUserId = clsGlobalSettings.CurrentUser.UserID;
            driver.CreatedDate = DateTime.Now;
            driver.Save();

            clsLicense license = new clsLicense();
            license.ApplicationID = app.ApplicationID;
            license.DriverID = driver.DriverId;
            license.LicenseClassID = app.LicenseClassID;
            license.IssueDate = DateTime.Now;
            license.ExpirationDate = DateTime.Now.AddYears(clsLicenseClass.FindLicenseClass(license.LicenseClassID).DefaultValidityLength);
            license.Notes = string.IsNullOrWhiteSpace(tbNotes.Text)? string.Empty : tbNotes.Text;
            license.PaidFees = app.PaidFees;
            license.IsActive = true;
            license.IssueReason = (int)enIssueReason.FirstTime;
            license.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
            if(license.Save())
            {
                MessageBox.Show("License Has Been Issued Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                app.ApplicationStatus = enApplicationStatus.Completed;
                app.Save();
                this.DialogResult = DialogResult.OK;
                Close();
                return;
            }
            MessageBox.Show("Something went wrong when trying to issue the license.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FrmIssueDrivingLicenseForFirstTime_Load(object sender, EventArgs e)
        {
            ctrlApplicationCard1.LoadApplication(app.LocalDrivingLicenseApplicationID);
        }
    }
}
