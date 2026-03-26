using DVLD___Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD___Business
{
    public class clsApplication
    {
        public enMode Mode;
        public int ApplicationID { get; private set; }
        public int PersonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public enApplicationStatus ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }

        public clsApplication()
        {
            this.ApplicationID = -1;
            this.PersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = enApplicationStatus.New;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            this.Mode = enMode.ADD;
        }

        private clsApplication(int ApplicationID, int PersonID, DateTime ApplicationDate, int ApplicationTypeID,
                               enApplicationStatus ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.PersonID = PersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.Mode = enMode.UPDATE;
        }

        public static DataTable GetAllApplication()
        {
            return clsApplicationData.GetAllApplications();
        }

        public static clsApplication FindApplication(int ApplicationID)
        {
            int PersonID = -1;
            DateTime ApplicationDate = DateTime.MinValue;
            int ApplicationTypeID = -1;
            byte ApplicationStatus = 0;
            DateTime LastStatusDate = DateTime.MinValue;
            decimal PaidFees = 0;
            int CreatedByUserID = -1;

            if (clsApplicationData.GetApplicationByID(ApplicationID, ref PersonID, ref ApplicationDate, ref ApplicationTypeID,
                ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
            {
                return new clsApplication(ApplicationID, PersonID, ApplicationDate, ApplicationTypeID,
                                          (enApplicationStatus)ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
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
                        if (_AddNewApplication())
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
                        return _UpdateApplication();
                    }
            }
            return false;
        }

        private bool _UpdateApplication()
        {
            return clsApplicationData.UpdateApplication(this.ApplicationID, this.PersonID, this.ApplicationDate,
                this.ApplicationTypeID, (byte)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
        }

        private bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationData.AddNewApplication(this.PersonID, this.ApplicationDate,
                this.ApplicationTypeID, (byte)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
            return this.ApplicationID > 0;
        }

        public static bool IsApplicationExists(int ApplicationID)
        {
            return clsApplicationData.IsApplicationExists(ApplicationID);
        }

        public static bool DeleteApplication(int ApplicationID)
        {
            if (IsApplicationExists(ApplicationID))
            {
                return clsApplicationData.DeleteApplication(ApplicationID);
            }
            else
            {
                return false;
            }
        }
    }
}