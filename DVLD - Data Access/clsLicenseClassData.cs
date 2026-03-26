using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD___Data_Access
{
    public class clsLicenseClassData
    {
        public static bool GetLicenseClassByID(int LicenseClassID, ref string ClassName, ref string ClassDescription,
                                                ref int MinimumAllowedAge, ref int DefaultValidityLength, ref decimal ClassFees)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ClassName = reader["ClassName"].ToString();
                    ClassDescription = reader["ClassDescription"].ToString();
                    MinimumAllowedAge = (int)reader["MinimumAllowedAge"];
                    DefaultValidityLength = (int)reader["DefaultValidityLength"];
                    ClassFees = (decimal)reader["ClassFees"];
                }
                else
                {
                    isFound = false;
                }

                reader.Close();
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

        public static int AddNewLicenseClass(string ClassName, string ClassDescription, int MinimumAllowedAge,
                                             int DefaultValidityLength, decimal ClassFees)
        {
            int LicenseClassID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO LicenseClasses (ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees)
                         VALUES (@ClassName, @ClassDescription, @MinimumAllowedAge, @DefaultValidityLength, @ClassFees);
                         SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            command.Parameters.AddWithValue("@ClassFees", ClassFees);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LicenseClassID = insertedID;
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

            return LicenseClassID;
        }

        public static bool UpdateLicenseClass(int LicenseClassID, string ClassName, string ClassDescription,
                                              int MinimumAllowedAge, int DefaultValidityLength, decimal ClassFees)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE LicenseClasses SET 
                            ClassName = @ClassName,
                            ClassDescription = @ClassDescription,
                            MinimumAllowedAge = @MinimumAllowedAge,
                            DefaultValidityLength = @DefaultValidityLength,
                            ClassFees = @ClassFees
                         WHERE LicenseClassID = @LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            command.Parameters.AddWithValue("@ClassFees", ClassFees);

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

        public static DataTable GetAllLicenseClasses()
        {
            DataTable dt = new DataTable();
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT * FROM LicenseClasses";

            SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            return dt;
        }

        public static bool DeleteLicenseClass(int LicenseClassID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

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

        public static bool IsLicenseClassExists(int LicenseClassID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT 1 FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    isFound = reader.HasRows;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error checking LicenseClass existence: " + ex.Message);
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