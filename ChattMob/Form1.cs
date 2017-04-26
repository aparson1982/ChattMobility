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
        DBConnect Connect = new DBConnect();
        public CMServiceManager()
        {
            InitializeComponent();
        }
       
        RequestFile RequestNewJobs = new RequestFile();

        private void FetchJobs_Click(object sender, EventArgs e)
        {
            
            
            RequestNewJobs.RequestFromWeb();

            Connect.OpenConnection();


        }

    }
}
