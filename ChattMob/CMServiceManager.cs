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
            //_requestNewJobs.RequestFromWeb();

            //_connect.OpenConnection();

            _connect.Insert();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
        }
    }
}