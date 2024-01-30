using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Course_Work
{
   internal class DataBase
    {

        SqlConnection sqlConnection = new SqlConnection
            (@"Data Source = DESKTOP-DB318D2; Initial Catalog = CASINOBASE; Integrated Security = True");

        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }
        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection getConnection() 
        {
            return sqlConnection;
        }

    }
}
