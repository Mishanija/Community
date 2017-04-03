<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SuperCommunity.Models.PageModels.UserAlbumsModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Мои альбомы
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <link href="/Content/css/shared/touchTouch.css" rel="stylesheet" />
    <link href="/Content/css/shared/ImageStyles.css" rel="stylesheet" />

    <script src="/Scripts/jquery.unobtrusive-ajax.min.js"></script>

    <h2>Ваши альбомы</h2>
    
    <a href="/Album/Create" class="btn createButton">Создайте новый альбом </a>
    
    <div class="row">
        <div class="span12">

            <% foreach (var album in Model.Albums)
               { %>
            <h2>Album name: <%: album.AlbumName %></h2>
            
            <% Html.RenderPartial("AlbumPage", album); %>

            <a href="/Album/Edit/<%: album.AlbumId %>" class="btn editButton">Редактировать информацию</a>
            <a href="/Album/Details/<%: album.AlbumId %>" class="btn detailsButton">Подробно</a>
            <a href="/User/UploadPhotos?AlbumId=<%: album.AlbumId %>" class="btn addButton">Добавить новые фотографии</a>
            <a href="/Album/Delete/<%: album.AlbumId %>" class="btn deleteButton">Удалить альбом</a>
            <% } %>
        </div>
    </div>

</asp:Content>
