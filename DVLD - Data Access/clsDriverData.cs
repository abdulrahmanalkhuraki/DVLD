using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD___Data_Access
{
    public class clsDriverData
    {
        public static bool GetDriverByID(int DriverID, ref int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Drivers WHERE DriverID = @DriverID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DriverID", DriverID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        isFound = true;
                        PersonID = (int)reader["PersonID"];
                        CreatedByUserID = (int)reader["CreatedByUserID"];
                        CreatedDate = (DateTime)reader["CreatedDate"];
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

        public static bool GetDriverByPersonID(int PersonID, ref int DriverID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Drivers WHERE PersonID = @PersonID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        isFound = true;
                        DriverID = (int)reader["DriverID"];
                        CreatedByUserID = (int)reader["CreatedByUserID"];
                        CreatedDate = (DateTime)reader["CreatedDate"];
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

        public static DataTable GetAllDrivers()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT DriverID, PersonID, CreatedByUserID, CreatedDate FROM Drivers";
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

        public static DataTable GetDriversWithPersonInfo()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT 
                                    Drivers.DriverID,
                                    Drivers.PersonID,
                                    Drivers.CreatedByUserID,
                                    Drivers.CreatedDate,
                                    People.NationalNo,
                                    People.FirstName,
                                    People.SecondName,
                                    People.ThirdName,
                                    People.LastName,
                                    People.DateOfBirth,
                                    People.Gendor AS Gender,
                                    People.Address,
                                    People.Phone,
                                    People.Email
                                FROM Drivers
                                INNER JOIN People ON Drivers.PersonID = People.PersonID";
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

        public static int AddNewDriver(int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            int DriverID = -1;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO Drivers (PersonID, CreatedByUserID, CreatedDate)
                                 VALUES (@PersonID, @CreatedByUserID, @CreatedDate);
                                 SELECT SCOPE_IDENTITY();";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                command.Parameters.AddWithValue("@CreatedDate", CreatedDate);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        DriverID = insertedID;
                }
                catch
                {
                    // handle
                }
            }
            return DriverID;
        }

        public static bool UpdateDriver(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Drivers SET
                                    PersonID = @PersonID,
                                    CreatedByUserID = @CreatedByUserID,
                                    CreatedDate = @CreatedDate
                                WHERE DriverID = @DriverID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DriverID", DriverID);
                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                command.Parameters.AddWithValue("@CreatedDate", CreatedDate);

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

        public static bool DeleteDriver(int DriverID)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM Drivers WHERE DriverID = @DriverID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DriverID", DriverID);
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

        public static bool IsDriverExists(int DriverID)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT Found=1 FROM Drivers WHERE DriverID = @DriverID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DriverID", DriverID);
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

        public static bool IsDriverExistsByPersonID(int PersonID)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT Found=1 FROM Drivers WHERE PersonID = @PersonID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);
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
    }
}