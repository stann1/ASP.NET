<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormMain.aspx.cs" Inherits="TodoList.WebFormMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="FormMain" runat="server">
        <asp:EntityDataSource runat="server" ID="EntityDSCategories" ConnectionString="name=TodoListDBEntities"
            DefaultContainerName="TodoListDBEntities" EntitySetName="Categories" >
        </asp:EntityDataSource>
         <asp:DropDownList runat="server" ID="DropDownCategories" DataSourceID="EntityDSCategories" DataTextField="Title"
            DataValueField="Id" AutoPostBack="true" >                         
        </asp:DropDownList><br />
        <asp:Button runat="server" ID="ButtonShowEdit" Text="Edit" OnClick="ButtonShowEdit_Click" />        
        <asp:Button runat="server" ID="ButtonDeleteCat" Text="Delete" OnClick="ButtonDeleteCat_Click" />
        <div id="editCategories" runat="server" visible="false">
            <asp:TextBox runat="server" ID="TextBoxEditCategory"></asp:TextBox>
            <asp:Button Text="Ok" runat="server" ID="ButtonConfirmEdit" OnClick="ButtonConfirmEdit_Click" />
        </div>
        <asp:Label Text="" runat="server" ID="LabelCategoryResult" />


        <asp:EntityDataSource runat="server" ID="EntityDSTodos" ConnectionString="name=TodoListDBEntities"
            DefaultContainerName="TodoListDBEntities" EnableInsert="true" EnableUpdate="true" EnableDelete="true"
            EntitySetName="Todos" Where="it.CategoryId=@CatID" EnableFlattening="false" >
            <WhereParameters>
                <asp:ControlParameter ControlID="DropDownCategories" Name="CatID" Type="Int32" />
            </WhereParameters>
        </asp:EntityDataSource>

        <asp:GridView runat="server" ID="GridViewTodos" DataSourceID="EntityDSTodos" 
           DataKeyNames="Id" AutoGenerateColumns="false" >
            <Columns>
                <asp:CheckBoxField DataField="IsDone" HeaderText="Done?"  />
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Body" HeaderText="Description" />
                <asp:BoundField DataField="LastChanged" HeaderText="Modified on" />
                <asp:CommandField ShowEditButton="true" />                              
            </Columns>                             
        </asp:GridView>
        <div id="addTodos" runat="server">
            <asp:TextBox runat="server" ID="TextBoxAddTitle" Text="Title" />
            <asp:TextBox runat="server" ID="TextBoxAddBody" Text="Body" />
            <asp:TextBox runat="server" ID="TextBoxAddCategory" Text="Category" />
            <asp:Button Text="Add" runat="server" ID="ButtonAddTodo" OnClick="ButtonAddTodo_Click" />
            <asp:Label ID="LabelAddTodoResult" runat="server" />
        </div>
    </form>
</body>
</html>
