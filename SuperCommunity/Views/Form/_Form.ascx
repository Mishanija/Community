<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SuperCommunity.Models.PageModels.FormModel>" %>



<% using (Html.BeginForm())
       { %>
<%: Html.AntiForgeryToken() %>
<%: Html.ValidationSummary(true) %>


<%: Html.ValidationMessageFor(model => model.Form.FormId) %>
<%: Html.ValidationMessageFor(model => model.Form.MyPhoto) %>
<%: Html.ValidationMessageFor(model => model.PictureLinks) %>



<div class="row">
    <div class="span3">

        <div style="color: red;">
            <input type="text" id="Form.AboutMe" name="Form.AboutMe" required="required" maxlength="100" placeholder="Несколько слов о себе" value="<%: Model.Form.AboutMe %>" />
            <%: Html.ValidationMessageFor(model => model.Form.AboutMe) %>
        </div>

        <h3>Ваше фото:</h3>

        <h3>
            <img src="/Images/UserPhotos/<%: Model.Form.MyPhoto %>" id="currentPhoto" style="height: 200px; width: 300px; margin-bottom: 20px;" /></h3>

        <a href="#" class="btn deleteButton" onclick="notPhoto()">Без фото</a>
        <a href="#" class="btn resetButton" onclick="resetChanges()">Сбросить изменения</a>
        <br />
        <br />
        <p>
            <input type="submit" value="Сохранить изменения" class="btn-large btn submitButton" />
        </p>
    </div>

    <div class="span9">

        <h4>Ваши фотографии:</h4>
        <% if (Model.PictureLinks.Count != 0)
           {
               int count = 0;
               foreach (var link in Model.PictureLinks)
               {
                   count += 1;
        %>
        <div class="span2">
            <h6>
                <img id="<%: count %>" src="/Images/UserPhotos/<%: link %>" style="height: 100px; width: 150px;" />

            </h6>
            <a href="#" class="btn chooseButton" onclick="changeCurrentPhoto(<%: count %>)">Сделать аватаром</a>
        </div>
        <input type="hidden" id="PictureLinks" name="PictureLinks" value="<%: link %>" />

        <%
               }
           } %>

        <%: Html.HiddenFor(model => model.Form.FormId) %>
        <%: Html.HiddenFor(model => model.Form.UserId) %>


        <input type="hidden" id="Form.MyPhoto" name="Form.MyPhoto" value="/Images/UserPhotos/<%: Model.Form.MyPhoto %>" />
    </div>

    <br />
</div>

<%
           // ----- End form -----
       } %>


<script type="text/javascript">

    var currentPhoto = document.getElementById("currentPhoto");
    var myPhoto = document.getElementById("Form.MyPhoto");

    var currentAboutMe = document.getElementById("Form.AboutMe");

    var lastPhoto = document.getElementById("currentPhoto").src;
    var lastAboutMe = document.getElementById("Form.AboutMe").value;

    var noPhoto = "/Images/NoPhoto.jpg";

    myPhoto.value = currentPhoto.src;

    function setPhoto(photo) {
        currentPhoto.src = photo;
        myPhoto.value = photo;
    };

    function changeCurrentPhoto(newPhoto) {
        var photo = document.getElementById(newPhoto);
        setPhoto(photo.src);
    };

    function resetChanges() {
        setPhoto(lastPhoto);
        currentAboutMe.value = lastAboutMe;
    };

    function notPhoto() {
        setPhoto(noPhoto);
    };

</script>


