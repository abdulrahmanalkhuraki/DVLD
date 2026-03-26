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
            _ConfigureComponents(LocalDrivingLicenseApplication.Mode);
        }

        public FrmAddEditLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplications(LocalDrivingLicenseApplicationID);
            _ConfigureComponents(LocalDrivingLicenseApplication.Mode);
        }

        #region Event Handlers

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void btnSaveRecord_Click(object sender, EventArgs e)
        {
            if (!_AreInputsValid())
            {
                return;
            }
            clsApplication application = new clsApplication();
            application


            LocalDrivingLicenseApplication.ApplicationID = (int)ctrlApplicationCardWithFilter1.ApplicationID;
            LocalDrivingLicenseApplication.LicenseClassID = (int)cbLicenseClass.SelectedValue;

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
            if (clsLocalDrivingLicenseApplication.IsLocalDrivingLicenseApplicationsExists(ApplicationID))
            {
                MessageBox.Show("This Application Is Already A Local Driving License Application in the System!", "Conflict", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LocalDrivingLicenseApplication.ApplicationID = -2;
                return;
            }

            LocalDrivingLicenseApplication.ApplicationID = ApplicationID;
            _LoadApplicationFees();
            btnSaveRecord.Enabled = true;
        }

        private void cbLicenseClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLicenseClass.SelectedValue != null)
            {
                LocalDrivingLicenseApplication.LicenseClassID = (int)cbLicenseClass.SelectedValue;
            }
        }

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

            clsApplication application = clsApplication.FindApplication(LocalDrivingLicenseApplication.ApplicationID);

            ctrlPersonCardWithFilter1.LoadPerson(application.PersonID);
            lblApplicationID.Text = LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblApplicationDate.Text = application.ApplicationDate.ToString("yyyy-MM-dd");
            cbLicenseClass.SelectedIndex = LocalDrivingLicenseApplication.LicenseClassID;
            lblCreatedBy.Text = application.CreatedByUserID.ToString();
        }

        private void _LoadLicenseClasses()
        {
            DataTable dtLicenseClasses = clsLicenseClass.GetAllLicenseClasses();
            cbLicenseClass.DataSource = dtLicenseClasses;
            cbLicenseClass.DisplayMember = "ClassName";
            cbLicenseClass.ValueMember = "LicenseClassID";
        }

        private bool _AreInputsValid()
        {
            if (LocalDrivingLicenseApplication. == -1)
            {
                ErrorMessage("You Should Select An Application To Connect with this Local Driving License Application.");
                return false;
            }

            if (LocalDrivingLicenseApplication.ApplicationID == -2)
            {
                ErrorMessage("The Application You Selected Is Already A Local Driving License Application In the System, Try Select Another Application.");
                return false;
            }

            if (cbLicenseClass.SelectedValue == null || (int)cbLicenseClass.SelectedValue == -1)
            {
                ErrorMessage("Please Select A License Class.");
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