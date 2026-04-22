using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD___Data_Access
{
    public class clsInternationalLicenseData
    {
        public static int AddNewInternationalLicense(int applicationID, int driverID, int issuedUsingLocalLicenseID,
            DateTime issueDate, DateTime expirationDate, bool isActive, int createdByUser)
        {
            int internationalLicenseID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO InternationalLicenses 
                                (ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, 
                                 ExpirationDate, IsActive, CreatedByUser)
                                VALUES (@ApplicationID, @DriverID, @IssuedUsingLocalLicenseID, @IssueDate, 
                                        @ExpirationDate, @IsActive, @CreatedByUser);
                                SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApplicationID", applicationID);
                command.Parameters.AddWithValue("@DriverID", driverID);
                command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", issuedUsingLocalLicenseID);
                command.Parameters.AddWithValue("@IssueDate", issueDate);
                command.Parameters.AddWithValue("@ExpirationDate", expirationDate);
                command.Parameters.AddWithValue("@IsActive", isActive);
                command.Parameters.AddWithValue("@CreatedByUser", createdByUser);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        internationalLicenseID = insertedID;
                }
                catch
                {
                    // Log exception if needed
                    internationalLicenseID = -1;
                }
            }
            return internationalLicenseID;
        }

        public static bool DeleteInternationalLicense(int interationalLicenseId)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@InternationalLicenseID", interationalLicenseId);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch
                {
                    // Log exception if needed
                    return false;
                }
            }
            return rowsAffected > 0;
        }

        public static DataTable GetAllInternationalLicesnes()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT 
                                    InternationalLicenseID, ApplicationID, DriverID, 
                                    IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, 
                                    IsActive, CreatedByUser
                                FROM InternationalLicenses 
                                ORDER BY IssueDate DESC";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                        dt.Load(reader);
                    reader.Close();
                }
                catch
                {
                    // Log exception if needed
                }
            }
            return dt;
        }

        public static bool GetInternationalLicenseByDriverId(int driverID, ref int applicationId, ref int internationalLicenseId,
            ref int issuedUsingLocalLicenseId, ref DateTime issueDate, ref DateTime expirationDate,
            ref bool isActive, ref int createdByUser)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM InternationalLicenses WHERE DriverID = @DriverID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DriverID", driverID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        isFound = true;
                        internationalLicenseId = (int)reader["InternationalLicenseID"];
                        applicationId = (int)reader["ApplicationID"];
                        issuedUsingLocalLicenseId = (int)reader["IssuedUsingLocalLicenseID"];
                        issueDate = (DateTime)reader["IssueDate"];
                        expirationDate = (DateTime)reader["ExpirationDate"];
                        isActive = (bool)reader["IsActive"];
                        createdByUser = (int)reader["CreatedByUser"];
                    }
                    reader.Close();
                }
                catch
                {
                    isFound = false;
                }
            }
            return isFound;
        }

        public static bool GetInternationalLicenseById(int InternationalLicenseID, ref int ApplicationId, ref int DriverId,
            ref int IssuedUsingLocalLicenseId, ref DateTime IssueDate, ref DateTime expirationDate,
            ref bool IsActive, ref int CreatedByUser)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        isFound = true;
                        ApplicationId = (int)reader["ApplicationID"];
                        DriverId = (int)reader["DriverID"];
                        IssuedUsingLocalLicenseId = (int)reader["IssuedUsingLocalLicenseID"];
                        IssueDate = (DateTime)reader["IssueDate"];
                        expirationDate = (DateTime)reader["ExpirationDate"];
                        IsActive = (bool)reader["IsActive"];
                        CreatedByUser = (int)reader["CreatedByUser"];
                    }
                    reader.Close();
                }
                catch
                {
                    isFound = false;
                }
            }
            return isFound;
        }

        public static bool IsInternationalLicenseExists(int interationalLicenseId)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT Found=1 FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@InternationalLicenseID", interationalLicenseId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    isFound = reader.HasRows;
                    reader.Close();
                }
                catch
                {
                    isFound = false;
                }
            }
            return isFound;
        }

        public static bool UpdateInternationalLicense(int internationalLicenseID, int applicationID, int driverID,
            int issuedUsingLocalLicenseID, DateTime issueDate, DateTime expirationDate,
            bool isActive, int createdByUser)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE InternationalLicenses SET
                                    ApplicationID = @ApplicationID,
                                    DriverID = @DriverID,
                                    IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID,
                                    IssueDate = @IssueDate,
                                    ExpirationDate = @ExpirationDate,
                                    IsActive = @IsActive,
                                    CreatedByUser = @CreatedByUser
                                WHERE InternationalLicenseID = @InternationalLicenseID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@InternationalLicenseID", internationalLicenseID);
                command.Parameters.AddWithValue("@ApplicationID", applicationID);
                command.Parameters.AddWithValue("@DriverID", driverID);
                command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", issuedUsingLocalLicenseID);
                command.Parameters.AddWithValue("@IssueDate", issueDate);
                command.Parameters.AddWithValue("@ExpirationDate", expirationDate);
                command.Parameters.AddWithValue("@IsActive", isActive);
                command.Parameters.AddWithValue("@CreatedByUser", createdByUser);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
            }
            return rowsAffected > 0;
        }
    }
}