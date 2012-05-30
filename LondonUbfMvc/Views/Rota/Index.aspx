<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<LondonUbfWeb.Domain.Models.Job>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Rota for Worship Service
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Rota for Worship Service</h1>
    
    <table style="width: 800px;">
    <thead>
        <tr>
            <th>Date</th>
            <th>Messenger</th>
            <th>Presider</th>
            <th>Reader</th>
            <th>Prayer servants</th>
        </tr>
    </thead>
    <tbody>
    <% foreach (var job in Model) {%>
        <tr>
            <td><%= job.Date.ToString("ddd dd/MM") %></td>
            <td><%= Html.Encode(job.Messenger.Firstname) %></td>
            <td><%= Html.Encode(job.Presider.Firstname) %></td>
            <td><%= Html.Encode(job.Reader.Firstname) %></td>
            <td><%= Html.Encode(job.PrayerServantMan.Firstname) %>, <%= Html.Encode(job.PrayerServantWoman.Firstname) %>
            </td>
        </tr>
    <% }%>
    </tbody>
    </table>    
    
</asp:Content>

<asp:Content ID="sidebar" ContentPlaceHolderID="cplSideBar" runat="server">

<h2>Menu</h2> 
<div class="featured"> 
    <dl><%= Html.ActionLink("Add service rota", "AddService") %></dl>
    <dl><a href="/">Back to home page</a></dl>
</div> 

</asp:Content>