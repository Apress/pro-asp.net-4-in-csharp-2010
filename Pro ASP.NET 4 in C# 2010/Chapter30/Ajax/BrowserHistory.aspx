<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BrowserHistory.aspx.cs" Inherits="BrowserHistory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
   
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableHistory="True" EnableSecureHistoryState="false"
                    onnavigate="ScriptManager1_Navigate" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>                
                <asp:Wizard ID="Wizard1" runat="server" BackColor="#EFF3FB" 
                    BorderColor="#B5C7DE" BorderWidth="1px" Font-Names="Verdana" 
                    Font-Size="0.9em" ActiveStepIndex="0" CellPadding="10" Height="146px" 
                    onactivestepchanged="Wizard1_ActiveStepChanged" Width="412px">
                    <StepStyle Font-Size="0.8em" ForeColor="#333333" Width="200px" />
                    <WizardSteps>
                        <asp:WizardStep runat="server" title="Step 1">
                            This is Step 1.
                        </asp:WizardStep>
                        <asp:WizardStep runat="server" title="Step 2">
                            This is Step 2.
                        </asp:WizardStep>
                        <asp:WizardStep runat="server" Title="Step 3">
                            This is Step 3.
                        </asp:WizardStep>
                    </WizardSteps>
                    <SideBarButtonStyle BackColor="#507CD1" Font-Names="Verdana" 
                        ForeColor="White" />
                    <NavigationButtonStyle BackColor="White" BorderColor="#507CD1" 
                        BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" 
                        ForeColor="#284E98" />
                    <SideBarStyle BackColor="#507CD1" Font-Size="0.9em" VerticalAlign="Top" />
                    <HeaderStyle BackColor="#284E98" BorderColor="#EFF3FB" BorderStyle="Solid" 
                        BorderWidth="2px" Font-Bold="True" Font-Size="0.9em" ForeColor="White" 
                        HorizontalAlign="Center" />
                </asp:Wizard>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
