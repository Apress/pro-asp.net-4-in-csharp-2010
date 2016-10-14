<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <asp:Login ID="Login1" runat="server" BackColor="#E3EAEB" BorderColor="#E6E2D8" 
		BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
		Font-Size="0.8em" ForeColor="#333333" TextLayout="TextOnTop">
			<textboxstyle font-size="0.8em" />
			<loginbuttonstyle backcolor="White" bordercolor="#C5BBAF" borderstyle="Solid" 
			borderwidth="1px" font-names="Verdana" font-size="0.8em" forecolor="#1C5E55" />
			<instructiontextstyle font-italic="True" forecolor="Black" />
			<titletextstyle backcolor="#1C5E55" font-bold="True" font-size="0.9em" 
			forecolor="White" />
        </asp:Login>
    </div>
    </form>
</body>
</html>
