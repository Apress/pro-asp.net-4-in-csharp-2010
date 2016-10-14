<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ExtendedModel.Models.ProductListWrapper>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <% using (Html.BeginForm()) {%>



    <fieldset>
        <legend>Edit Product Details</legend>

        <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

        <table>
                <tr>
                    <td>Product Name:</td>
                    <td><%: Html.TextBoxFor(model => model.product.ProductName) %></td>
                </tr>
                <tr>
                    <td>Supplier:</td>
                    <td><%: Html.DropDownListFor(model => model.SelectedSupplier, ViewData["suppliers"] as SelectList)  %></td>
                </tr>
                <tr>
                    <td>Category:</td>
                    <td><%: Html.DropDownListFor(model => model.SelectedCategory, ViewData["categories"] as SelectList)  %></td>
                </tr>
                <tr>
                    <td>Quantity per Unit:</td>
                    <td><%: Html.TextBoxFor(model => model.product.QuantityPerUnit)%></td>
                </tr>
                <tr>
                    <td>Unit Price:</td>
                    <td><%: Html.TextBoxFor(model => model.product.UnitPrice, new { Value = String.Format("{0:F2}", Model.product.UnitPrice) })%></td>
                </tr>
                <tr>
                    <td>Units in Stock:</td>
                    <td><%: Html.TextBoxFor(model => model.product.UnitsInStock)%></td>
                </tr>
                <tr>
                    <td>Units on Order:</td>
                    <td><%: Html.TextBoxFor(model => model.product.UnitsOnOrder)%></td>
                </tr>
                <tr>
                    <td>Reorder Level:</td>
                    <td><%: Html.TextBoxFor(model => model.product.ReorderLevel)%>
                    <%: Html.ValidationMessageFor(model => model.product.ReorderLevel) %>
                    </td>
                </tr>
                <tr>
                    <td>Discontinued:</td>
                    <td><%: Html.CheckBoxFor(model => model.product.Discontinued)%></td>
                </tr>
        </table>
    </fieldset>
    <p>
        <input type="submit" value="Save" />
    </p>
    <% } %>
    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>

