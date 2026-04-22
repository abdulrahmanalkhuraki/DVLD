using DVLD___Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD___Business
{
    public class clsInternationalLicense
    {
        private enMode Mode;
        public int InternationalLicenseID { get; private set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUser { get; set; }

        public clsInternationalLicense()
        {
            Mode = enMode.ADD;
            InternationalLicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            IssuedUsingLocalLicenseID = -1;
            IssueDate = DateTime.MinValue;
            ExpirationDate = DateTime.MinValue;
            IsActive = false;
            CreatedByUser = -1;
        }


        private clsInternationalLicense(int InternationalLicenseID, int ApplicationID, int DriverID,
            int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate,
            bool IsActive, int CreatedByUser)
        {
            Mode = enMode.UPDATE;
            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUser = CreatedByUser;
        }

        public static clsInternationalLicense Find(int InternationalLicenseID)
        {
            int applicationId = -1;
            int driverId = -1;
            int issuedUsingLocalLicenseId = -1;
            DateTime issueDate = DateTime.MinValue;
            DateTime expirationDate = DateTime.MinValue;
            bool isActive = false;
            int createdByUser = -1;

            if (clsInternationalLicenseData.GetInternationalLicenseById(InternationalLicenseID, ref applicationId, ref driverId,
                ref issuedUsingLocalLicenseId, ref issueDate, ref expirationDate, ref isActive, ref createdByUser))
            {
                return new clsInternationalLicense(InternationalLicenseID, applicationId, driverId, issuedUsingLocalLicenseId,
                    issueDate, expirationDate, isActive, createdByUser);
            }

            return null;
        }

        public static clsInternationalLicense FindByDriverId(int DriverID)
        {
            int internationalLicenseId = -1;
            int applicationId = -1;
            int issuedUsingLocalLicenseId = -1;
            DateTime issueDate = DateTime.MinValue;
            DateTime expirationDate = DateTime.MinValue;
            bool isActive = false;
            int createdByUser = -1;

            if (clsInternationalLicenseData.GetInternationalLicenseByDriverId(DriverID, ref applicationId, ref internationalLicenseId,
                ref issuedUsingLocalLicenseId, ref issueDate, ref expirationDate, ref isActive, ref createdByUser))
            {
                return new clsInternationalLicense(internationalLicenseId, applicationId, DriverID, issuedUsingLocalLicenseId,
                    issueDate, expirationDate, isActive, createdByUser);
            }

            return null;
        }

        public static DataTable GetAllInternationalLicesnes()
        {
            return clsInternationalLicenseData.GetAllInternationalLicesnes();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.ADD:
                    {
                        if (_AddNewInternationalLicense())
                        {
                            Mode = enMode.UPDATE;
                            return true;
                        }
                        return false;
                    }
                case enMode.UPDATE:
                    return _UpdateInternationalLicense();
                default:
                    return false;
            }
        }

        private bool _UpdateInternationalLicense()
        {
            return clsInternationalLicenseData.UpdateInternationalLicense(
                this.InternationalLicenseID, this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID,
                this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUser);
        }

        private bool _AddNewInternationalLicense()
        {
            int internationalLicenseId = clsInternationalLicenseData.AddNewInternationalLicense(
                this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID,
                this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUser);

            if (internationalLicenseId > 0)
            {
                this.InternationalLicenseID = internationalLicenseId;
                return true;
            }
            return false;
        }

        public static bool Delete(int InterationalLicenseId)
        {
            if (Exists(InterationalLicenseId))
                return clsInternationalLicenseData.DeleteInternationalLicense(InterationalLicenseId);
            return false;
        }

        public static bool Exists(int InterationalLicenseId)
        {
            return clsInternationalLicenseData.IsInternationalLicenseExists(InterationalLicenseId);
        }
    }
}