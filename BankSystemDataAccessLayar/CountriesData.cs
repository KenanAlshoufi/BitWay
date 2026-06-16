using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemDataAccessLayar
{
    public class CountriesData
    {
        public static bool FindCountryByID(int CountryID, ref string CountryName)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(ConnectionString.connectionstring);

            string SP = "SP_FindCountryByID";


            SqlCommand command = new SqlCommand(SP, connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    CountryName = (string)reader["CountryName"];

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

        public static bool FindCountryByName(ref int CountryID, string CountryName)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(ConnectionString.connectionstring);

            string SP = "SP_FindCountryByName";


            SqlCommand command = new SqlCommand(SP, connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    CountryID = (int)reader["CountryID"];

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

        public static bool IsCountryExist(string CountryName)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                string SP = " SP_IsCountryExist";
                using (SqlCommand command = new SqlCommand(SP, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@CountryName", CountryName);

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
                }
            }
            return IsFound;
        }

        public static DataTable GetAllCountries()
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = new SqlConnection(ConnectionString.connectionstring);

            string SP = "SP_GetAllCountries";

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
