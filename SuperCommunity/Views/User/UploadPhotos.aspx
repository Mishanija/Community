<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    UploadPhotos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <h2>Upload</h2>

        <div class="row">
            <div class="span3">
                <p>
                    <% using (Html.BeginForm("UploadPhotos", "User", FormMethod.Post, new { enctype = "multipart/form-data" }))
                       { %>
                    <input type="file" name="fileUpload" multiple /><br />
                    
                    <input type="submit" name="Navigation" id="button" value="Upload" />

                    <input type="hidden" value="<%: Convert.ToInt32(Request["albumId"]) %>" name="id" />
                    <% } %>
                </p>
            </div>
            <div class="span6">

                <p style="text-align: center">
                    <img src="/Images/uploadPhotos.png" style="height: 300px" />
                </p>

            </div>
        </div>
    </div>
    
    

</asp:Content>
