using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Person
{
    public partial class FrmPersonDetails : Form
    {
        private int PersonID;
        public FrmPersonDetails(int PersonID)
        {
            InitializeComponent();
            this.PersonID = PersonID;
        }

        private void FrmPersonDetails_Load(object sender, EventArgs e)
        {
            ctrlPersonCard1.LoadPersonInformation(PersonID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
