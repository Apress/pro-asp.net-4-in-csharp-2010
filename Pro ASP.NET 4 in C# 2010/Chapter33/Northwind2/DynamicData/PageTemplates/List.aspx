<%@ Page Language="C#" MasterPageFile="~/Site.master" CodeFile="List.aspx.cs" Inherits="List" %>

<%@ Register src="~/DynamicData/Content/GridViewPager.ascx" tagname="GridViewPager" tagprefix="asp" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:DynamicDataManager ID="DynamicDataManager1" runat="server" AutoLoadForeignKeys="true">
        <DataControls>
            <asp:DataControlReference ControlID="GridView1" />
        </DataControls>
    </asp:DynamicDataManager>

    <h2 class="DDSubHeader"><%= table.DisplayName%></h2>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="DD">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" EnableClientScript="true"
                    HeaderText="List of validation errors" CssClass="DDValidator" />
                <asp:DynamicValidator runat="server" ID="GridViewValidator" ControlToValidate="GridView1" Display="None" CssClass="DDValidator" />

                <asp:QueryableFilterRepeater runat="server" ID="FilterRepeater">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("DisplayName") %>' OnPreRender="Label_PreRender" />
                        <asp:DynamicFilter runat="server" ID="DynamicFilter" OnFilterChanged="DynamicFilter_FilterChanged" /><br />
                    </ItemTemplate>
                </asp:QueryableFilterRepeater>
                <br />
            </div>

            <asp:GridView ID="GridView1" runat="server" DataSourceID="GridDataSource" EnablePersistedSelection="True"
                AllowPaging="True" AllowSorting="True" CssClass="DDGridView"
                RowStyle-CssClass="td" HeaderStyle-CssClass="th" CellPadding="4" 
                ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:DynamicHyperLink runat="server" Action="Edit" Text="Edit"
                            />&nbsp;<asp:LinkButton runat="server" CommandName="Delete" Text="Delete"
                                OnClientClick='return confirm("Are you sure you want to delete this item?");'
                            />&nbsp;<asp:DynamicHyperLink runat="server" Text="Details" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" CssClass="th" Font-Bold="True" 
                    ForeColor="White" />

                <PagerStyle CssClass="DDFooter" BackColor="#2461BF" ForeColor="White" 
                    HorizontalAlign="Center"/>        
                <PagerTemplate>
                    <asp:GridViewPager runat="server" />
                </PagerTemplate>
                <EditRowStyle BackColor="#2461BF" />
                <EmptyDataTemplate>
                    There are currently no items in this table.
                </EmptyDataTemplate>
                <RowStyle BackColor="#EFF3FB" CssClass="td" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>

            <asp:LinqDataSource ID="GridDataSource" runat="server" EnableDelete="true" />
            
            <asp:QueryExtender TargetControlID="GridDataSource" ID="GridQueryExtender" runat="server">
                <asp:DynamicFilterExpression ControlID="FilterRepeater" />
            </asp:QueryExtender>

            <br />

            <div class="DDBottomHyperLink">
                <asp:DynamicHyperLink ID="InsertHyperLink" runat="server" Action="Insert"><img runat="server" src="~/DynamicData/Content/Images/plus.gif" alt="Insert new item" />Insert new item</asp:DynamicHyperLink>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

