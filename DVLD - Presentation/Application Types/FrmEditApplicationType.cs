using DVLD___Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Application_Types
{
    public partial class FrmEditApplicationType : Form
    {
        private clsApplicationType ApplicationType;

        public FrmEditApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();
            ApplicationType = clsApplicationType.FindApplicationType(ApplicationTypeID);
            _LoadApplicationTypeInformation();
        }

        #region Event Handlers
        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void btnSaveRecord_Click(object sender, EventArgs e)
        {
            if (!AreInputsValid())
            {
                return;
            }
            if (MessageBox.Show("Are You Sure You Want to Update This Application Type?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            ApplicationType.Title = tbTitle.Text;
            ApplicationType.Fees = nudFees.Value;

            if (ApplicationType.Save())
            {
                MessageBox.Show("Application Type Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _LoadApplicationTypeInformation();
            }
            else
            {
                ErrorMessage("Something Went Wrong When Trying to Update Application Type.");
            }
        }

        #endregion

        #region Helpers
        private void _LoadApplicationTypeInformation()
        {
            Tag = ApplicationType.ID;
            tbTitle.Text = ApplicationType.Title;
            nudFees.Value = ApplicationType.Fees;
        }

        private bool AreInputsValid()
        {
            if (string.IsNullOrWhiteSpace(tbTitle.Text))
            {
                ErrorMessage("Title Shouldn't Be Empty.");
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
