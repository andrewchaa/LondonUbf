<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<LondonUbfWeb.Domain.Models.PersonListViewModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	List of contacts
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Contacts</h2>

    <% using (Html.BeginForm("Add", "Contact")) {%>

    <table style="width: 100%;">
    <thead>
        <tr>
            <th style="width: 210px;">Name</th>
            <th style="width: 300px;">Email</th>
            <th>Mobile</th>
            <th style="width: 100px;">&nbsp;</th>
        </tr>
    </thead>
    <tbody>
    <% foreach (var viewModel in Model) {%>
        <tr>
            <td><%= Html.ActionLink(viewModel.Name, "Edit", new { id = viewModel.Id })%></td>
            <td><%= Html.Encode(viewModel.Email) %></td>
            <td><%= Html.Encode(viewModel.Mobile) %></td>
            <td>&nbsp;</td>
        </tr>
    <% }%>
    </tbody>
    </table>    

    <table style="width: 100%;">
    <tbody>
        <tr>
            <td style="width: 210px;">
                <input type="text" name="Firstname" style="width: 70px;" /> 
                <input type="text" name="Lastname" style="width: 70px;" />
            </td>
            <td style="width: 260px;"><input type="text" name="Email" style="width: 180px;" /></td>
            <td><input type="text" name="Mobile" /></td>
            <td align="right"><input type="submit" value="Add" /></td>
        </tr>
    </tbody>
    </table>

    <% } %>

</asp:Content>

