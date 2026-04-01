using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD___Data_Access;

namespace DVLD___Business
{
    public class clsTest
    {

        public enMode Mode { get; set; }
        public int TestID { get; private set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        public clsTest()
        {
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = false;
            this.Notes = string.Empty;
            this.CreatedByUserID = -1;
            this.Mode = enMode.ADD;
        }

        private clsTest(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;
            this.Mode = enMode.UPDATE;
        }

        public static DataTable GetAllTests()
        {
            return clsTestData.GetAllTests();
        }

        public static clsTest FindTest(int TestID)
        {
            int TestAppointmentID = -1;
            bool TestResult = false;
            string Notes = string.Empty;
            int CreatedByUserID = -1;

            if (clsTestData.GetTestByID(TestID, ref TestAppointmentID, ref TestResult, ref Notes, ref CreatedByUserID))
            {
                return new clsTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }

        public static clsTest FindTestByAppointmentID(int TestAppointmentID)
        {
            int TestID = -1;
            bool TestResult = false;
            string Notes = string.Empty;
            int CreatedByUserID = -1;

            if (clsTestData.GetTestByAppointmentID(TestAppointmentID, ref TestID, ref TestResult, ref Notes, ref CreatedByUserID))
            {
                return new clsTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
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
                        if (_AddNewTest())
                        {
                            this.Mode = enMode.UPDATE;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case enMode.UPDATE:
                    {
                        return _UpdateTest();
                    }
            }
            return false;
        }

        private bool _UpdateTest()
        {
            return clsTestData.UpdateTest(this.TestID, this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);
        }

        private bool _AddNewTest()
        {
            this.TestID = clsTestData.AddNewTest(this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);
            return this.TestID > 0;
        }

        public static bool IsTestExists(int TestID)
        {
            return clsTestData.IsTestExists(TestID);
        }

        public static bool IsTestExistsByAppointmentID(int TestAppointmentID)
        {
            return clsTestData.IsTestExistsByAppointmentID(TestAppointmentID);
        }

        public static bool DeleteTest(int TestID)
        {
            if (IsTestExists(TestID))
            {
                return clsTestData.DeleteTest(TestID);
            }
            else
            {
                return false;
            }
        }

        public static DataTable GetTestsByUserID(int UserID)
        {
            return clsTestData.GetTestsByUserID(UserID);
        }

        public static DataTable GetTestsByResult(bool TestResult)
        {
            return clsTestData.GetTestsByResult(TestResult);
        }

        public static DataTable GetTestsByPersonIDAndTestTypeID(int PersonID, int TestTypeID)
        {
            return clsTestData.GetTestsByPersonIDAndTestTypeID(PersonID, TestTypeID);
        }

        public static bool IsThereFaildTestsTakenBefore(int PersonID, int TestTypeID)
        {
           DataTable dt = GetTestsByPersonIDAndTestTypeID(PersonID,TestTypeID);

            if(dt.Rows.Count == 0)
                return false;

           DataRow[] faildTests = dt.Select("TestResult = 0");
           return faildTests.Length > 0; 
        }


    }
}