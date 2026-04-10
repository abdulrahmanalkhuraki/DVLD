using DVLD___Data_Access;
using System;
using System.Data;

namespace DVLD___Business
{
    public class clsDriver
    {
        public enMode Mode;
        public int DriverId { get; private set; }
        public int PersonId { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }

        public clsDriver()
        {
            this.DriverId = -1;
            this.PersonId = -1;
            this.CreatedByUserId = -1;
            this.CreatedDate = DateTime.Now;
            this.Mode = enMode.ADD;
        }

        private clsDriver(int DriverId, int PersonId, int CreatedByUserId, DateTime CreatedDate)
        {
            this.DriverId = DriverId;
            this.PersonId = PersonId;
            this.CreatedByUserId = CreatedByUserId;
            this.CreatedDate = CreatedDate;
            this.Mode = enMode.UPDATE;
        }

        public static DataTable GetAllDrivers()
        {
            return clsDriverData.GetAllDrivers();
        }

        public static clsDriver FindDriver(int DriverId)
        {
            int PersonId = -1;
            int CreatedByUserId = -1;
            DateTime CreatedDate = DateTime.MinValue;

            if (clsDriverData.GetDriverById(DriverId, ref PersonId, ref CreatedByUserId, ref CreatedDate))
            {
                return new clsDriver(DriverId, PersonId, CreatedByUserId, CreatedDate);
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
                        if (_AddNewDriver())
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
                        return _UpdateDriver();
                    }
            }
            return false;
        }

        private bool _UpdateDriver()
        {
            return clsDriverData.UpdateDriver(this.DriverId, this.PersonId, this.CreatedByUserId, this.CreatedDate);
        }

        private bool _AddNewDriver()
        {
            this.DriverId = clsDriverData.AddDriver(this.PersonId, this.CreatedByUserId, this.CreatedDate);
            return this.DriverId > 0;
        }

        public static bool IsDriverExists(int DriverId)
        {
            return clsDriverData.IsDriverExists(DriverId);
        }

        public static bool DeleteDriver(int DriverId)
        {
            if (IsDriverExists(DriverId))
            {
                return clsDriverData.DeleteDriver(DriverId);
            }
            else
            {
                return false;
            }
        }
    }
}