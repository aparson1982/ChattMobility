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
                MessageBox.Show("Successfully Closed Connection");
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
            
        }

        public void Update()
        {
            
        }

        public void Delete()
        {
            
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

    }
}
