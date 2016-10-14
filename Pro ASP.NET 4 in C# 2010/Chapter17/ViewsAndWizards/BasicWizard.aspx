<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BasicWizard.aspx.cs" Inherits="BasicWizard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 112px">
       <asp:Wizard ID="Wizard1" runat="server" Width="448px" 
              BackColor="#EFF3FB" BorderColor="#B5C7DE" BorderWidth="1px" Font-Names="Verdana"
              CellPadding="5" ActiveStepIndex="0" Font-Size="Small" 
            OnFinishButtonClick="Wizard1_FinishButtonClick">
              <WizardSteps>
                <asp:WizardStep ID="WizardStep1" runat="server" Title="Personal">
                  <h3>Personal Profile</h3>
                  Preferred Programming Language:
                  <asp:DropDownList ID="lstLanguage" runat="server">
                    <asp:ListItem>C#</asp:ListItem>
                    <asp:ListItem>VB</asp:ListItem>
                    <asp:ListItem>J#</asp:ListItem>
                    <asp:ListItem>Java</asp:ListItem>
                    <asp:ListItem>C++</asp:ListItem>
                    <asp:ListItem>C</asp:ListItem>         
                  </asp:DropDownList>
                  <br />
                </asp:WizardStep>
                <asp:WizardStep ID="WizardStep2" runat="server" Title="Company">
                  <h3>Company Profile</h3>
                  Number of Employees: <asp:TextBox ID="txtEmpCount" runat="server"></asp:TextBox><br />
                  Number of Locations: &nbsp;<asp:TextBox ID="txtLocCount" runat="server"></asp:TextBox>
                </asp:WizardStep>
                <asp:WizardStep ID="WizardStep3" runat="server" Title="Software">
                  <h3>Software Profile</h3>
                  Licenses Required:
                  <asp:CheckBoxList ID="lstTools" runat="server">
                    <asp:ListItem>Visual Studio 2008</asp:ListItem>
                    <asp:ListItem>Office 2007</asp:ListItem>
                    <asp:ListItem>Windows Server 2008</asp:ListItem>
                    <asp:ListItem>SQL Server 2008</asp:ListItem>                    
                  </asp:CheckBoxList>
                </asp:WizardStep>
                <asp:WizardStep ID="Complete" runat="server" Title="Complete " StepType="Complete">
                  <br />
                    <asp:Label ID="lblSummary" runat="server" Text="Label"></asp:Label>
                  <br /><br />
                  Thank you for completing this survey.<br />
                  Your products will be delivered shortly.<br /><br />
                </asp:WizardStep>
              </WizardSteps>
           <SideBarStyle VerticalAlign="Top" />
             
            </asp:Wizard>
    
    </div>
    </form>
</body>
</html>
