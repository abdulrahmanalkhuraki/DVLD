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

namespace DVLD.License.International_License
{
    public partial class FrmInternationalLicenseDetails : Form
    {
        private clsInternationalLicense license;

        public FrmInternationalLicenseDetails(int InternationalLicenseID)
        {
            InitializeComponent();
            license = clsInternationalLicense.Find(InternationalLicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void FrmInternationalLicenseDetails_Load(object sender, EventArgs e)
            => ctrlInternationalLicenseCard1.LoadLicenseInfo(license.InternationalLicenseID);
    }
}
