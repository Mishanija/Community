<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SuperCommunity.Models.Membership.Picture>" %>

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

        <%: Html.HiddenFor(model => model.PictureId) %>
        <%: Html.HiddenFor(model => model.PictureUrl) %>
        <%: Html.HiddenFor(model => model.AlbumId) %>
        <%: Html.HiddenFor(model => model.PictureName) %>
        
        <img src="/Images/UserPhotos/<%: Model.PictureUrl %>" width="500" style="height: 380px;" />
                
        <div class="editor-label">
            <h4>Описание изображения</h4>
        </div>
        <div class="editor-field">
            <%: Html.TextAreaFor(model => model.PictureDescribe, new { style = "height: 100px; width: 300px;" })%>
            <%: Html.ValidationMessageFor(model => model.PictureDescribe) %>
        </div>

        <p>
            <input type="submit" value="Save" class="btn-success btn-large" />
        </p>
    </fieldset>
<% } %>
    
</asp:Content>
