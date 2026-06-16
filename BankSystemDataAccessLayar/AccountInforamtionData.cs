using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemDataAccessLayar
{
    public class AccountInforamtionData
    {
        public static DataTable GetAllAccountInformation()
        {
            DataTable AccountInformation = new DataTable();

            using (SqlConnection conn = new SqlConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetAllAccountInformation", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(AccountInformation);
                }
            }
            return AccountInformation;
        }

        public static bool UpdateAccountInformation(int AccountID, string Username, string Password,
            decimal TotalAmount, int Currency, bool IsAccountVerified,string QrAccountID)
        {
            bool IsFound = false;
            string SP = @"SP_UpdateAccountInformation";

            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                using (SqlCommand command = new SqlCommand(SP, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@AccountID", AccountID);
                    command.Parameters.AddWithValue("@Username", Username);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@TotalAmount", TotalAmount);
                    command.Parameters.AddWithValue("@Currency", Currency);
                    command.Parameters.AddWithValue("@IsAccountVerified", IsAccountVerified);
                    command.Parameters.AddWithValue("@QrAccountID", QrAccountID);

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


        public static int AddAccountInformation(string AccountInformationID, int PersonID, string Username, string Password,
            decimal TotalAmount, int Currency, bool IsAccountVerified, DateTime AccountCreationDate, string QrAccountID)
        {
            int AccountID = -1;

            string SP = @"SP_AddNewAccountInformation";

            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                using (SqlCommand command = new SqlCommand(SP, connection))
                {
                   
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@AccountInformationID", AccountInformationID);
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@Username", Username);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@TotalAmount", TotalAmount);
                    command.Parameters.AddWithValue("@Currency", Currency);
                    command.Parameters.AddWithValue("@IsAccountVerified", IsAccountVerified);
                    command.Parameters.AddWithValue("@AccountCreationDate", AccountCreationDate);
                    command.Parameters.AddWithValue("@QrAccountID", QrAccountID);

                    SqlParameter OutputParameterID = new SqlParameter("@AccountID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(OutputParameterID);

                    try
                    {
                        connection.Open();

                        command.ExecuteNonQuery();

                        AccountID = (int)command.Parameters["@AccountID"].Value;


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
            return AccountID;
        }

        public static bool LogIn(string Username, string Password)
        {
            bool IsFound = false;

            string SP = "SP_LogInToAccount";

            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                using (SqlCommand command = new SqlCommand(SP, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Username", Username);
                    command.Parameters.AddWithValue("@Password", Password);

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

        public static bool LogInByEmail(string Email, string Password)
        {
            bool IsFound = false;

            string SP = "SP_LogInToAccountByEmail";

            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                using (SqlCommand command = new SqlCommand(SP, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@Password", Password);

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

        public static bool AccountVerified(int AccountID)
        {
            bool IsFound = false;
            string SP = @"SP_AccountVerified";

            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                using (SqlCommand command = new SqlCommand(SP, connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@AccountID", AccountID);


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


        public static bool FindByAccountID(int AccountID, ref string AccountInformationID, ref int PersonID, ref string Username
            , ref string Password,
            ref decimal TotalAmount, ref int Currency, ref bool IsAccountVerified, ref DateTime AccountCreationDate,ref string QrAccountID)
        {
            bool IsFound = false;

            string SP = "SP_FindAccountInformationByID";

            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                using (SqlCommand command = new SqlCommand(SP, connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@AccountID", AccountID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;
                                AccountInformationID = (string)reader["AccountInformationID"];
                                PersonID = (int)reader["PersonID"];
                                Username = (string)reader["Username"];
                                Password = (string)reader["Password"];
                                TotalAmount = (decimal)reader["TotalAmount"];
                                Currency = (int)reader["Currency"];
                                IsAccountVerified = (bool)reader["IsAccountVerified"];
                                AccountCreationDate = (DateTime)reader["AccountCreationDate"];
                                QrAccountID = (string)reader["QrAccountID"];

                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        IsFound = false;
                    }
                }
            }
            return IsFound;
        }

        public static bool FindByPersonID(int PersonID, ref int AccountID, ref string AccountInformationID, ref string Username
           , ref string Password,
           ref decimal TotalAmount, ref int Currency, ref bool IsAccountVerified, ref DateTime AccountCreationDate, ref string QrAccountID)
        {
            bool IsFound = false;

            string SP = "SP_FindAccountInformationByPersonID";

            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                using (SqlCommand command = new SqlCommand(SP, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;
                                AccountInformationID = (string)reader["AccountInformationID"];
                                AccountID = (int)reader["AccountID"];
                                Username = (string)reader["Username"];
                                Password = (string)reader["Password"];
                                TotalAmount = (decimal)reader["TotalAmount"];
                                Currency = (int)reader["Currency"];
                                IsAccountVerified = (bool)reader["IsAccountVerified"];
                                AccountCreationDate = (DateTime)reader["AccountCreationDate"];
                                QrAccountID = (string)reader["QrAccountID"];
                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        IsFound = false;
                    }


                }
            }
            return IsFound;
        }

        public static bool FindByUsername(string Username, ref int AccountID, ref string AccountInformationID, ref int PersonID
           , ref string Password,
           ref decimal TotalAmount, ref int Currency, ref bool IsAccountVerified, ref DateTime AccountCreationDate, ref string QrAccountID)
        {
            bool IsFound = false;

            string SP = "SP_FindAccountInformationByUsername";

            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {


                using (SqlCommand command = new SqlCommand(SP, connection))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Username", Username);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {


                            if (reader.Read())
                            {
                                IsFound = true;
                                AccountInformationID = (string)reader["AccountInformationID"];
                                AccountID = (int)reader["AccountID"];
                                PersonID = (int)reader["PersonID"];
                                Password = (string)reader["Password"];
                                TotalAmount = (decimal)reader["TotalAmount"];
                                Currency = (int)reader["Currency"];
                                IsAccountVerified = (bool)reader["IsAccountVerified"];
                                AccountCreationDate = (DateTime)reader["AccountCreationDate"];
                                QrAccountID = (string)reader["QrAccountID"];
                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        IsFound = false;
                    }
                }
            }

            return IsFound;
        }


        public static bool FindByAccountInformationID(string AccountInformationID, ref int AccountID, ref string Username, ref int PersonID
          , ref string Password,
          ref decimal TotalAmount, ref int Currency, ref bool IsAccountVerified, ref DateTime AccountCreationDate,ref  string QrAccountID)
        {
            bool IsFound = false;

            string SP = "SP_FindByAccountInformationID";

            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                using (SqlCommand command = new SqlCommand(SP, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@AccountInformationID", AccountInformationID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;
                                Username = (string)reader["Username"];
                                AccountID = (int)reader["AccountID"];
                                PersonID = (int)reader["PersonID"];
                                Password = (string)reader["Password"];
                                TotalAmount = (decimal)reader["TotalAmount"];
                                Currency = (int)reader["Currency"];
                                IsAccountVerified = (bool)reader["IsAccountVerified"];
                                AccountCreationDate = (DateTime)reader["AccountCreationDate"];
                                QrAccountID = (string)reader["QrAccountID"];
                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        IsFound = false;
                    }

                }
            }
            return IsFound;
        }


        public static int Numberofusers()
        {
            int Numberofusers = -1;

            string SP = @"SP_Numberofusers";

            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                using (SqlCommand command = new SqlCommand(SP, connection))
                {
                    command.CommandType= CommandType.StoredProcedure;


                    SqlParameter parameter = new SqlParameter("@Numberofusers", DbType.Int32)
                    {
                        Direction= ParameterDirection.Output
                    };

                    command.Parameters.Add(parameter);

                    try
                    {
                        connection.Open();

                        command.ExecuteNonQuery();

                        Numberofusers = (int)command.Parameters["@Numberofusers"].Value;

                    }
                    catch (Exception ex)
                    {
                        Numberofusers = -1;
                    }

                }
            }

            return Numberofusers;
        }


        public static bool IsUserNameExist(string Username)
        {
            bool IsFound = false;

            string SP = "SP_IsUsernameExist";

            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                using (SqlCommand command = new SqlCommand(SP, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Username", Username);

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



    }
}
