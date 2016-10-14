<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VaryByControlHost.aspx.cs" Inherits="VaryByControlHost" %>
<%@ Register Src="VaryingDate.ascx" TagName="VaryingDate" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:VaryingDate ID="VaryByControl1" runat="server" />
    
    </div>
    </form>
</body>
</html>
