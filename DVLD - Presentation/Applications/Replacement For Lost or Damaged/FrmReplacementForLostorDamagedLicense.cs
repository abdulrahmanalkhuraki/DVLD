using DVLD.Drivers;
using DVLD.License;
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

namespace DVLD.Applications.Replacement_For_Lost_or_Damaged
{
    public partial class FrmReplacementForLostorDamagedLicense : Form
    {
        private clsApplication Application;
        private clsLicense OldLicense;
        public FrmReplacementForLostorDamagedLicense()
        {
            InitializeComponent();
            Application = new clsApplication();
            Application.PaidFees = 5;
            Application.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
        }


        #region Event Handlers
        private void rbDamaged_CheckedChanged(object sender, EventArgs e)
        {
            Application.ApplicationTypeID = rbDamaged.Checked ? 4 : 3;
            Application.PaidFees = clsApplicationType.FindApplicationType(Application.ApplicationTypeID).Fees;
            lblApplicationFees.Text = Application.PaidFees.ToString(clsGlobalSettings.MoneyFormat);
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void btnReplaceLicense_Click(object sender, EventArgs e)
        {
            // confirm operation
            if (clsMessages.Confirm("Are You Sure You Want To Replace This license?") == DialogResult.No)
                return;

            // save the application
            Application.Save();
            lblReplaceLicenseApplicationID.Text = Application.ApplicationID.ToString();

            // making old license inactive
            OldLicense.IsActive = false;
            OldLicense.Save();

            // creating new license record
            clsLicense ReplacedLicense = new clsLicense();
            ReplacedLicense.ApplicationID = Application.ApplicationID;
            ReplacedLicense.LicenseClassID = OldLicense.LicenseClassID;
            ReplacedLicense.PaidFees = clsLicenseClass.FindLicenseClass(ReplacedLicense.LicenseClassID).ClassFees;
            ReplacedLicense.DriverID = clsDriver.FindDriverByPersonId(Application.PersonID).DriverId;
            ReplacedLicense.IssueDate = DateTime.Now;
            int validityLength = clsLicenseClass.FindLicenseClass(OldLicense.LicenseClassID).DefaultValidityLength;
            ReplacedLicense.ExpirationDate = DateTime.Now.AddYears(validityLength);
            ReplacedLicense.IsActive = true;
            ReplacedLicense.Notes = rbDamaged.Checked ? "Replacement For Damaged." : "Replacement For Lost.";
            ReplacedLicense.IssueReason = rbDamaged.Checked?(int)enIssueReason.ReplacementForDamaged
                : (int)enIssueReason.ReplacementForLost;
            ReplacedLicense.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;

            // saving replaced license to the database
            if (ReplacedLicense.Save())
            {
                clsMessages.Success("License Has Been Replaced Successfully.");
                lblReplacedLicenseID.Text = ReplacedLicense.LicenseID.ToString();
                lnklblLicenseInfo.Enabled = true;
            }
            else
            {
                clsMessages.Error("something went wrong when trying to replace license");
            }
        }

        private void ctrlLicenseFilter1_OnLicenseSelected(int LicenseId)
        {
            lnklblLicensesHistory.Enabled = true;
            gbReplacementReason.Enabled = true;

            OldLicense = clsLicense.FindLicense(LicenseId);
            lblOldLicenseID.Text = OldLicense.LicenseID.ToString();

            Application.PersonID = clsDriver.FindDriver(OldLicense.DriverID).PersonId;

            _LoadApplicationInfo();

            // check if license Expired
            if (OldLicense.ExpirationDate < DateTime.Now)
            {
                clsMessages.Error($"Sorry, this License Is Expired you can't replace it, Renew this license.");
                return;
            }

            if (OldLicense.IsLicenseDetained())
            {
                clsMessages.Error("Sorry, this License is Detained.");
                return;
            }

            btnReplaceLicense.Enabled = true;
        }

        private void lnklblLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmDriverLicenseHistory frm = new FrmDriverLicenseHistory(clsDriver.
                FindDriverByPersonId(Application.PersonID).DriverId);
            frm.ShowDialog();
        }

        private void lnklblLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (int.TryParse(lblReplacedLicenseID.Text, out int id))
            {
                FrmLicenseDetails frm = new FrmLicenseDetails(id);
                frm.ShowDialog();

            }
        }
        #endregion

        #region Helpers
        private void _LoadApplicationInfo()
        {
            lblReplaceLicenseApplicationID.Text = Application.ApplicationID == -1 ?
                "???" : Application.ApplicationID.ToString();

            lblApplicationDate.Text = Application.ApplicationDate.ToString(clsGlobalSettings.DateFormat);

            lblApplicationFees.Text = Application.PaidFees.ToString(clsGlobalSettings.MoneyFormat);

            lblCreatedBy.Text = clsGlobalSettings.CurrentUser.Username;
        }
        #endregion

    }
}
