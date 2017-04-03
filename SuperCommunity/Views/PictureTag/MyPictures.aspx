<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SuperCommunity.Models.PageModels.MyPicturesModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    MyPictures
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h3>Выберите фотографию, которой нужно добавить / отредактировать тэги</h3>


<% foreach (var item in Model.Images) { %>

    <a href="/PictureTag/EditTags/<%: item.PictureId %>">
        <img src="/Images/UserPhotos/<%: item.PictureUrl %>" alt="" style="height: 250px; width: 250px; margin-top: 15px; margin-left: 10px;" />
    </a>

<% } %>


</asp:Content>
