<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormEscaping.aspx.cs" Inherits="_03.Escaping.WebFormEscaping" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="FormEscaping" runat="server">
        <asp:TextBox ID="TextBoxInput" runat="server" />
        <asp:Button Text="Submit" ID="ButtonInput" runat="server" OnClick="ButtonIput_Click" /><br />
        <p><strong>Unescaped content:</strong></p>
        <asp:TextBox ID="TextBoxOutput" runat="server" ReadOnly="true" /><br />
        <asp:Label ID="LabelOutput" runat="server"></asp:Label><br />
        <hr />
        <p><strong>Escaped content:</strong></p>
        <asp:Label ID="LabelEscaped" runat="server" /><br />
        <%: this.TextBoxInput.Text %><br />
        <p><strong>Escaped and encoded content:</strong></p>
        <asp:Literal ID="LiteralEscaped" runat="server" Mode="Encode" />
    </form>
</body>
</html>
