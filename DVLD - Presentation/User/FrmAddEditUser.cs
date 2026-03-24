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
    public partial class FrmAddEditUser : Form
    {
        public clsUser User {  get; set; }

        public FrmAddEditUser()
        {
            InitializeComponent();
            User = new clsUser();
            _ConfigureComponents(User.Mode);
        }

        public FrmAddEditUser(int UserID)
        {
            InitializeComponent();
            User = clsUser.FindUser(UserID);
            _ConfigureComponents(User.Mode);
        }

        #region Event Handlers

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void btnBack_Click(object sender, EventArgs e) => tabControl1.SelectTab(0);

        private void btnNext_Click(object sender, EventArgs e) => tabControl1.SelectTab(1);

        private void tbUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbUsername.Text))
            {
                errorProvider1.SetError(tbUsername, "This Field Can't be Empty.");
            }
            else if (clsUser.FindUser(tbUsername.Text) != null) // Is this username used before
            {
                errorProvider1.SetError(tbUsername, "Sorry, This Username Is Used Before.");
            }
            else
            {
                errorProvider1.SetError(tbUsername, string.Empty);
            }
        }

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                errorProvider1.SetError(tbPassword, "This Field Can't be Empty.");
            }
            else
            {
                errorProvider1.SetError(tbPassword, string.Empty);
            }
        }

        private void tbConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!tbPassword.Text.Equals(tbConfirmPassword.Text))
            {
                errorProvider1.SetError(tbConfirmPassword, "Password and confirm password doesn't match.");
            }
            else
            {
                errorProvider1.SetError(tbConfirmPassword, string.Empty);
            }
        }

        private void btnSaveRecord_Click(object sender, EventArgs e)
        {
            if (!_AreInputsValid())
            {
                return;
            }

            User.Username = tbUsername.Text;
            User.Password = tbPassword.Text;
            User.IsActive = rbActive.Checked;

            if (User.Save())
            {
                
                MessageBox.Show("User Has Been Saved Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ConfigureComponents(User.Mode);
            }
            else
            {
                MessageBox.Show("Error With Saving User.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int PersonID)
        {
            if (clsUser.IsPersonConnectedToUser(PersonID))
            {
                MessageBox.Show("This Person Is Already A User in the System!","Conflict",MessageBoxButtons.OK, MessageBoxIcon.Information);
                User.PersonID = -2;
                return;
            }

            User.PersonID = PersonID;
            btnNext.Enabled = true;
        }

        #endregion

        #region Helpers
        private void _ConfigureComponents(enMode Mode)
        {
            switch (Mode)
            {
                case enMode.ADD:
                    {
                        Text = "Add New User";

                        lblUserId.Text = "Unknown";
                        lblPassword.Visible = true;
                        lblConfirmPassword.Visible = true;

                        tbUsername.Clear();
                        tbPassword.Visible = true;
                        tbPassword.Clear();
                        tbConfirmPassword.Visible = true;
                        tbConfirmPassword.Clear();

                        gbStatus.Location = new Point(177, 255);
                        lblStatus.Location = new Point(52, 267);

                        rbActive.Checked = true;

                        btnNext.Enabled = false;
                        btnSaveRecord.Text = "Save User Record";
                    }
                    break;
                case enMode.UPDATE:
                    {
                        Text = "Edit User";

                        tbPassword.Clear();
                        tbPassword.Visible = false;
                        tbConfirmPassword.Clear();
                        tbConfirmPassword.Visible = false;

                        lblPassword.Visible = false;
                        lblConfirmPassword.Visible = false;

                        gbStatus.Location = new Point(177, 190);
                        lblStatus.Location = new Point(52, 200);

                        btnNext.Enabled = true;
                        btnSaveRecord.Text = "Save Changes";
                        _LoadUserInfo();
                    }
                    break;
            }
        }

        private void _LoadUserInfo()
        {
            if (User == null)
                return;
            lblUserId.Text = User.UserID.ToString();
            ctrlPersonCardWithFilter1.LoadPerson(User.PersonID);
            tbUsername.Text = User.Username;
            rbActive.Checked = User.IsActive;
            rbInActive.Checked = !User.IsActive;
        }

        private bool _AreInputsValid()
        {
            if (User.PersonID == -1)
            {
                MessageBox.Show("You Should Select A Person To Connect her/him with this User.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (User.PersonID == -2)
            {
                MessageBox.Show("The Person You Selected Is Already A User In the System, Try Select Another Person.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(tbUsername.Text))
            {
                MessageBox.Show("Username Shouldn't be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (clsUser.IsUserExists(tbUsername.Text) && !User.Username.Equals(tbUsername.Text))
            {
                MessageBox.Show("Sorry, This Username is used Before.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (User.Mode == enMode.ADD)
            {
                if (string.IsNullOrWhiteSpace(tbPassword.Text))
                {
                    MessageBox.Show("Password Shouldn't be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (!tbPassword.Text.Equals(tbConfirmPassword.Text))
                {
                    MessageBox.Show("Password and confirm password doesn't match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }
        #endregion

    }
}
