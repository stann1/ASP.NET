using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TodoList
{
    public partial class WebFormMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAddTodo_Click(object sender, EventArgs e)
        {
            TodoListDBEntities context = new TodoListDBEntities();
            string title = this.TextBoxAddTitle.Text;
            string body = this.TextBoxAddBody.Text;
            string categoryText = this.TextBoxAddCategory.Text;
            if (string.IsNullOrEmpty(categoryText))
            {
                categoryText = "Uncategorized";
            }
            var cat = context.Categories.FirstOrDefault(ca => ca.Title == categoryText);
            if (cat == null)
            {
                cat = new Category() { Title = categoryText };
            }

            DateTime date = DateTime.Now;

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(body))
            {
                this.LabelAddTodoResult.Text = "Error: a todo item cannot have an empty title or body!";
            }
            else
            {
                Todo todo = new Todo() { Title = title, Body = body, LastChanged = date, Category = cat };
                context.Todos.Add(todo);
                context.SaveChanges();
                this.LabelAddTodoResult.Text = "Todo added.";
            }
            this.GridViewTodos.DataBind();
            
        }

        protected void ButtonConfirmEdit_Click(object sender, EventArgs e)
        {
            int selectedCatIndex = int.Parse(this.DropDownCategories.SelectedValue);
            string newTitle = this.TextBoxEditCategory.Text;
            if (string.IsNullOrEmpty(newTitle))
            {
                this.LabelCategoryResult.Text = "Error: category name cannot be empty!";
            }
            else
            {
                TodoListDBEntities context = new TodoListDBEntities();
                var existingCat = context.Categories.FirstOrDefault(ca => ca.Id == selectedCatIndex);
                existingCat.Title = newTitle;
                context.SaveChanges();
                this.DropDownCategories.DataBind();
                this.LabelCategoryResult.Text = "Category name changed";
            }

            this.editCategories.Visible = false;
        }

        protected void ButtonShowEdit_Click(object sender, EventArgs e)
        {
            this.LabelCategoryResult.Text = "";
            if (this.editCategories.Visible)
            {
                this.editCategories.Visible = false;
            }
            else
            {
                this.editCategories.Visible = true;
                this.TextBoxEditCategory.Text = this.DropDownCategories.SelectedItem.Text;
            }
        }       

        protected void ButtonDeleteCat_Click(object sender, EventArgs e)
        {
            this.LabelCategoryResult.Text = "";
            int selectedCatIndex = int.Parse(this.DropDownCategories.SelectedValue);
            TodoListDBEntities context = new TodoListDBEntities();
            var existingCat = context.Categories.FirstOrDefault(ca => ca.Id == selectedCatIndex);
            context.Categories.Remove(existingCat);
            this.LabelCategoryResult.Text = "Category deleted";
        }
    }
}