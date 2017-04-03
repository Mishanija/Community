<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SuperCommunity.Models.Membership.Picture>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    EditEffects
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        function edit() {

            var img = $('#picture');

            var blur = $('#input01').val();
            var brightness = $('#input02').val();
            var saturate = $('#input03').val();
            var contrast = $('#input05').val();
            var invert = $('#input06').val();
            var grayscale = $('#input07').val();
            var sepia = $('#input08').val();

            $(img).css({
                'filter': 'blur(' + blur + 'px) brightness(' + brightness + ') saturate(' + saturate + '%) contrast(' + contrast + '%) invert(' + invert + '%) grayscale(' + grayscale + '%)  sepia(' + sepia + '%)',
                '-webkit-filter': 'blur(' + blur + 'px) brightness(' + brightness + ') saturate(' + saturate + '%) contrast(' + contrast + '%) invert(' + invert + '%) grayscale(' + grayscale + '%)  sepia(' + sepia + '%)',
                '-moz-filter': 'blur(' + blur + 'px) brightness(' + brightness + ') saturate(' + saturate + '%) contrast(' + contrast + '%) invert(' + invert + '%) grayscale(' + grayscale + '%)  sepia(' + sepia + '%)',
                '-o-filter': 'blur(' + blur + 'px) brightness(' + brightness + ') saturate(' + saturate + '%) contrast(' + contrast + '%) invert(' + invert + '%) grayscale(' + grayscale + '%)  sepia(' + sepia + '%)',
                '-ms-filter': 'blur(' + blur + 'px) brightness(' + brightness + ') saturate(' + saturate + '%) contrast(' + contrast + '%) invert(' + invert + '%) grayscale(' + grayscale + '%)  sepia(' + sepia + '%)'
            });
            window.prettyPrint();

            // ppc
            editFile = $('#picture');


        }
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            edit();
        });
    </script>

    <div class="container">
        <div class="row">
            <div class="span6" style="margin-top: 100px;">

                <img src="/Images/UserPhotos/<%: Model.PictureUrl %>" id="picture" />

            </div>

            <div class="span6">
                <div class="form-horizontal">
                    <fieldset>
                        <legend style="color: #e8381c; font-size: 30px">Controls</legend>
                        <div class="control-group">
                            <label class="control-label" for="input01">Edited Element:</label>
                            <div class="control-group">
                                <input id="element" class="input-medium span3" value="<%: Model.PictureName %>" />
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="input01">Blur</label>
                            <div class="controls">
                                <input onchange="edit()" type="range" min="0" max="20" step="1" value="0" class="span4" id="input01">
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="input02">Brightness</label>
                            <div class="controls">
                                <input onchange="edit()" type="range" min="0.01" max="0.99" step="0.01" value="0.99" class="span4" id="input02">
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="input03">Saturation</label>
                            <div class="controls">
                                <input onchange="edit()" type="range" min="1" max="1000" step="1" value="100" class="span4" id="input03">
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="input05">Contrast</label>
                            <div class="controls">
                                <input onchange="edit()" type="range" min="10" max="1000" step="1" value="100" class="span4" id="input05">
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="input06">Invert</label>
                            <div class="controls">
                                <input onchange="edit()" type="range" min="0" max="100" step="1" value="0" class="span4" id="input06">
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="input07">Grayscale</label>
                            <div class="controls">
                                <input onchange="edit()" type="range" min="0" max="100" step="1" value="0" class="span4" id="input07">
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="input08">Sepia</label>
                            <div class="controls">
                                <input onchange="edit()" type="range" min="0" max="100" step="1" value="0" class="span4" id="input08">
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
