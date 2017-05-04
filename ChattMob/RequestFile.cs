using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace ChattMob
{
    public class RequestFile
    {
        private bool downloadComplete = false;
        /*private string filepath;

        public RequestFile(string filepath)
        {
            this.filepath = filepath;
        }

        public IEnumerable<ClientRecord> ParseFileForRecords()
        {
            List<ClientRecord> records = new List<ClientRecord>();

            if (File.Exists(filepath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (reader.Peek() >= 0)
                    {
                        string[] lineValues = reader.ReadLine().Split(':');
                    }
                }
            }
        }*/

        public async void RequestFromWeb()
        {
            //Downloads the text file then deletes the file at the url.

            //  String logFilePath = RequestParser.GetCurrentWorkingDirectory() + "\\NewJobs\\testdelete.txt";
            using (var wc = new System.Net.WebClient())
            {
                await wc.DownloadFileTaskAsync(new Uri("http://problemdescription.000webhostapp.com/testdelete.txt"), @"C:\Users\Robert\Desktop\Chatt Mobility\Download Here\testdelete.txt");  //directory needs to be fixed
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://problemdescription.000webhostapp.com/clearfile.php");
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        }
    }
}