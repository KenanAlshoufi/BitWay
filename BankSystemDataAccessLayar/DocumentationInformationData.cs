using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemDataAccessLayar
{
    public class DocumentationInformationData
    {
        public static int AddNewDocumentationInformation(int AccountID, string Address, string FrontImageoftheID,
            string BackImageoftheID)
        {
            int DocumentationInformationID = -1;

            string SP = @"SP_AddNewDocumentationInformation";

            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                using (SqlCommand command = new SqlCommand(SP, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@AccountID", AccountID);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@FrontImageoftheID", FrontImageoftheID);
                    command.Parameters.AddWithValue("@BackImageoftheID", BackImageoftheID);


                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int ID))
                        {
                            DocumentationInformationID = ID;
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
            return DocumentationInformationID;
        }

        public static bool IsDocumentationInformationExist(int AccountID)
        {
            bool IsFound = false;

            string SP = "SP_IsDocumentationInformationExist";

            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                using (SqlCommand command = new SqlCommand(SP, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@AccountID", AccountID);

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

        public static bool IsAccountVerified(int AccountID)
        {
            bool IsFound = false;

            string SP = "SP_IsAccountVerified";

            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                using (SqlCommand command = new SqlCommand(SP, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@AccountID", AccountID);

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

        public static bool FindDocumentationInformationByAccountID(int AccountID, ref int DocumentationInformationID, ref string Address,
            ref string FrontImageoftheID, ref string BackImageoftheID, ref DateTime DocumentationInformationDate
            , ref bool IsVerified)
        {
            bool IsFound = false;

            string SP = "SP_FindDocumentationInformationByAccountID";

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
                                DocumentationInformationID = (int)reader["DocumentationInformationID"];
                                Address = (string)reader["Address"];
                                FrontImageoftheID = (string)reader["FrontImageoftheID"];

                                BackImageoftheID = (string)reader["BackImageoftheID"];

                                DocumentationInformationDate = (DateTime)reader["DocumentationInformationDate"];
                                IsVerified = (bool)reader["IsVerified"];
                            }

                        }
                    }
                    catch
                    {
                        IsFound = false;
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
                    catch
                    {
                        IsFound = false;
                    }
                   
                }
            }
            return IsFound;
        }
    }
}
