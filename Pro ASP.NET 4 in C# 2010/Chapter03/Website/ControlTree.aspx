<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ControlTree.aspx.cs" Inherits="ControlTree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head >
    <title>Controls</title>
</head>
    <body>    
        <p><i>This is static HTML (not a web control).</i></p>
        <form id="frm" method="post" runat="server">
        <div>
            <asp:panel id="MainPanel" runat="server" Height="112px">
            <p><asp:Button id="Button1" runat="server" Text="Button1"/>
            <asp:Button id="Button2" runat="server" Text="Button2"/>
            <asp:Button id="Button3" runat="server" Text="Button3"/></p>
            <p><asp:Label id="Label1" runat="server" Width="48px">
              Name:</asp:Label>
            <asp:TextBox id="TextBox1" runat="server"></asp:TextBox></p>
            </asp:panel>
            <p><asp:Button id="Button4" runat="server" Text="Button4"/></p>
        </div>
        </form>
        <p><i>This is static HTML (not a web control).</i></p>
    </body>
</html>
