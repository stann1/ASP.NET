﻿using ChatAppTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChatAppTest
{
    public partial class Admin : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

       // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewAdmin_DeleteItem(int id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var message = context.Messages.Find(id);
            context.Messages.Remove(message);
            context.SaveChanges();
        }

        public IQueryable<ChatAppTest.Models.Message> GridViewAdmin_GetData()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            return context.Messages.OrderBy(m => m.Id);
        }
               

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            int index = Convert.ToInt32(this.ViewState["editedRowIndex"]);
            var msg = context.Messages.Find(index);

            string newText = this.TbEditMsg.Text;
            msg.Content = newText;
            context.SaveChanges();
            this.LabelEditResult.Text = "Message edited.";
            this.msgEditor.Visible = false;
            Response.Redirect(Request.RawUrl);
        }

        protected void LinkButtonShowEdit_Command(object sender, CommandEventArgs e)
        {
            this.msgEditor.Visible = true;
            int index = Convert.ToInt32(e.CommandArgument);            
            
            this.ViewState["editedRowIndex"] = index;
        }
    }
}