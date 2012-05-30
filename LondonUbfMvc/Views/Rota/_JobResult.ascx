<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<LondonUbfWeb.Domain.Models.JobListViewModel>>" %>

<table style="width: 90%;" id="result">
<thead>
    <tr align="left">
        <th width="100px">Date</th>
        <th width="100px">Messenger</th>
        <th width="100px">Presider</th>
        <th width="100px">Reader</th>
        <th width="200px">Prayer servants</th>
        <th>&nbsp;</th>
    </tr>
</thead>
<tbody>
    <% foreach (var job in Model) { %>
    <tr>
        <td width="100px"><%= Html.Encode(job.Date) %></td>
        <td width="100px"><%= Html.Encode(job.Messenger) %></td>
        <td width="100px"><%= Html.Encode(job.Presider) %></td>
        <td width="100px"><%= Html.Encode(job.Reader) %></td>
        <td width="200px"><%= Html.Encode(job.PrayerServantMan) %>, <%= Html.Encode(job.PrayerServantWoman) %></td>
        <td>
            <a href="#delete" name="delete" rel="#confirm" id="<%= job.Id %>">Delete</a>
        </td>
    </tr>
    <% } %>
</tbody>
</table>

