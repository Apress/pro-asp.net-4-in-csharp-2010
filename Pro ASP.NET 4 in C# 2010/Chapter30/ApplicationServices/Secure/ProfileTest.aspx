<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProfileTest.aspx.cs" Inherits="Secure_ProfileTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="../StyleSheet.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">
    function pageLoad()
    {
        Sys.Services.ProfileService.load(null, onLoadCompleted, onLoadFailed, null);
    }

    function onLoadCompleted(numProperties, userContext, methodName)
    {
        var profile = Sys.Services.ProfileService.properties;
        alert ("Your name is " + profile.FirstName + " " + profile.LastName);
    }

    function onLoadFailed(error, userContext, methodName)
    {
        alert(error.get_message());
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>    
    </div>
    </form>
</body>
</html>
