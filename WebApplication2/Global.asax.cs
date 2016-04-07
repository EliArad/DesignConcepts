using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApplication2
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {

            if (Directory.Exists("c:\\App_Data") == false)
                Directory.CreateDirectory("c:\\App_Data");

        }
    }
}