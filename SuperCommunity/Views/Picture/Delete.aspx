<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SuperCommunity.Models.Membership.Picture>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Удаление фоторафии</h2>

<h3>Are you sure you want to delete this?</h3>

<fieldset>
    <legend></legend>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.Album.AlbumName) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Album.AlbumName) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.PictureName) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.PictureName) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.PictureUrl) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.PictureUrl) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.PictureDescribe) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.PictureDescribe) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <%: Html.AntiForgeryToken() %>
    <p>
        <input type="submit" value="Delete" class="btn-warning" /> 
    </p>
<% } %>

</asp:Content>
