<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SuperCommunity.Models.Membership.Tag>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Тэги
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Список тэгов</h2>

    <a href="/Tag/Create" class="btn createButton">Добавить новый тэг</a>
    <br />
    <br />

    <table style="line-height: 35px;">
        <tr>
            <th style="font-size: 30px; color: #4cff00">Имя тэга
            </th>
            <th style="font-size: 30px; color: #4cff00">Правка
            </th>
        </tr>

        <% foreach (var item in Model)
           { %>
        <tr>
            <td style="font-size: 26px; color: #ffd800">
                <%: Html.DisplayFor(modelItem => item.TagName) %> 
            </td>
            <td>
                <a href="/Tag/Edit/<%: item.TagId %>" class="btn" style="color: #EBFF00; background-image: linear-gradient(to bottom, #FFFFFF, #2FB35E); background-color: #34B854">Редактировать</a>
                <a href="/Tag/Details/<%: item.TagId %>" class="btn" style="color: #EBFF00; background-image: linear-gradient(to bottom, #FFFFFF, #2E85CA); background-color: #3F7FB9">Подробно</a>
                <a href="/Tag/Delete/<%: item.TagId %>" class="btn" style="color: #EBFF00; background-image: linear-gradient(to bottom, #FFFFFF, #CA2E5A); background-color: #D62D3A">Удалить</a>
            </td>
        </tr>
        <% } %>
    </table>

</asp:Content>
