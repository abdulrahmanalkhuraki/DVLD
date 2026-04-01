using DVLD___Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD___Business
{
    public class clsTestType
    {
        public int ID { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Fees { get; set; }

        public clsTestType(int testTypeID, string testTypeTitle, string testTypeDescription, decimal testTypeFees)
        {
            ID = testTypeID;
            Title = testTypeTitle;
            Description = testTypeDescription;
            Fees = testTypeFees;
        }

        public static clsTestType FindTestType(int TestTypeID)
        {
            string testTypeTitle = string.Empty;
            string testTypeDescription = string.Empty;
            decimal testTypeFees = decimal.Zero;

            if (clsTestTypeData.GetTestTypeByID(TestTypeID, ref testTypeTitle, ref testTypeDescription, ref testTypeFees))
            {
                return new clsTestType(TestTypeID, testTypeTitle, testTypeDescription, testTypeFees);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypeData.GetAllTestTypes();
        }

        public bool Save()
        {
            return clsTestTypeData.UpdateTestType(ID, Title, Description, Fees);
        }

    }
}
