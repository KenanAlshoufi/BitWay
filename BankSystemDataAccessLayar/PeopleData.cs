using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemDataAccessLayar
{
    public class PeopleData
    {
        public static DataTable GetAllPerson()
        {
            DataTable People = new DataTable();


            using (SqlConnection conn = new SqlConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetAllPeople", conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(People);
                }
            }
            return People;
        }

        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName,
          short Gendor, DateTime DateOfBirth, string PhoneNumber, string Email, int Nationality, string PersonPhoto)
        {
            int PersonID = -1;

            string SP = @"SP_AddNewPerson";

            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                using (SqlCommand command = new SqlCommand(SP, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@SecondName", SecondName);
                    command.Parameters.AddWithValue("@ThirdName", (object)ThirdName ?? System.DBNull.Value);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Gendor", Gendor);
                    command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                    command.Parameters.AddWithValue("@Email", (object)Email ?? System.DBNull.Value);
                    command.Parameters.AddWithValue("@Nationality", Nationality);
                    command.Parameters.AddWithValue("@PersonPhoto", (object)PersonPhoto ?? System.DBNull.Value);

                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int ID))
                        {
                            PersonID = ID;
                        }

                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        connection.Close();
                    }

                }
            }
            return PersonID;
        }

        public static bool UpdatePerson(int PersonID,  string FirstName, string SecondName, string ThirdName,
            string LastName
       , string PhoneNumber, string Email, int Nationality, string PersonPhoto)
        {
            bool IsFound = false;
            string SP = @"SP_UpdatePerson";

            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                using (SqlCommand command = new SqlCommand(SP, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@SecondName", SecondName);
                    command.Parameters.AddWithValue("@ThirdName", (object)ThirdName ?? System.DBNull.Value);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                    command.Parameters.AddWithValue("@Email", (object)Email ?? System.DBNull.Value);
                    command.Parameters.AddWithValue("@Nationality", Nationality);
                    command.Parameters.AddWithValue("@PersonPhoto", (object)PersonPhoto ?? System.DBNull.Value);

                    try
                    {
                        connection.Open();

                        int Result = command.ExecuteNonQuery();

                        if (Result > 0)
                        {
                            IsFound = true;
                        }

                    }
                    catch (Exception ex)
                    {
                        IsFound = false;
                    }
                    finally
                    {
                        connection.Close();
                    }

                }
            }
            return IsFound;
        }

        public static bool DeletePerson(int PersonID)
        {
            bool IsFound = false;

            string SP = @"SP_DeletePerson";

            SqlConnection connection = new SqlConnection(ConnectionString.connectionstring);

            SqlCommand command = new SqlCommand(SP, connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                int Result = command.ExecuteNonQuery();

                if (Result > 0)
                {
                    IsFound = true;
                }

            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool IsPersonExist(int PersonID)
        {
            bool IsFound = false;

            string SP = "SP_IsPersonExist";

            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                using (SqlCommand command = new SqlCommand(SP, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            IsFound = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        IsFound = false;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }

            return IsFound;
        }

        public static bool IsPersonExist(string NationalNo)
        {
            bool IsFound = false;

            string SP = "SP_IsPersonExistByNationalNo";

            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                using (SqlCommand command = new SqlCommand(SP, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@NationalNo", NationalNo);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            IsFound = true;

                        }
                    }
                    catch (Exception ex)
                    {
                        IsFound = false;
                    }
                    finally
                    {
                        connection.Close();
                    }

                }
            }
            return IsFound;
        }

        public static bool FindByPersonID(int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName,
         ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref short Gendor
          , ref string PhoneNumber, ref string Email, ref int Nationality, ref string PersonPhoto)
        {
            bool IsFound = false;

            string SP = "SP_FindPersonByID";

            SqlConnection connection = new SqlConnection(ConnectionString.connectionstring);

            SqlCommand command = new SqlCommand(SP, connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    ThirdName = reader["ThirdName"] == DBNull.Value? "": (string)reader["ThirdName"];

                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (byte)reader["Gendor"];
                   
                    PhoneNumber = (string)reader["PhoneNumber"];

                    Email = reader["Email"] == DBNull.Value ? "" : (string)reader["Email"];

                    Nationality = (int)reader["Nationality"];

                    PersonPhoto = reader["PersonPhoto"] == DBNull.Value ? "" : (string)reader["PersonPhoto"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool FindByNationalNo(string NationalNo, ref int PersonID, ref string FirstName, ref string SecondName,
         ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref short Gendor
          , ref string PhoneNumber, ref string Email, ref int Nationality, ref string PersonPhoto)
        {
            bool IsFound = false;

            string Quere = "SP_FindPersonByNationalNo";

            SqlConnection connection = new SqlConnection(ConnectionString.connectionstring);

            SqlCommand command = new SqlCommand(Quere, connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    ThirdName = reader["ThirdName"] == DBNull.Value ? "" : (string)reader["ThirdName"];

                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (byte)reader["Gendor"];

                    PhoneNumber = (string)reader["PhoneNumber"];

                    Email = reader["Email"] == DBNull.Value ? "" : (string)reader["Email"];

                    Nationality = (int)reader["Nationality"];

                    PersonPhoto = reader["PersonPhoto"] == DBNull.Value ? "" : (string)reader["PersonPhoto"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }


        public static bool FindByEmail(string Email, ref int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName,
         ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref short Gendor
          , ref string PhoneNumber, ref int Nationality, ref string PersonPhoto)
        {
            bool IsFound = false;

            string SP = "SP_FindByEmail";

            SqlConnection connection = new SqlConnection(ConnectionString.connectionstring);

            SqlCommand command = new SqlCommand(SP, connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Email", Email);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    PersonID = (int)reader["PersonID"];
                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    ThirdName = reader["ThirdName"] == DBNull.Value ? "" : (string)reader["ThirdName"];

                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (byte)reader["Gendor"];

                    PhoneNumber = (string)reader["PhoneNumber"];

                    Nationality = (int)reader["Nationality"];

                    PersonPhoto = reader["PersonPhoto"] == DBNull.Value ? "" : (string)reader["PersonPhoto"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

    }

}

