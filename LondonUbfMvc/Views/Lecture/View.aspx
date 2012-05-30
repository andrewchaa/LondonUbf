<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<LondonUbfWeb.Domain.Models.LectureViewModel>" %>

<asp:Content ID="Content4" ContentPlaceHolderID="metaTags" runat="server">
    <meta name="biblicaltranslation" content="New Internation Version, NIV" />
    <meta name="book" content="<%: Model.BookName %>" />
    <meta name="passage" content="<%: Model.BiblePassage %>" />
    <meta name="title" content="<%: Model.Title %>" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%: Model.Title %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1><%: Model.Title %></h1>

    <div><%: Model.Year %> <%: Model.BookName %> <%: Model.LectureNo %></div>
    <div>Delivered on <%: Model.DeliveryDate %></div>

    <p>
        <%: Model.BiblePassage %><br />
        <strong><%: Model.KeyVerse %></strong>
    </p>

    <p><%= Model.ContentHtml %></p>
    
    <p></p>
        
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cplSideBar" runat="server">

<h2>Menu</h2> 
<div class="featured"> 
    <dl><%= Html.ActionLink("Back to list", "Index", new {book = "all"}) %></dl>
    <dl><a href="/">Back to home page</a></dl>
    
    <br />
    <% if (Model.IsAdmin) { %>
    <d><%= Html.ActionLink("Edit this lecture", "Edit", new {id = Model.Id}) %></d>
    <% } %>
</div> 

</asp:Content>

