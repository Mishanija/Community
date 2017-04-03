<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SuperCommunity.Models.Membership.Album>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Album
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <h2>Album details</h2>

        <h3>Album name: <%: Model.AlbumName %></h3>

        <div class="row">

            <% foreach (var item in Model.Pictures)
               { %>
            <div class="span4">
             
                <% Html.RenderPartial("PictureInfo", item, null); %>

                <p>
                    <%: Html.ActionLink("Редактировать информацию", "Edit", "Picture", new { id = item.PictureId }, null) %> |
                    <%: Html.ActionLink("Редактировать изображение", "EditEffects", "User", new { id = item.PictureId }, null) %> |
                    <%: Html.ActionLink("Удалить изображение", "Delete", "Picture", new { id = item.PictureId }, null) %>
                </p>
            </div>
            <% } %>
        </div>

        <p style="margin-top: 50px">
            <%: Html.ActionLink("Мои альбомы", "Index") %> |
        <%: Html.ActionLink("Загрузить фото", "UploadPhotos", "User", new { Model.AlbumId }, null) %>
        </p>
    </div>
</asp:Content>
