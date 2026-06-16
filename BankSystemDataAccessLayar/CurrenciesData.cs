using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemDataAccessLayar
{
    public class CurrenciesData
    {
        public static bool FindCurrencyByID(int Id, ref string CurrencyName ,ref string CurrencyCode,ref string
            Symbol)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(ConnectionString.connectionstring);

            string SP = "SP_FindCurrencyByID";


            SqlCommand command = new SqlCommand(SP, connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id", Id);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    CurrencyName = (string)reader["CurrencyName"];
                    CurrencyCode = (string)reader["CurrencyCode"];
                    Symbol = (string)reader["Symbol"];

                }
                else
                {
                    IsFound = false;
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

        public static bool FindCurrencyByName(ref int Id,  string CurrencyName, ref string CurrencyCode, ref string
          Symbol)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(ConnectionString.connectionstring);

            string SP = "SP_FindCurrencyByName";


            SqlCommand command = new SqlCommand(SP, connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CurrencyName", CurrencyName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    Id = (int)reader["Id"];
                    CurrencyCode = (string)reader["CurrencyCode"];
                    Symbol = (string)reader["Symbol"];

                }
                else
                {
                    IsFound = false;
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

        public static bool FindCurrencyByCode(ref int Id,ref string CurrencyName, string CurrencyCode, ref string
          Symbol)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(ConnectionString.connectionstring);

            string SP = "SP_FindCurrencyByCode";


            SqlCommand command = new SqlCommand(SP, connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CurrencyCode", CurrencyCode);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    Id = (int)reader["Id"];
                    CurrencyName = (string)reader["CurrencyName"];
                    Symbol = (string)reader["Symbol"];

                }
                else
                {
                    IsFound = false;
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

        public static bool IsCurrencyExist(string CurrencyCode)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(ConnectionString.connectionstring);

            string SP = " SP_IsCurrencyExist";


            SqlCommand command = new SqlCommand(SP, connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CurrencyCode", CurrencyCode);

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                IsFound = (Result != null);


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

        public static DataTable GetAllCurrencies()
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.connectionstring);

            string SP = "SP_GetAllCurrencies";

            SqlCommand command = new SqlCommand(SP, connection);

            command.CommandType = CommandType.StoredProcedure;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    dataTable.Load(reader);
                }

                reader.Close();


            }
            catch (Exception ex)
            {

            }

            finally { connection.Close(); }

            return dataTable;
        }
    }
}
