using DVLD.Drivers;
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
    public partial class FrmIssueInternationalLicesne : Form
    {
        private clsApplication Application;

        public FrmIssueInternationalLicesne()
        {
            InitializeComponent();
            Application = new clsApplication();
            Application.ApplicationTypeID = 6;
            Application.PaidFees = clsApplicationType.FindApplicationType(6).Fees;
            Application.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
        }

        #region Event Handlers
        private void FrmIssueInternationalLicesne_Load(object sender, EventArgs e)
        {
            _LoadApplicationInfo();
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            Application.Save();
            lblInternationalApplicationID.Text = Application.ApplicationID.ToString();

            clsLicense internationalLicense = new clsLicense();
            internationalLicense.ApplicationID = Application.ApplicationID;
            internationalLicense.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
            internationalLicense.LicenseClassID = 3;
            internationalLicense.IsActive = true;
            internationalLicense.IssueReason = (int)enIssueReason.FirstTime;
            internationalLicense.IssueDate = DateTime.Now;
            internationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
            internationalLicense.Notes = "International License";
            internationalLicense.PaidFees = Application.PaidFees;
            internationalLicense.DriverID = clsDriver.FindDriverByPersonId(Application.PersonID).DriverId;

            if (internationalLicense.Save())
            {
                clsMessages.Success("International License Has Been Issued Successfully.");
                lblInternationalLicenseId.Text = internationalLicense.LicenseID.ToString();
                lnklblLicenseInfo.Enabled = true;
            }
            else
            {
                clsMessages.Error("something went wrong when trying to issue new international license");
            }
        }

        private void ctrlLicenseFilter1_OnLicenseSelected(int LicenseId)
        {
            lnklblLicensesHistory.Enabled = true;

            clsLicense localLicense = clsLicense.FindLicense(LicenseId);
            lblLocalLicenseId.Text = localLicense.LicenseID.ToString();

            int personId = clsApplication.Find(localLicense.ApplicationID).PersonID;
            Application.PersonID = personId;

            if(localLicense.LicenseClassID != (int)enLicenseClass.Class3_Ordinary)
            {
                clsMessages.Error("Sorry, this License From Class " +
                    clsLicenseClass.FindLicenseClass(localLicense.LicenseClassID).ClassName +
                    ", To Issue International License You should Have License from class " +
                    clsLicenseClass.FindLicenseClass(3).ClassName);
                return;
            }

            if (!localLicense.IsActive)
            {
                clsMessages.Error("Sorry, this License is Not Active.");
                return;
            }

            if(DateTime.Now > localLicense.ExpirationDate)
            {
                clsMessages.Error("Sorry, this License is Expired.");
                return;
            }

            if(clsDriver.FindDriverByPersonId(personId).GetInternationalDrivingLicenses().Rows.Count > 0)
            {
                clsMessages.Error("Sorry, this Person Has International Driving License.");
                return;
            }

            btnIssueLicense.Enabled = true;
        }

        #endregion

        #region Helpers
        private void _LoadApplicationInfo()
        {
            lblInternationalApplicationID.Text = Application.ApplicationID == -1 ? 
                "???" : Application.ApplicationID.ToString();
            lblApplicationDate.Text = Application.ApplicationDate.ToString(clsGlobalSettings.DateFormat);
            lblIssueDate.Text = DateTime.Now.ToString(clsGlobalSettings.DateFormat);
            lblFees.Text = Application.PaidFees.ToString(clsGlobalSettings.MoneyFormat);
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToString(clsGlobalSettings.DateFormat);
            lblCreatedBy.Text = clsGlobalSettings.CurrentUser.Username;
        }


        #endregion

        private void lnklblLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmDriverLicenseHistory frm = new FrmDriverLicenseHistory(clsDriver.
                FindDriverByPersonId(Application.PersonID).DriverId);
            frm.ShowDialog();
        }

        private void lnklblLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(int.TryParse(lblInternationalLicenseId.Text,out int id))
            {
                FrmLicenseDetails frm = new FrmLicenseDetails(id);
                frm.ShowDialog();

            }
        }
    }
}
