<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormMain.aspx.cs" Inherits="_01.RegistrationValidator.WebFormMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formRegister" runat="server">
        Username:
        <asp:TextBox ID="TextBoxUsername" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ErrorMessage="Username is required!" ControlToValidate="TextBoxUsername" runat="server"
            Display="None" ForeColor="Red" /><br />

        Password:
        <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox><br />

        Password (repeat):
        <asp:TextBox ID="TextBoxRepeatPassword" runat="server"></asp:TextBox>
        <asp:CompareValidator ErrorMessage="Passwords do not match!" runat="server" ControlToValidate="TextBoxRepeatPassword" 
            ControlToCompare="TextBoxPassword" Display="Dynamic" ForeColor="Red" EnableClientScript="false" /><br />

        First name:
        <asp:TextBox ID="TextBoxFirstName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ErrorMessage="First name is required!" ControlToValidate="TextBoxFirstName" runat="server"
            Display="None" ForeColor="Red" /><br />

        Last name:
        <asp:TextBox ID="TextBoxLastName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ErrorMessage="Last name is required!" ControlToValidate="TextBoxLastName" runat="server"
            Display="None" ForeColor="Red" /><br />

        Age:
        <asp:TextBox ID="TextBoxAge" runat="server"></asp:TextBox>        
        <asp:RangeValidator ErrorMessage="Entry denied due to age restrictions" ControlToValidate="TextBoxAge" runat="server"
           MinimumValue="18" MaximumValue="81" Display="Dynamic" ForeColor="Red" />
        <asp:RequiredFieldValidator ErrorMessage="Age field is required!" ControlToValidate="TextBoxAge" runat="server"
            Display="None" ForeColor="Red" /><br />        

        Email:
        <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ErrorMessage="Email field is required!" ControlToValidate="TextBoxEmail" runat="server"
            Display="None" ForeColor="Red" />
        <asp:RegularExpressionValidator
            id="RegularExpressionValidatorEmail"
            runat="server" ForeColor="Red" Display="Dynamic"
            ErrorMessage="Email address is incorrect!"
            ControlToValidate="TextBoxEmail" EnableClientScript="False"
            ValidationExpression=
            "[a-zA-Z][a-zA-Z0-9\-\.]*[a-zA-Z]@[a-zA-Z][a-zA-Z0-9\-\.]+[a-zA-Z]+\.[a-zA-Z]{2,4}">
        </asp:RegularExpressionValidator><br />

        Address:
        <asp:TextBox ID="TextBoxAddress" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ErrorMessage="Address field is required!" ControlToValidate="TextBoxAddress" runat="server"
            Display="None" ForeColor="Red" /><br />

        Phone:
        <asp:TextBox ID="TextBoxPhone" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ErrorMessage="Phone field is required!" ControlToValidate="TextBoxPhone" runat="server"
            Display="None" ForeColor="Red" /><br />

        I accept the conditions:
        <asp:CheckBox Text="Accept" runat="server" ID="CheckBoxAccept" />
        <asp:CustomValidator ID="CustValidator" ErrorMessage="Terms should be accepted" runat="server"
           OnServerValidate="CustValidator_ServerValidate" ForeColor="Red" /><br />
        <asp:Button Text="Submit" ID="BtnSubmit" runat="server" OnClick="BtnSubmit_Click" /><br />
        <asp:Label ID="LabelOutput" runat="server" />
        <hr />
        Validation summary: <asp:ValidationSummary runat="server" ForeColor="Red" />
    </form>
</body>
</html>
