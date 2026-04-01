using DVLD___Data_Access;
using System;
using System.Data;

namespace DVLD___Business
{
    public class clsTestAppointment
    {
        public enMode Mode { get; private set; }
        public int AppointmentID { get; private set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }

        public clsTestAppointment()
        {
            this.Mode = enMode.ADD;
            this.AppointmentID = -1;
            this.TestTypeID = -1;
            this.LocalDrivingLicenseApplicationID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            this.IsLocked = false;
        }

        private clsTestAppointment(int AppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID,
            DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked)
        {
            this.Mode = enMode.UPDATE;
            this.AppointmentID = AppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
        }

        public static DataTable GetAllAppointments()
        {
            return clsTestAppointmentData.GetAllAppointments();
        }

        private bool _AddNewAppointment()
        {
            this.AppointmentID = clsTestAppointmentData.AddNewAppointment(
                this.TestTypeID,
                this.LocalDrivingLicenseApplicationID,
                this.AppointmentDate,
                this.PaidFees,
                this.CreatedByUserID,
                this.IsLocked);

            if (this.AppointmentID != -1)
            {
                this.Mode = enMode.UPDATE;
                return true;
            }

            return false;
        }

        private bool _UpdateAppointment()
        {
            return clsTestAppointmentData.UpdateAppointment(
                this.AppointmentID,
                this.TestTypeID,
                this.LocalDrivingLicenseApplicationID,
                this.AppointmentDate,
                this.PaidFees,
                this.CreatedByUserID,
                this.IsLocked);
        }

        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.ADD:
                    return _AddNewAppointment();

                case enMode.UPDATE:
                    return _UpdateAppointment();

                default:
                    return false;
            }
        }

        public static clsTestAppointment Find(int AppointmentID)
        {
            int testTypeId = -1, localDrivingLicenseID = -1, createdByUserId = -1;
            DateTime appointmentDate = DateTime.MinValue;
            decimal paidFees = decimal.Zero;
            bool isLocked = false;

            if (clsTestAppointmentData.GetAppointmentByID(AppointmentID, ref testTypeId, ref localDrivingLicenseID,
                ref appointmentDate, ref paidFees, ref createdByUserId, ref isLocked))
            {
                return new clsTestAppointment(AppointmentID, testTypeId, localDrivingLicenseID,
                    appointmentDate, paidFees, createdByUserId, isLocked);
            }

            return null;
        }

        public static bool Exists(int AppointmentID)
        {
            return clsTestAppointmentData.IsAppointmentExists(AppointmentID);
        }

        public static bool Delete(int AppointmentID)
        {
            return clsTestAppointmentData.DeleteAppointment(AppointmentID);
        }

        public bool IsForRetakeTest()
        {
            int renewApplicationTypeID = 2;
            return clsLocalDrivingLicenseApplication.Find(LocalDrivingLicenseApplicationID).ApplicationTypeID == renewApplicationTypeID;
        }
    }
}