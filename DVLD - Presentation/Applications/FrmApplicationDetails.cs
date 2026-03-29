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

namespace DVLD.Applications
{
    public partial class FrmApplicationDetails : Form
    {
        private int ApplicationID;
        public FrmApplicationDetails(int ApplicationID)
        {
            InitializeComponent();
            this.ApplicationID = ApplicationID;
        }

        private void FrmApplicationDetails_Load(object sender, EventArgs e)
        {
            ctrlApplicationCard1.LoadApplication(ApplicationID);
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

    }
}
