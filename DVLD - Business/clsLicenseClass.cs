using DVLD___Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD___Business
{
    public class clsLicenseClass
    {
        public enum enMode
        {
            ADD,
            UPDATE
        }

        public enMode Mode;
        public int LicenseClassID { get; private set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public int MinimumAllowedAge { get; set; }
        public int DefaultValidityLength { get; set; }
        public decimal ClassFees { get; set; }

        public clsLicenseClass()
        {
            this.LicenseClassID = -1;
            this.ClassName = string.Empty;
            this.ClassDescription = string.Empty;
            this.MinimumAllowedAge = 0;
            this.DefaultValidityLength = 0;
            this.ClassFees = 0;
            this.Mode = enMode.ADD;
        }

        private clsLicenseClass(int LicenseClassID, string ClassName, string ClassDescription,
                                int MinimumAllowedAge, int DefaultValidityLength, decimal ClassFees)
        {
            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;
            this.Mode = enMode.UPDATE;
        }

        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassData.GetAllLicenseClasses();
        }

        public static clsLicenseClass FindLicenseClass(int LicenseClassID)
        {
            string ClassName = string.Empty;
            string ClassDescription = string.Empty;
            int MinimumAllowedAge = 0;
            int DefaultValidityLength = 0;
            decimal ClassFees = 0;

            if (clsLicenseClassData.GetLicenseClassByID(LicenseClassID, ref ClassName, ref ClassDescription,
                ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))
            {
                return new clsLicenseClass(LicenseClassID, ClassName, ClassDescription,
                                           MinimumAllowedAge, DefaultValidityLength, ClassFees);
            }
            else
            {
                return null;
            }
        }

        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.ADD:
                    {
                        if (_AddNewLicenseClass())
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
                        return _UpdateLicenseClass();
                    }
            }
            return false;
        }

        private bool _UpdateLicenseClass()
        {
            return clsLicenseClassData.UpdateLicenseClass(this.LicenseClassID, this.ClassName, this.ClassDescription,
                this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);
        }

        private bool _AddNewLicenseClass()
        {
            this.LicenseClassID = clsLicenseClassData.AddNewLicenseClass(this.ClassName, this.ClassDescription,
                this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);
            return this.LicenseClassID > 0;
        }

        public static bool IsLicenseClassExists(int LicenseClassID)
        {
            return clsLicenseClassData.IsLicenseClassExists(LicenseClassID);
        }

        public static bool DeleteLicenseClass(int LicenseClassID)
        {
            if (IsLicenseClassExists(LicenseClassID))
            {
                return clsLicenseClassData.DeleteLicenseClass(LicenseClassID);
            }
            else
            {
                return false;
            }
        }
    }
}
