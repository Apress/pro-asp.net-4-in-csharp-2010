<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ItemRemovedCallbackTest.aspx.cs" Inherits="ItemRemovedCallbackTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:button id="cmdCheck" runat="server"
    	  Width="103px" Text="Check Items" OnClick="cmdCheck_Click"></asp:button>
		<asp:button id="cmdRemove" runat="server" Width="135px" 
		  Text="Remove One Item" OnClick="cmdRemove_Click"></asp:button>
		<br /><br />
		<asp:label id="lblInfo" runat="server"
		  Width="480px" BorderWidth="2px"
		  BorderStyle="Groove" BackColor="LightYellow"></asp:label>
    </div>
    </form>
</body>
</html>
