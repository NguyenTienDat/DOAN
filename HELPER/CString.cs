using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HELPER
{
    public class CString
    {
        public static String To2Digit(String p_Value)
        {
            if (p_Value.Length == 2)
                return p_Value;
            else
                return "0" + p_Value;
        }
        public static string RemoveAbnormalCharacter(string p_str) {
            return p_str.Replace("'", "");
        }
    }
}
