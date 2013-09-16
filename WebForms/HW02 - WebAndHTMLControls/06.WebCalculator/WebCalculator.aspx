<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebCalculator.aspx.cs" Inherits="_06.WebCalculator.WebCalculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #result input {width: 200px}

        #pannel {
            width: 240px;
            height: 160px;
        }

        #pannel input {
            width: 60px;
            height: 40px;
            float:left;
        }

        #equals input {
            width:240px;
        }
    </style>
</head>
<body>
    <form id="form" runat="server">
        <div id="result">
            <asp:TextBox runat="server" ID="InputOutput" ReadOnly="true" />
            <asp:Label ID="LabelCommandString" runat="server" />  
        </div>
        <div id="pannel">            
            <asp:Button Text="1" ID="Button1" runat="server" OnCommand="OnNumberAction"/>
            <asp:Button Text="2" ID="Button2" runat="server" OnCommand="OnNumberAction" />
            <asp:Button Text="3" ID="Button3" runat="server" OnCommand="OnNumberAction" />
            <asp:Button Text="+" ID="ButtonPlus" runat="server" OnCommand="OnCommandAction" OnClick="ButtonOperator_Click" />
            <asp:Button Text="4" ID="Button5" runat="server" OnCommand="OnNumberAction" />
            <asp:Button Text="5" ID="Button6" runat="server" OnCommand="OnNumberAction" />
            <asp:Button Text="6" ID="Button7" runat="server" OnCommand="OnNumberAction" />
            <asp:Button Text="-" ID="ButtonMinus" runat="server" OnCommand="OnCommandAction" OnClick="ButtonOperator_Click" />
            <asp:Button Text="7" ID="Button9" runat="server" OnCommand="OnNumberAction" />
            <asp:Button Text="8" ID="Button10" runat="server" OnCommand="OnNumberAction" />
            <asp:Button Text="9" ID="Button11" runat="server" OnCommand="OnNumberAction" />
            <asp:Button Text="*" ID="ButtonMultiply" runat="server" OnCommand="OnCommandAction" OnClick="ButtonOperator_Click" />
            <asp:Button Text="Clear" ID="ButtonClear" runat="server" OnClick="ButtonClear_Click" />
            <asp:Button Text="0" ID="Button0" runat="server" OnCommand="OnNumberAction" />
            <asp:Button Text="/" ID="ButtonDivide" runat="server" OnCommand="OnCommandAction" OnClick="ButtonOperator_Click" />
            <asp:Button Text="sqrt" ID="ButtonSqrt" runat="server" OnCommand="OnCommandAction" OnClick="ButtonOperator_Click" />
        </div><br />  
        <div id="equals">
            <asp:Button Text="=" ID="ButtonEquals" runat="server" OnClick="ButtonEquals_Click" />
        </div>      
    </form>
</body>
</html>
