<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SuperCommunity.Models.PageModels.GalleryModel>" %>

<%@ Import Namespace="SuperCommunity.HtmlHelpers.Solutions" %>


    <%: Ajax.BuildGallery(Model.PaginationModel, Model.TagId, "Gallery") %>



