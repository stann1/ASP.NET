<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormSumator.aspx.cs" Inherits="_01.ASP_Sumator.WebFormSumator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <input type="text" id="sum1" runat="server" /><br />
        <input type="text" id="sum2" runat="server" /><br />
        <asp:Button onclick="Calc_Sum" runat="server" text="Get sum"/>
        <asp:TextBox ID="TextBoxSum" runat="server"></asp:TextBox>
    </form>
</body>
</html>
