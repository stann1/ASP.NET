using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.NorthWindEmployees
{
    public partial class EmployeeDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                int paramId = int.Parse(Request.QueryString["id"]);
                NorthwindEntities context = new NorthwindEntities();
                var employee = context.Employees.FirstOrDefault(em => em.EmployeeID == paramId);
                this.DetailsViewEmployee.DataSource = new List<Employee>() { employee };
                this.DetailsViewEmployee.DataBind();
            }
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EmployeesGrid.aspx");
        }
    }
}