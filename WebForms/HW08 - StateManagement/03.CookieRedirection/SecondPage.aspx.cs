using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.CookieRedirection
{
    public partial class SecondPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var receivedCookies = Request.Cookies;
            if (receivedCookies == null || receivedCookies.Count == 0)
            {
                Response.Redirect("WebFormMain.aspx");
            }
            else
            {
                foreach (string cookie in receivedCookies)
                {
                    this.LabelCookie.Text += receivedCookies[cookie].Value + "<br/>";
                }
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormMain.aspx");
        }
    }
}