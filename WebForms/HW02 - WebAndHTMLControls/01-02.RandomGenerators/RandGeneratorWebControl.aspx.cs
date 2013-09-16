using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01_02.RandomGenerators
{
    public partial class RandGeneratorWebControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonWebSubmit_Click(object sender, EventArgs e)
        {
            int start = int.Parse(this.TextStartRange.Text);
            int end = int.Parse(this.TextEndRange.Text);

            Random rand = new Random();
            int num = rand.Next(start, end + 1);

            this.TextResult.Text = num.ToString();
        }
    }
}