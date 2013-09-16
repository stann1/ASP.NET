using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.RegistrationValidator
{
    public partial class WebFormMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                this.LabelOutput.Text = "Page is valid";
            }
            this.LabelOutput.Visible = Page.IsValid;
        }

        protected void CustValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = this.CheckBoxAccept.Checked;
        }
    }
}