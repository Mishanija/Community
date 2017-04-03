<%@ Page Title="yyy" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SuperCommunity.Models.PageModels.EditTagsModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    EditTags
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>EditTags</h2>

    <% using (Html.BeginForm())
       { %>
    <%: Html.AntiForgeryToken() %>
    <%: Html.ValidationSummary(true) %>


    <fieldset>
        <legend></legend>

        <%: Html.HiddenFor(model => model.PictureUrl) %>

        <div class="row">

            <div class="span4">
                <img src="/Images/UserPhotos/<%: Model.PictureUrl %>" alt="" style="height: 250px; width: 250px;" />
                <br /><br />
                <input type="submit" value="Подать данные" class="btn createButton" />
            </div>

            <div class="span8">
                <h4>Отметьте фотографию нужными тэгами:</h4>
                <br />


                <% int count = 0;
                   foreach (var selectTag in Model.SelectTags)
                   { %>
                <div class="span2">
                    <h3>
                        <%: Html.CheckBoxFor(model => model.SelectTags[count].IsSelected, new {style = "height: 17px; width: 17px;"}) %>
                        <%: selectTag.TagName %>
                    </h3>
                    <%: Html.HiddenFor(model => model.SelectTags[count].TagName) %>
                </div>

                <% count++;
               } %>
            </div>
        </div>

    </fieldset>
    <% } %>
</asp:Content>
