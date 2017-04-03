<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    AlreadyRegistered
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h4>Вы зашли на сайт, как пользователь. Чтобы зарегистрировать еще один аккаунт, произведите выход с текущего аккаунта и повторите попытку.</h4>

    <p style="text-align: center">
        <img src="../../Images/Strange.jpg" alt="" style="height: 400px; width: 650px;" />
    </p>

</asp:Content>
