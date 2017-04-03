<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SuperCommunity.Models.Membership.Album>" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create Album</h2>

    <img src="/Images/Album.jpg" style="height: 300px; width: 400px;" />

    <% using (Html.BeginForm())
       { %>
    <%: Html.AntiForgeryToken() %>
    <%: Html.ValidationSummary(true) %>
    
    <%: Html.HiddenFor(model => model.UserId) %>
    
    

    <br />
    <br />

    <div style="color: red;">
        <input type="text" required="required" id="AlbumName" name="AlbumName" placeholder="Введите название альбома" value="" maxlength="100" />
        <%: Html.ValidationMessageFor(model => model.AlbumName) %>
    </div>

    <p>
        <input type="submit" value="Create" class="btn createButton" />
    </p>
    <% } %>
</asp:Content>
