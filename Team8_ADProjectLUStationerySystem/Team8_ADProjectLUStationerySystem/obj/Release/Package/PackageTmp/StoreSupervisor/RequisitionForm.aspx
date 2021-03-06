﻿<%@ Page Title="" Language="C#" MasterPageFile="~/StoreSupervisorMaster.Master" AutoEventWireup="true" CodeBehind="RequisitionForm.aspx.cs" Inherits="Team8_ADProjectLUStationerySystem.StoreSupervisor.RequisitionForm" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server"> 
   <table style="width:85%; margin-left:10%; text-align:left; height: 100px;">
        <tr>
            <td>
    <asp:GridView ID="GridView1" runat="server" CssClass="mGrid" style="font-size:20px" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="itemCode" HeaderText="Item Code" />
            <asp:BoundField DataField="qtyNeeded" HeaderText="Quantity Needed" />
            <asp:BoundField DataField="qtyActual" HeaderText="Actual Quantity" />
            <asp:BoundField DataField="qtyOutstaning" HeaderText="Oustanding Quantity" />
            <asp:BoundField DataField="outstandingField" HeaderText="Oustanding?" />
        </Columns>


    </asp:GridView></td></tr><tr><td align ="right">
    <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click" style="font-size:20px" CssClass="button4"/>
    <CR:CrystalReportViewer ID="RequisitionReport" runat="server" AutoDataBind="true" />
        </td></tr></table>
</asp:Content>
