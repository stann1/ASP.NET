<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentForm.aspx.cs" Inherits="_04.StudentsForm.StudentForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="studentForm" runat="server">
        <h1>Student form</h1>
        <label>First Name: </label>
        <asp:TextBox runat="server" ID="TextInputFirstName" EnableViewState="true" /><br />
        <label>Last Name: </label>
        <asp:TextBox runat="server" ID="TextInputLastName" EnableViewState="true" /><br />
        <label>Faculty number: </label>
        <asp:TextBox runat="server" ID="TextInputFaculty" EnableViewState="true" /><br />
        <label>Select university: </label>
        <asp:DropDownList runat="server" ID="DropDownUniversityList">
            <asp:ListItem Text="Sofia University" />
            <asp:ListItem Text="UNSS" />
            <asp:ListItem Text="UASG" />
        </asp:DropDownList>
        <label>Select specialty: </label>
        <asp:DropDownList runat="server" ID="DropDownSpecialtyList">     
            <asp:ListItem Text="Informatics" />
            <asp:ListItem Text="Economics" />
            <asp:ListItem Text="Architecture" /> 
            <asp:ListItem Text="Civil engineering" />
            <asp:ListItem Text="Infrastructure engineering" />
            <asp:ListItem Text="Finance" />
            <asp:ListItem Text="Public relations" />       
        </asp:DropDownList>
        <label>Select course: </label>
        <asp:ListBox runat="server" ID="ListBoxCourses" SelectionMode="Multiple">
            <asp:ListItem Text="Microeconomics" />
            <asp:ListItem Text="Macroeconomics" />
            <asp:ListItem Text="Corporate Law" />
            <asp:ListItem Text="C#" />
            <asp:ListItem Text="JavaScript" />
            <asp:ListItem Text="Physics 101" />
            <asp:ListItem Text="Hydroengineering" />
            <asp:ListItem Text="PHP" />
            <asp:ListItem Text="Cost accounting" />
            <asp:ListItem Text="Derivatives" />
            <asp:ListItem Text="ASP.NET" />
        </asp:ListBox><br />
        <asp:Button Text="Submit" ID="ButtonSubmit" runat="server" OnClick="ButtonSubmit_Click" />
        <asp:Label ID="LabelOutput" runat="server" />

    </form>
</body>
</html>
