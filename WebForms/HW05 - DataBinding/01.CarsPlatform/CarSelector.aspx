<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarSelector.aspx.cs" Inherits="_01.CarsPlatform.CarSelector" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form" runat="server">
        <label>Manufacturer:</label>
        <asp:DropDownList ID="DropDownProducers" runat="server" AutoPostBack="true"
           DataTextField="Name" OnSelectedIndexChanged="DropDownProducers_SelectedIndexChanged" >           
        </asp:DropDownList><br />
        <label>Model:</label>
        <asp:DropDownList runat="server" ID="DropDownModels">           
        </asp:DropDownList><br />
        <label>Engine:</label><br />
        <asp:RadioButtonList runat="server" ID="RadioListEngines">            
        </asp:RadioButtonList><br />
        <label>Extras:</label>
        <asp:ListBox runat="server" SelectionMode="Multiple" ID="ListBoxExtras" DataTextField="Name">            
        </asp:ListBox><br />
        <asp:Button Text="Submit" ID="ButtonSubmit" runat="server" OnClick="ButtonSubmit_Click" /><br />
        <hr />
        <asp:Literal ID="LiteralShowResult" runat="server" />
    </form>
</body>
</html>
