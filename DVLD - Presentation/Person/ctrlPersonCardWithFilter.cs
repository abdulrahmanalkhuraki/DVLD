using DVLD___Business;
using System;
using System.Windows.Forms;

namespace DVLD.Person
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public event Action<int> OnPersonSelected;

        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(PersonID);
            }
        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            string[] SearchByItems = new string[] { "Person ID", "National No." };
            cbSearchBy.Items.Clear();
            cbSearchBy.Items.AddRange(SearchByItems);
            cbSearchBy.SelectedIndex = 1;
        }

        private void tbSearchText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbSearchBy.SelectedIndex == 1)
                return;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbSearchText.Text))
            {
                MessageBox.Show("Person Not Found.", "Search Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool IsPersonFound = false;
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
                                    IsPersonFound = true;
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
                                IsPersonFound = true;
                            }
                            else
                            {
                                MessageBox.Show("Person Not Found.", "Search Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        break;

                }

                if (OnPersonSelected != null && IsPersonFound)
                {
                    OnPersonSelected(ctrlPersonCard1.person.PersonID);
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

                if (OnPersonSelected != null)
                {
                    OnPersonSelected(ctrlPersonCard1.person.PersonID);
                }
            }
        }

        public void LoadPerson(int PersonID)
        {
            ctrlPersonCard1.LoadPersonInformation(PersonID);

            if (OnPersonSelected != null)
            {
                OnPersonSelected(ctrlPersonCard1.person.PersonID);
            }

            if (cbSearchBy.SelectedIndex == 1) 
                cbSearchBy.SelectedIndex = 0;
            tbSearchText.Text = PersonID.ToString();
        }
    }
}
