<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SuperCommunity.Models.Membership.Album>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete</h2>

    <img src="/Images/delete.jpg" style="height: 150px; width: 270px;" />

    <h3>Are you sure you want to delete "<%: Model.AlbumName %>" album?</h3>

    <ul class="list-photo">
        <% foreach (var picture in Model.Pictures)
           { %>

        <li>
            <img src="/Images/UserPhotos/<%: picture.PictureUrl %>" width="150" style="height: 100px; visibility: visible; opacity: 1;">
        </li>
        <% } %>
    </ul>

    <% using (Html.BeginForm())
       { %>
    <%: Html.AntiForgeryToken() %>
    <p>
        <input type="submit" value="Delete" class="btn-warning" />
        |
        <a href="/Album/Index" class="btn" style="color: #FFFFFF; background-image: linear-gradient(to bottom, #1638C0, #21D845); background-color: #3F5AAF">Нет, не надо!</a>
    </p>
    <% } %>
</asp:Content>
