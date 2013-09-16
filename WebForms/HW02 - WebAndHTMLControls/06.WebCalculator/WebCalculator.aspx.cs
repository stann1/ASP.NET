using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _06.WebCalculator
{
    public partial class WebCalculator : System.Web.UI.Page
    {       
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        
        protected void ButtonEquals_Click(object sender, EventArgs e)
        {
            IButtonControl clickedButton = (IButtonControl)sender;
                        
            int firstNum = (int)this.ViewState["firstNum"];
            string operation = (string)this.ViewState["command"];
            string second = this.InputOutput.Text;
            int secondNum = second != string.Empty ? int.Parse(second) : 0;
           
            double? output = null;

            switch (operation)
            {
                case "+": output = firstNum + secondNum;
                    break;
                case "-": output = firstNum - secondNum;
                    break;
                case "*": output = firstNum * secondNum;
                    break;
                case "/": output = (double)firstNum / secondNum;
                    break;
                case "sqrt": output = Math.Sqrt(firstNum);
                    break;
                default: 
                    break;
            }

            if (output != null)
            {
                this.InputOutput.Text = output.ToString();
            }
            else
            {
                this.InputOutput.Text = "Not allowed operation!";
            }

            //reset the viewstate
            this.ViewState.Remove("firstNum");
            this.ViewState.Remove("command");
        }

        protected void ButtonOperator_Click(object sender, EventArgs e)
        {
            IButtonControl clickedButton = (IButtonControl)sender;
            
            try
            {
                int inputNum = int.Parse(this.InputOutput.Text);
                this.ViewState.Add("firstNum", inputNum);

            }
            catch (Exception ex)
            {
                this.InputOutput.Text = "Invalid number!";
            }

            string command = clickedButton.Text;
            this.ViewState.Add("command", command);
            this.InputOutput.Text = "";
        }

        protected void OnNumberAction(object sender, CommandEventArgs e)
        {
            IButtonControl clickedButton = (IButtonControl)sender;
            this.InputOutput.Text = this.InputOutput.Text + clickedButton.Text;   
        }

        protected void OnCommandAction(object sender, CommandEventArgs e)
        {
            IButtonControl clickedButton = (IButtonControl)sender;
            this.LabelCommandString.Text = clickedButton.Text;           
        }

        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            if (this.ViewState["firstNum"] != null)
            {
                this.ViewState.Remove("firstNum");
            }
            if (this.ViewState["command"] != null)
            {
                this.ViewState.Remove("command");
            }
            
            this.InputOutput.Text = "";
        }
    }
}