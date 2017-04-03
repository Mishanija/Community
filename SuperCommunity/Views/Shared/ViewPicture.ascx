<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<String>" %>


<% if (Model.Equals("NoPhoto.jpg"))
   {%>
<img src="/Images/NoPhoto.jpg" style="height: 200px; width: 300px;">
<%  }
   else
   {%>
<img src="/Images/UserPhotos/<%: Model %>" style="height: 200px; width: 300px;">
<% } %>

