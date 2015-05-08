<%@ Page Title="" Language="vb" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="WeeklyScoringUpdate.aspx.vb" Inherits="LoserPool1.WeeklyScoringUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <h2><%:CStr(Session("dayNumber"))%></h2>
    <br />
  <div id="GameElement1" style="width:720px; text-align: center; min-width: 720px;">
    <asp:Table ID="TeamsByGameTable1" runat="server" CssClass="table table-striped table-border" Height="150px" Width="720px">
        <asp:TableRow>
            <asp:TableHeaderCell ID="Nothing1" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell Id="GameNumber1" ColumnSpan="2" style="text-align:center" ></asp:TableHeaderCell>
            <asp:TableHeaderCell Id="GameNumber2" ColumnSpan="2" style="text-align:center" ></asp:TableHeaderCell>
            <asp:TableHeaderCell Id="GameNumber3" ColumnSpan="2" style="text-align:center" ></asp:TableHeaderCell>
            <asp:TableHeaderCell Id="GameNumber4" ColumnSpan="2" style="text-align:center" ></asp:TableHeaderCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableHeaderCell ID="Status1" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell Id="GameNumber1Status" ColumnSpan="2" style="text-align:center" ></asp:TableHeaderCell>
            <asp:TableHeaderCell Id="GameNumber2Status" ColumnSpan="2" style="text-align:center" ></asp:TableHeaderCell>
            <asp:TableHeaderCell Id="GameNumber3Status" ColumnSpan="2" style="text-align:center" ></asp:TableHeaderCell>
            <asp:TableHeaderCell Id="GameNumber4Status" ColumnSpan="2" style="text-align:center" ></asp:TableHeaderCell>

        </asp:TableRow>
        <asp:TableRow>
            <asp:TableHeaderCell ID="Nothing1A" Width="80px"></asp:TableHeaderCell> 
            <asp:TableHeaderCell ID="HomeTeam1" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="AwayTeam1" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="HomeTeam2" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="AwayTeam2" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="HomeTeam3" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="AwayTeam3" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="HomeTeam4" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="AwayTeam4" style="text-align:center" Width="80px"></asp:TableHeaderCell>
        </asp:TableRow>
        <asp:TableHeaderRow>
            <asp:TableHeaderCell ID="Nothing1B"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="HomeScore1" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="AwayScore1" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="HomeScore2" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="AwayScore2" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="HomeScore3" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="AwayScore3" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="HomeScore4" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="AwayScore4" style="text-align:center" Width="80px"></asp:TableHeaderCell>
        </asp:TableHeaderRow>

    </asp:Table>
    <br />
    <br />
    <asp:Table ID="TeamsByGameTable2" runat="server" CssClass="table table-striped table-border" Height="150px" Width="720px">
        <asp:TableRow>
            <asp:TableHeaderCell ID="Nothing5" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell Id="GameNumber5" ColumnSpan="2" style="text-align:center" ></asp:TableHeaderCell>
            <asp:TableHeaderCell Id="GameNumber6" ColumnSpan="2" style="text-align:center" ></asp:TableHeaderCell>
            <asp:TableHeaderCell Id="GameNumber7" ColumnSpan="2" style="text-align:center" ></asp:TableHeaderCell>
            <asp:TableHeaderCell Id="GameNumber8" ColumnSpan="2" style="text-align:center" ></asp:TableHeaderCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableHeaderCell ID="Status2" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell Id="GameNumber5Status" ColumnSpan="2" style="text-align:center" ></asp:TableHeaderCell>
            <asp:TableHeaderCell Id="GameNumber6Status" ColumnSpan="2" style="text-align:center" ></asp:TableHeaderCell>
            <asp:TableHeaderCell Id="GameNumber7Status" ColumnSpan="2" style="text-align:center" ></asp:TableHeaderCell>
            <asp:TableHeaderCell Id="GameNumber8Status" ColumnSpan="2" style="text-align:center" ></asp:TableHeaderCell>

        </asp:TableRow>
        <asp:TableRow>
            <asp:TableHeaderCell ID="Nothing5A" Width="80px"></asp:TableHeaderCell> 
            <asp:TableHeaderCell ID="HomeTeam5" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="AwayTeam5" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="HomeTeam6" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="AwayTeam6" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="HomeTeam7" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="AwayTeam7" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="HomeTeam8" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="AwayTeam8" style="text-align:center" Width="80px"></asp:TableHeaderCell>
        </asp:TableRow>
        <asp:TableHeaderRow>
            <asp:TableHeaderCell ID="Nothing5B"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="HomeScore5" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="AwayScore5" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="HomeScore6" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="AwayScore6" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="HomeScore7" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="AwayScore7" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="HomeScore8" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="AwayScore8" style="text-align:center" Width="80px"></asp:TableHeaderCell>
        </asp:TableHeaderRow>

    </asp:Table>
    <br />
    <br />
    <asp:Table ID="TeamsByGameTable3" runat="server" CssClass="table table-striped table-border" Height="150px" Width="720px">
        <asp:TableRow>
            <asp:TableHeaderCell ID="Nothing9" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell Id="GameNumber9" ColumnSpan="2" style="text-align:center" ></asp:TableHeaderCell>
            <asp:TableHeaderCell Id="GameNumber10" ColumnSpan="2" style="text-align:center" ></asp:TableHeaderCell>
            <asp:TableHeaderCell Id="GameNumber11" ColumnSpan="2" style="text-align:center" ></asp:TableHeaderCell>
            <asp:TableHeaderCell Id="GameNumber12" ColumnSpan="2" style="text-align:center" ></asp:TableHeaderCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableHeaderCell ID="Status3" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell Id="GameNumber9Status" ColumnSpan="2" style="text-align:center" ></asp:TableHeaderCell>
            <asp:TableHeaderCell Id="GameNumber10Status" ColumnSpan="2" style="text-align:center" ></asp:TableHeaderCell>
            <asp:TableHeaderCell Id="GameNumber11Status" ColumnSpan="2" style="text-align:center" ></asp:TableHeaderCell>
            <asp:TableHeaderCell Id="GameNumber12Status" ColumnSpan="2" style="text-align:center" ></asp:TableHeaderCell>

        </asp:TableRow>
        <asp:TableRow>
            <asp:TableHeaderCell ID="Nothing9A" Width="80px"></asp:TableHeaderCell> 
            <asp:TableHeaderCell ID="HomeTeam9" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="AwayTeam9" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="HomeTeam10" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="AwayTeam10" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="HomeTeam11" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="AwayTeam11" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="HomeTeam12" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="AwayTeam12" style="text-align:center" Width="80px"></asp:TableHeaderCell>
        </asp:TableRow>
        <asp:TableHeaderRow>
            <asp:TableHeaderCell ID="Nothing9B"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="HomeScore9" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="AwayScore9" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="HomeScore10" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="AwayScore10" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="HomeScore11" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="AwayScore11" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="HomeScore12" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="AwayScore12" style="text-align:center" Width="80px"></asp:TableHeaderCell>
        </asp:TableHeaderRow>

    </asp:Table>
    <br />
    <asp:Table ID="TeamsByGameTable4" runat="server" CssClass="table table-striped table-border" Height="150px" Width="720px">
        <asp:TableRow>
            <asp:TableHeaderCell ID="Nothing13" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell Id="GameNumber13" ColumnSpan="2" style="text-align:center" ></asp:TableHeaderCell>
            <asp:TableHeaderCell Id="GameNumber14" ColumnSpan="2" style="text-align:center" ></asp:TableHeaderCell>
            <asp:TableHeaderCell Id="GameNumber15" ColumnSpan="2" style="text-align:center" ></asp:TableHeaderCell>
            <asp:TableHeaderCell Id="GameNumber16" ColumnSpan="2" style="text-align:center" ></asp:TableHeaderCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableHeaderCell ID="Status4" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell Id="GameNumber13Status" ColumnSpan="2" style="text-align:center" ></asp:TableHeaderCell>
            <asp:TableHeaderCell Id="GameNumber14Status" ColumnSpan="2" style="text-align:center" ></asp:TableHeaderCell>
            <asp:TableHeaderCell Id="GameNumber15Status" ColumnSpan="2" style="text-align:center" ></asp:TableHeaderCell>
            <asp:TableHeaderCell Id="GameNumber16Status" ColumnSpan="2" style="text-align:center" ></asp:TableHeaderCell>

        </asp:TableRow>
        <asp:TableRow>
            <asp:TableHeaderCell ID="Nothing13A" Width="80px"></asp:TableHeaderCell> 
            <asp:TableHeaderCell ID="HomeTeam13" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="AwayTeam13" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="HomeTeam14" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="AwayTeam14" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="HomeTeam15" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="AwayTeam15" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="HomeTeam16" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="AwayTeam16" style="text-align:center" Width="80px"></asp:TableHeaderCell>
        </asp:TableRow>
        <asp:TableHeaderRow>
            <asp:TableHeaderCell ID="Nothing13B"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="HomeScore13" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="AwayScore13" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="HomeScore14" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="AwayScore14" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="HomeScore15" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="AwayScore15" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="HomeScore16" style="text-align:center" Width="80px"></asp:TableHeaderCell>
            <asp:TableHeaderCell ID="AwayScore16" style="text-align:center" Width="80px"></asp:TableHeaderCell>
        </asp:TableHeaderRow>

    </asp:Table>


    <br />


 </div>
    <br />
 <asp:Button ID="Button1" runat="server" Height="35px" Text="Return" Width="120px"/>
      
</asp:Content>
