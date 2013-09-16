<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandGeneratorWebControl.aspx.cs" Inherits="_01_02.RandomGenerators.RandGeneratorWebControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <fieldset>
        <legend>Web Control random generator</legend>
        <form id="WebControl" runat="server">
            Range from: 
            <asp:TextBox ID="TextStartRange" runat="server" />  to:
            <asp:TextBox ID="TextEndRange" runat="server" /><br />
            <asp:Button Text="Submit" ID="ButtonSubmit" OnClick="ButtonWebSubmit_Click" runat="server" /><br />
            <asp:TextBox ID="TextResult" runat="server" ReadOnly="true" />
        </form>
    </fieldset>    
</body>
</html>
