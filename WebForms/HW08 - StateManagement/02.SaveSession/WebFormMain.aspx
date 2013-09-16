<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormMain.aspx.cs" Inherits="_02.SaveSession.WebFormMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formMain" runat="server">
        <asp:TextBox ID="TextBoxInput" runat="server" />
        <asp:Button Text="Submit" runat="server" ID="BtnSubmit" OnClick="BtnSubmit_Click" /><br />
        <asp:Label id="LabelOutput" runat="server" />
    </form>
</body>
</html>
