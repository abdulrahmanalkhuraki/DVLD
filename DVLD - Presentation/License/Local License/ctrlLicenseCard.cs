using DVLD___Business;
using DVLD___Business.Enums;
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

namespace DVLD.License
{
    public partial class ctrlLicenseCard : UserControl
    {
        public clsLicense License { get; private set; }
        public ctrlLicenseCard()
        {
            InitializeComponent();
        }

        public void LoadLicenseInfo(int LicenseId)
        {
            License = clsLicense.FindLicense(LicenseId);

            if (License == null)
            {
                return;
            }

            clsApplication licenseApplication = clsApplication.Find(License.ApplicationID);
            clsPerson licenseOwner = clsPerson.FindPerson(licenseApplication.PersonID);


            lblLicenseClass.Text = clsLicenseClass.FindLicenseClass(License.LicenseClassID).ClassName;
            lblName.Text = licenseOwner.Fullname;
            lblLicenseId.Text = License.LicenseID.ToString();
            lblNationalNumber.Text = licenseOwner.NationalNo;
            lblGender.Text = licenseOwner.Gender ? "Female" : "Male";
            lblIssueDate.Text = License.IssueDate.ToString("yyyy-MM-dd");
            lblIssueReason.Text = ((enIssueReason)License.IssueReason).ToString();
            lblNotes.Text =  string.IsNullOrEmpty(License.Notes)? "No Notes" : License.Notes;
            lblIsActive.Text = License.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = licenseOwner.DateOfBirth.ToString("yyyy-MM-dd");
            lblExpirationDate.Text = License.ExpirationDate.ToString("yyyy-MM-dd");
            lblDriverId.Text = License.DriverID.ToString();
            lblIsDetained.Text = License.IsLicenseDetained() ? "Yes" : "No";
            _LoadPersonPicture(licenseOwner);

        }

        private void _LoadPersonPicture(clsPerson person)
        {
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


    }
}
