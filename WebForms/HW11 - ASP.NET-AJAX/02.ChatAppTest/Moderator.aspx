<%@ Page Title="Moderator" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Moderator.aspx.cs" Inherits="ChatAppTest.Moderator" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <header>
        <h1><%: Title %></h1>
        <p class="lead">Your contact page.</p>
    </header>
    <div>
        <asp:GridView runat="server" ID="GridViewModerator" DataKeyNames="Id" AutoGenerateColumns="false" SelectMethod="GridViewModerator_GetData"
           ItemType="ChatAppTest.Models.Message" AllowSorting="true" CssClass="table" >
            <Columns>
                <asp:BoundField DataField="User.UserName" HeaderText="User" />
                <asp:BoundField DataField ="Content" HeaderText="Message" SortExpression="Content" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonShowEdit" Text="Edit" runat="server"
                             CommandName="ShowEdit" CommandArgument="<%# Item.Id %>" OnCommand="LinkButtonShowEdit_Command" />                        
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
    </div>
</asp:Content>
