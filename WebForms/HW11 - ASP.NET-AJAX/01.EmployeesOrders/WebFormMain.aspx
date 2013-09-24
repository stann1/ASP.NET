<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormMain.aspx.cs" Inherits="_01.EmployeesOrders.WebFormMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formMain" runat="server">
        <asp:ScriptManager runat="server" ID="ScriptManager" />

        <asp:UpdatePanel runat="server" ID="UpdatePanelEmployees" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="panel">
                    <h3>Northwind employees:</h3>
                    <asp:GridView runat="server" ID="GridViewEmployees" DataKeyNames="EmployeeID"
                      SelectMethod="GridViewEmployees_GetData" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false"
                        OnSelectedIndexChanged="GridViewEmployees_SelectedIndexChanged" PageSize="4" >
                        <Columns>
                            <asp:CommandField ShowSelectButton="true" />
                            <asp:BoundField DataField="FirstName" HeaderText="First name" SortExpression="FirstName" />
                            <asp:BoundField DataField="LastName" HeaderText="Last name" SortExpression="LastName"  />
                        </Columns>
                    </asp:GridView>
                </div>

                 <asp:UpdateProgress runat="server" ID="UpdateProgress" AssociatedUpdatePanelID="UpdatePanelEmployees" >
                    <ProgressTemplate>
                        Loading...
                    </ProgressTemplate>
                </asp:UpdateProgress>

                <div class="panel">
                    <h3>Employee's orders:</h3>
                    <asp:GridView runat="server" ID="GridViewOrders" DataKeyNames="OrderID" AutoGenerateColumns="false"
                        AllowSorting="true" >
                        <Columns>
                            <asp:BoundField DataField="OrderDate" HeaderText="Order date" SortExpression="OrderDate" />
                            <asp:BoundField DataField="ShipAddress" HeaderText="Shipping address" SortExpression="ShipAddress" />
                            <asp:BoundField DataField="ShipCity" HeaderText="City" SortExpression="ShipCity" />
                        </Columns>
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
