using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace HELPER
{
    public class CFile
    {
        public static String GetUniqueFileName(String sFileName) {
            return  DateTime.Now.Ticks + "_" + sFileName ;
        }
        
    }
}
