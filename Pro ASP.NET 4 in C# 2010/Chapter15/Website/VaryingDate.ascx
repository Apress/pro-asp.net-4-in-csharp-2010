<%@ Control Language="C#" AutoEventWireup="true" CodeFile="VaryingDate.ascx.cs" Inherits="VaryingDate" %>
<%@ OutputCache Duration="30" VaryByControl="lstMode"  %>

<asp:DropDownList id="lstMode" runat="server" Width="187px">
            <asp:ListItem>Large</asp:ListItem>
            <asp:ListItem>Small</asp:ListItem>
            <asp:ListItem>Medium</asp:ListItem>
            </asp:DropDownList>&nbsp;<br />
<asp:Button ID="Button1" text="Submit" runat="server" />
<br /><br />

Control generated at:<br />
 <asp:label id="TimeMsg" runat="server" />
