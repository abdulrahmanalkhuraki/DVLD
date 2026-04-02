using DVLD___Data_Access;
using System;

namespace DVLD___Business
{
    public class clsDetainedLicense
    {
        public enMode Mode;

        public int DetainID { get; private set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleasedByUserID { get; set; }
        public int ReleaseApplicationID { get; set; }

        // Constructors
        public clsDetainedLicense()
        {
            this.DetainID = -1;
            this.LicenseID = -1;
            this.DetainDate = DateTime.Now;
            this.FineFees = 0;
            this.CreatedByUserID = -1;
            this.IsReleased = false;
            this.ReleaseDate = DateTime.MinValue;
            this.ReleasedByUserID = -1;
            this.ReleaseApplicationID = -1;
            this.Mode = enMode.ADD;
        }

        private clsDetainedLicense(int DetainID, int LicenseID, DateTime DetainDate, decimal FineFees,
                                   int CreatedByUserID, bool IsReleased, DateTime ReleaseDate,
                                   int ReleasedByUserID, int ReleaseApplicationID)
        {
            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsReleased = IsReleased;
            this.ReleaseDate = ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;
            this.Mode = enMode.UPDATE;
        }

        // Static methods
        public static clsDetainedLicense FindDetainedLicenseByLicenseID(int LicenseID)
        {
            int DetainID = -1, CreatedByUserID = -1, ReleasedByUserID = -1, ReleaseApplicationID = -1;
            DateTime DetainDate = DateTime.MinValue, ReleaseDate = DateTime.MinValue;
            decimal FineFees = 0;
            bool IsReleased = false;

            if (clsDetainedLicenseData.GetDetainedLicenseByLicenseID(LicenseID, ref DetainID, ref DetainDate,
                ref FineFees, ref CreatedByUserID, ref IsReleased, ref ReleaseDate,
                ref ReleasedByUserID, ref ReleaseApplicationID))
            {
                return new clsDetainedLicense(DetainID, LicenseID, DetainDate, FineFees,
                    CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            }
            return null;
        }

        public static clsDetainedLicense FindDetainedLicenseByDetainID(int DetainID)
        {
            int LicenseID = -1, CreatedByUserID = -1, ReleasedByUserID = -1, ReleaseApplicationID = -1;
            DateTime DetainDate = DateTime.MinValue, ReleaseDate = DateTime.MinValue;
            decimal FineFees = 0;
            bool IsReleased = false;

            if (clsDetainedLicenseData.GetDetainedLicenseByDetainID(DetainID, ref LicenseID, ref DetainDate,
                ref FineFees, ref CreatedByUserID, ref IsReleased, ref ReleaseDate,
                ref ReleasedByUserID, ref ReleaseApplicationID))
            {
                return new clsDetainedLicense(DetainID, LicenseID, DetainDate, FineFees,
                    CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            }
            return null;
        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            return clsDetainedLicenseData.IsLicenseDetained(LicenseID);
        }

        // Instance methods
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.ADD:
                    if (_AddNewDetainedLicense())
                    {
                        Mode = enMode.UPDATE;
                        return true;
                    }
                    return false;
                case enMode.UPDATE:
                    return _UpdateDetainedLicense();
                default:
                    return false;
            }
        }

        private bool _AddNewDetainedLicense()
        {
            this.DetainID = clsDetainedLicenseData.AddNewDetainedLicense(this.LicenseID, this.DetainDate,
                this.FineFees, this.CreatedByUserID, this.IsReleased, this.ReleaseDate,
                this.ReleasedByUserID, this.ReleaseApplicationID);
            return this.DetainID > 0;
        }

        private bool _UpdateDetainedLicense()
        {
            return clsDetainedLicenseData.UpdateDetainedLicense(this.DetainID, this.LicenseID, this.DetainDate,
                this.FineFees, this.CreatedByUserID, this.IsReleased, this.ReleaseDate,
                this.ReleasedByUserID, this.ReleaseApplicationID);
        }
    }
}