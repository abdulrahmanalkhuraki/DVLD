using DVLD___Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLD.User
{
    public partial class FrmLogin : Form
    {
        private string RememberMeFilePath = Path.Combine(Application.StartupPath, "RememberMe.txt");
        public FrmLogin()
        {
            InitializeComponent();
        }

        #region Event Handlers
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(RememberMeFilePath))
                    return;

                string content = File.ReadAllText(RememberMeFilePath);

                if (string.IsNullOrWhiteSpace(content))
                    return;

                string[] credentials = content.Split(',');


                if (credentials.Length >= 2)
                {
                    tbUsername.Text = credentials[0]?.Trim() ?? string.Empty;
                    tbPassword.Text = credentials[1]?.Trim() ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}",
                    "Remember Me", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!_IsCredentialsValid())
            {
                MessageBox.Show("Invalid Username or Password!", "Authentication Faild"
                    , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (!_IsUserActive())
            {
                MessageBox.Show("Your Account is Deactivated, Try Contact The Administrator", "Authentication Faild"
                    , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (chkRememberMe.Checked)
            {
                _SaveRememberMeCredentials();
            }
            else
            {
                _ClearRememberMeCredentials();
            }

                DialogResult = DialogResult.OK;
            Close();
        }

        #endregion

        #region Helpers
        private void _ClearRememberMeCredentials()
        {

            if (!File.Exists(RememberMeFilePath))
            {
                return;
            }

            try
            {
                File.Delete(RememberMeFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to clear saved credentials: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void _SaveRememberMeCredentials()
        {
            if (string.IsNullOrWhiteSpace(tbUsername.Text) ||
                string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                return;
            }

            try
            {
                string username = tbUsername.Text.Trim();
                string password = tbPassword.Text.Trim();
                string credentials = $"{username},{password}";

                File.WriteAllText(RememberMeFilePath, credentials);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to save your credentials: {ex.Message}",
                    "Unsaved Credentials", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool _IsUserActive()
        {
            clsUser user = clsUser.FindUser(tbUsername.Text);

            if (user != null && user.IsActive)
            {
                return true;
            }

            return false;
        }

        private bool _IsCredentialsValid()
        {
            clsUser user = clsUser.FindUser(tbUsername.Text);

            if (user != null && user.Password == tbPassword.Text)
            {
                return true;
            }

            return false;
        }
        #endregion

    }
}
