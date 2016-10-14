<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SimpleDrawingPointer.aspx.cs"
    Inherits="SimpleDrawingPointer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Image ID="Image1" runat="server" ImageUrl="SimpleDrawing.aspx" />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <br />
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>Sample Item</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Image ID="Image2" runat="server" ImageUrl="SimpleDrawing.aspx" />
    </div>
    </form>
</body>
</html>
