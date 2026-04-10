using DVLD___Data_Access;
using System;
using System.Data;

namespace DVLD___Business
{
    public class clsDriver
    {
        public enMode Mode;
        public int DriverID { get; private set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public clsPerson PersonInfo { get; private set; }

        // Constructors
        public clsDriver()
        {
            this.DriverID = -1;
            this.PersonID = -1;
            this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.Now;
            this.PersonInfo = null;
            this.Mode = enMode.ADD;
        }

        private clsDriver(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
            this.PersonInfo = clsPerson.FindPerson(PersonID);
            this.Mode = enMode.UPDATE;
        }

        // Static methods
        public static DataTable GetAllDrivers()
        {
            return clsDriverData.GetAllDrivers();
        }

        public static DataTable GetDriversWithPersonInfo()
        {
            return clsDriverData.GetDriversWithPersonInfo();
        }

        public static clsDriver FindDriver(int DriverID)
        {
            int PersonID = -1, CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.MinValue;

            if (clsDriverData.GetDriverByID(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate))
            {
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            }
            return null;
        }

        public static clsDriver FindDriverByPersonID(int PersonID)
        {
            int DriverID = -1, CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.MinValue;

            if (clsDriverData.GetDriverByPersonID(PersonID, ref DriverID, ref CreatedByUserID, ref CreatedDate))
            {
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            }
            return null;
        }

        public static bool IsDriverExists(int DriverID)
        {
            return clsDriverData.IsDriverExists(DriverID);
        }

        public static bool IsDriverExistsByPersonID(int PersonID)
        {
            return clsDriverData.IsDriverExistsByPersonID(PersonID);
        }

        public static bool DeleteDriver(int DriverID)
        {
            if (IsDriverExists(DriverID))
                return clsDriverData.DeleteDriver(DriverID);
            return false;
        }

        // Instance methods
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.ADD:
                    if (_AddNewDriver())
                    {
                        Mode = enMode.UPDATE;
                        return true;
                    }
                    return false;
                case enMode.UPDATE:
                    return _UpdateDriver();
                default:
                    return false;
            }
        }

        private bool _AddNewDriver()
        {
            this.DriverID = clsDriverData.AddNewDriver(this.PersonID, this.CreatedByUserID, this.CreatedDate);
            if (this.DriverID > 0)
            {
                // Load person info after successful add
                this.PersonInfo = clsPerson.FindPerson(this.PersonID);
                return true;
            }
            return false;
        }

        private bool _UpdateDriver()
        {
            return clsDriverData.UpdateDriver(this.DriverID, this.PersonID, this.CreatedByUserID, this.CreatedDate);
        }

        // Utility methods
        public DataTable GetDriverLicenses()
        {
            return clsLicenseData.GetLicensesByDriverID(this.DriverID);
        }

        public DataTable GetDriverActiveLicenses()
        {
            return clsLicenseData.GetActiveLicensesByDriverID(this.DriverID);
        }

        public int GetNumberOfActiveLicenses()
        {
            DataTable dt = GetDriverActiveLicenses();
            return dt == null ? 0 : dt.Rows.Count;
        }

        public bool HasActiveLicenseOfClass(int LicenseClass)
        {
            DataTable dt = GetDriverActiveLicenses();
            if (dt == null) return false;
            foreach (DataRow row in dt.Rows)
            {
                if ((int)row["LicenseClassID"] == LicenseClass)
                    return true;
            }
            return false;
        }
    }
}