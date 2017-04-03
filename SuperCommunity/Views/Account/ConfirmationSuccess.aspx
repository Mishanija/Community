<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ConfirmationSuccess
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>
    Регистрация прошла успешно, можно перейти по ссылке для авторизации -  
    <a href="/Account/Login">Кликнуть сюда :))</a>
</h2>
    

</asp:Content>
