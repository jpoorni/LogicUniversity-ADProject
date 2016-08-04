<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewStationeryCatalogue.aspx.cs" Inherits="Team8_ADProjectLUStationerySystem.ViewStationeryCatalogue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <h3>Stationery Catalogue</h3>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <br />
    Search by Category:&nbsp;&nbsp; <asp:DropDownList ID="DropDownList1" runat="server" CssClass="dropdown1">
    </asp:DropDownList>
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Search by Item Name:&nbsp; <asp:DropDownList ID="DropDownList2" runat="server" CssClass="dropdown1">
    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
    <asp:Button Id="Button1" runat="server" Text="Search" CssClass="button4"/>
    <br />
    <br />






    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="594px">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>


</asp:Content>
