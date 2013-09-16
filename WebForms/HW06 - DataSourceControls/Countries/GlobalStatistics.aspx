<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GlobalStatistics.aspx.cs" Inherits="GlobalStats.GlobalStatistics" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="FormMain" runat="server">
        <asp:EntityDataSource runat="server" ID="EntityDataSourceContinents" 
            ConnectionString="name=AddressBookEntities" DefaultContainerName="AddressBookEntities" 
            EntitySetName="Continents">
        </asp:EntityDataSource>

        <h2>Continents:</h2>
        <asp:ListBox runat="server" ID="ListBoxContinents" DataSourceID="EntityDataSourceContinents"
            DataTextField="Name" DataValueField="ContinentId" AutoPostBack="true">                        
        </asp:ListBox>
        <asp:Button Text="Add" runat="server" ID="ButtonAddContinent" OnClick="ButtonAddContinent_Click" />
        <asp:Button Text="Edit" runat="server" ID="ButtonEditContinent" OnClick="ButtonEditContinent_Click" />
        <asp:Button Text="Delete" runat="server" ID="ButtonDeleteContinent" OnClick="ButtonDeleteContinent_Click" /><br />
        <asp:TextBox runat="server" ID="TextBoxAddContinent" Visible="false" />
        <asp:Button Text="Ok" runat="server" ID="ButtonConfirmAdding" OnClick="CreateContinent" Visible="false" />
        <asp:Button Text="Ok" runat="server" ID="ButtonConfirmEdit" OnClick="EditContinentName" Visible="false" />
        <asp:Label runat="server" ID="LabelResponse" />

        <asp:EntityDataSource runat="server" ID="EntityDataSourceCountries" 
            ConnectionString="name=AddressBookEntities" DefaultContainerName="AddressBookEntities" 
            EntitySetName="Countries" Where="it.ContinentId=@ContinentID" 
            EnableInsert="true" EnableUpdate="true" EnableDelete="true" EnableFlattening="false" >
            <WhereParameters>
                <asp:ControlParameter Name="ContinentID" Type="Int32"
                    ControlID="ListBoxContinents" />
            </WhereParameters>
        </asp:EntityDataSource>

        <h2>Countries:</h2>
        <asp:GridView runat="server" ID="GridViewCountries" DataSourceID="EntityDataSourceCountries"
           AutoGenerateColumns="False" AllowSorting="True" DataKeyNames="CountryId" CellPadding="4" >                                          
            <Columns>                
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="Name" HeaderText="Country name" SortExpression="Name" />
                <asp:BoundField DataField="Language" HeaderText="Language" SortExpression="Language" />
                <asp:BoundField DataField="Population" HeaderText="Population" SortExpression="Population" /> 
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />                 
            </Columns>
        </asp:GridView>
        <asp:Button Text="Add country" runat="server" ID="ButtonShowAddCountry" OnClick="ButtonShowAddCountry_Click" />
        <div id="addCountry" runat="server" visible="false">
            <asp:TextBox runat="server" ID="TextBoxAddCountryName" Text="Country name" />
            <asp:TextBox runat="server" ID="TextBoxAddCountryLang" Text="Language" />
            <asp:TextBox runat="server" ID="TextBoxAddCountryPop" Text="Population" />
            <asp:Button Text="Ok" runat="server" ID="ButtonConfirmAddingCountry" OnClick="CreateCountry" />
            <asp:Button Text="Cancel" runat="server" ID="ButtonCancelAdding" OnClick="ButtonCancelAdding_Click" />
        </div>
        <asp:Label runat="server" ID="LabelAddCountryResponse" />
        
        <asp:EntityDataSource runat="server" ID="EntityDataSourceTowns" 
            ConnectionString="name=AddressBookEntities" DefaultContainerName="AddressBookEntities" 
            EntitySetName="Towns" Where="it.CountryId=@CountryID" EnableFlattening="False"
            EnableInsert="true" EnableUpdate="true" EnableDelete="true" >
            <WhereParameters>
                <asp:ControlParameter Name="CountryID" Type="Int32"
                    ControlID="GridViewCountries" />
            </WhereParameters>
            <InsertParameters>
                <asp:ControlParameter Name="CountryId" ControlId="GridViewCountries" Type="Int32" />
            </InsertParameters>
        </asp:EntityDataSource>

        <h3>Towns:</h3>
        <asp:ListView runat="server" ID="ListViewTowns" DataSourceID="EntityDataSourceTowns"
             ItemType="GlobalStats.Town" DataKeyNames="TownId" InsertItemPosition="LastItem" >           
            <AlternatingItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    </td>                    
                    <td>
                        <asp:Label ID="NameLabel" runat="server" Text='<%#: Eval("Name") %>' />
                    </td>                    
                    <td>
                        <asp:Label ID="PopulationLabel" runat="server" Text='<%#: Eval("Population") %>' />
                    </td>                   
                </tr>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                    </td>                    
                    <td>
                        <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                    </td>                    
                    <td>
                        <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%# Bind("Population") %>' />
                    </td>                    
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="">
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>         
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                    </td>                    
                    <td>
                        <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                    </td>                    
                    <td>
                        <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%# Bind("Population") %>' />
                    </td>                    
                </tr>
            </InsertItemTemplate>
            <ItemTemplate>                
                <tr style="">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    </td>                    
                    <td>
                        <asp:Label ID="NameLabel" runat="server" Text='<%#: Eval("Name") %>' />
                    </td>                    
                    <td>
                        <asp:Label ID="PopulationLabel" runat="server" Text='<%#: Eval("Population") %>' />
                    </td>                    
                </tr>                
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                                <tr runat="server" style="">
                                    <th runat="server">Action</th>                                     
                                    <th runat="server">Name</th>                                    
                                    <th runat="server">Population</th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="">
                            <asp:DataPager ID="DataPager1" runat="server">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>   
            <SelectedItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    </td>                    
                    <td>
                        <asp:Label ID="NameLabel" runat="server" Text='<%#: Eval("Name") %>' />
                    </td>                    
                    <td>
                        <asp:Label ID="PopulationLabel" runat="server" Text='<%#: Eval("Population") %>' />
                    </td>                    
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
    </form>
</body>
</html>
