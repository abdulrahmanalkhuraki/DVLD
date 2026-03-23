using DVLD___Business;
using System;
using System.Windows.Forms;

namespace DVLD.Person
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            string[] SearchByItems = new string[] { "Person ID", "National No." };
            cbSearchBy.Items.Clear();
            cbSearchBy.Items.AddRange(SearchByItems);
            cbSearchBy.SelectedIndex = 0;
        }

        private void cbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearchBy.SelectedIndex == 0)
            {
                tbSearchText.KeyPress += tbSearchText_KeyPress;
            }
            else
            {
                tbSearchText.KeyPress -= tbSearchText_KeyPress;
            }
        }

        private void tbSearchText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbSearchText.Text))
            {
                MessageBox.Show("Person Not Found.", "Search Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                switch (cbSearchBy.SelectedIndex)
                {
                    case 0: // Person ID
                        {
                            if (int.TryParse(tbSearchText.Text, out int PersonID))
                            {
                                clsPerson Person = clsPerson.FindPerson(PersonID);
                                if (Person != null)
                                {
                                    ctrlPersonCard1.LoadPersonInformation(Person.PersonID);
                                }
                                else
                                {
                                    MessageBox.Show("Person Not Found.", "Search Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        break;
                    case 1: // National No.
                        {
                            clsPerson Person = clsPerson.FindPerson(tbSearchText.Text);
                            if (Person != null)
                            {
                                ctrlPersonCard1.LoadPersonInformation(Person.PersonID);
                            }
                            else
                            {
                                MessageBox.Show("Person Not Found.", "Search Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        break;
                }
            }

        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            FrmAddEditPerson frm = new FrmAddEditPerson();
            frm.DataBack += FrmAddEditPerson_DataBack;
            frm.ShowDialog();
        }

        private void FrmAddEditPerson_DataBack(object sender, int PersonID)
        {
            if (PersonID > 0)
            {
                ctrlPersonCard1.LoadPersonInformation(PersonID);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
