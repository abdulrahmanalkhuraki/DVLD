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
        public int ID { get;private set; }
        public string Title { get; set; }
        public decimal Fees { get; set; }

        public clsApplicationType(int applicationTypeID, string applicationTypeTitle, decimal applicationFees)
        {
            ID = applicationTypeID;
            Title = applicationTypeTitle;
            Fees = applicationFees;
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
           return clsApplicationTypeData.UpdateApplicationType(ID,Title,Fees);
        }

    }
}
