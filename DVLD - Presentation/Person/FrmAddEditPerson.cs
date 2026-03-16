using DVLD___Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Person
{
    public partial class FrmAddEditPerson : Form
    {
        private string PhotosStoragePath = Path.Combine(Application.StartupPath, "People_Photos");
        private string CurrentSavedImagePath = string.Empty;
        private bool IsPersonInfoEdited = false;
        private clsPerson Person;


        public FrmAddEditPerson()
        {
            InitializeComponent();

            if (!Directory.Exists(PhotosStoragePath))
            {
                Directory.CreateDirectory(PhotosStoragePath);
            }

            Person = new clsPerson();
            _ConfigureComponents(Person.Mode);


        }

        public FrmAddEditPerson(int PersonID)
        {
            InitializeComponent();

            if (!Directory.Exists(PhotosStoragePath))
            {
                Directory.CreateDirectory(PhotosStoragePath);
            }

            Person = clsPerson.FindPerson(PersonID);
            _ConfigureComponents(Person.Mode);
        }

        #region Event Handlers

        private void tbNationalNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty((sender as TextBox).Text))
            {
                errorProvider1.SetError(sender as TextBox, "This Field Can't Be Empty");
            }
            else if(!Person.NationalNo.Equals(tbNationalNumber.Text) && clsPerson.IsPersonExists((sender as TextBox).Text))
            {
                errorProvider1.SetError(sender as TextBox, "This National Number Is set For another Person");
            }
            else
            {
                errorProvider1.SetError(sender as TextBox, "");
            }

        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(pbPersonPhoto.Tag)) // check if there is an image
            {
                return;
            }

            if (rbFemale.Checked)
            {
                pbPersonPhoto.Image = Properties.Resources.icons8_person_100;
            }
            else
            {
                pbPersonPhoto.Image = Properties.Resources.icons8_person_100__1_;
            }
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            _ClearForm();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            IsPersonInfoEdited = true;

            if (ofdPersonPhoto.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = ofdPersonPhoto.FileName;

                if (pbPersonPhoto.Image != null)
                {
                    pbPersonPhoto.Image.Dispose();
                    pbPersonPhoto.Image = null;
                }

                using (FileStream fs = new FileStream(selectedFile, FileMode.Open, FileAccess.Read))
                {
                    pbPersonPhoto.Image = Image.FromStream(fs);
                }
                pbPersonPhoto.Tag = true;
                btnClearImage.Visible = true;
            }
        }

        private void btnClearImage_Click(object sender, EventArgs e)
        {
            IsPersonInfoEdited = true;

            if (!Convert.ToBoolean(pbPersonPhoto.Tag))
            {
                return;
            }

            if (pbPersonPhoto.Image != null)
            {
                pbPersonPhoto.Image.Dispose();
                pbPersonPhoto.Image = rbFemale.Checked? Properties.Resources.icons8_person_100
                    : Properties.Resources.icons8_person_100__1_;

            }

            btnClearImage.Visible = false;
            pbPersonPhoto.Tag = false;
        }

        private void btnSaveRecord_Click(object sender, EventArgs e)
        {
            if (!_IsInputValid())
            {
                return;
            }

            Person.NationalNo = tbNationalNumber.Text;
            Person.FirstName = tbFirstname.Text;
            Person.SecondName = tbSecondname.Text;
            Person.ThirdName = tbThirdname.Text;
            Person.LastName = tbLastname.Text;
            Person.Gender = rbFemale.Checked;
            Person.NationalityCountryId = cbCountry.SelectedIndex + 1;
            Person.Email = tbEmail.Text;
            Person.Phone = tbPhone.Text;
            Person.DateOfBirth = dtpDateOfBirth.Value;
            Person.Address = tbAddress.Text;
            _SaveImage();
            if (Person.Save())
            {
                MessageBox.Show("Person Record Has Been Saved Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ClearForm();
            }
        }

        private void _SaveImage()
        {
            if(!Convert.ToBoolean(pbPersonPhoto.Tag))
            {
                return;
            }

            string selectedFile = ofdPersonPhoto.FileName;

            if (!string.IsNullOrEmpty(CurrentSavedImagePath) && File.Exists(CurrentSavedImagePath))
            {
                File.Delete(CurrentSavedImagePath);
            }


            string filename = Guid.NewGuid().ToString()+Path.GetFileName(selectedFile.Substring(selectedFile.Length-4));
            string destinationPath = Path.Combine(PhotosStoragePath, filename);

            File.Copy(selectedFile, destinationPath, true);
            CurrentSavedImagePath = destinationPath;
            Person.ImagePath = CurrentSavedImagePath;
        }

        private void tbFirstname_Enter(object sender, EventArgs e)
        {
            IsPersonInfoEdited = true;
        }

        private void tbFirstname_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty((sender as TextBox).Text))
            {
                errorProvider1.SetError(sender as TextBox, "This Field Can't Be Empty");
            }
            else
            {
                errorProvider1.SetError(sender as TextBox, "");
            }
        }

        #endregion


        #region Helpers

        private void _LoadCountries()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();
            List<string> Countries = new List<string>();
            foreach (DataRow Country in dtCountries.Rows)
            {
                Countries.Add(Country["CountryName"].ToString());
            }
            cbCountry.Items.Clear();
            cbCountry.Items.AddRange(Countries.ToArray());
        }

        private void _ConfigureComponents(enMode Mode)
        {
            _LoadCountries();
            switch (Mode)
            {
                case enMode.ADD:
                    {
                        Text = "Add New Person";
                        btnSaveRecord.Text = "Save Person Record";
                        lblPersonId.Visible = false;
                        label1.Visible = false;
                        btnClearForm.Visible = true;
                        _ClearForm();
                    }
                    break;
                case enMode.UPDATE:
                    {
                        Text = "Edit Person";
                        btnSaveRecord.Text = "Save Changes";
                        lblPersonId.Visible = true;
                        label1.Visible = true;
                        btnClearForm.Visible = false;
                        _LoadPersonInfo();
                    }
                    break;
            }
        }

        private void _LoadPersonInfo()
        {
            lblPersonId.Text = Person.PersonID.ToString();
            tbNationalNumber.Text = Person.NationalNo;
            tbFirstname.Text = Person.FirstName;
            tbSecondname.Text = Person.SecondName;
            tbThirdname.Text = Person.ThirdName;
            tbLastname.Text = Person.LastName;
            rbFemale.Checked = Person.Gender;
            cbCountry.SelectedIndex = Person.NationalityCountryId - 1; // index starts from zero while id starts from one
            tbEmail.Text = Person.Email;
            tbPhone.Text = Person.Phone;
            tbAddress.Text = Person.Address;
            dtpDateOfBirth.Value = Person.DateOfBirth;
            _LoadPersonPhoto(Person.ImagePath);
        }

        private void _ClearForm()
        {
            DateTime MaxDate = DateTime.Now.Subtract(new TimeSpan(6574, 12, 0, 0));
            tbFirstname.Clear();
            tbSecondname.Clear();
            tbThirdname.Clear();
            tbLastname.Clear();
            tbNationalNumber.Clear();
            tbEmail.Clear();
            tbPhone.Clear();
            tbAddress.Clear();
            dtpDateOfBirth.MaxDate = MaxDate;
            dtpDateOfBirth.Value = MaxDate;
            rbMale.Checked = true;
            cbCountry.SelectedIndex = 168; // select Syria

            if (pbPersonPhoto.Image != null)
            {
                pbPersonPhoto.Image.Dispose();
                pbPersonPhoto.Image = rbFemale.Checked ? Properties.Resources.icons8_person_100
                    : Properties.Resources.icons8_person_100__1_;

            }
            btnClearImage.Visible = false;
            pbPersonPhoto.Tag = false;
        }

        private void _LoadPersonPhoto(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
            {
                return;
            }

            using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                pbPersonPhoto.Image = Image.FromStream(fs);
                CurrentSavedImagePath = imagePath;
            }
            pbPersonPhoto.Tag = true;// there is an image 

        }


        private bool _IsInputValid()
        {
            if (!IsPersonInfoEdited)
            {
                if (Person.Mode == enMode.ADD)
                {
                    ErrorMessage("You've Not Entered Any Field Yet.");
                }
                return false;
            }
            if (string.IsNullOrEmpty(tbNationalNumber.Text))
            {
                ErrorMessage("National Number Shouldn't Be Empty.");
                return false;
            }
            if (!Person.NationalNo.Equals(tbNationalNumber.Text) && clsPerson.IsPersonExists(tbNationalNumber.Text))
            {
                ErrorMessage("National Number Is Set By Another Person.");
                return false;
            }
            if (string.IsNullOrEmpty(tbFirstname.Text))
            {
                ErrorMessage("Firstname Shouldn't Be Empty.");
                return false;
            }
            if (string.IsNullOrEmpty(tbSecondname.Text))
            {
                ErrorMessage("Secondname Shouldn't Be Empty.");
                return false;
            }
            if (string.IsNullOrEmpty(tbLastname.Text))
            {
                ErrorMessage("Lastname Shouldn't Be Empty.");
                return false;
            }
            if (string.IsNullOrEmpty(tbPhone.Text))
            {
                ErrorMessage("Phone Shouldn't Be Empty.");
                return false;
            }
            if (string.IsNullOrEmpty(tbAddress.Text))
            {
                ErrorMessage("Address Shouldn't Be Empty.");
                return false;
            }
            if (!string.IsNullOrEmpty(tbEmail.Text))
            {
                if (!IsValidEmail(tbEmail.Text))
                {
                    ErrorMessage("Person Email Unvalid.");
                    return false;
                }
            }
            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void ErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        #endregion


    }
}
