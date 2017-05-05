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
            loadTable();
        }

        private MySqlConnection connection;
        private MySqlCommand cmdDataBase;
        private MySqlDataAdapter sda;
        private DataTable dbdataset;
        private readonly DBConnect _connect = new DBConnect();
        private readonly RequestFile _requestNewJobs = new RequestFile();
        private readonly RequestParser _requestParser = new RequestParser();

        private void FetchJobs_Click(object sender, EventArgs e)
        {
            _requestNewJobs.RequestFromWeb();

            //_connect.OpenConnection();

            _connect.Insert();
        }

        private void loadTable()
        {
            string server = "localhost";
            string database = "chattmob";
            string uid = "root";
            string password = "T0mgr33n";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" +
                               "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
            cmdDataBase = new MySqlCommand("SELECT * FROM chattmob.customer_table;", connection);

            try
            {
                sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                dbdataset = new DataTable();
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

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dbdataset);
            DV.RowFilter = string.Format("LAST_NAME LIKE '%{0}%' OR FIRST_NAME LIKE '%{0}%' OR EMAIL LIKE '%{0}%' OR PHONE LIKE '%{0}%'", searchBox.Text);
            //DV.RowFilter = string.Format("SELECT customer_table.* FROM chattmob.customer_table JOIN( SELECT CUSTOMER_ID, IFNULL(FIRST_NAME, '')+IFNULL(LAST_NAME,'')+IFNULL(EMAIL,'')+IFNULL(PHONE,'') concatenated FROM chattmob.customer_table) AS T ON T.CUSTOMER_ID = customer_table.CUSTOMER_ID WHERE t.concatenated LIKE '%{0}%'", searchBox.Text);
            dataGridView1.DataSource = DV;
        }

        private void FirstNameTextBox_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dbdataset);
            DV.RowFilter = string.Format("FIRST_NAME LIKE '%{0}%'", FirstNameTextBox.Text);
            dataGridView1.DataSource = DV;
        }

        private void LastNameTextBox_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dbdataset);
            DV.RowFilter = string.Format("LAST_NAME LIKE '%{0}%'", LastNameTextBox.Text);
            dataGridView1.DataSource = DV;
        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dbdataset);
            DV.RowFilter = string.Format("EMAIL LIKE '%{0}%'", emailTextBox.Text);
            dataGridView1.DataSource = DV;
        }

        private void phoneTextBox_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dbdataset);
            DV.RowFilter = string.Format("PHONE LIKE '%{0}%'", phoneTextBox.Text);
            dataGridView1.DataSource = DV;
        }

        private void productTextBox_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dbdataset);
            DV.RowFilter = string.Format("PRODUCT LIKE '%{0}%'", productTextBox.Text);
            dataGridView1.DataSource = DV;
        }

        private void manufacturerTextBox_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dbdataset);
            DV.RowFilter = string.Format("MANUFACTURER LIKE '%{0}%'", manufacturerTextBox.Text);
            dataGridView1.DataSource = DV;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dbdataset);
            DV.RowFilter = string.Format("DESCRIPTION LIKE '%{0}%'", textBox1.Text);
            dataGridView1.DataSource = DV;
        }
    }
}