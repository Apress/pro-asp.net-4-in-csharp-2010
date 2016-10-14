<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>
        <asp:Label runat="server" ID="TitleLabel" meta:resourcekey="TitleLabelResource1" />
    </h1>
    <asp:Label runat="server" ID="SelectionLegend" meta:resourcekey="SelectionLegendResource1" /><br />
    <asp:DropDownList runat="server" ID="LanguageList" meta:resourcekey="LanguageListResource1" Width="166px">
        <asp:ListItem Text="German" Value="de-at" meta:resourcekey="ListItemResource1" />
        <asp:ListItem Text="English" Value="en-us" meta:resourcekey="ListItemResource2" />
    </asp:DropDownList>
    <br />
    <asp:Button runat="server" ID="SwitchCommand" meta:resourcekey="SwitchCommandResource1" OnClick="SwitchCommand_Click" />
    </div>
    </form>
</body>
</html>
