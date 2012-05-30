<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<LondonUbfWeb.Domain.Models.FileViewModel>" %>
<%@ Import Namespace="LondonUbfWeb.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">all files</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>All files</h2><br />
    
    <% using (Html.BeginForm()) { %>
    <p>
        <input type="text" name="searchword" value="" style="width:300px;" />
        <input type="submit" value="Search" />
    </p>
    <% } %>

    <table>
        <tr>
            <th style="text-align:left;">Name</th>
            <th width="100px">Date</th>
        </tr>

        <tr>
            <td>
                <img src="<%= AppHelper.ImageUrl("folder.png") %>" alt="folder" title="folder" />
                <%= Html.ActionLink("...", "Browse", new {page = 0, path = Model.Item.ParentDirectory})%>
            </td>
            <td>&nbsp;</td>
        </tr>

    <% foreach (var item in Model.List) { %>
        <tr>
            <td>
                <% if (item.IsFolder) { %>
                    <img src="<%= AppHelper.ImageUrl("folder.png") %>" alt="folder" title="folder" />
                    <%= Html.ActionLink(item.Name, "Browse", new {page = 0, path = item.PartialPath})%>
                    
                <% } else {%>
                    <img src="<%= AppHelper.ImageUrl("file.png") %>" alt="file" title="file" />
                    <%= Html.ActionLink(item.Name, "Download", new { type = 1, name = item.Name, path = item.PartialPath })%>
                
                <% } %>
            </td>
            <td><%: item.Date.ToString("dd/MM/yyyy") %></td>
        </tr>
    <% } %>

    </table>
    
    <br />
    <% if (Model.List.HasPreviousPage) { %>
        <%= Html.RouteLink("Previous", new { 
                controller = "File", 
                action = "Browse",
                page = (Model.List.PageIndex - 1),
                searchword = Model.SearchWord,
                path = Model.Item.PartialPath }
                ) %>
    <% } %>&nbsp;
    <% if (Model.List.HasNextPage) { %>
        <%= Html.RouteLink("Next", new { 
               controller = "File", 
               action = "Browse", 
               page = (Model.List.PageIndex + 1), 
               searchword = Model.SearchWord,
               path = Model.Item.PartialPath 
               }) %>
    <% } %>
    
</asp:Content>
