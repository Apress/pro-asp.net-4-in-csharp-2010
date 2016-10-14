<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdatePanelTest.aspx.cs" Inherits="UpdatePanelTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="lblError" style="color:Red; font-weight:bold"></div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
              <div style="background-color:#FFFFDD; padding: 20px">
                <asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="Refresh Time" />
                </div>
            </ContentTemplate>           
        </asp:UpdatePanel>
        &nbsp;<asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div style="background-color:#FFFFDD;padding: 20px">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True"></asp:Label>
                    <br />
                    <br />
                <asp:Button ID="Button2" runat="server" Text="Refresh Time" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        &nbsp;
        <br />
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <div style="background-color:#FFFFDD;padding: 20px">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="Button3" runat="server" Text="Refresh Time" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        
        
        
        <script type="text/javascript">
        function pageLoad()
        {
            var pageManager = Sys.WebForms.PageRequestManager.getInstance();
            pageManager.add_endRequest(endRequest);
        }
        function endRequest(sender, args)
        {
            // Handle the error.
            if (args.get_error() != null)
            {
                $get("lblError").innerHTML = args.get_error().message;

                // Suppress the message box.
                args.set_errorHandled(true);
            }
        }
        </script>

        
    </div>
    </form>
</body>
</html>

