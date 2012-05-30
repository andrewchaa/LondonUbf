<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<LondonUbfWeb.Domain.Models.PersonInput>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<style type="text/css">
.editor-label 
{
    width: 10%;
    float: left;
    margin: 1px 20px 1px 0px;
    text-align: right;
}
.editor-field 
{
    width: 80%;
    float: left;
    margin: 1px 0px 1px 0px;
}
input[type="text"] 
{
    width: 120px;
}
</style>


    <h2>Edit</h2>
    <br />

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Edit the contact</legend>
            
            <div class="editor-label"><%: Html.LabelFor(model => model.Firstname) %></div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Firstname) %>
                <%: Html.ValidationMessageFor(model => model.Firstname) %>
            </div>
            
            <div class="editor-label"><%: Html.LabelFor(model => model.Lastname) %></div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Lastname) %>
                <%: Html.ValidationMessageFor(model => model.Lastname) %>
            </div>
            
            <div class="editor-label"><%: Html.LabelFor(model => model.Email) %></div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Email, new {@style="width: 200px;"}) %>
                <%: Html.ValidationMessageFor(model => model.Email) %>
            </div>

            <div class="editor-label"><%: Html.LabelFor(model => model.Mobile) %></div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Mobile) %>
                <%: Html.ValidationMessageFor(model => model.Mobile) %>
            </div>

            <div class="editor-label">&nbsp;</div>
            <div class="editor-field">&nbsp;</div>

            <div class="editor-label"><input type="submit" value="Save" /></div>
            <div class="editor-field"><a href="#delete" id="lnkDelete" data-Id="<%= Model.Id %>" rel="#confirm">Delete this contact</a></div>

        </fieldset>

    <% } %>
    <br />
    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

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
    $('#lnkDelete').click(function(e) {
        $('#btnYes').attr('data-id', $(this).attr('data-id'))
    });

    var trigger = $('#lnkDelete').overlay({
	    mask: {
		    color: '#ebecff',
		    loadSpeed: 200,
		    opacity: 0.9
	    },

	    closeOnClick: false,
        top: 200,
    });

    $('#btnYes').click(function(e){
        $.post('<%= Url.Action("Delete") %>', {id: $(this).attr('data-id')}, function(result) {
            window.location = '<%= Url.Action("Index") %>';
        });
    });


});

</script>

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cplSideBar" runat="server">
</asp:Content>

