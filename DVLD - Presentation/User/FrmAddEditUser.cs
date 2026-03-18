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
        private int userId;

        public FrmAddEditUser()
        {
            InitializeComponent();
        }

        public FrmAddEditUser(int userId)
        {
            this.userId = userId;
        }
    }
}
