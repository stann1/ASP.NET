<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MainChat.aspx.cs" Inherits="ChatAppTest.MainChat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="wrapper">
        <h2>This is the main chat page</h2>
       
        <p>This text is not updated by the partial rendering. The pannel below refreshes every 0.5 sec and shows last 20 messages</p>
        <asp:UpdatePanel runat='server' ID='UpdatePanelTime' UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="TimerTimeRefresh" EventName="Tick" />
            </Triggers>
            <ContentTemplate>
                <div id="messagesContainer" runat="server">
                    alblalbal<br />
                    afapoakopfjapfj<br />
                    alblalbal<br />
                    afapoakopfjapfj<br />
                    alblalbal<br />
                    afapoakopfjapfj<br />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Timer ID="TimerTimeRefresh" runat="Server" Interval="500" />
         
        <div id="input-container" class="form-inline">
            <asp:TextBox runat="server" ID="TextBoxInputMsg" CssClass="span4" />
            <asp:Button Text="Send" runat="server" ID="ButtonSend" CssClass="btn" OnCommand="ButtonSend_Command" />
            <asp:Label ID="LabelResult" runat="server" EnableViewState="false" />
        </div>                
        <p>This text is also not updated.</p>
    </div>
</asp:Content>
