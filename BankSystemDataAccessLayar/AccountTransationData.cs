using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemDataAccessLayar
{
    public class AccountTransationData
    {
        public static DataTable GetAllAccountTransation(int UserAccountID)
        {
            DataTable AccountOperations = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConnectionString.connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetAllAccountTransation", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserAccountID", UserAccountID);

                    try
                    {
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(AccountOperations);

                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            return AccountOperations;
        }
    }
}
