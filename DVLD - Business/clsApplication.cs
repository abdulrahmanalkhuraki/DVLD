using DVLD___Data_Access;
using System;
using System.Data;

namespace DVLD___Business
{
    public class clsApplication
    {
        public enMode Mode { get; private set; }
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
            this.Mode = enMode.ADD;
            this.ApplicationID = -1;
            this.PersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = enApplicationStatus.New;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
        }

        protected clsApplication(
            int applicationID,
            int personID,
            DateTime applicationDate,
            int applicationTypeID,
            enApplicationStatus applicationStatus,
            DateTime lastStatusDate,
            decimal paidFees,
            int createdByUserID)
        {
            this.Mode = enMode.UPDATE;
            this.ApplicationID = applicationID;
            this.PersonID = personID;
            this.ApplicationDate = applicationDate;
            this.ApplicationTypeID = applicationTypeID;
            this.ApplicationStatus = applicationStatus;
            this.LastStatusDate = lastStatusDate;
            this.PaidFees = paidFees;
            this.CreatedByUserID = createdByUserID;
        }


        public virtual bool Save()
        {
            switch (this.Mode)
            {
                case enMode.ADD:
                    return AddNewApplication();

                case enMode.UPDATE:
                    return UpdateApplication();

                default:
                    return false;
            }
        }

        private bool AddNewApplication()
        {
            this.ApplicationID = clsApplicationData.AddNewApplication(
                this.PersonID,
                this.ApplicationDate,
                this.ApplicationTypeID,
                (byte)this.ApplicationStatus,
                this.LastStatusDate,
                this.PaidFees,
                this.CreatedByUserID);

            if (this.ApplicationID > 0)
            {
                this.Mode = enMode.UPDATE;
                return true;
            }

            return false;
        }

        private bool UpdateApplication()
        {
            return clsApplicationData.UpdateApplication(
                this.ApplicationID,
                this.PersonID,
                this.ApplicationDate,
                this.ApplicationTypeID,
                (byte)this.ApplicationStatus,
                this.LastStatusDate,
                this.PaidFees,
                this.CreatedByUserID);
        }

        public static DataTable GetAllApplications()
        {
            return clsApplicationData.GetAllApplications();
        }

        public static clsApplication Find(int applicationID)
        {
            int personID = -1;
            DateTime applicationDate = DateTime.MinValue;
            int applicationTypeID = -1;
            byte applicationStatus = 0;
            DateTime lastStatusDate = DateTime.MinValue;
            decimal paidFees = 0;
            int createdByUserID = -1;

            bool isFound = clsApplicationData.GetApplicationByID(
                applicationID,
                ref personID,
                ref applicationDate,
                ref applicationTypeID,
                ref applicationStatus,
                ref lastStatusDate,
                ref paidFees,
                ref createdByUserID);

            if (isFound)
            {
                return new clsApplication(
                    applicationID,
                    personID,
                    applicationDate,
                    applicationTypeID,
                    (enApplicationStatus)applicationStatus,
                    lastStatusDate,
                    paidFees,
                    createdByUserID);
            }

            return null;
        }

        public static bool Exists(int applicationID)
        {
            return clsApplicationData.IsApplicationExists(applicationID);
        }

        public static bool Delete(int applicationID)
        {
            if (Exists(applicationID))
            {
                return clsApplicationData.DeleteApplication(applicationID);
            }

            return false;
        }
    }
}