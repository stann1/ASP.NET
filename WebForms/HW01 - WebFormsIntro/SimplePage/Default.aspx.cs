using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimplePage
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LabelPrint.Text = "Hello ASP.NET";
            var path = Assembly.GetExecutingAssembly().Location;
            this.LabelPrintExec.Text = path;
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            string text = this.TextInput.Text;
            this.Label1.Text = text;
        }
   
    }
}