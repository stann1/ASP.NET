using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.Escaping
{
    public partial class WebFormEscaping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonIput_Click(object sender, EventArgs e)
        {
            //unsescaped
            string input = this.TextBoxInput.Text;
            this.TextBoxOutput.Text = input;
            this.LabelOutput.Text = input;

           //escaped
            this.LabelEscaped.Text = Server.HtmlEncode(input);
            this.LiteralEscaped.Text = Server.HtmlEncode(input);
        }

       
    }
}