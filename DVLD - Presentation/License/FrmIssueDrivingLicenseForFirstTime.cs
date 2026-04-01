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

        }

        private void FrmIssueDrivingLicenseForFirstTime_Load(object sender, EventArgs e)
        {
            ctrlApplicationCard1.LoadApplication(app.LocalDrivingLicenseApplicationID);
        }
    }
}
