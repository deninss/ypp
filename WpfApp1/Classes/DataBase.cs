using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Classes
{
    public class DataBase
    {
        public static DataTable Select(string selectSQL)
        {
            DataTable dataTable = new DataTable("database");
            SqlConnection sqlConnection = new SqlConnection("server =SD\\ADM; Trusted_Connection = No; DataBase =YP-01; User =sa; PWD =Asdfg123!");
            sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = selectSQL;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
    }
}
