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
    public partial class ctrlPersonCard : UserControl
    {
        clsPerson person;
        public ctrlPersonCard(int PersonID)
        {
            InitializeComponent();
            person = clsPerson.FindPerson(PersonID);
        }

        private void ctrlPersonCard_Load(object sender, EventArgs e)
        {
            _LoadPersonInformation();
        }

        private void _LoadPersonInformation()
        {
            lblPersonId.Text = person.PersonID.ToString();
            lblNationalNumber.Text = person.NationalNo;
            lblName.Text = person.Fullname;
            lblEmail.Text = string.IsNullOrEmpty(person.Email)? "Unknown" : person.Email;
            lblPhone.Text = person.Phone;
            lblAddress.Text = person.Address;
            lblDateOfBirth.Text = person.DateOfBirth.ToString("f");
            lblCountry.Text = clsCountry.FindCountry(person.NationalityCountryId).CountryName;
        }
    }
}
