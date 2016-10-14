<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ExtendedModel.Models.Product>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

    <table>
        <tr>
            <th></th>

            <th>
                ProductName
            </th>
            <th>
                QuantityPerUnit
            </th>
            <th>
                UnitPrice
            </th>
            <th>
                UnitsInStock
            </th>
    
            <th>
                Discontinued
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id=item.ProductID }) %> |
                <%: Html.ActionLink("Details", "Details", new { id=item.ProductID })%> |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.ProductID })%>
            </td>

            <td>
                <%: item.ProductName %>
            </td>
            <td>
                <%: item.QuantityPerUnit %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.UnitPrice) %>
            </td>
            <td>
                <%: item.UnitsInStock %>
            </td>
            <td>
                <%: Html.CheckBoxFor(e => item.Discontinued, new { disabled = "true" })%>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

