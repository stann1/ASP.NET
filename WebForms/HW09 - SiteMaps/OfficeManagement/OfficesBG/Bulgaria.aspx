<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bulgaria.aspx.cs" Inherits="OfficeManagement.OfficesBG.Bulgaria" %>

<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <h1>Добре дошли</h1>
    <p>Нашите офиси в България:</p>
    <asp:Menu ID="NavigationMenu" runat="server" CssClass="verticalMenu" 
        EnableViewState="False" IncludeStyleBlock="False" SkipLinkText=""
        DataSourceID="SiteMapDataSource">
    </asp:Menu>
    <asp:SiteMapDataSource ID="SiteMapDataSource" runat="server" 
        ShowStartingNode="False" StartingNodeOffset="2" />
</asp:Content>
