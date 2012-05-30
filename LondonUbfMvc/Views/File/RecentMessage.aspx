<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<LondonUbfWeb.Domain.Models.FileViewModel>" %>
<%@ Import Namespace="LondonUbfWeb.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Recent messages, ordered by date
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Message</h1>
    
    <% using (Html.BeginForm()) { %>
    <p>
        <input type="text" name="searchword" value="" style="width:300px;" />
        <input type="submit" value="Search" />
    </p>
    <% } %>

    <table width="100%">
    <tr>
        <th style="text-align:left;">Name</th>
        <th width="100px">Date</th>
    </tr>

    <% foreach (var item in Model.List) { %>
    <tr>
        <td>
            <% if (item.IsFolder) { %>
                <img src="<%= AppHelper.ImageUrl("folder.png") %>" alt="folder" title="folder" />
            <% } else {%>
                <img src="<%= AppHelper.ImageUrl("file.png") %>" alt="file" title="file" />
            <% } %>
                
            <%= Html.ActionLink(item.Name, "Download", new { type = 0, name = item.Name, path = item.PartialPath })%>
        </td>
        <td><%: item.Date.ToString("dd/MM/yyyy") %></td>
    </tr>
    <% } %>

    </table>
    
    <br />
    <% 
       if (Model.List.HasPreviousPage) {
           Response.Write(Html.RouteLink("Previous", new { controller="file", action="RecentMessage", page = (Model.List.PageIndex - 1), searchword = Model.SearchWord }));
       }
       Response.Write("&nbsp;"); 
       if (Model.List.HasNextPage) {
           Response.Write(Html.RouteLink("Next", new { controller = "file", action = "RecentMessage", page=(Model.List.PageIndex + 1), searchword = Model.SearchWord }));
       }
    %>
    
</asp:Content>
