<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MainChat.aspx.cs" Inherits="ChatAppTest.MainChat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="wrapper">
        <h2>This is the main chat page</h2>
        <div id="messagesContainer" runat="server">
            alblalbal<br />
            afapoakopfjapfj<br />
            alblalbal<br />
            afapoakopfjapfj<br />
            alblalbal<br />
            afapoakopfjapfj<br />
        </div>
        <div id="input-container">
            <asp:TextBox runat="server" ID="TextBoxInputMsg" CssClass="span4" />
            <asp:Button Text="Send" runat="server" ID="ButtonSend" CssClass="btn" OnCommand="ButtonSend_Command" />
            <asp:Label ID="LabelResult" runat="server" EnableViewState="false" />
        </div>
    </div>
</asp:Content>
