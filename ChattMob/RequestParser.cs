using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChattMob
{
    public class RequestParser
    {
        public static string GetCurrentDirectory()
        {
            string startupPath = System.AppDomain.CurrentDomain.BaseDirectory;
            var pathItems = startupPath.Split(Path.DirectorySeparatorChar);
            string projectPath = String.Join(Path.DirectorySeparatorChar.ToString(), (pathItems.Length - 3));
            
            return projectPath;
        }

        public static string GetCurrentWorkingDirectory()
        {
           
            string fileName = String.Format(@"{0}\NewJobs\testdelete.txt", Environment.CurrentDirectory);
            return fileName;
        }
    }
}
