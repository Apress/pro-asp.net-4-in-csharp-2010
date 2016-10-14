<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompiledLinqQuery.aspx.cs" Inherits="CompiledLinqQuery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged" Width="149px">
            <asp:ListItem>London</asp:ListItem>
            <asp:ListItem>Paris</asp:ListItem>
            <asp:ListItem>San Francisco</asp:ListItem>
        </asp:DropDownList>
    
    </div>
    </form>
</body>
</html>
