using DVLD___Data_Access;
using System;
using System.Data;

namespace DVLD___Business
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        public enMode LocalDrivingLicenseApplicationMode { get; private set; }
        public int LocalDrivingLicenseApplicationID { get; private set; }
        public int LicenseClassID { get; set; }


        public clsLocalDrivingLicenseApplication() : base()
        {
            this.LocalDrivingLicenseApplicationMode = enMode.ADD;
            this.ApplicationTypeID = 1;
            this.PaidFees = 15;
            this.LocalDrivingLicenseApplicationID = -1;
            this.LicenseClassID = -1;
        }

        private clsLocalDrivingLicenseApplication(
            int applicationID,
            int personID,
            DateTime applicationDate,
            int applicationTypeID,
            enApplicationStatus applicationStatus,
            DateTime lastStatusDate,
            decimal paidFees,
            int createdByUserID,
            int localDrivingLicenseApplicationID,
            int licenseClassID)
            : base(applicationID, personID, applicationDate, applicationTypeID,
                  applicationStatus, lastStatusDate, paidFees, createdByUserID)
        {
            this.LocalDrivingLicenseApplicationMode = enMode.UPDATE;
            this.LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            this.LicenseClassID = licenseClassID;
        }

        public override bool Save()
        {
            if (!base.Save())
                return false;


            switch (LocalDrivingLicenseApplicationMode)
            {
                case enMode.ADD:
                    return _AddNewLocalDrivingLicenseApplication();

                case enMode.UPDATE:
                    return _UpdateLocalDrivingLicenseApplication();

                default:
                    return false;
            }
        }

        private bool _AddNewLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID =
                clsLocalDrivingLicenseApplicationsData.AddNewLocalDrivingLicenseApplication(
                    this.ApplicationID,
                    this.LicenseClassID);

            return this.LocalDrivingLicenseApplicationID > 0;
        }

        private bool _UpdateLocalDrivingLicenseApplication()
        {
            return clsLocalDrivingLicenseApplicationsData.UpdateLocalDrivingLicenseApplication(
                this.LocalDrivingLicenseApplicationID,
                this.ApplicationID,
                this.LicenseClassID);
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationsData.GetAllLocalDrivingLicenseApplications();
        }

        public static clsLocalDrivingLicenseApplication Find(int localDrivingLicenseApplicationID)
        {
            int applicationID = -1;
            int licenseClassID = -1;

            bool isFound = clsLocalDrivingLicenseApplicationsData.GetLocalDrivingLicenseApplication(
                localDrivingLicenseApplicationID,
                ref applicationID,
                ref licenseClassID);

            if (!isFound)
                return null;

            clsApplication baseApplication = clsApplication.Find(applicationID);

            if (baseApplication == null)
                return null;

            return new clsLocalDrivingLicenseApplication(
                baseApplication.ApplicationID,
                baseApplication.PersonID,
                baseApplication.ApplicationDate,
                baseApplication.ApplicationTypeID,
                baseApplication.ApplicationStatus,
                baseApplication.LastStatusDate,
                baseApplication.PaidFees,
                baseApplication.CreatedByUserID,
                localDrivingLicenseApplicationID,
                licenseClassID);
        }

        public static bool Exists(int localDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseApplicationsData.IsLocalDrivingLicenseApplicationExists(
                localDrivingLicenseApplicationID);
        }

        public static bool Delete(int localDrivingLicenseApplicationID)
        {
            if (!Exists(localDrivingLicenseApplicationID))
                return false;

            // Note: You might want to also delete the base application
            // Consider the business logic - should the base application be deleted too?
            return clsLocalDrivingLicenseApplicationsData.DeleteLocalDrivingLicenseApplication(
                localDrivingLicenseApplicationID);
        }

        public static int IsThereActiveOrderBefore(int personID, int LicenseClassID)
        {
            // check if there an active order with the same license class for this person
            // it returns the active order id if exists and if not it returns -1
            return clsLocalDrivingLicenseApplicationsData.IsThereActiveOrderBefore(personID, LicenseClassID);

        }

        public static int GetPassedTests(int ApplicationID)
        {
            DataRow[] row = GetAllLocalDrivingLicenseApplications().Select($"LocalDrivingLicenseApplicationID = {ApplicationID}");
            if (int.TryParse(row[0]["PassedTestCount"].ToString(),out int passedTestsCount))
                return passedTestsCount;
            else return -1;
        }
    }
}