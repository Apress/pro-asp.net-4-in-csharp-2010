<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CalendarTest.aspx.cs" Inherits="CalendarTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Calendar runat="server" ID="Calendar1"  ForeColor="#663399" BackColor="#FFFFCC" 
		onselectionchanged="Calendar1_SelectionChanged" BorderColor="#FFCC66" 
		BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
		Height="200px" SelectionMode="DayWeekMonth" ShowGridLines="True" Width="220px" >
		<selecteddaystyle backcolor="#CCCCFF" font-bold="True" />
		<selectorstyle backcolor="#FFCC66" />
		<todaydaystyle backcolor="#FFCC66" forecolor="White" />
		<othermonthdaystyle forecolor="#CC9966" />
		<nextprevstyle font-size="9pt" forecolor="#FFFFCC" />
		<dayheaderstyle backcolor="#FFCC66" font-bold="True" height="1px" />
		<titlestyle backcolor="#990000" font-bold="True" font-size="9pt" 
		forecolor="#FFFFCC" />
		</asp:Calendar>
    	<br />
		<asp:Label ID="lblDates" runat="server"></asp:Label> 
    </div>
    </form>
</body>
</html>
