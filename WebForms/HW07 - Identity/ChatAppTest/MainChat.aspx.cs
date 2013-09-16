using ChatAppTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChatAppTest
{
    public partial class MainChat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var messages = context.Messages.ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var msg in messages)
            {
                sb.AppendFormat("[{0}] {1} <br/>", msg.User.UserName, msg.Content);
            }

            this.messagesContainer.InnerHtml = sb.ToString();
        }

        protected void ButtonSend_Command(object sender, CommandEventArgs e)
        {
            string messages = this.TextBoxInputMsg.Text;
            ApplicationDbContext context = new ApplicationDbContext();
            var currUser = HttpContext.Current.User.Identity;
            var loggedUser = context.Users.FirstOrDefault(u => u.UserName == currUser.Name);

            context.Messages.Add(new Message() { Content = messages, UserId = loggedUser.Id });
            context.SaveChanges();
            //this.messagesContainer.DataBind();
            
        }
    }
}