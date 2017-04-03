<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Гостевая страничка
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <link href="/Content/css/shared/touchTouch.css" rel="stylesheet" />

    <script type="text/javascript" src="/Content/js/jquery.kwicks-1.5.1.js"></script>
    

    <div class="bg-content">
        <div class="container">
            <div class="row">
                <div class="span12">
                    <!--============================== slider =================================-->
                    <div class="flexslider">
                        <ul class="slides">

                            <li>
                                <img src="/Images/Top5/1.jpg" style="width: 770px; height: 393px"></li>
                            <li>
                                <img src="/Images/Top5/2.jpg" style="width: 770px; height: 393px">
                            </li>
                            <li>
                                <img src="/Images/Top5/3.jpg" style="width: 770px; height: 393px">
                            </li>
                            <li>
                                <img src="/Images/Top5/4.jpg" style="width: 770px; height: 393px">
                            </li>
                            <li>
                                <img src="/Images/Top5/5.jpg" style="width: 770px; height: 393px">
                            </li>
                        </ul>
                    </div>
                    <span id="responsiveFlag"></span>
                    <div class="block-slogan">
                        <h2>Welcome!</h2>
                        <div>
                            <p>
                                Привет! :) Это сообщество для тех, кому нравится делиться своими яркими моментами жизни с другими :) 
                                Вступайте в наше сообщество, приглашайте друзей :)
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript" src="/Content/js/bootstrap.js"></script>

</asp:Content>
