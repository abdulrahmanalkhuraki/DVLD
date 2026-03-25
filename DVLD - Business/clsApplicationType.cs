using DVLD___Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD___Business
{
    public class clsApplicationType
    { 
        public int ApplicationTypeID { get;private set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationFees { get; set; }

        public clsApplicationType(int applicationTypeID, string applicationTypeTitle, decimal applicationFees)
        {
            ApplicationTypeID = applicationTypeID;
            ApplicationTypeTitle = applicationTypeTitle;
            ApplicationFees = applicationFees;
        }

        public static clsApplicationType FindApplicationType(int ApplicationTypeID)
        {
            string applicationTypeTitle = string.Empty;
            decimal applicationFees = decimal.Zero;

            if (clsApplicationTypeData.GetApplicationTypeByID(ApplicationTypeID, ref applicationTypeTitle, ref applicationFees))
            {
                return new clsApplicationType(ApplicationTypeID, applicationTypeTitle, applicationFees);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetAllApplicationTypes()
        {
           return clsApplicationTypeData.GetAllApplicationTypes();
        }

        public bool Save()
        {
           return clsApplicationTypeData.UpdateApplicationType(ApplicationTypeID,ApplicationTypeTitle,ApplicationFees);
        }

    }
}
