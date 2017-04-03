<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SuperCommunity.Models.Membership.Picture>" %>


<img src="/Images/UserPhotos/<%: Model.PictureUrl %>" width="350" style="height: 230px"/>

<h5>Описание изображения: <%: Model.PictureDescribe %></h5>