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
        internal class TextFileParser
        {
            private List<object> list = new List<object>();

            public void TxtParser()
            {
                string line;
                using (StreamReader file = new StreamReader(@"C:\Users\Robert\Music\test.txt"))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        char[] delimiters = new char[] { '\t' };
                        string[] parts = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var part in parts)
                        {
                            list.Add(part);
                        }
                    }
                    foreach (var item in list)
                    {
                        Console.WriteLine(item);
                    }
                    file.Close();
                }
            }
        }
    }
}