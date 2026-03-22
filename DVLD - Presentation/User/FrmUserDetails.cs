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
    public partial class FrmUserDetails : Form
    {
        private clsUser User;

        public FrmUserDetails(int UserId)
        {
            InitializeComponent();
            this.User = clsUser.FindUser(UserId);
        }

        private void FrmUserDetails_Load(object sender, EventArgs e)
        {
            if (User != null)
            {
                ctrlUserCard1.LoadUserInformation(User.UserID);
            }
        }
    }
}
