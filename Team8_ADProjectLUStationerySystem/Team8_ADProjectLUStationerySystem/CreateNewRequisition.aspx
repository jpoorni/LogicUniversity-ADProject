<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateNewRequisition.aspx.cs" Inherits="Team8_ADProjectLUStationerySystem.CreateNewRequisition" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

         <h3>Create New Requisition</h3>
     <p>&nbsp;</p>
     <p>&nbsp;</p>
<p>Item Name:
    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="dropdown1">
    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Quantity:
    <asp:TextBox ID="TextBox1" runat="server" Width="75px"  CssClass="tb1"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Text="Submit"  CssClass="button4"/>
    <asp:GridView ID="GridView1" runat="server" Height="211px" Width="743px">
    </asp:GridView>
</p>
<p>
    <asp:CheckBox ID="CheckBox1" runat="server" Text="Self-Collection" />
</p>
<p>
    <asp:Button ID="Button2" runat="server" Text="Clear" CssClass="button4"/>
&nbsp;<asp:Button ID="Button3" runat="server" Text="Submit" CssClass="button4" />
</p>

</asp:Content>
