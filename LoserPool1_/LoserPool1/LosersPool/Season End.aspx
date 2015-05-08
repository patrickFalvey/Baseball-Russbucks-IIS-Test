<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Season End.aspx.vb" Inherits="LoserPool1.Season_End" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Season End   Final Results</h2>

    <br />
    <br />

    <div ID="GridViewTable1">
        <asp:GridView ID="ContendersTable" runat="server" AutoGenerateColumns="false" CellPadding="4" ItemType="LoserPool1.LosersPool.Models.UserResult" SelectMethod="ContendersTable_GetData" CssClass="table table-striped table-border">
            <Columns>

                <asp:BoundField DataField="Username" HeaderText="Contender's Name" />
                <asp:BoundField DataField="Washington" HeaderText="Washington" />
                <asp:BoundField DataField="Miami" HeaderText="Miami" />
                <asp:BoundField DataField="Colorado" HeaderText="Colorado" />
                <asp:BoundField DataField="Arizona" HeaderText="Arizona" />
                <asp:BoundField DataField="SanFrancisco" HeaderText="San Francisco" />
                <asp:BoundField DataField="SanDiego" HeaderText="San Diego" />
                <asp:BoundField DataField="Pittsburg" HeaderText="Pittsburg" />
                <asp:BoundField DataField="Cincinnati" HeaderText="Cincinnati" />
                <asp:BoundField DataField="Toronto" HeaderText="Toronto" />
                <asp:BoundField DataField="NYYankees" HeaderText="NY Yankees" />
                <asp:BoundField DataField="Boston" HeaderText="Boston" />
                <asp:BoundField DataField="TampaBay" HeaderText="Tampa Bay" />
                <asp:BoundField DataField="Atlanta" HeaderText="Atlanta" />
                <asp:BoundField DataField="Philadelphia" HeaderText="Philadelphia" />
                <asp:BoundField DataField="ChicagoWhiteSox" HeaderText="Chicago White Sox" />
                <asp:BoundField DataField="Detroit" HeaderText="Detroit" />
                <asp:BoundField DataField="KansasCity" HeaderText="Kansas City" />
                <asp:BoundField DataField="Cleveland" HeaderText="Cleveland" />
                <asp:BoundField DataField="Milwaukee" HeaderText="Milwaukee" />
                <asp:BoundField DataField="LADodgers" HeaderText="LA Dodgers" />
                <asp:BoundField DataField="Minnesota" HeaderText="Minnesota" />
                <asp:BoundField DataField="Oakland" HeaderText="Oakland" />
                <asp:BoundField DataField="Houston" HeaderText="Houston" />
                <asp:BoundField DataField="Texas" HeaderText="Texas" />
                <asp:BoundField DataField="STLouis" HeaderText="St. Louis" />
                <asp:BoundField DataField="ChicagoCubs" HeaderText="Chicago Cubs" />
                <asp:BoundField DataField="LAAngels" HeaderText="LA Angels" />
                <asp:BoundField DataField="Seattle" HeaderText="Seattle" />
                <asp:BoundField DataField="NYMets" HeaderText="NY Mets" />
                <asp:BoundField DataField="Baltimore" HeaderText="Baltimore" />              

            </Columns>

        </asp:GridView>
    </div>
    <br />
    <br />
    <div id="GridViewTable2">
        <asp:GridView ID="LosersTable" runat="server" AutoGenerateColumns="false" CellPadding="4" ItemType="LoserPool1.LosersPool.Models.Loser" SelectMethod="LosersTable_GetData" CssClass="table table-striped table-border" >
            <Columns>
                <asp:BoundField DataField="UserName" HeaderText="The Losers" />
                <asp:BoundField DataField="DayId" HeaderText="Day" />
                <asp:BoundField DataField="LosingPick" HeaderText="Losing Pick" />
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Height="35px" Text="Return" Width="120px"/>

</asp:Content>
