using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.GroupValidation
{
    public partial class WebFormMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            this.LabelOutput.Text = "Valid groups:<br/>";
            if (this.CheckIsValid("ValidateLoginData"))
            {
                this.LabelOutput.Text += "Login data is valid<br/>";
            }
            if (this.CheckIsValid("ValidatePersonalData"))
            {
                this.LabelOutput.Text += "Personal data is valid<br/>";
            }
            if (this.CheckIsValid("ValidateAddressData"))
            {
                this.LabelOutput.Text += "Address data is valid<br/>";
            }
            if (this.CheckIsValid("ValidateTerms"))
            {
                this.LabelOutput.Text += "Terms have been accepted<br/>";
            }
                       
        }

        protected void CustValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = this.CheckBoxAccept.Checked;
        }

        private bool CheckIsValid(string validationGroup)
        {
            this.Page.Validate(validationGroup);
            if (this.Page.IsValid)
            {
                return true;
            }
            return false;
        }
    }
}