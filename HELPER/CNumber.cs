using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
namespace HELPER
{
    public class CNumber
    {
        public static bool IsNumber(String value)
        {
            float fOut;
            return float.TryParse(value, out fOut);

        }
        public static int ToNumber(String value)
        {
            int iOut=0;
            int.TryParse(value, out iOut);
            return iOut;
        }
        public static int ToNumber(object  value)
        {
            int iOut = 0;
            int.TryParse(value.ToString(), out iOut);
            return iOut;
        }
        public static int ToNumberDefault0(object value)
        {
            if (value == null) return 0;
            try
            {
                int iOut = 0;
                int.TryParse(value.ToString(), out iOut);
                return iOut;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static String ToFormatNumber(float val)
        {
            NumberFormatInfo numberFormat = new NumberFormatInfo();
            numberFormat.NumberDecimalDigits = 0;
            numberFormat.NumberDecimalSeparator = ".";

            numberFormat.NumberGroupSeparator = ".";
            return val.ToString("N", numberFormat);
        }
        public static String ToFormatNumber(string val)
        {
            if (val == "0") return "";
            NumberFormatInfo numberFormat = new NumberFormatInfo();
            numberFormat.NumberDecimalDigits = 0;
            numberFormat.NumberDecimalSeparator = ".";

            numberFormat.NumberGroupSeparator = ".";
            if (val != "")
                return long.Parse(val).ToString("N", numberFormat);
            else
                return "";
        }
    }
}
