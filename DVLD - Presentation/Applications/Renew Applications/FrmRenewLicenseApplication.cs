using DVLD.Drivers;
using DVLD.License;
using DVLD.License.International_License;
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

namespace DVLD.Applications.Renew_Applications
{
    public partial class FrmRenewLicenseApplication : Form
    {
        private clsApplication Application;
        private clsLicense OldLicense;
        public FrmRenewLicenseApplication()
        {
            InitializeComponent();
            Application = new clsApplication();
            Application.ApplicationTypeID = 2;
            Application.PaidFees = clsApplicationType.FindApplicationType(2).Fees;
            Application.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
        }

        #region Event Handlers

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void btnRenewLicense_Click(object sender, EventArgs e)
        {
            // confirm operation
            if (clsMessages.Confirm("Are You Sure You Want To Renew This license?") == DialogResult.No)
                return;

            // save the application
            Application.Save();
            lblRenewLicenseApplicationID.Text = Application.ApplicationID.ToString();

            int RenewedLicenseID = -1;

            if (OldLicense.RenewLicense(clsGlobalSettings.CurrentUser.UserID,Application.ApplicationID,ref RenewedLicenseID))
            {
                clsMessages.Success("License Has Been Renewed Successfully.");
                lblRenewedLicenseID.Text = RenewedLicenseID.ToString();
                lnklblLicenseInfo.Enabled = true;
            }
            else
            {
                clsMessages.Error("something went wrong when trying to renew license");
            }
        }

        private void ctrlLicenseFilter1_OnLicenseSelected(int LicenseId)
        {
            lnklblLicensesHistory.Enabled = true;

            OldLicense = clsLicense.FindLicense(LicenseId);
            lblOldLicenseID.Text = OldLicense.LicenseID.ToString();

            Application.PersonID = clsDriver.FindDriver(OldLicense.DriverID).PersonId;

            _LoadApplicationInfo();

            // check if license Expired
            if (OldLicense.ExpirationDate > DateTime.Now)
            {
                clsMessages.Error($"Sorry, this License Is not yet Expired it will expire in " +
                    $"{OldLicense.ExpirationDate.ToString(clsGlobalSettings.DateFormat)}");
                return;
            }

            if (!OldLicense.IsActive)
            {
                clsMessages.Error("Sorry, this License is Not Active.");
                return;
            }

            if (OldLicense.IsDetained())
            {
                clsMessages.Error("Sorry, this License is Detained.");
                return;
            }

            btnRenewLicense.Enabled = true;
        }

        private void lnklblLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmDriverLicenseHistory frm = new FrmDriverLicenseHistory(clsDriver.
                FindDriverByPersonId(Application.PersonID).DriverId);
            frm.ShowDialog();
        }

        private void lnklblLicenseInfo_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (int.TryParse(lblRenewedLicenseID.Text, out int id))
            {
                FrmLicenseDetails frm = new FrmLicenseDetails(id);
                frm.ShowDialog();

            }
        }

        #endregion

        #region Helpers
        private void _LoadApplicationInfo()
        {
            decimal applicaionFees = Application.PaidFees;
            decimal licenseFees = clsLicenseClass.FindLicenseClass(OldLicense.LicenseClassID).ClassFees;

            lblRenewLicenseApplicationID.Text = Application.ApplicationID == -1 ?
                "???" : Application.ApplicationID.ToString();

            lblApplicationDate.Text = Application.ApplicationDate.ToString(clsGlobalSettings.DateFormat);

            lblIssueDate.Text = DateTime.Now.ToString(clsGlobalSettings.DateFormat);
            int validityLength = clsLicenseClass.FindLicenseClass(OldLicense.LicenseClassID).DefaultValidityLength;
            lblExpirationDate.Text = DateTime.Now.AddYears(validityLength).ToString(clsGlobalSettings.DateFormat);

            lblApplicationFees.Text = applicaionFees.ToString(clsGlobalSettings.MoneyFormat);
            lblLicenseFees.Text = licenseFees.ToString(clsGlobalSettings.MoneyFormat);
            lblTotalFees.Text = (licenseFees + applicaionFees).ToString(clsGlobalSettings.MoneyFormat);

            lblCreatedBy.Text = clsGlobalSettings.CurrentUser.Username;
        }

        #endregion
    }
}
