<%@ Page Title="" Language="C#" MasterPageFile="~/StoreSupervisorMaster.Master" AutoEventWireup="true" CodeBehind="DisbursementForm.aspx.cs" Inherits="Team8_ADProjectLUStationerySystem.StoreSupervisor.DisbursementForm" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:85%; margin-left:10%; text-align:left; height: 100px;">
        <tr>
            <td>
    <asp:GridView ID="DisbursementGridView" style="font-size:20px" CssClass="mGrid" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="disbursementId" HeaderText="Disbursement ID" />
            <asp:BoundField DataField="itemCode" HeaderText="Item Code" />
            <asp:BoundField DataField="reqQuantity" HeaderText="Required Quantity" />
            <asp:BoundField DataField="receivedQuantity" HeaderText="Quantity Received" />
        </Columns>
    </asp:GridView>
    <CR:CrystalReportViewer ID="DisbursementReport" runat="server" AutoDataBind="true" />
    </td></tr><tr><td align ="right">
    <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click" CssClass="button4" style="font-size:20px"/>
    </td></tr></table>
</asp:Content>
