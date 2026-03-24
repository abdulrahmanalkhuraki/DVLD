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

namespace DVLD.User
{
    public partial class FrmChangePassword : Form
    {
        clsUser User;
        public FrmChangePassword(int UserID)
        {
            InitializeComponent();
            User = clsUser.FindUser(UserID);
        }

        #region Event Handlers
        private void FrmChangePassword_Load(object sender, EventArgs e)
        {
            ctrlUserCard1.LoadUserInformation(User.UserID);
        }

        private void tbCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbCurrentPassword.Text))
            {
                errorProvider1.SetError(tbCurrentPassword, "This Field Shouldn't Be Empty.");
            }
            else if (!User.Password.Equals(tbCurrentPassword.Text))
            {
                errorProvider1.SetError(tbCurrentPassword, "Current Password Is Wrong.");
            }
            else
            {
                errorProvider1.SetError(tbCurrentPassword, string.Empty);
            }
        }

        private void tbNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNewPassword.Text))
            {
                errorProvider1.SetError(tbNewPassword, "This Field Shouldn't Be Empty.");
            }
            else
            {
                errorProvider1.SetError(tbNewPassword, string.Empty);
            }
        }

        private void tbConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!tbNewPassword.Text.Equals(tbConfirmPassword.Text))
            {
                errorProvider1.SetError(tbConfirmPassword, "Password and Confirm Password Should match.");
            }
            else
            {
                errorProvider1.SetError(tbConfirmPassword, string.Empty);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void btnSaveRecord_Click(object sender, EventArgs e)
        {
            if (!_AreInputsValid())
            {
                return;
            }
            if (MessageBox.Show("Password Canged Successfully", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            User.Password = tbNewPassword.Text;
            if (User.Save())
            {
                MessageBox.Show("Password Canged Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Something Went Wrong When Trying to Change the Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Helpers
        private bool _AreInputsValid()
        {
            if (string.IsNullOrWhiteSpace(tbCurrentPassword.Text))
            {
                MessageBox.Show("Current Password Field Shouldn't Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            if (!User.Password.Equals(tbCurrentPassword.Text))
            {
                MessageBox.Show("Current Password Is Wrong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbNewPassword.Text))
            {
                MessageBox.Show("New Password Field Shouldn't Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            if (!tbNewPassword.Text.Equals(tbConfirmPassword.Text))
            {
                MessageBox.Show("Password and Confirm Password Should match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        #endregion
    }
}
