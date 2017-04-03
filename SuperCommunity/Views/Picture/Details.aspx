<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SuperCommunity.Models.Membership.Picture>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <h2>Details</h2>

        <% Html.RenderPartial("PictureInfo"); %>

        <p>
            <a href="/Picture/Edit/<%: Model.PictureId %>" class="btn btn-success">Редактировать</a> 
            <a href="/Album/Index/" class="btn btn-info">Мои альбомы</a> 
        </p>

    </div>
</asp:Content>
