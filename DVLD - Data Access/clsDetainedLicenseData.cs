using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD___Data_Access
{
    public class clsDetainedLicenseData
    {
        public static bool GetDetainedLicenseByLicenseID(int LicenseID, ref int DetainID,
            ref DateTime DetainDate, ref decimal FineFees, ref int CreatedByUserID,
            ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserID,
            ref int ReleaseApplicationID)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM DetainedLicenses WHERE LicenseID = @LicenseID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LicenseID", LicenseID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        isFound = true;
                        DetainID = (int)reader["DetainID"];
                        DetainDate = (DateTime)reader["DetainDate"];
                        FineFees = (decimal)reader["FineFees"];
                        CreatedByUserID = (int)reader["CreatedByUserID"];
                        IsReleased = (bool)reader["IsReleased"];
                        ReleaseDate = reader["ReleaseDate"] != DBNull.Value ? (DateTime)reader["ReleaseDate"] : DateTime.MinValue;
                        ReleasedByUserID = reader["ReleasedByUserID"] != DBNull.Value ? (int)reader["ReleasedByUserID"] : -1;
                        ReleaseApplicationID = reader["ReleaseApplicationID"] != DBNull.Value ? (int)reader["ReleaseApplicationID"] : -1;
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

        public static bool GetDetainedLicenseByDetainID(int DetainID, ref int LicenseID,
            ref DateTime DetainDate, ref decimal FineFees, ref int CreatedByUserID,
            ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserID,
            ref int ReleaseApplicationID)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM DetainedLicenses WHERE DetainID = @DetainID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DetainID", DetainID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        isFound = true;
                        LicenseID = (int)reader["LicenseID"];
                        DetainDate = (DateTime)reader["DetainDate"];
                        FineFees = (decimal)reader["FineFees"];
                        CreatedByUserID = (int)reader["CreatedByUserID"];
                        IsReleased = (bool)reader["IsReleased"];
                        ReleaseDate = reader["ReleaseDate"] != DBNull.Value ? (DateTime)reader["ReleaseDate"] : DateTime.MinValue;
                        ReleasedByUserID = reader["ReleasedByUserID"] != DBNull.Value ? (int)reader["ReleasedByUserID"] : -1;
                        ReleaseApplicationID = reader["ReleaseApplicationID"] != DBNull.Value ? (int)reader["ReleaseApplicationID"] : -1;
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

        public static int AddNewDetainedLicense(int LicenseID, DateTime DetainDate, decimal FineFees,
            int CreatedByUserID, bool IsReleased, DateTime ReleaseDate,
            int ReleasedByUserID, int ReleaseApplicationID)
        {
            int DetainID = -1;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO DetainedLicenses 
                                (LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID)
                                VALUES (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, @IsReleased, @ReleaseDate, @ReleasedByUserID, @ReleaseApplicationID);
                                SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LicenseID", LicenseID);
                command.Parameters.AddWithValue("@DetainDate", DetainDate);
                command.Parameters.AddWithValue("@FineFees", FineFees);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                command.Parameters.AddWithValue("@IsReleased", IsReleased);

                // Handle nullable ReleaseDate
                if (ReleaseDate == DateTime.MinValue || ReleaseDate == default)
                    command.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);

                // Handle nullable ReleasedByUserID
                if (ReleasedByUserID == -1)
                    command.Parameters.AddWithValue("@ReleasedByUserID", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);

                // Handle nullable ReleaseApplicationID
                if (ReleaseApplicationID == -1)
                    command.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        DetainID = insertedID;
                }
                catch
                {
                    // handle
                }
            }
            return DetainID;
        }

        public static bool UpdateDetainedLicense(int DetainID, int LicenseID, DateTime DetainDate, decimal FineFees,
            int CreatedByUserID, bool IsReleased, DateTime ReleaseDate,
            int ReleasedByUserID, int ReleaseApplicationID)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE DetainedLicenses SET
                                    LicenseID = @LicenseID,
                                    DetainDate = @DetainDate,
                                    FineFees = @FineFees,
                                    CreatedByUserID = @CreatedByUserID,
                                    IsReleased = @IsReleased,
                                    ReleaseDate = @ReleaseDate,
                                    ReleasedByUserID = @ReleasedByUserID,
                                    ReleaseApplicationID = @ReleaseApplicationID
                                WHERE DetainID = @DetainID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DetainID", DetainID);
                command.Parameters.AddWithValue("@LicenseID", LicenseID);
                command.Parameters.AddWithValue("@DetainDate", DetainDate);
                command.Parameters.AddWithValue("@FineFees", FineFees);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                command.Parameters.AddWithValue("@IsReleased", IsReleased);

                // Handle nullable ReleaseDate
                if (ReleaseDate == DateTime.MinValue || ReleaseDate == default)
                    command.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);

                // Handle nullable ReleasedByUserID
                if (ReleasedByUserID == -1)
                    command.Parameters.AddWithValue("@ReleasedByUserID", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);

                // Handle nullable ReleaseApplicationID
                if (ReleaseApplicationID == -1)
                    command.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);

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

        public static bool IsLicenseDetained(int LicenseID)
        {
            bool isDetained = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT Found=1 FROM DetainedLicenses WHERE LicenseID = @LicenseID AND IsReleased = 0";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LicenseID", LicenseID);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    isDetained = reader.HasRows;
                    reader.Close();
                }
                catch
                {
                    isDetained = false;
                }
            }
            return isDetained;
        }

        public static DataTable GetAllDetainedLicenses()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM DetainedLicenses ORDER BY DetainDate DESC";
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
                    // handle
                }
            }
            return dt;
        }
    }
}