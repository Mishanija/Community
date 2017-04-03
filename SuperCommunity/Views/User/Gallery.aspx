<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SuperCommunity.Models.PageModels.GalleryModel>" %>

<%@ Import Namespace="SuperCommunity.HtmlHelpers.Solutions" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Gallery
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <link href="/Content/css/pages/likes.css" rel="stylesheet" />
    <link href="/Content/css/shared/ImageStyles.css" rel="stylesheet" />
    <link href="/Content/css/shared/touchTouch.css" rel="stylesheet" />
    <link href="/Content/css/pages/tagCloud.css" rel="stylesheet" />

    <script src="/Content/js/jquery.js"></script>
    <script src="/Content/js/jquery.easing.1.3.js"></script>
    <script src="/Content/js/jquery.flexslider-min.js"></script>

    <script src="/Content/js/touchTouch.jquery.js"></script>
    <script src="/Scripts/jquery.unobtrusive-ajax.min.js"></script>



    <div class="row">
        <div class="span3">
            <h1>Gallery</h1>
        </div>

        <h4>Поиск фотографий по тэгам</h4>
        <div class="span7">
            <%: Html.BuildTagCloud(Model.TagCloud, "Gallery", "/User/Gallery") %>
        </div>
    </div>

    <div id="Gallery">
        <% Html.RenderPartial("AjaxGallery", Model); %>
    </div>


</asp:Content>
