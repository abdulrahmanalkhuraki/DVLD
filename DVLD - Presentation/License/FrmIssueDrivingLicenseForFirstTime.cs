using DVLD___Business;
using DVLD___Business.Enums;
using DVLD___Business.Utility;
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
            if(clsLocalDrivingLicenseApplication.GetPassedTests(app.LocalDrivingLicenseApplicationID) != 3)
            {
                clsMessages.Error("The license cannot be issued, as some tests have not yet been taken.");
                return;
            }

            if (clsMessages.Confirm("Are You Sure You Want to Issue License For this Person?") != DialogResult.Yes) return;

            // Creating Driver
            clsDriver driver = new clsDriver();
            driver.PersonID = app.PersonID;
            driver.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
            driver.Save();

            // Creating license
            clsLicense license = new clsLicense();
            license.ApplicationID = app.ApplicationID;
            license.DriverID = driver.DriverID;
            license.LicenseClassID = app.LicenseClassID;
            license.IssueDate = DateTime.Now;
            license.ExpirationDate = license.IssueDate.AddYears(clsLicenseClass.FindLicenseClass(license.LicenseClassID).DefaultValidityLength);

            if(!string.IsNullOrWhiteSpace(tbNotes.Text))
                license.Notes = tbNotes.Text;
            license.PaidFees = app.PaidFees;
            license.IsActive = true;
            license.IssueReason = (int)enIssueReason.FirstTime;
            license.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;

            if (license.Save()) 
            {
                clsMessages.Success("License Has Been Issued Successfully.");
                app.ApplicationStatus = enApplicationStatus.Completed;
                app.Save();
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                clsMessages.Error("Something Went Wrong When trying to Issue License.");
            }

        }

        private void FrmIssueDrivingLicenseForFirstTime_Load(object sender, EventArgs e)
        {
            ctrlApplicationCard1.LoadApplication(app.LocalDrivingLicenseApplicationID);
        }
    }
}
