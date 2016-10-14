<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SessionStateTest.aspx.cs" Inherits="SessionStateTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label id="lblSession" runat="server" Font-Size="Medium" Font-Names="Verdana" Font-Bold="True"></asp:Label>
        <br /><br />
	    <div style="border: groove 2px; background-color: #FFFFCC;">
	        <table>
	            <tr>
	                <td>
	                    <asp:ListBox id="lstItems" runat="server" Width="208px" Height="128px"></asp:ListBox>
	                </td>
	                <td style="vertical-align: top;">
	                    <asp:Button id="cmdMoreInfo" runat="server" Text="More Information" OnClick="cmdMoreInfo_Click"></asp:Button>
	                    <br /><br />
		                <asp:Label id="lblRecord" runat="server" Font-Size="Small" Font-Names="Verdana" Font-Bold="True"></asp:Label>
	                </td>
	            </tr>		    
		    </table>
	    </div>
    </div>
    </form>
</body>
</html>
