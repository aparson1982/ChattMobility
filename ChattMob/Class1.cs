using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ChattMob
{
    class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public DBConnect()
        {
            Initialize();
        }

        public void Initialize()
        {
            server = "localhost";
            database = "chattmob";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" +
                               "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        }

        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                MessageBox.Show("Connection Success");
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact Adam Parson");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return true;
            }
        
        }

        public void Insert()
        {
            string query = "INSERT INTO customer_table (FIRST_NAME, LAST_NAME, EMAIL, PHONE) VALUES('TestFirst', 'TestLast', 'tftl@gmail.com', '4236371925')";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        public void Update()
        {
            string query = "UPDATE customer_table SET FIRST_NAME='ChangeFirst', LAST_NAME='ChangeLast', EMAIL='ChangeEmail', PHONE='5555555555' WHERE FIRST_NAME='TestFirst'";

            if (this.OpenConnection()==true)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }

        }

        public void Delete()
        {
            string query = "DELETE FROM customer_table WHERE FIRST_NAME='ChangeFirst'";
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //public List <string> [] Select()
        //{
            
        //}

        //public int Count()
        //{
            
        //}

        public void Backup()
        {
            
        }

        public void Restore()
        {
            
        }

        public List <string> [] Select()
        {
            
        }

    }
}
