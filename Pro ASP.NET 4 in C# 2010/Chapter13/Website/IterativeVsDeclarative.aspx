<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IterativeVsDeclarative.aspx.cs" Inherits="IterativeVsDeclarative" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Iterative Vs. Decalarative</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="cmdForeach" runat="server" OnClick="cmdForeach_Click" Text="Get Matches with foreach" />
        <asp:Button ID="cmdLinq" runat="server" OnClick="cmdLinq_Click" Text="Get Matches with LINQ" /><br />
        <br />
        <asp:GridView ID="gridEmployees" runat="server">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
