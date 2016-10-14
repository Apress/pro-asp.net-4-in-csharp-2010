<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Grouping2.aspx.cs" Inherits="Grouping2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView ID="gridEmployees" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Category" HeaderText="Category" />
            <asp:BoundField DataField="MaximumPrice" HeaderText="MaximumPrice" DataFormatString="{0:C}" />
            <asp:BoundField DataField="MinimumPrice" HeaderText="MinimumPrice" DataFormatString="{0:C}" />
            <asp:BoundField DataField="AveragePrice" HeaderText="AveragePrice" DataFormatString="{0:C}" />    
        </Columns>
    </asp:GridView>
    </div>
    </form>
</body>
</html>
