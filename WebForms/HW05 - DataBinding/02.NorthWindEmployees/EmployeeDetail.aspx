<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeDetail.aspx.cs" Inherits="_02.NorthWindEmployees.EmployeeDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="FormDetails" runat="server">        
        <asp:DetailsView runat="server" ID="DetailsViewEmployee" AllowPaging="True" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" >
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <EditRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        </asp:DetailsView>
        <asp:LinkButton Text="Back" ID="ButtonBack" runat="server" OnClick="ButtonBack_Click"/>
    </form>
</body>
</html>
