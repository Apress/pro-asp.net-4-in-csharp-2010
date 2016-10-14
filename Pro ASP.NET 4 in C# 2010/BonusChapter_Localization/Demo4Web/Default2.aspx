<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button runat="server" ID="FirstButton" meta:resourcekey="ButtonResource1" />
            <br />
            <asp:Button runat="server" ID="SecondButton" meta:resourcekey="ButtonResource2" />
            <br />
            <asp:LinkButton runat="server" ID="LinkTestButton" meta:resourcekey="LinkButtonResource1" />
        </div>
        <hr />
        Please switch the browser locale settings to see, how the controls are localized
        as shown in the following image (Tools - Internet Options - Languages of the IE
        settings). The resources for localization are located in the <b>ResourceString-table</b>
        of the <b>SimpleResources.mdf</b> database in the App_Data directory of this project.
        <br />
        <img src="IELocaleSettings.JPG" />
    </form>
</body>
</html>
