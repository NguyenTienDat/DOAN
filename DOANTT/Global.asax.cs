using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
using Microsoft.AspNet.SignalR;

namespace DOANTT
{
    public class Global : System.Web.HttpApplication
    {
        System.IO.StreamWriter sw;
        protected void Application_Start(object sender, EventArgs e)
        {

            Application.Lock();
            System.IO.StreamReader sr;

            string path = Server.MapPath("/SL.txt");
            sr = new System.IO.StreamReader(path);
            string sl = sr.ReadLine();
            sr.Close();
            Application.UnLock();

            Application.Add("SoNguoiTruyCap", 0);
            Application.Add("TongTruyCap", sl);


            // Storage is the only thing required for basic configuration.
            // Just discover what configuration options do you have.

            //.UseActivator(...)
            //.UseLogProvider(...)
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session.Add(HELPER.CGlobal.USER_ID, 1); //1//for test

            Application.Contents["SoNguoiTruyCap"] = int.Parse(Application.Contents["SoNguoiTruyCap"].ToString()) + 1;
            Application.Contents["TongTruyCap"] = int.Parse(Application.Contents["TongTruyCap"].ToString()) + 1;

            string path = Server.MapPath("/SL.txt");
            try
            {
                sw = new System.IO.StreamWriter(path);
                sw.Write(Application.Contents["TongTruyCap"].ToString());
                sw.Close();
            }
            catch
            {
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application.Contents["SoNguoiTruyCap"] = int.Parse(Application.Contents["SoNguoiTruyCap"].ToString()) - 1;
        }

        protected void Application_End(object sender, EventArgs e)
        {
            //Application.Contents["SoNguoiTruyCap"] = 0;
        }
    }
}