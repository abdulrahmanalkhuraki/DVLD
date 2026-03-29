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
    public partial class ctrlUserCard : UserControl
    {
        public ctrlUserCard()
        {
            InitializeComponent();
            IsPersonEdited = false;
        }

        public void LoadUserInformation(int UserID)
        {
            clsUser user = clsUser.FindUser(UserID);

            if (user == null)
            {
                return;
            }

            ctrlPersonCard1.LoadPersonInformation(user.PersonID);
            lblUserId.Text = user.UserID.ToString();
            lblUsername.Text = user.Username;

            if (user.IsActive)
            {
                lblUserStatus.Text = "Active";
                lblUserStatus.ForeColor = Color.Green;
            }
            else
            {
                lblUserStatus.Text = "Inactive";
                lblUserStatus.ForeColor = Color.Red;
            }

        }

        public bool IsPersonEdited()
        {
            return ctrlPersonCard1.IsPersonEdited;
        }
    }
}
