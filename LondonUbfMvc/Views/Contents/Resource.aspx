<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Useful links
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Useful links</h2>

    <ul>
        <li>
            <a href="http://www.biblegateway.com/">Bible Gateway</a>&nbsp;
            A tool for reading and researching scripture online -- all in the language or translation of your choice!
        </li>
        <li><a href="http://www.marshillchurch.org/media/featured">Mars hill church sermons and music</a></li>
        <li><a href="http://www.hillsong.co.uk/podcasts">Hillsong podcasts</a></li>
        <li>
            <a href="http://www.biblemap.org/">Bible map</a>
            You can search cities and towns in the bible.
        </li>
    </ul>
    

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cplSideBar" runat="server">
</asp:Content>
