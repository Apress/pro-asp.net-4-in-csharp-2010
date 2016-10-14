<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QueryExtenderTest4.aspx.cs" Inherits="QueryExtenderTest4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="EmployeeID" DataSourceID="EntityDataSource1">
            <Columns>
                <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" ReadOnly="True" 
                    SortExpression="EmployeeID" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" 
                    SortExpression="LastName" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" 
                    SortExpression="FirstName" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="TitleOfCourtesy" HeaderText="TitleOfCourtesy" 
                    SortExpression="TitleOfCourtesy" />
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />

            </Columns>
        </asp:GridView>
        <br />


        <asp:EntityDataSource ID="EntityDataSource1" runat="server" 
            ConnectionString="name=NorthwindEntities" 
            DefaultContainerName="NorthwindEntities" EnableDelete="True" 
            EnableFlattening="False" EnableInsert="True" EnableUpdate="True" 
            EntitySetName="Employees">
        </asp:EntityDataSource>
    
        <asp:QueryExtender ID="QueryExtender1" runat="server"
            TargetControlID="EntityDataSource1">
            <asp:MethodExpression TypeName="QueryExtenderMethods" MethodName="FilterEmployees" IgnoreIfNotFound="false" />
        </asp:QueryExtender>
    </div>
    </form>
</body>
</html>
