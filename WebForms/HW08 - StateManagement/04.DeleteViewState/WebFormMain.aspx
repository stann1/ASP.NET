<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormMain.aspx.cs" Inherits="_04.DeleteViewState.WebFormMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formMain" runat="server">
        <asp:TextBox ID="TextBox" runat="server"></asp:TextBox>
        <asp:Button Text="Submit" runat="server" ID="BtnSubmit" OnClick="BtnSubmit_Click" /><br />
        Output from viewstate: <asp:Label ID="LabelOutput" runat="server" /><br />
        <button id="delete-viewstate" >Delete ViewState</button>
    </form>
    <script>
        (function () {
            document.getElementById("delete-viewstate")
                .addEventListener("click", function () {
                    var vs = document.getElementById("__VIEWSTATE");
                    vs.parentNode.removeChild(vs);
                });
        })();
    </script>
</body>
</html>
