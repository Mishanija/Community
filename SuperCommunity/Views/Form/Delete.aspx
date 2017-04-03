<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<SuperCommunity.Models.Membership.Form>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>Form</legend>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.UserProfile.UserName) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.UserProfile.UserName) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.AboutMe) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.AboutMe) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.MyPhoto) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.MyPhoto) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <%: Html.AntiForgeryToken() %>
    <p>
        <input type="submit" value="Delete" />
    </p>
<% } %>

</asp:Content>
