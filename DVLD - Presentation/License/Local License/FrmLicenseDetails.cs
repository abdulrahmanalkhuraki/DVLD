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

namespace DVLD.License
{
    public partial class FrmLicenseDetails : Form
    {
        private clsLicense License;

        public FrmLicenseDetails(int LicenseId)
        {
            InitializeComponent();
            License = clsLicense.FindLicense(LicenseId);
        }

        private void FrmShowLicense_Load(object sender, EventArgs e)
        {
            ctrlLicenseCard1.LoadLicenseInfo(License.LicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();
    }
}
