using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace ChattMob
{
    public class RequestParser
    {
        private List<string> list = new List<string>();

        private string server;
        private string database;
        private string uid;
        private string password;

        public void Insert()
        {
            server = "localhost";
            database = "chattmob";
            uid = "root";
            password = "T0mgr33n";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" +
                               "PASSWORD=" + password + ";";
            // connection = new MySqlConnection(connectionString);

            string line;

            using (StreamReader file = new StreamReader(@"C:\Users\Robert\Music\test.txt"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    char[] delimiters = new char[] { '\t' };
                    string[] parts = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var part in parts)
                    {
                        list.Add(part);
                    }
                }
            }

            // query = "INSERT INTO customer_table (FIRST_NAME, LAST_NAME, EMAIL, PHONE, DATE_CREATED) VALUES(@first, @last, @email, @phone, @date)";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText =
                    "INSERT INTO customer_table (FIRST_NAME, LAST_NAME, EMAIL, PHONE) VALUES(@first, @last, @email, @phone)";
                cmd.Parameters.AddWithValue("@first", 0);
                cmd.Parameters.AddWithValue("@last", 0);
                cmd.Parameters.AddWithValue("@email", 0);
                cmd.Parameters.AddWithValue("@phone", 0);
                //cmd.Parameters.AddWithValue("@date", 0);

                for (int i = 0; i < list.Count; i++)
                {
                    cmd.Parameters["@first"].Value = list[i];
                    cmd.Parameters["@last"].Value = list[i + 1];
                    cmd.Parameters["@email"].Value = list[i + 2];
                    cmd.Parameters["@phone"].Value = list[i + 3];
                    // cmd.Parameters["@date"].Value = list[i + 4];
                    cmd.ExecuteNonQuery();
                }

                // MySqlCommand cmd = new MySqlCommand(query, connection);
            }
        }
    }
}