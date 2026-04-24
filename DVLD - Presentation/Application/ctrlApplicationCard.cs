using DVLD.License;
using DVLD.Person;
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
    public partial class ctrlApplicationCard : UserControl
    {
        public clsLocalDrivingLicenseApplication application { get; set; }
        public ctrlApplicationCard()
        {
            InitializeComponent();
            application = new clsLocalDrivingLicenseApplication();
        }

        #region Event Handlers
        private void lnklblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsLicense license = clsLicense.FindLicenseByApplicationID(application.ApplicationID);
            if (license != null)
            {
                FrmLicenseDetails frm = new FrmLicenseDetails(license.LicenseID);
                frm.ShowDialog();
            }
        }

        private void lnklblShowPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmPersonDetails frm = new FrmPersonDetails(application.PersonID);
            frm.ShowDialog();
            if (frm.IsPersonEdited())
            {
                lblApplicant.Text = clsPerson.FindPerson(application.PersonID).Fullname;
            }
        }

        #endregion

        public void LoadApplication(int LocalDrivingLicenseApplicationID)
        {
            application = clsLocalDrivingLicenseApplication.Find(LocalDrivingLicenseApplicationID);
            lblDrivingLicenseApplicationID.Text = application.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = clsLicenseClass.FindLicenseClass(application.LicenseClassID).ClassName;
            lblPassedTests.Text = $"{clsLocalDrivingLicenseApplication.GetPassedTests(application.LocalDrivingLicenseApplicationID)}/3";
            lblApplicationID.Text = application.ApplicationID.ToString();
            lblApplicationDate.Text = application.ApplicationDate.ToString("yyyy-MM-dd");
            lblStatus.Text = application.ApplicationStatus.ToString();
            lblStatusDate.Text = application.LastStatusDate.ToString("yyyy-MM-dd");
            lblFees.Text = application.PaidFees.ToString();
            lblType.Text = clsApplicationType.FindApplicationType(application.ApplicationTypeID).Title;
            lblApplicant.Text = clsPerson.FindPerson(application.PersonID).Fullname;
            lblCreatedBy.Text = clsUser.FindUser(application.CreatedByUserID).Username;

            if (clsPerson.FindPerson(application.PersonID).HasLicense(application.LicenseClassID))
                lnklblShowLicenseInfo.Enabled = true;
            else
                lnklblShowLicenseInfo.Enabled = false;
        }

    }
}
