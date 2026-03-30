using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD___Data_Access
{
    public class clsTestAppointmentData
    {
        public static bool GetAppointmentByID(int AppointmentID, ref int TestTypeID, ref int LocalDrivingLicenseApplicationID,
            ref DateTime AppointmentDate, ref decimal PaidFees, ref int CreatedByUserID, ref bool IsLocked)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", AppointmentID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    TestTypeID = (int)reader["TestTypeID"];
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsLocked = (bool)reader["IsLocked"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                // Optionally log the error: Console.WriteLine(ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int AddNewAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID,
            DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked)
        {
            int AppointmentID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO TestAppointments (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked)
                             VALUES (@TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate, @PaidFees, @CreatedByUserID, @IsLocked);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    AppointmentID = insertedID;
                }
            }
            catch
            {
                return -1;
            }
            finally
            {
                connection.Close();
            }

            return AppointmentID;
        }

        public static bool UpdateAppointment(int AppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID,
            DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE TestAppointments SET 
                                TestTypeID = @TestTypeID,
                                LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID,
                                AppointmentDate = @AppointmentDate,
                                PaidFees = @PaidFees,
                                CreatedByUserID = @CreatedByUserID,
                                IsLocked = @IsLocked
                             WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", AppointmentID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static DataTable GetAllAppointments(int PersonID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select TestAppointmentID,AppointmentDate,PaidFees,IsLocked from (
	select R2.*,Applications.ApplicantPersonID from (
		select TestAppointmentID,AppointmentDate,
			PaidFees,IsLocked,LocalDrivingLicenseApplications.ApplicationID from TestAppointments_View 
			join LocalDrivingLicenseApplications 
		on TestAppointments_View.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID)R2
	join Applications on Applications.ApplicationID = R2.ApplicationID
)R1 where ApplicantPersonID = 1 order by AppointmentDate desc;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch
            {
                // Handle error
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool DeleteAppointment(int AppointmentID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "DELETE FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", AppointmentID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool IsAppointmentExists(int AppointmentID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT 1 FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", AppointmentID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                isFound = (result != null);
            }
            catch
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        

    }
}