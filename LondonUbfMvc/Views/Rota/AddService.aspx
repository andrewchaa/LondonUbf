<%@ Page Inherits="System.Web.Mvc.ViewPage<LondonUbfWeb.Domain.Models.JobAddViewModel>" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Title="" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Add Rota for Worship Service
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Add service rota</h1>

    <% using (Html.BeginForm()) {%>

    <% Html.RenderPartial("_JobResult", Model.ListViewModels); %>

    <table style="width: 90%;" id="addjob">
    <tbody>
        <tr>
            <td width="100px"><%= Html.TextBoxFor(m => m.Input.Date, new {@style="width: 70px;"}) %></td>
            <td width="100px"><%= Html.DropDownListFor(m => m.Input.Messenger, Model.PersonList) %></td>
            <td width="100px"><%= Html.DropDownListFor(m => m.Input.Presider, Model.PersonList) %></td>
            <td width="100px"><%= Html.DropDownListFor(m => m.Input.Reader, Model.PersonList) %></td>
            <td width="200px">
                <%= Html.DropDownListFor(m => m.Input.PrayerServantMan, Model.PersonList) %>
                <%= Html.DropDownListFor(m => m.Input.PrayerServantWoman, Model.PersonList) %>
            </td>
            <td><input type="submit" value="Add" /></td>
        </tr>
    </tbody>
    </table>
    
    <% } %>

<div class="modal" id="confirm">
	<h2>Confirmation</h2>
	<p>Are you sure you want to delete this?</p>

	<p>
		<button class="close" data-id="" id="btnYes"> Yes </button>
		<button class="close"> No </button>
	</p>
</div>

<script type="text/javascript">

$(function() {
    var bindResultEvents = function() {
        $('a[name="delete"]').overlay({
            mask: {
		        color: '#ebecff',
		        loadSpeed: 200,
		        opacity: 0.9
	        },
            top: 200
        });

        $('#result').delegate('a[name="delete"]', 'click', function(e) {
            e.preventDefault();

            var id = $(this).attr('id');
            $('#btnYes').attr('data-id', id);
        });
        
    };

    $('#Input_Date').dateinput({
        format: 'dd/mm/yyyy'
    });

    $('#btnYes').click(function(e){
        var id = $(this).attr('data-id');
        $.post('<%= Url.Action("Delete") %>', {id: id}, function(result) {
            $('#result').html(result);
            bindResultEvents();

        });
    });


    $('form').submit(function(e) {
        e.preventDefault();
        $.post('<%= Url.Action("Add") %>', $(this).serialize(), function(result) {
            $('#result').html(result);
            bindResultEvents();
        });
    });

    bindResultEvents();

});

</script>

</asp:Content>

<asp:Content ID="sidebar" ContentPlaceHolderID="cplSideBar" runat="server">

<h2>Menu</h2> 
<div class="featured"> 
    <dl><%= Html.ActionLink("Rota for Worship Service", "Index") %></dl>
    <dl><a href="/">Back to home page</a></dl>
</div> 

</asp:Content>