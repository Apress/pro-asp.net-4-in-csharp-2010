<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImageHandlerTest.aspx.cs" Inherits="ImageHandlerTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Allowed:
        <img src="Images/360.gif" alt="Crayons" /><br />
        <br />
        <br />
        To see a denied image request, follow these steps:<br />
        <br />
        1. Open a new browser window <a href="" target="_blank">here</a>
        <br />
        2. Type this into the address bar:
        <asp:TextBox ID="txtUrl" runat="server" Width="360px"></asp:TextBox><br />
        </div>
    </form>
</body>
</html>
