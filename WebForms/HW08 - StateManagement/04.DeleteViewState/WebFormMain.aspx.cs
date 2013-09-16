using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _04.DeleteViewState
{
    public partial class WebFormMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["inputs"] == null)
            {
                ViewState["inputs"] = new List<string>();
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            string text = this.TextBox.Text;
            List<string> inputs = (List<string>)ViewState["inputs"];
            inputs.Add(text);

            StringBuilder sb = new StringBuilder();
            foreach (var item in inputs)
            {
                sb.AppendFormat("{0}<br/>", item);
            }
            this.LabelOutput.Text = sb.ToString();
        }
    }
}