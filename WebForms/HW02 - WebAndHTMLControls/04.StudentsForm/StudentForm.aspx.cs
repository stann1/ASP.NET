using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _04.StudentsForm
{
    public partial class StudentForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            string outputHtml =
                "<div>" +
                "<p><strong>Student: </strong>" + this.TextInputFirstName.Text + " " + this.TextInputLastName.Text + "</p>" +
                "<p>Faculty number: " + this.TextInputFaculty.Text + "</p>" +
                "<p>University: " + this.DropDownUniversityList.SelectedItem.Text + "</p>" +
                "<p>Specialty: " + this.DropDownSpecialtyList.SelectedItem.Text + "</p>" +
                "<p>Courses: " +
                "<ul>" + StringifyCourses() + "</ul>" +
                "</p>";

            this.LabelOutput.Text = outputHtml;
                    
        }
               

        private string StringifyCourses()
        {
            StringBuilder sb = new StringBuilder();
            foreach (ListItem course in this.ListBoxCourses.Items)
            {
                if (course.Selected)
                {
                    sb.AppendFormat("<li>{0}</li>", course.ToString());
                }                
            }
            return sb.ToString();
        }

        
    }
}