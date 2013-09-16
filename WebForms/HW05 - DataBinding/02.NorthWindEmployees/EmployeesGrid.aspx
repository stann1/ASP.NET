<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeesGrid.aspx.cs" Inherits="_02.NorthWindEmployees.EmployeesGrid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>    
    <form id="FormMain" runat="server">
        <h2>Employee: </h2>        
        <asp:EntityDataSource ID="EntityDataSourceEmployees" runat="server" ConnectionString="name=NorthwindEntities" 
            DefaultContainerName="NorthwindEntities" EntitySetName="Employees" />

        <asp:GridView runat="server" ID="GridViewEmployees" DataSourceID="EntityDataSourceEmployees"
            AutoGenerateColumns="False" DataKeyNames="EmployeeID" AllowPaging="True" AllowSorting="True">
           <Columns>
               <asp:CommandField ShowSelectButton="true" HeaderStyle-Width="50px" />
               <asp:HyperLinkField DataTextField="LastName" DataNavigateUrlFields="EmployeeID"
                   DataNavigateUrlFormatString="~/EmployeeDetail.aspx?id={0}"
                    DataTextFormatString="{0}" HeaderText="Last name" />
               <asp:BoundField DataField="FirstName" HeaderText="First name"/>
           </Columns>
        </asp:GridView>
        <label>* For full employee detail click on a name</label>

        <h2>Employee short details (in a FormView):</h2>
        <asp:EntityDataSource ID="EntityDataSourceEmployeesDetails" runat="server" ConnectionString="name=NorthwindEntities" 
            DefaultContainerName="NorthwindEntities" EntitySetName="Employees" 
            Where="it.EmployeeID=@EmployeeId" EnableFlattening="False">
            <WhereParameters>
                <asp:ControlParameter Name="EmployeeId" Type="Int32"
                    ControlID="GridViewEmployees" />
            </WhereParameters>
        </asp:EntityDataSource>

        <asp:FormView runat="server" ID="FormViewEmployeeDetails" DataSourceID="EntityDataSourceEmployeesDetails"
            ItemType="_02.NorthWindEmployees.Employee" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
            <EditRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <ItemTemplate>
                LastName: <%#: Item.LastName %><br />
                FirstName: <%#: Item.FirstName %><br />
                Title: <%#: Item.Title %><br />                
                BirthDate:	<%#: Item.BirthDate %><br />
                HireDate:	<%#: Item.HireDate %><br />
                Address:  <%#: Item.Address %>
            </ItemTemplate>
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        </asp:FormView>

        <h2>Employee short details (in a Repeater):</h2>
        <asp:Repeater runat="server" ID="RepeaterEmployeeDetails" DataSourceID="EntityDataSourceEmployeesDetails"
            ItemType="_02.NorthWindEmployees.Employee">
            <ItemTemplate>
                LastName: <%#: Item.LastName %><br />
                FirstName: <%#: Item.FirstName %><br />
                Title: <%#: Item.Title %><br />                
                BirthDate:	<%#: Item.BirthDate %><br />
                HireDate:	<%#: Item.HireDate %><br />
                Address:  <%#: Item.Address %>
            </ItemTemplate>
        </asp:Repeater>

        <h2>Employee short details (in a ListView):</h2>
        <asp:ListView runat="server" ID="ListViewEmployeeDetails" DataSourceID="EntityDataSourceEmployeesDetails"
            ItemType="_02.NorthWindEmployees.Employee">
            <ItemTemplate>
                LastName: <%#: Item.LastName %><br />
                FirstName: <%#: Item.FirstName %><br />
                Title: <%#: Item.Title %><br />                
                BirthDate:	<%#: Item.BirthDate %><br />
                HireDate:	<%#: Item.HireDate %><br />
                Address:  <%#: Item.Address %>
            </ItemTemplate>
        </asp:ListView>
    </form>
</body>
</html>
