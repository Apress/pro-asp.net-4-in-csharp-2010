<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ExtendedModel.Models.Product>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ProductID) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ProductID) %>
                <%: Html.ValidationMessageFor(model => model.ProductID) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ProductName) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ProductName) %>
                <%: Html.ValidationMessageFor(model => model.ProductName) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.SupplierID) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.SupplierID) %>
                <%: Html.ValidationMessageFor(model => model.SupplierID) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.CategoryID) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.CategoryID) %>
                <%: Html.ValidationMessageFor(model => model.CategoryID) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.QuantityPerUnit) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.QuantityPerUnit) %>
                <%: Html.ValidationMessageFor(model => model.QuantityPerUnit) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.UnitPrice) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.UnitPrice) %>
                <%: Html.ValidationMessageFor(model => model.UnitPrice) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.UnitsInStock) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.UnitsInStock) %>
                <%: Html.ValidationMessageFor(model => model.UnitsInStock) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.UnitsOnOrder) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.UnitsOnOrder) %>
                <%: Html.ValidationMessageFor(model => model.UnitsOnOrder) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ReorderLevel) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ReorderLevel) %>
                <%: Html.ValidationMessageFor(model => model.ReorderLevel) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Discontinued) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Discontinued) %>
                <%: Html.ValidationMessageFor(model => model.Discontinued) %>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

