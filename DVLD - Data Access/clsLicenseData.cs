using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD___Data_Access
{
    public class clsLicenseData
    {
        public static bool GetLicenseByID(int LicenseID, ref int ApplicationID, ref int DriverID,
            ref int LicenseClass, ref DateTime IssueDate, ref DateTime ExpirationDate,
            ref string Notes, ref decimal PaidFees, ref bool IsActive,
            ref int IssueReason, ref int CreatedByUserID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Licenses WHERE LicenseID = @LicenseID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LicenseID", LicenseID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        isFound = true;
                        ApplicationID = (int)reader["ApplicationID"];
                        DriverID = (int)reader["DriverID"];
                        LicenseClass = (int)reader["LicenseClass"];
                        IssueDate = (DateTime)reader["IssueDate"];
                        ExpirationDate = (DateTime)reader["ExpirationDate"];
                        Notes = reader["Notes"] != DBNull.Value ? (string)reader["Notes"] : string.Empty;
                        PaidFees = (decimal)reader["PaidFees"];
                        IsActive = (bool)reader["IsActive"];
                        IssueReason = (int)reader["IssueReason"];
                        CreatedByUserID = (int)reader["CreatedByUserID"];
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

        public static bool GetLicenseByApplicationID(int ApplicationID, ref int LicenseID, ref int DriverID,
            ref int LicenseClass, ref DateTime IssueDate, ref DateTime ExpirationDate,
            ref string Notes, ref decimal PaidFees, ref bool IsActive,
            ref int IssueReason, ref int CreatedByUserID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Licenses WHERE ApplicationID = @ApplicationID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        isFound = true;
                        LicenseID = (int)reader["LicenseID"];
                        DriverID = (int)reader["DriverID"];
                        LicenseClass = (int)reader["LicenseClass"];
                        IssueDate = (DateTime)reader["IssueDate"];
                        ExpirationDate = (DateTime)reader["ExpirationDate"];
                        Notes = reader["Notes"] != DBNull.Value ? (string)reader["Notes"] : string.Empty;
                        PaidFees = (decimal)reader["PaidFees"];
                        IsActive = (bool)reader["IsActive"];
                        IssueReason = (int)reader["IssueReason"];
                        CreatedByUserID = (int)reader["CreatedByUserID"];
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

        public static DataTable GetAllLicenses()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT 
                                    LicenseID, ApplicationID, DriverID, LicenseClass,
                                    IssueDate, ExpirationDate, Notes, PaidFees,
                                    IsActive, IssueReason, CreatedByUserID
                                FROM Licenses";
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                        dt.Load(reader);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    // log ex.Message if needed
                }
            }
            return dt;
        }

        public static DataTable GetLicensesByDriverID(int DriverID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Licenses WHERE DriverID = @DriverID ORDER BY IssueDate DESC";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DriverID", DriverID);
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
                    // handle
                }
            }
            return dt;
        }

        public static DataTable GetActiveLicensesByDriverID(int DriverID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Licenses WHERE DriverID = @DriverID AND IsActive = 1 ORDER BY IssueDate DESC";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DriverID", DriverID);
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
                    // handle
                }
            }
            return dt;
        }

        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClass,
            DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees,
            bool IsActive, int IssueReason, int CreatedByUserID)
        {
            int LicenseID = -1;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO Licenses 
                                (ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate,
                                 Notes, PaidFees, IsActive, IssueReason, CreatedByUserID)
                                VALUES (@ApplicationID, @DriverID, @LicenseClass, @IssueDate, @ExpirationDate,
                                        @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID);
                                SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                command.Parameters.AddWithValue("@DriverID", DriverID);
                command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
                command.Parameters.AddWithValue("@IssueDate", IssueDate);
                command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                command.Parameters.AddWithValue("@PaidFees", PaidFees);
                command.Parameters.AddWithValue("@IsActive", IsActive);
                command.Parameters.AddWithValue("@IssueReason", IssueReason);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                // Handle nullable Notes
                if (string.IsNullOrEmpty(Notes))
                    command.Parameters.AddWithValue("@Notes", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@Notes", Notes);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        LicenseID = insertedID;
                }
                catch
                {
                    // handle
                }
            }
            return LicenseID;
        }

        public static bool UpdateLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClass,
            DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees,
            bool IsActive, int IssueReason, int CreatedByUserID)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Licenses SET
                                    ApplicationID = @ApplicationID,
                                    DriverID = @DriverID,
                                    LicenseClass = @LicenseClass,
                                    IssueDate = @IssueDate,
                                    ExpirationDate = @ExpirationDate,
                                    Notes = @Notes,
                                    PaidFees = @PaidFees,
                                    IsActive = @IsActive,
                                    IssueReason = @IssueReason,
                                    CreatedByUserID = @CreatedByUserID
                                WHERE LicenseID = @LicenseID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LicenseID", LicenseID);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                command.Parameters.AddWithValue("@DriverID", DriverID);
                command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
                command.Parameters.AddWithValue("@IssueDate", IssueDate);
                command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                command.Parameters.AddWithValue("@PaidFees", PaidFees);
                command.Parameters.AddWithValue("@IsActive", IsActive);
                command.Parameters.AddWithValue("@IssueReason", IssueReason);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                if (string.IsNullOrEmpty(Notes))
                    command.Parameters.AddWithValue("@Notes", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@Notes", Notes);

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

        public static bool DeleteLicense(int LicenseID)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM Licenses WHERE LicenseID = @LicenseID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LicenseID", LicenseID);
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

        public static bool IsLicenseExists(int LicenseID)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT Found=1 FROM Licenses WHERE LicenseID = @LicenseID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LicenseID", LicenseID);
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

        public static bool IsLicenseExistsByApplicationID(int ApplicationID)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT Found=1 FROM Licenses WHERE ApplicationID = @ApplicationID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
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

        public static bool IsLicenseActive(int LicenseID)
        {
            bool isActive = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT IsActive FROM Licenses WHERE LicenseID = @LicenseID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LicenseID", LicenseID);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                        isActive = (bool)result;
                }
                catch
                {
                    isActive = false;
                }
            }
            return isActive;
        }
    }
}