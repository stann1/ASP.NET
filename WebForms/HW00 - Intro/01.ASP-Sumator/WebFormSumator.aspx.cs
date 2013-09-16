using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.ASP_Sumator
{
    public partial class WebFormSumator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Calc_Sum(object sender, EventArgs e)
        {
            double numOne = double.Parse(this.sum1.Value);
            double numTwo = double.Parse(this.sum2.Value);
            this.TextBoxSum.Text = (numOne + numTwo).ToString();
        }

        
    }
}