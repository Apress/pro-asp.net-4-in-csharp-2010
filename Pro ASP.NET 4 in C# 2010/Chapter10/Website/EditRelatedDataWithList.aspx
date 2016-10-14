<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditRelatedDataWithList.aspx.cs" Inherits="EditRelatedDataWithList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="sourceProducts" runat="server" ConnectionString="<%$ ConnectionStrings:Northwind %>"
            ProviderName="System.Data.SqlClient" SelectCommand="SELECT ProductID,ProductName,Products.CategoryID,CategoryName,UnitPrice FROM Products INNER JOIN Categories ON Products.CategoryID=Categories.CategoryID"
            UpdateCommand="UPDATE Products SET ProductName=@ProductName,CategoryID=@CategoryID,UnitPrice=@UnitPrice WHERE ProductID=@ProductID"
            ></asp:SqlDataSource>
            
            <asp:SqlDataSource ID="sourceCategories" runat="server" ConnectionString="<%$ ConnectionStrings:Northwind %>"
            ProviderName="System.Data.SqlClient" SelectCommand="SELECT CategoryName,CategoryID FROM Categories"></asp:SqlDataSource>
            
            
        <asp:DetailsView ID="detailsProducts" runat="server" AllowPaging="True" 
            AutoGenerateEditButton="True" AutoGenerateRows="False"
            BorderStyle="Double" CellPadding="4" DataKeyNames="ProductID" DataSourceID="sourceProducts"
            Font-Names="Verdana" Font-Size="Small" ForeColor="#333333" GridLines="None" Height="50px"
            Width="280px" OnPageIndexChanged="DetailsView1_PageIndexChanged">
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <CommandRowStyle BackColor="#FFFFC0" Font-Bold="True" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <FieldHeaderStyle BackColor="#FFFF99" Font-Bold="True" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <Fields>
                <asp:BoundField DataField="ProductID" HeaderText="ID" InsertVisible="False"
                    ReadOnly="True" SortExpression="ProductID" />
                <asp:BoundField DataField="ProductName" HeaderText="Product" SortExpression="ProductName" />                
                <asp:TemplateField HeaderText="Category" SortExpression="CategoryID">
                    <ItemTemplate>
                      <%# Eval("CategoryName") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                      <asp:DropDownList id="lstCategories" runat="server" DataSourceID="sourceCategories"
                       DataTextField="CategoryName" DataValueField="CategoryID" 
                        SelectedValue='<%# Bind("CategoryID")%>' >
                      </asp:DropDownList>                
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="UnitPrice" HeaderText="Price" SortExpression="UnitPrice" />                
            </Fields>
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:DetailsView>
        
        </div>
    </form>
</body>
</html>
