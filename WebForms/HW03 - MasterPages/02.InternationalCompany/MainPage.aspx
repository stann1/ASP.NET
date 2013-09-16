<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="_02.InternationalCompany.MainPage" %>

<asp:Content ID="ContentPage" ContentPlaceHolderID="MainContentPlaceholder" runat="server">
    <h1 id="welcome-text">Global deliveries - delivering it to you since 1885</h1>
    <asp:HyperLink runat="server" NavigateUrl="~/ContentBulgaria/BGHome.aspx" 
        Text="BG Portal" CssClass="bg-icon"/>
    <asp:HyperLink runat="server" NavigateUrl="~/ContentUSA/USHome.aspx"
         Text="US Portal" CssClass="us-icon"/>
</asp:Content>
