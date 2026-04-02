using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLD___Data_Access
{
    public class clsPersonData
    {
        public static bool GetPersonByID(int PersonID, ref string NationalNo,
            ref string FirstName, ref string SecondName,
            ref string ThirdName, ref string LastName,
            ref DateTime DateOfBirth, ref bool Gender,
            ref string Address, ref string Phone, ref string Email,
            ref int NationalityCountryId, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM People WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = reader["ThirdName"] != DBNull.Value ? (string)reader["ThirdName"] : string.Empty; // Allows null
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gender = (bool)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    Email = reader["Email"] != DBNull.Value ? (string)reader["Email"] : string.Empty; // Allows null
                    NationalityCountryId = (int)reader["NationalityCountryId"];
                    ImagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : string.Empty; // Allows null

                }
                else
                {
                    // The record was not found
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

        public static bool GetPersonByNationalNo(string NationalNo, ref int PersonID,
            ref string FirstName, ref string SecondName,
            ref string ThirdName, ref string LastName,
            ref DateTime DateOfBirth, ref bool Gender,
            ref string Address, ref string Phone, ref string Email,
            ref int NationalityCountryId, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM People WHERE NationalNo = @NationalNo";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = reader["ThirdName"] != DBNull.Value ? (string)reader["ThirdName"] : string.Empty; // Allows null
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gender = (bool)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    Email = reader["Email"] != DBNull.Value ? (string)reader["Email"] : string.Empty; // Allows null
                    NationalityCountryId = (int)reader["NationalityCountryId"];
                    ImagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : string.Empty; // Allows null

                }
                else
                {
                    // The record was not found
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


        public static int AddNewPerson(string NationalNo,
            string FirstName,string SecondName,
            string ThirdName,string LastName,
            DateTime DateOfBirth,bool Gender,
            string Address,string Phone,string Email,
            int NationalityCountryId,string ImagePath)
        {
            //this function will return the new Person id if succeeded and -1 if not.
            int PersonId = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO People (NationalNo, FirstName,SecondName,ThirdName,LastName,DateOfBirth,
                                                Gendor,Address,Phone, Email,NationalityCountryId,ImagePath)
                             VALUES (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth,
                                                @Gendor, @Address, @Phone, @Email, @NationalityCountryId, @ImagePath);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gender);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@NationalityCountryId", NationalityCountryId);


            // --Handle Null Values--//

            // Third Name Allows Null
            if (string.IsNullOrEmpty(ThirdName))
            {
                command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            }

            // Email Allows Null
            if (string.IsNullOrEmpty(Email))
            {
                command.Parameters.AddWithValue("@Email", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Email", Email);
            }

            // ImagePath Allows Null
            if (string.IsNullOrEmpty(ImagePath))
            {
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    PersonId = insertedID;
                }
            }

            catch
            {
                //Console.WriteLine("Error: " + ex.Message);
            }

            finally
            {
                connection.Close();
            }

            return PersonId;
        }

        public static bool UpdatePerson(int PersonID, string NationalNo,
            string FirstName, string SecondName,
            string ThirdName, string LastName,
            DateTime DateOfBirth, bool Gender,
            string Address, string Phone, string Email,
            int NationalityCountryId, string ImagePath)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE People SET 
                                        NationalNo = @NationalNo,
                                        FirstName = @FirstName,
                                        SecondName = @SecondName,
                                        ThirdName = @ThirdName,
                                        LastName = @LastName,
                                        DateOfBirth = @DateOfBirth,
                                        Gendor = @Gendor,
                                        Address = @Address,
                                        Phone = @Phone,
                                        Email = @Email,
                                        NationalityCountryId = @NationalityCountryId,
                                        ImagePath = @ImagePath
                                        WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gender);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@NationalityCountryId", NationalityCountryId);


            // --Handle Null Values--//

            // Third Name Allows Null
            if (string.IsNullOrEmpty(ThirdName))
            {
                command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            }

            // Email Allows Null
            if (string.IsNullOrEmpty(Email))
            {
                command.Parameters.AddWithValue("@Email", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Email", Email);
            }

            // ImagePath Allows Null
            if (string.IsNullOrEmpty(ImagePath))
            {
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static DataTable GetAllPeople()
        {

            DataTable dt = new DataTable();
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT 
                                PersonId AS 'Person ID',
                                Firstname,Secondname,Thirdname,Lastname,
                                NationalNo AS 'National Number',
                                FORMAT(DateOfBirth, 'yyyy-MM-dd') AS 'Date Of Birth',
                                CASE
                                    WHEN Gendor = 0 THEN 'Male'
                                    WHEN Gendor = 1 THEN 'Female'
                                    ELSE 'Unknown'
                                END AS Gender,
                                Countries.CountryName AS 'Nationality',
                                Address,
                                Phone,
                                Email
                            FROM
                                People
                                JOIN Countries ON Countries.CountryID = People.NationalityCountryID;";

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
                //
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            return dt;
        }

        public static bool DeletePerson(int PersonID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete People where PersonId = @PersonId;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonId", PersonID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);
        }

        public static bool IsPersonExists(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM People WHERE PersonId = @PersonId";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonId", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool IsPersonExists(string NationalNo)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM People WHERE NationalNo = @NationalNo";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool DoesPersonHasLicense(int PersonID)
        {
            bool HasLicense = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select distinct 1 from Licenses join Applications on Licenses.ApplicationID = Applications.ApplicationID
  where Applications.ApplicantPersonID = @PersonId;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonId", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                HasLicense = reader.HasRows;

                reader.Close();
            }
            catch
            {
                //Console.WriteLine("Error: " + ex.Message);
                HasLicense = false;
            }
            finally
            {
                connection.Close();
            }

            return HasLicense;
        }
    }
}
