using DVLD.Person;
using DVLD___Business;
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
    public partial class ctrlLicenseFilter : UserControl
    {
        public event Action<int> OnLicenseSelected;
        public ctrlLicenseFilter()
        {
            InitializeComponent();
        }

        protected virtual void LicenseSelected(int LicenseID)
        {
            Action<int> handler = OnLicenseSelected;
            if (handler != null)
            {
                handler(LicenseID);
            }
        }

        public void DisableFilter() => gbFilter.Enabled = false;
        public void EnableFilter() => gbFilter.Enabled = true;

        public void LoadLicense(int LicenseID)
        {
            if (LicenseID <= 0) return;

            if (!clsLicense.IsLicenseExists(LicenseID))
            {
                clsMessages.Error($"License with Id = {LicenseID} Not Found.");
                return;
            }

            ctrlLicenseCard1.LoadLicenseInfo(LicenseID);

            if (OnLicenseSelected != null)
            {
                OnLicenseSelected(LicenseID);
            }
            tbLicenseId.Text = LicenseID.ToString();
            DisableFilter();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tbLicenseId.Text, out int LicenseID))
            {

                if (!clsLicense.IsLicenseExists(LicenseID))
                {
                    clsMessages.Error($"License with Id = {LicenseID} Not Found.");
                    return;
                }

                ctrlLicenseCard1.LoadLicenseInfo(LicenseID);

                if (OnLicenseSelected != null)
                {
                    OnLicenseSelected(LicenseID);
                }
            }
        }

    }
}
