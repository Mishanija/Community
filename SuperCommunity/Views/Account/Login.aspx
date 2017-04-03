<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SuperCommunity.Models.LoginModel>" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Log in
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <div class="span6">


                <hgroup class="title">
                    <h1>Log in.</h1>
                </hgroup>

                <section id="loginForm">
                    <h3>Вход в святилище. Строго охраняется. Нужна <a href="/Account/Register">Регистрация</a> </h3>

                    <% using (Html.BeginForm(new { ReturnUrl = ViewBag.ReturnUrl }))
                       { %>
                    <%: Html.AntiForgeryToken() %>
                    <%: Html.ValidationSummary(true) %>

                    <fieldset>
                        <legend></legend>

                        <%: Html.LabelFor(m => m.UserName) %>
                        <%: Html.TextBoxFor(m => m.UserName) %>
                        <%: Html.ValidationMessageFor(m => m.UserName) %>

                        <%: Html.LabelFor(m => m.Password) %>
                        <%: Html.PasswordFor(m => m.Password) %>
                        <%: Html.ValidationMessageFor(m => m.Password) %>
                        
                        <br />

                        <p style="font-size: 18px;">
                            <input type="checkbox" id="RememberMe" name="RememberMe" value="true" class="checkBox1"/>
                            Запомнить меня                            
                        </p>

                        <input type="submit" value="Log in" class="btn createButton" />
                    </fieldset>
                    <br />
                    <p>
                        <%: Html.ActionLink("Регистрация", "Register") %>
                , если нету ключика.
                    </p>
                    <% } %>
                </section>
            </div>
            <div class="span6">
                <img src="/Images/Lock.png" style="height: 250px; margin-top: 240px" />
            </div>

        </div>
    </div>
</asp:Content>

