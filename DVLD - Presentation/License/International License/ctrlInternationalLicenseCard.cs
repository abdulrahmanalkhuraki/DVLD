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

namespace DVLD.License.International_License
{
    public partial class ctrlInternationalLicenseCard : UserControl
    {
        clsInternationalLicense License { get; set; }
        public ctrlInternationalLicenseCard()
        {
            InitializeComponent();
        }
        public void LoadLicenseInfo(int LicenseId)
        {
            License = clsInternationalLicense.Find(LicenseId);

            if (License == null)
            {
                return;
            }

            clsApplication licenseApplication = clsApplication.Find(License.ApplicationID);
            clsPerson licenseOwner = clsPerson.FindPerson(licenseApplication.PersonID);


            lblName.Text = licenseOwner.Fullname;
            lblInternationalLicenseID.Text = License.InternationalLicenseID.ToString();
            lblLicenseId.Text = License.IssuedUsingLocalLicenseID.ToString();
            lblNationalNumber.Text = licenseOwner.NationalNo;
            lblGender.Text = licenseOwner.Gender ? "Female" : "Male";
            lblIssueDate.Text = License.IssueDate.ToString("yyyy-MM-dd");
            lblExpirationDate.Text = License.ExpirationDate.ToString("yyyy-MM-dd");
            lblIsActive.Text = License.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = licenseOwner.DateOfBirth.ToString("yyyy-MM-dd");
            lblDriverId.Text = License.DriverID.ToString();
            lblApplicationID.Text = License.ApplicationID.ToString();
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
