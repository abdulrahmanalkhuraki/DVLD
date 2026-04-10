using DVLD___Business.Enums;
using DVLD___Data_Access;
using System;
using System.Data;

namespace DVLD___Business
{
    public class clsLicense
    {
        public enMode Mode;

        public int LicenseID { get; private set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClassID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public int IssueReason { get; set; }
        public int CreatedByUserID { get; set; }

        // Read-only properties
        public string LicenseClassName
        {
            get
            {
                switch (LicenseClassID)
                {
                    case 1: return "Motorcycle";
                    case 2: return "Motorcycle with Sidecar";
                    case 3: return "Passenger Car";
                    case 4: return "Truck";
                    case 5: return "Bus";
                    case 6: return "Heavy Vehicle";
                    case 7: return "Forklift";
                    case 8: return "Trailer";
                    case 9: return "Public Transport";
                    case 10: return "Private Transport";
                    default: return "Unknown";
                }
            }
        }

        public string IssueReasonName
        {
            get
            {
                switch (IssueReason)
                {
                    case 1: return "First Time";
                    case 2: return "Renew";
                    case 3: return "Replacement For Lost";
                    case 4: return "Replacement For Damaged";
                    default: return "Unknown";
                }
            }
        }

        public bool IsExpired => DateTime.Now > ExpirationDate;

        public int RemainingDaysUntilExpiration => IsExpired ? 0 : (ExpirationDate - DateTime.Now).Days;

        // Constructors
        public clsLicense()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClassID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = string.Empty;
            this.PaidFees = 0;
            this.IsActive = false;
            this.IssueReason = (int)enIssueReason.FirstTime;
            this.CreatedByUserID = -1;
            this.Mode = enMode.ADD;
        }

        private clsLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClass,
                           DateTime IssueDate, DateTime ExpirationDate, string Notes,
                           decimal PaidFees, bool IsActive, int IssueReason, int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClassID = LicenseClass;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;
            this.Mode = enMode.UPDATE;
        }

        // Static methods
        public static DataTable GetAllLicenses()
        {
            return clsLicenseData.GetAllLicenses();
        }

        public static DataTable GetLicensesByDriverID(int DriverID)
        {
            return clsLicenseData.GetLicensesByDriverID(DriverID);
        }

        public static DataTable GetActiveLicensesByDriverID(int DriverID)
        {
            return clsLicenseData.GetActiveLicensesByDriverID(DriverID);
        }

