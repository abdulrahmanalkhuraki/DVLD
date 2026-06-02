using DVLD.Drivers;
using DVLD___Business;
using DVLD___Business.Utility;
using System;
using System.Windows.Forms;

namespace DVLD.License.Detained_Licenses
{
    public partial class FrmDetainLicense : Form
    {
        private clsLicense license;

        public FrmDetainLicense()
        {
            InitializeComponent();
        }
        public FrmDetainLicense(int LicenseID)
        {
            InitializeComponent();
            ctrlLicenseFilter1.LoadLicense(LicenseID);
        }

        #region Event Handlers

        private void tbFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ctrlLicenseFilter1_OnLicenseSelected(int licenseID)
        {
            lnklblLicensesHistory.Enabled = true;

            license = clsLicense.FindLicense(licenseID);
            _LoadDetainInfo();

            if (license.IsDetained())
            {
                clsMessages.Error("Sorry, This License Is Already Detatined.");
                return;
            }
            if (!license.IsActive)
            {
                clsMessages.Error("Sorry, Cannot Detain an Inactive License.");
                return;
            }
            btnDetainLicense.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void lnklblLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmDriverLicenseHistory frm = new FrmDriverLicenseHistory(clsDriver.
                FindDriver(license.DriverID).DriverId);
            frm.ShowDialog();
        }

        private void lnklblLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (int.TryParse(lblLicenseId.Text, out int id))
            {
                FrmLicenseDetails frm = new FrmLicenseDetails(id);
                frm.ShowDialog();

            }
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            // Confirm License Detaination
            if (clsMessages.Confirm("Are You Sure You Want To Detain This License?") == DialogResult.No)
            {
                return;
            }

            if (license == null)
            {
                clsMessages.Error("Sorry, No License To Detain.");
                return;
            }
            if (string.IsNullOrEmpty(tbFineFees.Text))
            {
                errorProvider1.SetError(tbFineFees, "Enter Fine Fees");
                tbFineFees.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(tbFineFees, "");
            }


            if (license.DetainLicense(decimal.Parse(tbFineFees.Text), clsGlobalSettings.CurrentUser.UserID))
            {
                clsMessages.Success("License Detained Successfully.");
                lblDetainId.Text = license.GetDetainInfo().DetainID.ToString();
                lnklblLicenseInfo.Enabled = true;
            }
            else
            {
                clsMessages.Error("something went wrong when trying to ditain this license.");
            }
        }

        #endregion

        #region Helpers
        private void _LoadDetainInfo()
        {
            lblLicenseId.Text = license.LicenseID.ToString();
            lblCreatedBy.Text = clsGlobalSettings.CurrentUser.Username;
            lblDetainDate.Text = DateTime.Now.ToString(clsGlobalSettings.DateFormat);
        }
        #endregion
    }
}
