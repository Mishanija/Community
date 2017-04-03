<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SuperCommunity.Models.PageModels.ContactModel>" %>

<%@ Import Namespace="SuperCommunity.HtmlHelpers.Solutions" %>

<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    About - My ASP.NET MVC Application
</asp:Content>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">

    <link href="/Content/css/pages/contactsAnimate.css" rel="stylesheet" />

    <script src="/Scripts/jquery-1.8.2.min.js"></script>

    <div class="bg-content">
        <div class="container">
            <h2>Сообщество кибер ... хороших людей :)</h2>
            <h2>Присоединяйтесь к нам!</h2>
            <div class="row">
                <div class="span6">
                    <h3>Мы вконтакте - <a href="http://vk.com/ilearning" title="группа на вк">Группа</a> </h3>
                    <h3>Вступить немедленно - <%: Html.ActionLink("Регистрация", "Register", "Account")%> </h3>
                    <%: Html.AnimateMyContacts(Model) %>
                </div>

                <div class="span6">
                    <p style="text-align: center">
                        <img src="/Images/Pages/good people.jpg" style="height: 500px" />
                    </p>
                </div>
            </div>
            <h1></h1>
        </div>
    </div>


    <script src="/Content/js/pages/AnimateContacts.js"></script>

    <script>
        $(document).ready(animateContacts( <%: Model.IconsSize %>));
    </script>

</asp:Content>
