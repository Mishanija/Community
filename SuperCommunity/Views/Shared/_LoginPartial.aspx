<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<% if (Request.IsAuthenticated)
   { %>
   <h4> Hi, <%: Page.User.Identity.Name %> ! <% using (Html.BeginForm("LogOff", "Account", FormMethod.Post, new { id = "logoutForm" })) { %> 
<%: Html.AntiForgeryToken() %> [ <a href="javascript:document.getElementById('logoutForm').submit()">Выйти</a> ]
<% } %> </h4>
<% }
   else
   { %>
<h4>[ <%: Html.ActionLink("Войти", "Login", "Account") %> ] </h4>
<% } %>