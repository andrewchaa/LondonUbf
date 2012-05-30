<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<LondonUbfWeb.Domain.Models.LectureListViewModel>" %>

<asp:Content ID="Content4" ContentPlaceHolderID="metaTags" runat="server">
    <meta name="biblicaltranslation" content="New Internation Version, NIV" />
    <meta name="book" content="<%: Model.CurrentBook %>" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Lectures
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Lectures</h1>

    <div>
        <%= Html.ActionLink("All", "Index", new {book = "all" })  %> |
        <% foreach (var book in Model.Books) {%>
            <% if (book.ToLower() == Model.CurrentBook.ToLower()) { %> 
                <%: book %>
            <% } else { %>
                <%= Html.ActionLink(book, "Index", new { book }) %>
            <% } %>
            |
        <% } %>
    </div>

    <table>
        <tr>
            <% if (Model.IsAdmin) { %> 
            <th width="70px;">&nbsp;</th> 
            <% } %>
            <th width="20px">Year</th>
            <th width="90px">Lecture</th>
            <th width="110px">Passage</th>
            <th>Title</th>
        </tr>

    <% foreach (var item in Model.PagedList) { %>
    
        <tr>
            <% if (Model.IsAdmin) { %>
            <td>
                <a href="#delete" name="delete" rel="#confirm" data-id="<%: item.Id %>" data-title="<%: item.Title %>">Delete</a> |
                <%= Html.ActionLink("Edit", "Edit", new {id = item.Id}) %>
            </td>
            <% } %>

            <td><%: item.Year %></td>
            <td><%: item.BookName %> <%: item.LectureNo %></td>
            <td><%: item.BiblePassage %></td>
            <td><%= Html.ActionLink(item.Title, "View", new {id = item.Id, book = item.BookName, title = item.SeoTitle}) %></td>
        </tr>
    
    <% } %>

    </table>

    <br />
    <% if (Model.PagedList.HasPreviousPage) { %>
        <%= Html.ActionLink("Previous", "Index", new { book = Model.CurrentBook, page = (Model.PagedList.PageIndex - 1) })%>
    <% } %>&nbsp;
    <% if (Model.PagedList.HasNextPage) { %>
        <%= Html.ActionLink("Next", "Index", 
            new { page = (Model.PagedList.PageIndex + 1), book = Model.CurrentBook }) %>
    <% } %>

<% if (Model.IsAdmin) { %>
<div class="modal" id="confirm">
	<h2>Confirmation</h2>
	<p>Are you sure you want to delete "<span id="nameToDelete"></span>"?</p>

	<p>
		<button class="close" data-id="" id="btnYes"> Yes </button>
		<button class="close"> No </button>
	</p>
</div>

<script type="text/javascript">
var bindEvents = function() {
        $('a[name="delete"]').overlay({
            mask: {
		        color: '#ebecff',
		        loadSpeed: 200,
		        opacity: 0.9
	        },
            top: 200
        });

        $('#list').delegate('a[name="delete"]', 'click', function(e) {
            var id = $(this).attr('data-id');
            var title = $(this).attr('data-title');

            $('#nameToDelete').text(title);
            $('#btnYes').attr('data-id', id);
        })

        $('#btnYes').click(function(e){
            e.preventDefault();
            $.post('<%= Url.Action("Delete") %>', {id: $(this).attr('data-id')}, function(result) {
                window.location.reload();
            })
        });
    };


$(function() {
    bindEvents();
})

</script>

<% } %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cplSideBar" runat="server">

<h2>Menu</h2> 
<div class="featured"> 
   
    <% if (Model.IsAdmin) {%>
        <dl><%= Html.ActionLink("Add", "Add") %></dl>
    <% } %>

    <dl><a href="/">Home</a></dl>
</div> 

</asp:Content>

