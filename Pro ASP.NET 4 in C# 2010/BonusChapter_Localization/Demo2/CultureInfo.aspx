<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CultureInfo.aspx.cs" Inherits="CultureInfo_aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:Label ID="LegendCI" runat="server"></asp:Label>
      <hr />
      <asp:Label ID="LegendDate" runat="server" /><br />
      <asp:TextBox ID="DateText" runat="server" /><br />
      <asp:Button ID="InsertDate" runat="server" Text="Insert Date (date parsing happens based on your locale-settings)" OnClick="InsertDate_Click" />
        <br />
        <hr />
        <br />
        <strong><em><span style="font-size: 16pt">Remember that the culture info is initialized
            in the code-beside with the de-AT culture (German / Austria). So date-parsing works
            only with the German/Austrian date format (which is dd.mm.yyyy).</span></em></strong></div>
    </form>
</body>
</html>
