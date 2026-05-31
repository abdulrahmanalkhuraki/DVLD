using DVLD.Drivers;
using DVLD___Business;
using DVLD___Business.Utility;
using System;
using System.Windows.Forms;

namespace DVLD.License.Detained_Licenses
{
    public partial class FrmReleaseDetainedLicense : Form
    {
        private clsApplication Application;
        private clsDetainedLicense DetainedLicense;
        public FrmReleaseDetainedLicense()
        {
            InitializeComponent();
            Application = new clsApplication();
            Application.ApplicationTypeID = 5;
            Application.PaidFees = clsApplicationType.FindApplicationType(5).Fees;
            Application.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
        }
        public FrmReleaseDetainedLicense(int LicenseId)
        {
            InitializeComponent();
            Application = new clsApplication();
            Application.ApplicationTypeID = 5;
            Application.PaidFees = clsApplicationType.FindApplicationType(5).Fees;
            Application.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
            ctrlLicenseFilter1.LoadLicense(LicenseId);
        }

        #region Event Handlers
        private void lnklblLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (int.TryParse(lblLicenseId.Text, out int id))
            {
                FrmLicenseDetails frm = new FrmLicenseDetails(id);
                frm.ShowDialog();

            }
        }

        private void lnklblLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmDriverLicenseHistory frm = new FrmDriverLicenseHistory(clsDriver.
                FindDriverByPersonId(Application.PersonID).DriverId);
            frm.ShowDialog();
        }

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            // confirm operation
            if (clsMessages.Confirm("Are You Sure You Want To Renew This license?") == DialogResult.No)
                return;

            // save the application
            Application.Save();
            lblReleaseApplicationId.Text = Application.ApplicationID.ToString();
            clsLicense license = clsLicense.FindLicense(DetainedLicense.LicenseID);

            if (license.ReleaseLicense(clsGlobalSettings.CurrentUser.UserID,Application.ApplicationID))
            {
                clsMessages.Success("License Has Been Released Successfully.");
                lnklblLicenseInfo.Enabled = true;
            }
            else
            {
                clsMessages.Error("something went wrong when trying to Release license");
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void ctrlLicenseFilter1_OnLicenseSelected(int LicenseId)
        {
            lnklblLicensesHistory.Enabled = true;

            if(!clsDetainedLicense.IsLicenseDetained(LicenseId))
            {
                clsMessages.Error("This License Is Not Detained.");
                return;
            }

            DetainedLicense = clsDetainedLicense.
                FindDetainedLicenseByLicenseID(LicenseId);
            clsLicense license = clsLicense.FindLicense(DetainedLicense.LicenseID);


            lblLicenseId.Text = license.LicenseID.ToString();

            Application.PersonID = clsDriver.FindDriver(license.DriverID).PersonId;

            _LoadApplicationInfo();

            btnReleaseLicense.Enabled = true;
        }


        #endregion

        #region Helpers
        private void _LoadApplicationInfo()
        {
            lblDetainId.Text = DetainedLicense.DetainID.ToString();
            lblDetainDate.Text = DetainedLicense.DetainDate.ToString(clsGlobalSettings.DateFormat);
            lblApplicationFees.Text = Application.PaidFees.ToString(clsGlobalSettings.MoneyFormat);
            lblFineFees.Text = DetainedLicense.FineFees.ToString(clsGlobalSettings.MoneyFormat);
            lblTotalFees.Text = (Application.PaidFees + DetainedLicense.FineFees).ToString(clsGlobalSettings.MoneyFormat);
            lblCreatedBy.Text = clsGlobalSettings.CurrentUser.Username;
        }
        #endregion
    }
}
