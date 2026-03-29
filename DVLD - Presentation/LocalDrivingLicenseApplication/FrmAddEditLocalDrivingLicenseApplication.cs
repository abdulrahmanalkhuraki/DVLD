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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD
{
    public partial class FrmAddEditLocalDrivingLicenseApplication : Form
    {
        public clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication { get; set; }

        public FrmAddEditLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
            _ConfigureComponents(LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationMode);
        }

        public FrmAddEditLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(LocalDrivingLicenseApplicationID);
            _ConfigureComponents(LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationMode);
        }

        #region Event Handlers

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void btnSaveRecord_Click(object sender, EventArgs e)
        {
            if (!_AreInputsValid())
            {
                return;
            }

            LocalDrivingLicenseApplication.LicenseClassID = cbLicenseClass.SelectedIndex + 1;
            LocalDrivingLicenseApplication.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;

            if (LocalDrivingLicenseApplication.Save())
            {
                MessageBox.Show("Local Driving License Application Has Been Saved Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ConfigureComponents(LocalDrivingLicenseApplication.Mode);
                _LoadApplicationInfo();
            }
            else
            {
                MessageBox.Show("Error With Saving Local Driving License Application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int PersonID)
        {
            LocalDrivingLicenseApplication.PersonID = PersonID;
            btnNext.Enabled = true;
        }

        private void btnNext_Click(object sender, EventArgs e) => tabControl1.SelectTab(1);

        private void btnBack_Click(object sender, EventArgs e) => tabControl1.SelectTab(0);

        #endregion

        #region Helpers

        private void _ConfigureComponents(enMode Mode)
        {
            _LoadLicenseClasses();
            lblApplicationFees.Text = clsApplicationType.FindApplicationType(1).Fees.ToString("N2");

            switch (Mode)
            {
                case enMode.ADD:
                    {
                        Text = "Add New Local Driving License Application";

                        lblApplicationID.Text = "Unknown";
                        lblApplicationDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                        cbLicenseClass.SelectedIndex = 0;
                        lblCreatedBy.Text = clsGlobalSettings.CurrentUser.Username;

                        btnSaveRecord.Text = "Save Application";
                        btnNext.Enabled = false;
                    }
                    break;

                case enMode.UPDATE:
                    {
                        Text = "Edit Local Driving License Application";

                        btnSaveRecord.Text = "Save Changes";
                        btnNext.Enabled = true;

                        _LoadApplicationInfo();
                    }
                    break;
            }
        }

        private void _LoadApplicationInfo()
        {
            if (LocalDrivingLicenseApplication == null)
                return;


            ctrlPersonCardWithFilter1.LoadPerson(LocalDrivingLicenseApplication.PersonID);
            lblApplicationID.Text = LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblApplicationDate.Text = LocalDrivingLicenseApplication.ApplicationDate.ToString("yyyy-MM-dd");
            cbLicenseClass.SelectedIndex = LocalDrivingLicenseApplication.LicenseClassID - 1; // cbLicenseClass index Starts from zero
            lblCreatedBy.Text = LocalDrivingLicenseApplication.CreatedByUserID.ToString();
        }

        private void _LoadLicenseClasses()
        {
            DataTable dtLicenseClasses = clsLicenseClass.GetAllLicenseClasses();
            cbLicenseClass.Items.Clear();
            foreach (DataRow row in dtLicenseClasses.Rows)
            {
                cbLicenseClass.Items.Add(row["ClassName"].ToString());
            }
        }

        private bool _AreInputsValid()
        {
            if (LocalDrivingLicenseApplication.PersonID == -1)
            {
                ErrorMessage("You Should Select A Person To Connect her/him with this User.");
                return false;
            }

            int existsApplicationID = clsLocalDrivingLicenseApplication.IsThereActiveOrderBefore(LocalDrivingLicenseApplication.PersonID,
                cbLicenseClass.SelectedIndex + 1);

            if (existsApplicationID != -1)  
            {
                ErrorMessage($"Choose another license class. The Selected person Already Has an acitve application for the selected class with ID = {existsApplicationID}");
                return false;
            }


            return true;
        }

        private void ErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

    }
}