<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<LondonUbfWeb.Domain.Models.LectureInput>" %>
<%@ Import Namespace="LondonUbfWeb.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Add a lecture
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


    <h1>Add a lecture</h1>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend> Add a lecture </legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.BookName) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.BookName) %> 
                <%: Html.ValidationMessageFor(model => model.BookName) %>
                
                <%: Html.TextBoxFor(model => model.LectureNo, new {@style="width: 30px"}) %>
                <%: Html.ValidationMessageFor(model => model.LectureNo) %>
                &nbsp;ex: Luke 20
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Title) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Title, new {@style="width:100%;"}) %>
                <%: Html.ValidationMessageFor(model => model.Title) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.BiblePassage) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.BiblePassage) %>
                <%: Html.ValidationMessageFor(model => model.BiblePassage) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.KeyVerse) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.KeyVerse, new { @style = "width:100%;" })%>
                <%: Html.ValidationMessageFor(model => model.KeyVerse) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.DeliveryDate) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.DeliveryDate, new {@style="width:70px;"}) %>
                <%: Html.ValidationMessageFor(model => model.DeliveryDate) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Content) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.Content, new {@style="width:100%;height:500px;"}) %>
                <%: Html.ValidationMessageFor(model => model.Content) %>
            </div>

            <div class="editor-label">&nbsp;</div>
            <div class="editor-field">&nbsp;</div>

            <div class="editor-label">&nbsp;</div>
            <div class="editor-field"><input type="submit" value="Add" /></div>

        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

<script type="text/javascript">

$(function() {
    $('#<%= Html.ClientIdFor(m => m.DeliveryDate) %>').dateinput({
        format: 'dd/mm/yyyy',
        selectors: true,
        value: '<%= Model.IsoDeliveryDate %>',
        yearRange: [-10, 1]
    });
    
    $('#<%= Html.ClientIdFor(m => m.BookName) %>').focus();
    $('#<%= Html.ClientIdFor(m => m.DeliveryDate) %>').change(function(e) {
        $('#<%= Html.ClientIdFor(m => m.Content) %>').focus();
    })

    /*
    $('form').submit(function(e) {
        e.preventDefault();
        $.ajax({
            url: '<%= Url.Action("Add") %>',
            type: 'post',
            dataType: 'html',
            data: $('form').serialize(),
            completed: function() {},
            success: function() {
                $('#<%= Html.ClientIdFor(m => m.BiblePassage) %>').val('');
                $('#<%= Html.ClientIdFor(m => m.Content) %>').val('');
                $('#<%= Html.ClientIdFor(m => m.KeyVerse) %>').val('');
                $('#<%= Html.ClientIdFor(m => m.LectureNo) %>').val('');
                $('#<%= Html.ClientIdFor(m => m.Title) %>').val('');
            }
        });
    });
    */

});

</script>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cplSideBar" runat="server">

<h2>Menu</h2> 
<div class="featured"> 
    <dl><%= Html.ActionLink("Back to list", "Index") %></dl>
    <dl><a href="/">Back to home page</a></dl>
</div> 

</asp:Content>

