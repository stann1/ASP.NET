using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.CookieRedirection
{
    public partial class WebFormMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnRedirect_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie(Guid.NewGuid().ToString(), "Cookie from main page");
            cookie.Expires = DateTime.Now.AddMinutes(1);
            Response.AppendCookie(cookie);
            Response.Redirect("SecondPage.aspx");
        }
    }
}