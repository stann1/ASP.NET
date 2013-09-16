using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.GetClientInfo
{
    public partial class WebFormMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var browserType = Request.Browser.Type;
            var address = Request.UserHostAddress;
            this.LiteralOutput.Text = "Browser --> " + browserType + "<br/>" + "IP --> " + address;
        }
    }
}