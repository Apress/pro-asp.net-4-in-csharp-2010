<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LinkTable.ascx.cs" Inherits="LinkTable" %>
<table cellpadding="2" width="100%" border="1">
	<tr>
		<td>
			<p style="margin: 8px">
			<asp:label id="lblTitle" Font-Size="Small"
			  Font-Names="Verdana" Font-Bold="True" ForeColor="#C00000"
			  runat="server">[Title Goes Here]</asp:label></p>
		</td>
	</tr>
	<tr>
		<td>
		    <asp:GridView id="gridLinkList" runat="server" OnRowCommand="gridLinkList_LinkClicked" AutoGenerateColumns="false"
		     ShowHeader="false" GridLines="None">
		      <Columns>
				<asp:TemplateField>
				<ItemTemplate>
				  <img height="23" src="exclaim.gif" alt="Menu Item" style="vertical-align: middle" />
				  <asp:LinkButton id="HyperLink1" Font-Names="Verdana" Font-Size="XX-Small"
				     ForeColor="#0000cd" runat="server" 
				     Text='<%# DataBinder.Eval(Container.DataItem, "Text") %>' 
				     CommandName="LinkClicked"
				     CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Url") %>'>
				   </asp:LinkButton>
				 </ItemTemplate>
		        </asp:TemplateField> 
			  </Columns>
			</asp:GridView>
		</td>
	</tr>
</table>