        public static clsLicense FindLicense(int LicenseID)
        {
            int ApplicationID = -1, DriverID = -1, LicenseClass = -1, IssueReason = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.MinValue, ExpirationDate = DateTime.MinValue;
            string Notes = string.Empty;
            decimal PaidFees = 0;
            bool IsActive = false;

            if (clsLicenseData.GetLicenseByID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClass,
                ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees,
                ref IsActive, ref IssueReason, ref CreatedByUserID))
            {
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClass,
                    IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            }
            return null;
        }

        public static clsLicense FindLicenseByApplicationID(int ApplicationID)
        {
            int LicenseID = -1, DriverID = -1, LicenseClass = -1, IssueReason = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.MinValue, ExpirationDate = DateTime.MinValue;
            string Notes = string.Empty;
            decimal PaidFees = 0;
            bool IsActive = false;

            if (clsLicenseData.GetLicenseByApplicationID(ApplicationID, ref LicenseID, ref DriverID, ref LicenseClass,
                ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees,
                ref IsActive, ref IssueReason, ref CreatedByUserID))
            {
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClass,
                    IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            }
            return null;
        }

        public static bool IsLicenseExists(int LicenseID)
        {
            return clsLicenseData.IsLicenseExists(LicenseID);
        }

        public static bool IsLicenseExistsByApplicationID(int ApplicationID)
        {
            return clsLicenseData.IsLicenseExistsByApplicationID(ApplicationID);
        }

        public static bool DeleteLicense(int LicenseID)
        {
            if (IsLicenseExists(LicenseID))
                return clsLicenseData.DeleteLicense(LicenseID);
            return false;
        }

        // Instance methods
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.ADD:
                    if (_AddNewLicense())
                    {
                        Mode = enMode.UPDATE;
                        return true;
                    }
                    return false;
                case enMode.UPDATE:
                    return _UpdateLicense();
                default:
                    return false;
            }
        }

        private bool _AddNewLicense()
        {
            this.LicenseID = clsLicenseData.AddNewLicense(this.ApplicationID, this.DriverID,
                this.LicenseClassID, this.IssueDate, this.ExpirationDate, this.Notes,
                this.PaidFees, this.IsActive, this.IssueReason, this.CreatedByUserID);
            return this.LicenseID > 0;
        }

        private bool _UpdateLicense()
        {
            return clsLicenseData.UpdateLicense(this.LicenseID, this.ApplicationID, this.DriverID,
                this.LicenseClassID, this.IssueDate, this.ExpirationDate, this.Notes,
                this.PaidFees, this.IsActive, this.IssueReason, this.CreatedByUserID);
        }

        public bool IsLicenseDetained()
        {
            return clsDetainedLicenseData.IsLicenseDetained(this.LicenseID);
        }

        public clsDetainedLicense GetDetainInfo()
        {
            return clsDetainedLicense.FindDetainedLicenseByLicenseID(this.LicenseID);
        }

        public bool DetainLicense(decimal FineFees, int CreatedByUserID)
        {
            if (IsLicenseDetained())
            {
                this.Notes = "License is already detained!";
                return false;
            }
            if (!this.IsActive)
            {
                this.Notes = "Cannot detain an inactive license!";
                return false;
            }

            clsDetainedLicense detained = new clsDetainedLicense();
            detained.LicenseID = this.LicenseID;
            detained.DetainDate = DateTime.Now;
            detained.FineFees = FineFees;
            detained.CreatedByUserID = CreatedByUserID;
            detained.IsReleased = false;
            detained.ReleaseDate = DateTime.MinValue;
            detained.ReleasedByUserID = -1;
            detained.ReleaseApplicationID = -1;

            if (detained.Save())
            {
                this.IsActive = false;
                return this.Save();
            }
            return false;
        }

        public bool ReleaseLicense(int ReleasedByUserID, int ReleaseApplicationID)
        {
            clsDetainedLicense detained = clsDetainedLicense.FindDetainedLicenseByLicenseID(this.LicenseID);
            if (detained == null || detained.IsReleased)
                return false;

            detained.IsReleased = true;
            detained.ReleaseDate = DateTime.Now;
            detained.ReleasedByUserID = ReleasedByUserID;
            detained.ReleaseApplicationID = ReleaseApplicationID;

            if (detained.Save())
            {
                this.IsActive = true;
                return this.Save();
            }
            return false;
        }

        public bool RenewLicense(int NewCreatedByUserID)
        {
            this.IsActive = false;
            if (!this.Save())
                return false;

            clsLicense newLicense = new clsLicense();
            newLicense.ApplicationID = this.ApplicationID;
            newLicense.DriverID = this.DriverID;
            newLicense.LicenseClassID = this.LicenseClassID;
            newLicense.IssueDate = DateTime.Now;
            newLicense.ExpirationDate = DateTime.Now.AddYears(10);
            newLicense.Notes = "Renewed from license ID: " + this.LicenseID;
            newLicense.PaidFees = this.PaidFees;
            newLicense.IsActive = true;
            newLicense.IssueReason = (int)enIssueReason.Renew;
            newLicense.CreatedByUserID = NewCreatedByUserID;

            return newLicense.Save();
        }

        public bool ReplaceLicense(int NewCreatedByUserID, enIssueReason ReplaceReason)
        {
            this.IsActive = false;
            if (!this.Save())
                return false;

            clsLicense newLicense = new clsLicense();
            newLicense.ApplicationID = this.ApplicationID;
            newLicense.DriverID = this.DriverID;
            newLicense.LicenseClassID = this.LicenseClassID;
            newLicense.IssueDate = DateTime.Now;
            newLicense.ExpirationDate = this.ExpirationDate;
            newLicense.Notes = $"Replaced due to: {ReplaceReason.ToString()} from license ID: {this.LicenseID}";
            newLicense.PaidFees = this.PaidFees;
            newLicense.IsActive = true;
            newLicense.IssueReason = (int)ReplaceReason;
            newLicense.CreatedByUserID = NewCreatedByUserID;

            return newLicense.Save();
        }
    }
}