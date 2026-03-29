using DVLD.Application_Types;
using DVLD.LocalDrivingLicenseApplication;
using DVLD.Person;
using DVLD.Test_Types;
using DVLD.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        #region Applications
        private void drivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manageApplicationsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmManageApplicationTypes frm = new FrmManageApplicationTypes();
            frm.ShowDialog();
        }

        private void manageTestsTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManageTestTypes frm = new FrmManageTestTypes();
            frm.ShowDialog();
        }

        #endregion

        #region Drivers
        #endregion

        #region People

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManagePeople frm = new FrmManagePeople();
            frm.ShowDialog();
        }

        #endregion

        #region Users

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManageUsers frm = new FrmManageUsers();
            frm.ShowDialog();
        }

        #endregion

        #region Account Settings
        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUserDetails frm = new FrmUserDetails(clsGlobalSettings.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChangePassword frm = new FrmChangePassword(clsGlobalSettings.CurrentUser.UserID);
            frm.ShowDialog();
        }


        #endregion

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddEditLocalDrivingLicenseApplication frm = new FrmAddEditLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManageLocalDrivingLicenseApplications frm = new FrmManageLocalDrivingLicenseApplications();
            frm.ShowDialog();
        }
    }
}
