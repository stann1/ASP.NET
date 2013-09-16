<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormMain.aspx.cs" Inherits="_03.CookieRedirection.WebFormMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formMain" runat="server">
        <asp:Button Text="Go to next page" runat="server" ID="BtnRedirect" OnClick="BtnRedirect_Click" />
    </form>
</body>
</html>
