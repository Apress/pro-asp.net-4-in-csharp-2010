<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginTest.aspx.cs" Inherits="LoginTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>    
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    
        
    <script type="text/javascript">
    function doLogin()
    {
        // Pull the user name and password from two text boxes
        // (using the $get shortcut).
        var username = $get("txtUserName");
        var password = $get("txtPassword");
        // Log in using the authentication service.
        Sys.Services.AuthenticationService.login(username.value, password.value,
          false, null, null, onLoginCompleted, onLoginFailed, null);
    }
    
    function onLoginCompleted(validCredentials, userContext, methodName)
    {
        // The asynchronous login attempt has finished, but you still need to check
        // the Boolean validCredentials parameter to determine if it succeeded.
        if (validCredentials == false)
        {
            $get("lblStatus").innerHTML = "Login failed.";
        }
        else
        {
            $get("lblStatus").innerHTML = "Logged in.";
        }
    }

    function onLoginFailed(error, userContext, methodName)
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
        
        <table>
          <tr>
            <td>User Name:</td>
            <td><input id="txtUserName" type="text" /></td>
          </tr>
          <tr>
            <td>Password:</td>
            <td><input id="txtPassword" type="password" /></td>
          </tr>
        </table>
        <br />        
        <span id="lblStatus" style="font-weight: bold; color: Red;"></span>
        <br /><br />
        <input id="cmdLogin" type="button" value="Login" onclick="doLogin();" />
        <br /><br />
        <span id="lblInfo" runat="server">
        Try user: <b>test</b> password: <b>test99!</b>
        </span>
        
        <br />
        <br />
        <br />
        <a href="Secure\RoleTest.aspx">Check Roles</a> (must be logged in)
        <br />
        <a href="Secure\ProfileTest.aspx">Check Profile</a> (must be logged in)
    </div>

    </form>
</body>
</html>
