using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemDataAccessLayar
{
    public class AccountOperationsData
    {

        public static DataTable GetAllAccountOperations(int UserAccountID)
        {
            DataTable AccountOperations = new DataTable();


            using (SqlConnection conn = new SqlConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetAllAccountOperations", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserAccountID", UserAccountID);

                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(AccountOperations);
                }
            }
            return AccountOperations;
        }

        public static int AddNewAccountOperations(decimal Amount,int SenderAccount ,int RecipientAccount
            ,int CurrencyID)
        {
            int UserAccountoperationsID = -1;

            string SP = @"SP_AddNewAccountOperations";

            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                using (SqlCommand command = new SqlCommand(SP, connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Amount", Amount);
                    command.Parameters.AddWithValue("@SenderAccount", SenderAccount);
                    command.Parameters.AddWithValue("@RecipientAccount", RecipientAccount);
                    command.Parameters.AddWithValue("@CurrencyID", CurrencyID);
                   
                   
                    
                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int ID))
                        {
                            UserAccountoperationsID = ID;
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
            return UserAccountoperationsID;
        }


        public static bool FindAccountOperationsByID(int UserAccountoperationsID, ref decimal Amount, ref int SenderAccount,
            ref int RecipientAccount, ref int CurrencyID, ref DateTime DateofOperation)
        {
            bool IsFound = false;

            string SP = "SP_FindAccountOperationsByID";

            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                using (SqlCommand command = new SqlCommand(SP, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@UserAccountoperationsID", UserAccountoperationsID);

                    try
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            IsFound = true;

                            Amount = (decimal)reader["Amount"];
                            SenderAccount = (int)reader["SenderAccount"];
                            RecipientAccount = (int)reader["RecipientAccount"];
                            CurrencyID = (int)reader["CurrencyID"];
                            DateofOperation = (DateTime)reader["DateofOperation"];

                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        IsFound = false;
                    }
                }
            }

            return IsFound;
        }




    }
}
