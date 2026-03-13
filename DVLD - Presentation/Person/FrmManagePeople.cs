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

namespace DVLD.Person
{
    public partial class FrmManagePeople : Form
    {
        public FrmManagePeople()
        {
            InitializeComponent();
        }

        private void FrmManagePeople_Load(object sender, EventArgs e)
        {
            _LoadPeople();
            cbFilterBy.SelectedIndex = 0;


        }

        private void _LoadPeople()
        {
            DataTable people = clsPerson.GetAllPeople();
            lblRecordsCount.Text = people.Rows.Count.ToString("N0");
            dgvPeople.DataSource = people;
        }


        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            /*
             * Items in cbFilterBy *
             index | property
               0   | select a filter
               1   | Person ID
               2   | National Number
               3   | First Name
               4   | Second Name
               5   | Third Name
               6   | Last Name
               7   | Gender
               8   | Phone
               9   | Email
               10  | Nationality Country
             
             */

            int[] ItemsNeedsTextBox = { 1, 2, 3, 4, 5, 6, 8, 9 };
            int[] ItemsNeedsCombo = { 7, 10 };

            int CurrentSelectedIndex = (sender as ComboBox).SelectedIndex;

            if (ItemsNeedsTextBox.Contains(CurrentSelectedIndex))
            {
                cbUserChoice.Visible = false;
                tbUserInput.Visible = true;
            }
            else if (ItemsNeedsCombo.Contains(CurrentSelectedIndex))
            {
                tbUserInput.Visible = false;
                cbUserChoice.Visible = true;

                if (CurrentSelectedIndex == 7)
                {
                    string[] genders = { "Male", "Female" };
                    cbUserChoice.Items.Clear();
                    cbUserChoice.Items.AddRange(genders);
                    cbUserChoice.SelectedIndex = 0;
                }
                else
                {
                    DataTable dtCountries = clsCountry.GetAllCountries();
                    List<string> Countries = new List<string>();
                    foreach (DataRow Country in dtCountries.Rows)
                    {
                        Countries.Add(Country["CountryName"].ToString());
                    }
                    cbUserChoice.Items.Clear();
                    cbUserChoice.Items.AddRange(Countries.ToArray());
                    cbUserChoice.SelectedIndex = 168;
                }
            }
            else
            {
                tbUserInput.Visible = false;
                cbUserChoice.Visible = false;
                dgvPeople.DataSource = clsPerson.GetAllPeople();
            }
        }

        private void cbUserChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex < 0 || cbUserChoice.SelectedIndex < 0)
                return;

            DataTable peopleData = clsPerson.GetAllPeople();
            DataRow[] filteredData = null;

            if (cbFilterBy.SelectedIndex == 7)
            {
                string gender = cbUserChoice.SelectedIndex == 0 ? "Male" : "Female";
                filteredData = peopleData.Select($"Gender = '{gender}'");
            }
            else if (cbFilterBy.SelectedIndex == 10)
            {
                string nationality = cbUserChoice.Text;
                filteredData = peopleData.Select($"Nationality = '{nationality}'");
            }

            UpdateDataGridView(filteredData);
        }

        private void UpdateDataGridView(DataRow[] filteredData)
        {
            if (filteredData != null && filteredData.Length > 0)
            {
                dgvPeople.DataSource = filteredData.CopyToDataTable();
            }
            else
            {
                DataTable dt = clsPerson.GetAllPeople().Clone();
                dgvPeople.DataSource = dt;
            }
        }

        private void tbUserInput_TextChanged(object sender, EventArgs e)
        {
            /*
             * Items in cbFilterBy *
             index | property
               0   | select a filter
               1   | Person ID
               2   | National Number
               3   | First Name
               4   | Second Name
               5   | Third Name
               6   | Last Name
               7   | Gender
               8   | Phone
               9   | Email
               10  | Nationality Country

             */

            if (cbFilterBy.SelectedIndex < 0 || string.IsNullOrEmpty(tbUserInput.Text))
                return;

            int filterByIndex = cbFilterBy.SelectedIndex;

            DataTable peopleData = clsPerson.GetAllPeople();
            DataRow[] filteredData = null;


            switch (filterByIndex)
            {
                case 1:
                    {
                        filteredData = peopleData.Select($"[Person ID] = {Convert.ToInt16(tbUserInput.Text)}");
                    }
                    break;
                case 2:
                    {
                        filteredData = peopleData.Select($"[National Number] = '{tbUserInput.Text}'");
                    }
                    break;
                case 3:
                    {
                        filteredData = peopleData.Select($"Firstname = '{tbUserInput.Text}'");
                    }
                    break;
                case 4:
                    {
                        filteredData = peopleData.Select($"Secondname = '{tbUserInput.Text}'");
                    }
                    break;
                case 5:
                    {
                        filteredData = peopleData.Select($"Thirdname = '{tbUserInput.Text}'");
                    }
                    break;
                case 6:
                    {
                        filteredData = peopleData.Select($"Lastname = '{tbUserInput.Text}'");
                    }
                    break;
                case 8:
                    {
                        filteredData = peopleData.Select($"Phone = '{tbUserInput.Text}'");
                    }
                    break;
                case 9:
                    {
                        filteredData = peopleData.Select($"Email = '{tbUserInput.Text}'");
                    }
                    break;
            }
            UpdateDataGridView(filteredData);

        }

        private void tbUserInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex != 1)
            {
                return;
            }


            if (!char.IsControl(e.KeyChar))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
