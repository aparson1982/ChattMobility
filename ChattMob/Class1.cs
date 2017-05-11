using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ChattMob
{
    internal class FormOperations
    {
        private MySqlConnection connection;
        private MySqlCommand cmdDataBase;
        private CMServiceManager cms = new CMServiceManager();

        public MySqlConnection connectToDB()
        {
            string server = "localhost";
            string database = "chattmob";
            string uid = "root";
            string password = "T0mgr33n";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" +
                               "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
            return connection;
        }

        public MySqlCommand LoadPrimaryTable()
        {
            cmdDataBase = new MySqlCommand("SELECT DISTINCT LAST_NAME, FIRST_NAME, EMAIL, PHONE FROM chattmob.customer_table ORDER BY LAST_NAME;", connectToDB());

            return cmdDataBase;
        }
    }
}