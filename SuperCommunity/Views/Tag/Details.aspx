<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SuperCommunity.Models.Membership.Tag>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Details</h2>

<fieldset>
    <legend>Tag</legend>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.TagName) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.TagName) %>
    </div>
</fieldset>
<p>

    <%: Html.ActionLink("Edit", "Edit", new { id=Model.TagId }) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
</p>

</asp:Content>
