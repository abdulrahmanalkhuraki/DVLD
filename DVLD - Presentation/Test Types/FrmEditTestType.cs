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

namespace DVLD.Test_Types
{
    public partial class FrmEditTestType : Form
    {
        private clsTestType TestType;

        public FrmEditTestType(int TestTypeID)
        {
            InitializeComponent();
            TestType = clsTestType.FindTestType(TestTypeID);
            _LoadTestTypeInformation();
        }

        #region Event Handlers
        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void btnSaveRecord_Click(object sender, EventArgs e)
        {
            if (!AreInputsValid())
            {
                return;
            }
            if (MessageBox.Show("Are You Sure You Want to Update This Test Type?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            TestType.Title = tbTitle.Text;
            TestType.Description = tbDescription.Text;
            TestType.Fees = nudFees.Value;

            if (TestType.Save())
            {
                MessageBox.Show("Test Type Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _LoadTestTypeInformation();
            }
            else
            {
                ErrorMessage("Something Went Wrong When Trying to Update Test Type.");
            }
        }

        #endregion

        #region Helpers
        private void _LoadTestTypeInformation()
        {
            lblTestTypeID.Text = TestType.ID.ToString();
            tbTitle.Text = TestType.Title;
            tbDescription.Text = TestType.Description;
            nudFees.Value = TestType.Fees;
        }

        private bool AreInputsValid()
        {
            if (string.IsNullOrWhiteSpace(tbTitle.Text))
            {
                ErrorMessage("Title Shouldn't Be Empty.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbDescription.Text))
            {
                ErrorMessage("Description Shouldn't Be Empty.");
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