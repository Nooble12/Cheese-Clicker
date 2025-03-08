using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Cheese_Clicker.Utilities
{
    public class ReadTextFile
    {
        private string filePath;
        public ReadTextFile(string inFilePath)
        {
            filePath = inFilePath;
        }

        public string ReadFile()
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                StreamReader sr = new StreamReader(filePath);
              
                string line = sr.ReadLine();

                while (line != null)
                {
                    sb.AppendLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch(Exception e)
            {
                Debug.WriteLine("Error could not read text file! " + e);
                return "Error could not read text file!";
            }
            return sb.ToString();
        }
    }
}
