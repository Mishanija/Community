<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SuperCommunity.Models.RegisterModel>" %>

<asp:Content ID="registerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Register
</asp:Content>

<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <div class="span6">

        <hgroup class="title">
            <h1>Register.</h1>
            <h2>Create a new account.</h2>
        </hgroup>

        <% using (Html.BeginForm())
           { %>
        <%: Html.AntiForgeryToken() %>
        <%: Html.ValidationSummary() %>

        <fieldset>
            <legend>Registration Form</legend>
            <ol>
                <li>
                    <%: Html.LabelFor(m => m.UserName) %>
                    <%: Html.TextBoxFor(m => m.UserName) %>
                </li>
                <li>
                    <%: Html.LabelFor(m => m.Email) %>
                    <%: Html.TextBoxFor(m => m.Email) %>
                </li>
                <li>
                    <%: Html.LabelFor(m => m.Password) %>
                    <%: Html.PasswordFor(m => m.Password) %>
                </li>
                <li>
                    <%: Html.LabelFor(m => m.ConfirmPassword) %>
                    <%: Html.PasswordFor(m => m.ConfirmPassword) %>
                </li>
            </ol>
            <input type="submit" value="Register" class="btn createButton" />
        </fieldset>
        <% } %>
                </div>
            <div class="span6">
                <img src="/Images/Keys.jpg" style="height: 250px; margin-top: 240px" />
            </div>
            </div>
    </div>
</asp:Content>

