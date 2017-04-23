using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.UI;
using System.Web.UI.WebControls;

namespace HELPER
{
    public class FileHelper
    {
        public static void SaveFile(string file, string content)
        {
            try
            {
                StreamWriter sw = new StreamWriter(file);
                sw.Write(content);
                sw.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ReadFile(string fileName)
        {
            StreamReader read = new StreamReader(fileName);
            string line = string.Empty;
            StringBuilder KQ = new StringBuilder();
            while ((line = read.ReadLine()) != null)
            {
                KQ.AppendLine(line);
                KQ.Append(Environment.NewLine);
            }
            read.Close();
            return KQ.ToString();
        }


        public static void ReadAllLines(TextBox txt, string filePath)
        {
            String[] allLines = System.IO.File.ReadAllLines(filePath);

            for (int i = 0; i < allLines.Length; i++)
            {
                txt.Text += allLines[i] + Environment.NewLine;
            }
        }
    }
}
