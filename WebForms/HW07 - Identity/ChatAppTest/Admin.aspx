<%@ Page Title="Admin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="ChatAppTest.Admin" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <header>
        <h1><%: Title %></h1>
        <p class="lead">Admin tools can be used here.</p>
    </header>
    
    <asp:GridView runat="server" ID="GridViewAdmin" DataKeyNames="Id" AutoGenerateColumns="false" SelectMethod="GridViewAdmin_GetData"
       DeleteMethod="GridViewAdmin_DeleteItem" ItemType="ChatAppTest.Models.Message" AllowSorting="true" CssClass="table" >
        <Columns>
            <asp:BoundField DataField="User.UserName" HeaderText="User" />
            <asp:BoundField DataField ="Content" HeaderText="Message" SortExpression="Content" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButtonShowEdit" Text="Edit" runat="server"
                         CommandName="ShowEdit" CommandArgument="<%# Item.Id %>" OnCommand="LinkButtonShowEdit_Command" />
                    <asp:LinkButton ID="LinkButtonDeleteQUestion" runat="server" 
                        CommandName="Delete" 
                        CommandArgument="<%# Item.Id %>"
                        OnClientClick = "return confirm('Do you want to proceed ?');"
                        Text="Delete" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div id="msgEditor" runat="server" visible="false">
        <strong>Edit the message</strong>
        <asp:TextBox runat="server" ID="TbEditMsg" CssClass="span6" /> 
        <asp:Button Text="Confirm" ID="ButtonConfirm" runat="server" OnClick="ButtonConfirm_Click" CssClass="btn" />        
    </div>
    <asp:Label ID="LabelEditResult" runat="server" EnableViewState="false" />
    
    
</asp:Content>
