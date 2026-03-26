using DVLD___Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD___Business
{
    public class clsLocalDrivingLicenseApplication
    {
        public enMode Mode;
        public int LocalDrivingLicenseApplicationID { get; private set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }

        public clsLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.ApplicationID = -1;
            this.LicenseClassID = -1;
            this.Mode = enMode.ADD;
        }

        private clsLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;
            this.Mode = enMode.UPDATE;
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationsData.GetAllLocalDrivingLicenseApplications();
        }

        public static clsLocalDrivingLicenseApplication FindLocalDrivingLicenseApplications(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = -1;
            int LicenseClassID = -1;

            if (clsLocalDrivingLicenseApplicationsData.GetLocalDrivingLicenseApplications(LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID))
            {
                return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID);
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
                        if (_AddNewLocalDrivingLicenseApplications())
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
                        return _UpdateLocalDrivingLicenseApplications();
                    }
            }
            return false;
        }

        private bool _UpdateLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationsData.UpdateLocalDrivingLicenseApplications(this.LocalDrivingLicenseApplicationID, this.ApplicationID, this.LicenseClassID);
        }

        private bool _AddNewLocalDrivingLicenseApplications()
        {
            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationsData.AddNewLocalDrivingLicenseApplications(this.ApplicationID, this.LicenseClassID);
            return this.LocalDrivingLicenseApplicationID > 0;
        }

        public static bool IsLocalDrivingLicenseApplicationsExists(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseApplicationsData.IsLocalDrivingLicenseApplicationsExists(LocalDrivingLicenseApplicationID);
        }

        public static bool DeleteLocalDrivingLicenseApplications(int LocalDrivingLicenseApplicationID)
        {
            if (IsLocalDrivingLicenseApplicationsExists(LocalDrivingLicenseApplicationID))
            {
                return clsLocalDrivingLicenseApplicationsData.DeleteLocalDrivingLicenseApplications(LocalDrivingLicenseApplicationID);
            }
            else
            {
                return false;
            }
        }
    }
}