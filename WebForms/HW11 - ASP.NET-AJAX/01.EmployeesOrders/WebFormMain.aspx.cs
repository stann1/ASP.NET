using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.EmployeesOrders
{
    public partial class WebFormMain : System.Web.UI.Page
    {
        private List<Order> dataOrders;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Employee> GridViewEmployees_GetData()
        {
            NorthwindEntities context = new NorthwindEntities();
            return context.Employees.Include("Orders").OrderBy(em => em.FirstName);
        }

        protected void GridViewEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            Thread.Sleep(2000);
            GridViewRow row = this.GridViewEmployees.SelectedRow;
            //this.LiteralEmplOutput.Text = this.GridViewEmployees.DataKeys[row.RowIndex]["EmployeeID"].ToString() +" --> " + row.Cells[1].Text;
            int index = (int)this.GridViewEmployees.SelectedValue;

            NorthwindEntities context = new NorthwindEntities();
            var orders = context.Orders.Where(o => o.EmployeeID == index).OrderBy(ord => ord.OrderDate);
            this.GridViewOrders.DataSource = orders.ToList();
            this.GridViewOrders.DataBind();
            this.dataOrders = orders.ToList();
        }
                
    }
}