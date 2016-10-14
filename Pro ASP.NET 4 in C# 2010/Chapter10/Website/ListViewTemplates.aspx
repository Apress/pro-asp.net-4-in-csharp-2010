<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListViewTemplates.aspx.cs" Inherits="ListViewTemplates" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="sourceEmployees" runat="server" ConnectionString="<%$ ConnectionStrings:Northwind %>"
            ProviderName="System.Data.SqlClient"
            SelectCommand="SELECT EmployeeID, FirstName, LastName, Title, City, Country, Notes, Address, Region, PostalCode, HomePhone, TitleOfCourtesy FROM Employees">
        </asp:SqlDataSource>

        <asp:ListView ID="ListView1" runat="server" DataSourceID="sourceEmployees" GroupItemCount="3">            
        <LayoutTemplate>
            <table border="1">
                <tr id="groupPlaceholder" runat="server"></tr>
            </table>
            <asp:DataPager runat="server" ID="ContactsDataPager" PageSize="6">
                <Fields>
                   <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowLastPageButton="true"
                        FirstPageText="|&lt;&lt; " LastPageText=" &gt;&gt;|"
                        NextPageText=" &gt; " PreviousPageText=" &lt; " />
                </Fields>
            </asp:DataPager>
        </LayoutTemplate>
        
        <GroupTemplate>
            <tr><td runat="server" id="itemPlaceholder" valign="top" /></tr>
        </GroupTemplate>

        <ItemTemplate>
            <td>
              <b>
                <%# Eval("EmployeeID") %>- 
                <%# Eval("TitleOfCourtesy") %> <%# Eval("FirstName") %> <%# Eval("LastName") %></b><hr />
              <small><i>
                <%# Eval("Address") %><br />
                <%# Eval("City") %>, <%# Eval("Country") %>,
                <%# Eval("PostalCode") %><br />
                <%# Eval("HomePhone") %></i><br /><br />
                <%# Eval("Notes") %><br /><br />
              </small>
            </td>  
        </ItemTemplate>                  
        </asp:ListView>
    </div>
    </form>
</body>
</html>
