using DVLD___Business.Enums;
using DVLD___Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD___Business
{

    public class clsPerson
    {
        public enMode Mode;
        public int PersonID { get; private set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryId { get; set; }
        public string ImagePath { get; set; }
        public string Fullname
        {
            get
            {
                return FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
            }
        }


        public clsPerson()
        {
            this.PersonID = -1;
            this.NationalNo = string.Empty;
            this.FirstName = string.Empty;
            this.SecondName = string.Empty;
            this.ThirdName = string.Empty;
            this.LastName = string.Empty;
            this.DateOfBirth = DateTime.Now;
            this.Gender = false;
            this.Address = string.Empty;
            this.Phone = string.Empty;
            this.Email = string.Empty;
            this.NationalityCountryId = -1;
            this.ImagePath = string.Empty;
            this.Mode = enMode.ADD;
        }

        private clsPerson(int PersonID, string NationalNo, string FirstName, string SecondName,
                          string ThirdName, string LastName, DateTime DateOfBirth, bool Gender,
                          string Address, string Phone, string Email, int NationalityCountryId,
                          string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryId = NationalityCountryId;
            this.ImagePath = ImagePath;
            this.Mode = enMode.UPDATE;
        }

        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }

        public static clsPerson FindPerson(int PersonId)
        {
            string NationalNo = string.Empty;
            string FirstName = string.Empty;
            string SecondName = string.Empty;
            string ThirdName = string.Empty;
            string LastName = string.Empty;
            DateTime DateOfBirth = DateTime.MinValue;
            bool Gender = false;
            string Address = string.Empty;
            string Phone = string.Empty;
            string Email = string.Empty;
            int NationalityCountryId = -1;
            string ImagePath = string.Empty;

            if (clsPersonData.GetPersonByID(PersonId, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                ref DateOfBirth, ref Gender, ref Address, ref Phone,
                ref Email, ref NationalityCountryId, ref ImagePath))
            {
                return new clsPerson(PersonId, NationalNo, FirstName, SecondName, ThirdName, LastName,
                    DateOfBirth, Gender, Address, Phone, Email, NationalityCountryId, ImagePath);
            }
            else
            {
                return null;
            }
        }

        public static clsPerson FindPerson(String NationalNo)
        {
            int PersonID = -1;
            string FirstName = string.Empty;
            string SecondName = string.Empty;
            string ThirdName = string.Empty;
            string LastName = string.Empty;
            DateTime DateOfBirth = DateTime.MinValue;
            bool Gender = false;
            string Address = string.Empty;
            string Phone = string.Empty;
            string Email = string.Empty;
            int NationalityCountryId = -1;
            string ImagePath = string.Empty;

            if (clsPersonData.GetPersonByNationalNo(NationalNo, ref PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                ref DateOfBirth, ref Gender, ref Address, ref Phone,
                ref Email, ref NationalityCountryId, ref ImagePath))
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                    DateOfBirth, Gender, Address, Phone, Email, NationalityCountryId, ImagePath);
            }
            else
            {
                return null;
            }
        }

        public bool HasLicense(int LicenseClassID)
        {
            return clsPersonData.DoesPersonHasLicense(this.PersonID,LicenseClassID);
        }

        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.ADD:
                    {
                        if (_AddNewPerson())
                        {
                            Mode = enMode.UPDATE;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case enMode.UPDATE:
                    {
                        return _UpdatePerson();
                    }
            }
            return false;
        }

        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(this.PersonID, this.NationalNo, this.FirstName,
                this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth,
                this.Gender, this.Address, this.Phone, this.Email,
                this.NationalityCountryId, this.ImagePath);
        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonData.AddNewPerson(this.NationalNo, this.FirstName,
                this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth,
                this.Gender, this.Address, this.Phone, this.Email,
                this.NationalityCountryId, this.ImagePath);
            return this.PersonID > 0;
        }

        public static bool IsPersonExists(int PersonID)
        {
            return clsPersonData.IsPersonExists(PersonID);
        }

        public static bool IsPersonExists(String NationalNo)
        {
            return clsPersonData.IsPersonExists(NationalNo);
        }

        public static bool DeletePerson(int PersonID)
        {
            if (IsPersonExists(PersonID))
            {
                return clsPersonData.DeletePerson(PersonID);
            }
            else
            {
                return false;
            }
        }

    }
}
