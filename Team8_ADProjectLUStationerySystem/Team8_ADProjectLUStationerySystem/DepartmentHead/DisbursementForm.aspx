<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DisbursementForm.aspx.cs" Inherits="Team8_ADProjectLUStationerySystem.DepartmentHead.DisbursementForm" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  
    <asp:GridView ID="DisbursementGridView" style="font-size:20px" CssClass="mGrid" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="disbursementId" HeaderText="Disbursement ID" />
            <asp:BoundField DataField="itemCode" HeaderText="Item Code" />
            <asp:BoundField DataField="reqQuantity" HeaderText="Quantity Required" />
            <asp:BoundField DataField="receivedQuantity" HeaderText="Quantity Received" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click" CssClass="button4" style ="font-size:20px" />
    <CR:CrystalReportViewer ID="DisbursementReport" runat="server" AutoDataBind="true" />
</asp:Content>
