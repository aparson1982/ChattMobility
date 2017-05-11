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
using System.Runtime.InteropServices;

namespace ChattMob
{
    public partial class CMServiceManager : Form
    {
        public CMServiceManager()
        {
            InitializeComponent();
            loadTable();

            tabControl1.DrawItem += new DrawItemEventHandler(tabControl1_DrawItem);

            //this.NativeTabControl2.AssignHandle(this.TabControl2.Handle);
        }

        private MySqlCommand _cmdDataBase;
        private MySqlDataAdapter _sda;
        private DataTable _dbdataset;
        private readonly DBConnect _connect = new DBConnect();
        private readonly RequestFile _requestNewJobs = new RequestFile();

        #region Textbox Strings

        private string firstName = "";
        private string lastName = "";
        private string email = "";
        private string phone = "";
        private string product = "";
        private string manufacturer = "";
        private DateTime fromDate;
        private DateTime toDate;
        private string toDates = "";
        private string fromDates = "";

        #endregion Textbox Strings

        private void FetchJobs_Click(object sender, EventArgs e)
        {
            _requestNewJobs.RequestFromWeb();

            //_connect.OpenConnection();

            _connect.Insert();
        }

        private void loadTable()
        {
            _cmdDataBase = new MySqlCommand("SELECT DISTINCT LAST_NAME, FIRST_NAME, EMAIL, PHONE FROM chattmob.customer_table ORDER BY LAST_NAME;", _connect.Initialize());

            try
            {
                _sda = new MySqlDataAdapter();
                _sda.SelectCommand = _cmdDataBase;
                _dbdataset = new DataTable();
                _sda.Fill(_dbdataset);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = _dbdataset;
                dataGridView1.DataSource = bSource;
                _sda.Update(_dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadCustomerTable()
        {
            _cmdDataBase = new MySqlCommand("SELECT PRODUCT_TYPE, MANUFACTURER, DESCRIPTION, DATE_CREATED FROM chattmob.customer_table WHERE FIRST_NAME='" + FirstNameCI.Text + "' OR LAST_NAME='" + LastnameCI + "' OR PHONE='" + PhoneCI + "';", _connect.Initialize());

            try
            {
                _sda = new MySqlDataAdapter();
                _sda.SelectCommand = _cmdDataBase;
                _dbdataset = new DataTable();
                _sda.Fill(_dbdataset);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = _dbdataset;
                dataGridViewCI.DataSource = bSource;
                _sda.Update(_dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(_dbdataset);
            DV.RowFilter = string.Format("LAST_NAME LIKE '%{0}%' OR FIRST_NAME LIKE '%{0}%' OR EMAIL LIKE '%{0}%' OR PHONE LIKE '%{0}%'", searchBox.Text);
            //DV.RowFilter = string.Format("SELECT customer_table.* FROM chattmob.customer_table JOIN( SELECT CUSTOMER_ID, IFNULL(FIRST_NAME, '')+IFNULL(LAST_NAME,'')+IFNULL(EMAIL,'')+IFNULL(PHONE,'') concatenated FROM chattmob.customer_table) AS T ON T.CUSTOMER_ID = customer_table.CUSTOMER_ID WHERE t.concatenated LIKE '%{0}%'", searchBox.Text);
            dataGridView1.DataSource = DV;
        }

        private void FirstNameTextBox_TextChanged(object sender, EventArgs e)
        {
            firstName = FirstNameTextBox.Text;
            AdvancedSearchBox();
        }

        private void LastNameTextBox_TextChanged(object sender, EventArgs e)
        {
            lastName = LastNameTextBox.Text;
            AdvancedSearchBox();
        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            email = emailTextBox.Text;
            AdvancedSearchBox();
        }

        private void phoneTextBox_TextChanged(object sender, EventArgs e)
        {
            phone = phoneTextBox.Text;
            AdvancedSearchBox();
        }

        private void productTextBox_TextChanged(object sender, EventArgs e)
        {
            product = productTextBox.Text;
            AdvancedSearchBox();
        }

        private void manufacturerTextBox_TextChanged(object sender, EventArgs e)
        {
            manufacturer = manufacturerTextBox.Text;
            AdvancedSearchBox();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(_dbdataset);
            DV.RowFilter = string.Format("DESCRIPTION LIKE '%{0}%'", textBox1.Text);
            dataGridView1.DataSource = DV;
        }

        private void AdvancedSearchBox()
        {
            DataView DV = new DataView(_dbdataset);
            DV.RowFilter = string.Format("FIRST_NAME LIKE '%" + firstName + "%' AND " + "LAST_NAME LIKE '%" + lastName + "%' AND " + "EMAIL LIKE '%" + email + "%' AND " + "PHONE LIKE '%" + phone + "%' AND " + "PRODUCT_TYPE LIKE '%" + product + "%' AND " + "MANUFACTURER LIKE '%" + manufacturer + "%'");
            dataGridView1.DataSource = DV;
        }

        private void fromDatePicker_ValueChanged(object sender, EventArgs e)
        {
            fromDate = this.fromDatePicker.Value.Date;
            fromDates = fromDate.ToString("yyyy-MM-dd");
            DateSearch();
        }

        private void toDatePicker_ValueChanged(object sender, EventArgs e)
        {
            toDate = this.toDatePicker.Value.Date;
            toDates = toDate.ToString("yyyy-MM-dd");
            DateSearch();
        }

        private void DateSearch()
        {
            DataView DV = new DataView(_dbdataset);
            DV.RowFilter = string.Format("SELECT * FROM chattmob.customer_table WHERE 'DATE_CREATED' BETWEEN '" + fromDates + "' AND '" + toDates + "';");
            dataGridView1.DataSource = DV;
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void SelectedRows()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string lastName = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
                string firstName = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
                string emailtxt = dataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;
                string phonetxt = dataGridView1.SelectedRows[0].Cells[3].Value + string.Empty;

                FirstNameCI.Text = firstName;
                LastnameCI.Text = lastName;
                EmailCI.Text = emailtxt;
                PhoneCI.Text = phonetxt;
            }
        }

        private void SelectedRowsCI()
        {
            if (dataGridViewCI.SelectedRows.Count > 0)
            {
                string product_type = dataGridViewCI.SelectedRows[0].Cells[0].Value + string.Empty;
                string manufacturer_type = dataGridViewCI.SelectedRows[0].Cells[1].Value + string.Empty;
                string description_type = dataGridViewCI.SelectedRows[0].Cells[2].Value + string.Empty;
                string date_type = dataGridViewCI.SelectedRows[0].Cells[3].Value + string.Empty;

                ProductCI.Text = product_type;
                ManufacturerCI.Text = manufacturer_type;
                DescriptionCI.Text = description_type;
                DateCI.Text = date_type;
            }
        }

        private void tabControl1_DrawItem(Object sender, DrawItemEventArgs e)
        {
            switch (e.Index)
            {
                case 0:
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(120, 47, 127)), e.Bounds);
                    break;

                case 1:
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(75, 75, 75)), e.Bounds);
                    break;

                default:
                    break;
            }
            Rectangle paddedBounds = e.Bounds;
            paddedBounds.Inflate(-3, -3);
            e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, this.Font, SystemBrushes.HighlightText,
                paddedBounds);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRows();
            LoadCustomerTable();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
        }

        private void dataGridViewCI_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRowsCI();
        }
    }
}