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

namespace DVLD.Person
{
    public partial class ctrlPersonCard : UserControl
    {
        public clsPerson person { get; set; }

        public ctrlPersonCard()
        {
            InitializeComponent();
            person = new clsPerson();
        }

        #region Event Handlers

        private void lnklblEditInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int personId;
            if(!int.TryParse(lblPersonId.Text, out personId))
            {
                MessageBox.Show("No Person Information To Edit.","Faild",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            FrmAddEditPerson updateForm = new FrmAddEditPerson(personId);
            updateForm.ShowDialog();
            LoadPersonInformation(personId);
        }

        #endregion

        #region Helpers

        public void LoadPersonInformation(int PersonID)
        {
            if (PersonID <= 0)
                return;

            person = clsPerson.FindPerson(PersonID);

            lblPersonId.Text = person.PersonID.ToString();
            lblNationalNumber.Text = person.NationalNo;
            lblName.Text = person.Fullname;
            lblEmail.Text = string.IsNullOrEmpty(person.Email)? "Unknown" : person.Email;
            lblPhone.Text = person.Phone;
            lblAddress.Text = person.Address;
            lblDateOfBirth.Text = person.DateOfBirth.ToString("yyyy-MM-dd");
            lblCountry.Text = clsCountry.FindCountry(person.NationalityCountryId).CountryName;
            // loading Gender
            if(person.Gender)
            {
                lblGender.Text = "Female";
            }
            else
            {
                lblGender.Text = "Male";
            }
            // loading person picture
            if (!string.IsNullOrEmpty(person.ImagePath))
            {
                using (FileStream fs = new FileStream(person.ImagePath, FileMode.Open, FileAccess.Read))
                {
                    pbPersonPicture.Image = System.Drawing.Image.FromStream(fs);
                }
            }
            else
            {
                if (person.Gender)
                    pbPersonPicture.Image = Properties.Resources.icons8_person_100;
                else
                    pbPersonPicture.Image = Properties.Resources.icons8_person_100__1_;
            }
        }

        #endregion
    }
}
