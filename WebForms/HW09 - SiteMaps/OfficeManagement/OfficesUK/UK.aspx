<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UK.aspx.cs" Inherits="OfficeManagement.OfficesUK.UK" %>

<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <h1>Welcome</h1>
    <p>All our offices in UK:</p>
    <asp:Menu ID="NavigationMenu" runat="server" CssClass="verticalMenu" 
        EnableViewState="False" IncludeStyleBlock="False" SkipLinkText=""
        DataSourceID="SiteMapDataSource">
    </asp:Menu>
    <asp:SiteMapDataSource ID="SiteMapDataSource" runat="server" 
        ShowStartingNode="False" StartingNodeOffset="2" />
</asp:Content>