<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandGeneratorHTMLControl.aspx.cs" Inherits="_01_02.RandomGenerators.RandomGenerator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <fieldset>
        <legend>HTML Control random generator</legend>
        <form id="HTMLControl" runat="server">
            Range from: 
            <input type="text" id="startRange" runat="server" /> to:
            <input type="text" id="endRange" runat="server" /><br />
            <input type="button" id="submitBtn" value="Submit" runat="server" onserverclick="Btn_Submit" /><br />
            <input type="text" id="InputResult" runat="server" disabled />
        </form>
    </fieldset>    
</body>
</html>
