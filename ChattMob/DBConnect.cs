using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ChattMob
{
    internal class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        private List<object> list = new List<object>();

        public DBConnect()
        {
            Initialize();
        }

        public void Initialize()
        {
            server = "localhost";
            database = "chattmob";
            uid = "root";
            password = "T0mgr33n";
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

        public bool CloseConnection()
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

        #region Insert Method

        public void Insert()
        {
            for (int j = 0; j < 20; j++)
                try
                {
                    string line;
                    string query = null;
                    using (StreamReader file = new StreamReader(@"C:\Users\Robert\Desktop\Chatt Mobility\Download Here\testdelete.txt"))
                    {
                        string firstName = null;
                        string lastName = null;
                        string email = null;
                        string phone = null;
                        string date = null;
                        string product = null;
                        string manufacturer = null;
                        string description = null;

                        if (this.OpenConnection() == true)
                        {
                            while ((line = file.ReadLine()) != null)
                            {
                                char[] delimiters = new char[] { '\t' };
                                string[] parts = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                                if (parts.Length > 0)
                                {
                                    for (int i = 0; i < parts.Length - 7; i++)
                                    {
                                        // list.Add(part);
                                        firstName = Regex.Replace(parts[i], @"[^\w\s]", "");
                                        lastName = Regex.Replace(parts[i + 1], @"[^\w\s]", ""); ;
                                        email = Regex.Replace(parts[i + 2], @"[^\w\s.@-_]", ""); ;
                                        phone = Regex.Replace(parts[i + 3], @"[^\w\s-]", "");
                                        date = parts[i + 4];
                                        product = Regex.Replace(parts[i + 5], @"[^\w\s]", "");
                                        manufacturer = Regex.Replace(parts[i + 6], @"[^\w\s]", "");
                                        description = Regex.Replace(parts[i + 7], @"[^\w\s,-.?!]", "");
                                    }

                                    query =
                                        "INSERT INTO chattmob.customer_table (FIRST_NAME, LAST_NAME, EMAIL, PHONE, DATE_CREATED, PRODUCT_TYPE, MANUFACTURER, DESCRIPTION) VALUES('" +
                                        firstName + "', '" + lastName + "', '" + email + "', '" + phone + "', '" + date + "', '" + product + "', '" + manufacturer + "', '" + description + "');";

                                    MySqlCommand cmd = new MySqlCommand(query, connection);

                                    cmd.ExecuteNonQuery();
                                }
                            }
                            this.CloseConnection();
                        }
                    }

                    j = 999;
                }
                catch
                {
                    System.Threading.Thread.Sleep(100);
                }
        }

        #endregion Insert Method

        #region LoadDataTable

        public void LoadDataTable()
        {
        }

        #endregion LoadDataTable

        public void Update()
        {
            string query = "UPDATE customer_table SET FIRST_NAME='ChangeFirst', LAST_NAME='ChangeLast', EMAIL='ChangeEmail', PHONE='5555555555' WHERE FIRST_NAME='TestFirst'";

            if (this.OpenConnection() == true)
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

        public int Count()
        {
            string query = "SELECT Count(*) FROM customer_table";
            int Count = -1;

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                Count = int.Parse(cmd.ExecuteScalar() + "");
                this.CloseConnection();
                return Count;
            }
            else
            {
                return Count;
            }
        }

        public void Backup()
        {
            try
            {
                DateTime Time = DateTime.Now;
                int year = Time.Year;
                int month = Time.Month;
                int day = Time.Day;
                int hour = Time.Hour;
                int minute = Time.Minute;
                int second = Time.Second;
                int millisecond = Time.Millisecond;

                string path;

                path = "C:\\MySqlBackup" + year + "-" + month + "-" + day + "-" + hour + "-" + minute + "-" + second +
                       "-" + millisecond + "-" + ".sql";

                StreamWriter file = new StreamWriter(path);

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysqldump";
                psi.RedirectStandardInput = false;
                psi.RedirectStandardOutput = true;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", uid, password, server, database);
                psi.UseShellExecute = false;

                Process process = Process.Start(psi);

                string output;
                output = process.StandardOutput.ReadToEnd();
                file.WriteLine(output);
                process.WaitForExit();
                file.Close();
                process.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error, unable to backup!");
            }
        }

        public void Restore()
        {
            try
            {
                string path;
                path = "C:\\MySqlBackup.sql";
                StreamReader file = new StreamReader(path);
                string input = file.ReadToEnd();
                file.Close();

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysql";
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = false;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", uid, password, server, database);
                psi.UseShellExecute = false;

                Process process = Process.Start(psi);
                process.StandardInput.WriteLine(input);
                process.StandardInput.Close();
                process.WaitForExit();
                process.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error, unable to Restore!");
            }
        }

        public List<string>[] Select()
        {
            string query = "SELECT * FROM customer_table";
            List<string>[] list = new List<string>[6];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();
            list[4] = new List<string>();
            list[5] = new List<string>();

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    list[0].Add(dataReader["CUSTOMER_ID"] + "");
                    list[1].Add(dataReader["FIRST_NAME"] + "");
                    list[2].Add(dataReader["LAST_NAME"] + "");
                    list[3].Add(dataReader["EMAIL"] + "");
                    list[4].Add(dataReader["PHONE"] + "");
                    list[5].Add(dataReader["DATE_CREATED"] + "");
                }
                dataReader.Close();
                this.CloseConnection();
                return list;
            }
            else
            {
                return list;
            }
        }
    }
}