using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HELPER
{
    public class CDateTime
    {
        public static String To_Standard(DateTime p_date)
        {
            return p_date.Month + "/" + p_date.Day + "/" + p_date.Year + " " + p_date.Hour + ":" + p_date.Minute + ":" + p_date.Second;
            //mm/dd/yyyy HH24:MI:SS
        }
        public static String To_VNDate(DateTime p_date)
        {
            return p_date.Day + "/" + p_date.Month + "/" + p_date.Year;
        }
        public static long To_Long(String p_VN_Date, String p_Hour, String p_Minute)
        {
            String[] arr;
            arr = p_VN_Date.Split('/');
            return long.Parse(arr[2] + arr[1] + arr[0] + CString.To2Digit(p_Hour) + CString.To2Digit(p_Minute));
        }
        public static String ToJavaScript(String p_date)
        {
            if (p_date != "")
            {
                DateTime d = Convert.ToDateTime(p_date);
                return d.Year.ToString() + "/" + (d.Month).ToString() + "/" + d.Day.ToString();
            }
            return "";
        }
        public static string getTimeNoti(DateTime onCreate)
        {
            if (DateTime.Now >= onCreate)
            {
                TimeSpan ts = DateTime.Now.Subtract(onCreate);
                if (ts.TotalDays >= 31 && ts.TotalDays <= 60)
                {
                    return "Tháng trước";
                }
                if ((int)ts.TotalDays > 0 && (int)ts.TotalDays <= 30)
                {
                    return (int)ts.TotalDays + " ngày trước";
                }
                if ((int)ts.TotalHours > 0 && (int)ts.TotalHours < 24)
                {
                    return (int)ts.TotalHours + " giờ trước";
                }
                if ((int)ts.TotalHours >= 24 && (int)ts.TotalHours < 48)
                {
                    return onCreate.ToString("HH:MM") + " hôm qua";
                }
                if ((int)ts.TotalMinutes > 0 && (int)ts.TotalMinutes < 60)
                {
                    return (int)ts.TotalMinutes + " phút trước";
                }
                if (ts.TotalSeconds < 60)
                {
                    return "Vừa xong";
                }
            }
            else
            {
                TimeSpan ts = onCreate.Subtract(DateTime.Now);
                if (ts.TotalDays >= 31 && ts.TotalDays <= 60)
                {
                    return "Tháng sau";
                }
                if ((int)ts.TotalDays > 0 && (int)ts.TotalDays <= 30)
                {
                    return (int)ts.TotalDays + " ngày nữa";
                }
                if ((int)ts.TotalHours > 0 && (int)ts.TotalHours < 24)
                {
                    return (int)ts.TotalHours + " giờ nữa";
                }
                if ((int)ts.TotalHours >= 24 && (int)ts.TotalHours < 48)
                {
                    return onCreate.ToString("HH:MM") + " ngày mai";
                }
                if ((int)ts.TotalMinutes > 0 && (int)ts.TotalMinutes < 60)
                {
                    return (int)ts.TotalMinutes + " phút nữa";
                }
                if (ts.TotalSeconds < 60)
                {
                    return "Vừa xong";
                }
            }
            return onCreate.ToString("dd/MM/yyyy");
        }

    }
}
