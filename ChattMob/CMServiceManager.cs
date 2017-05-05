using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using MySql.Data.MySqlClient;

namespace ChattMob
{
    public partial class CMServiceManager : Form
    {
        public CMServiceManager()
        {
            InitializeComponent();
        }

        private readonly DBConnect _connect = new DBConnect();
        private readonly RequestFile _requestNewJobs = new RequestFile();
        private readonly RequestParser _requestParser = new RequestParser();

        private void FetchJobs_Click(object sender, EventArgs e)
        {
            _requestNewJobs.RequestFromWeb();

            //_connect.OpenConnection();

            _connect.Insert();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            string server = "localhost";
            string database = "chattmob";
            string uid = "root";
            string password = "T0mgr33n";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" +
                               "PASSWORD=" + password + ";";
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmdDataBase = new MySqlCommand("SELECT * FROM chattmob.customer_table;", connection);

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}