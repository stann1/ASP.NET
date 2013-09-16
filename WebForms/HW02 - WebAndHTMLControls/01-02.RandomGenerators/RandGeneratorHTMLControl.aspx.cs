using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01_02.RandomGenerators
{
    public partial class RandomGenerator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Submit(object sender, EventArgs e)
        {
            int start = int.Parse(this.startRange.Value);
            int end = int.Parse(this.endRange.Value);

            Random rand = new Random();
            int num = rand.Next(start, end + 1);

            this.InputResult.Value = num.ToString();
        }

        
    }
}