<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RequisitionForm.aspx.cs" Inherits="Team8_ADProjectLUStationerySystem.DepartmentHead.RequisitionForm" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:80%; margin-left:10%; text-align:left; height: 100px;">
        <tr>
            <td>
                <h3>Requisition History</h3>
            </td>
        </tr>
      </table>
     <table style="width:80%; margin-left:10%; text-align:left; height: 100px;">
        <tr>
            <td>
    <asp:GridView ID="GridView1" runat="server" CssClass="mGrid" style="font-size:20px" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="itemCode" HeaderText="Item Code" />
            <asp:BoundField DataField="qtyNeeded" HeaderText="Quantity Needed" />
            <asp:BoundField DataField="qtyActual" HeaderText="Actual Quantity" />
            <asp:BoundField DataField="qtyOutstaning" HeaderText="Outstanding Quantity" />
            <asp:BoundField DataField="outstandingField" HeaderText="Quantity Outstanding?" />
        </Columns>


    </asp:GridView>
                </td></tr><tr><td align ="Right">
    <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click" CssClass="button4"/>
    <CR:CrystalReportViewer ID="RequisitionReport" runat="server" AutoDataBind="true" ToolPanelView="None" />
                    </td></tr>
    </table>
</asp:Content>
