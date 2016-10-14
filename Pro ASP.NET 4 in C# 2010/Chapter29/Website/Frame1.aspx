<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Frame1.aspx.cs" Inherits="Frame1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<a href="http://www.apress.com" target="content">Apress</a>
		<br /><br />
		<img src="buttonOriginal.jpg" onclick="parent.content.location='http://www.apress.com'" id="IMG1" alt="" />
		<br /><br />
		<asp:Button id="Button1" runat="server" Text="Click Here for Google" Width="144px" OnClick="Button1_Click"></asp:Button>
    </div>
    </form>
</body>
</html>
