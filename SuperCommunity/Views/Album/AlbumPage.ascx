<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SuperCommunity.Models.Entities.AlbumEditModel>" %>

<%@ Import Namespace="SuperCommunity.HtmlHelpers.Solutions" %>

<%: Ajax.BuildAlbumSlideShow(Model.Pictures, Model.AlbumId) %>



