<%@ Page Culture="auto" UICulture="auto" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SuperCommunity.Models.Membership.Form>" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/css/shared/ImageStyles.css" rel="stylesheet" />
    <div class="container">
        
        <div class="row">
            <div class="span4">
                <h4><%: User.Identity.Name %> <asp:label runat="server" meta:resourcekey="AboutMe"/></h4>

                <a href="/Form/Details/">
                    <img src="/Images/UserPhotos/<%: Model.MyPhoto %>" class="hightPicture">
                </a>
                <h3><asp:label runat="server" meta:resourcekey="AboutMeMessage"/></h3>

                <div class="border-horiz"></div>
                <h4><%: Model.AboutMe %></h4>
            </div>

            

            <div class="span4">
                <h4><asp:label runat="server" meta:resourcekey="MyPhotos"/></h4>
                <h4><a href="/Album/Index">
                    <img src="/Images/Bars/albums.jpg" class="hightPicture" />
                </a>
                </h4>
                <h3><asp:label runat="server" meta:resourcekey="MyPhotosMessage"/></h3>

            </div>

            <div class="span4">
                <h4><asp:label runat="server" meta:resourcekey="AddTags"/></h4>
                <h4><a href="/PictureTag/MyPictures/">
                    <img src="/Images/Bars/CloudTags.jpg" class="hightPicture" />
                </a></h4>
                <h3><asp:label runat="server" meta:resourcekey="AddTagsMessage"/></h3>
            </div>
        </div>
        <div class="row">

            <div class="span4">
                <h4><asp:label runat="server" meta:resourcekey="Gallery"/></h4>
                <h4><a href="/User/Gallery">
                    <img src="/Images/Bars/Photos.jpg" class="hightPicture" /></a></h4>
                <h3><asp:label runat="server" meta:resourcekey="GalleryMessage"/></h3>
            </div>

            <div class="span4">
                <h4><asp:label runat="server" meta:resourcekey="Promotion"/></h4>
                <h4><a href="/Home/Promotion">
                    <img src="/Images/Bars/promotion.jpg" class="hightPicture" /></a></h4>
                <h3><asp:label runat="server" meta:resourcekey="PromotionMessage"/></h3>
            </div>

            <div class="span4">
                <h4><asp:label ID="Label1" runat="server" meta:resourcekey="AboutUs"/></h4>
                <h4><a href="/Home/About">
                    <img src="/Images/Bars/community.jpg" class="hightPicture" /></a></h4>
                <h3><asp:label ID="Label2" runat="server" meta:resourcekey="AboutMeMessage"/></h3>
            </div>

        </div>
    </div>

</asp:Content>
