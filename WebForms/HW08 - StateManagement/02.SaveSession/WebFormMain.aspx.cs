using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.SaveSession
{
    public partial class WebFormMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Session["pageInputs"] != null)
            {
                StringBuilder sb = new StringBuilder();
                List<string> inputs = ((List<string>)Session["pageInputs"]);
                foreach (var input in inputs)
                {
                    sb.AppendLine(input);
                }
                this.LabelOutput.Text = "<pre>" + Server.HtmlEncode(sb.ToString()) + "</pre>";
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            string input = this.TextBoxInput.Text;
            if (Session["pageInputs"] == null)
            {
                Session["pageInputs"] = new List<string>();
            }
            ((List<string>)Session["pageInputs"]).Add(input);
        }
    }
}