using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace HELPER
{
    public static class Functions
    {
        static Dictionary<String, String> func = new Dictionary<String, String>();
        static   Functions() {
            func.Add("21", "~/Master/ctrHotel.ascx");
            func.Add("22", "~/Master/ctrRoom.ascx");
            func.Add("23", "~/Master/ctrCollateral.ascx");
            func.Add("24", "~/Master/ctrGroupOfItems.ascx");
            func.Add("25", "~/Master/ctrItems.ascx");
            func.Add("26", "~/Master/ctrGroupOfItems.ascx");
            func.Add("27", "~/Master/ctrItems.ascx");

            //Hotel business
            func.Add("31", "~/Hotel/ctrRoomPrice.ascx");
            func.Add("32", "~/Hotel/ctrItemPrice.ascx");
            func.Add("34", "~/Hotel/ctrRoomMgnt.ascx");
        }
        public static String getControls(String funcID) {
            if (func.ContainsKey(funcID))
            {
                return func[funcID];
            }
            else
                return "";
        }
    }
}
