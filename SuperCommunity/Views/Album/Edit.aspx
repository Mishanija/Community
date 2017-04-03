<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SuperCommunity.Models.Membership.Album>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Edit</h2>

<% using (Html.BeginForm()) { %>
    <%: Html.AntiForgeryToken() %>
    <%: Html.ValidationSummary(true) %>

    <fieldset>
        <legend></legend>

        <%: Html.HiddenFor(model => model.AlbumId) %>
        <%: Html.HiddenFor(model => model.UserId) %>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.AlbumName) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.AlbumName) %>
            <%: Html.ValidationMessageFor(model => model.AlbumName) %>
        </div>

        <p>
            <input type="submit" value="Save" class="btn-success"/>
        </p>
    </fieldset>
<% } %>
    
</asp:Content>
