<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SecondPage.aspx.cs" Inherits="_03.CookieRedirection.SecondPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formMain" runat="server">
       Received cookie: <asp:Label runat="server" ID="LabelCookie" /><br />
        <asp:Button Text="Go back" runat="server" ID="BtnBack" OnClick="BtnBack_Click" />       
    </form>
</body>
</html>
