using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HELPER
{
    public class Client
    {
        public static void Alert(System.Web.UI.Page page, String sMessage) {
            String sScript;
            sScript = "<script type =text/javascript> alert('" + sMessage + "');</script>";
            page.ClientScript.RegisterClientScriptBlock(page.GetType(), "alert", sScript);
        }

        //Public Shared Sub Alert(ByVal objPage As System.Web.UI.Page, ByVal sMessage As String)
        //    Dim sScript As String
        //    sScript = "<script type =text/javascript> alert('" + sMessage + "');</script>"
        //    objPage.ClientScript.RegisterClientScriptBlock(objPage.GetType(), "alert", sScript)
        //End Sub

        public static void OpenWindow(System.Web.UI.Page page, String url)
        {
             
            string sScript = "window.open('CMS_1.aspx','Report','menubar=yes,location=yes,resizable=yes,scrollbars=yes,status=yes')";
            page.ClientScript.RegisterClientScriptBlock(page.GetType(), "open", sScript);
        }
    }
}
