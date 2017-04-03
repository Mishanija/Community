<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<SuperCommunity.Models.Membership.Form>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Анкета
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Ваша анкета</h2>

    <h3 style="color: #b6ff00">Фото:</h3>

    <img src="/Images/UserPhotos/<%: Model.MyPhoto %>" style="height: 200px; width: 300px;">
    
    <h3 style="color: #119679">Обо мне:</h3>
    <h4><%: Model.AboutMe %></h4>


    <br />

    <a href="/Form/Edit/" class="btn editButton">Редактировать данные</a>
    <br />


</asp:Content>
