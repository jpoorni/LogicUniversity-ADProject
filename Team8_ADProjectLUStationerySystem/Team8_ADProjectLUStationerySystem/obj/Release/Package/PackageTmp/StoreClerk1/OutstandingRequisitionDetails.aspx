<%@ Page Title="" Language="C#" MasterPageFile="~/StoreClerk.Master" AutoEventWireup="true" CodeFile="OutstandingRequisitionDetails.aspx.cs" Inherits="Team8_ADProjectLUStationerySystem.StoreClerk1.OutstandingRequisitionDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


     
     <table style="width:85%; margin-left:5%; text-align:left; height: 100px;">
        <tr>
            <td>
                <h3>Outstanding Requisition Details</h3>
            </td>
        </tr>
      </table>

    <table style="width:85%; margin-left:5%; text-align:left; height: 231px;">
        <tr>
            <td>

                <asp:GridView ID="OutstandingRequisitionDetailsGridView" runat="server"  CssClass="mGrid" style="font-size:20px" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="requisitionId" HeaderText="Requisition Id" />
                        <asp:BoundField DataField="itemCode" HeaderText="Item Code" />
                        <asp:BoundField DataField="qtyOutstaning" HeaderText="Outstanding Quantity" />
                    </Columns>
                </asp:GridView>

                <asp:Label ID="Label1" runat="server" Text="All fullfilled!" Visible="False" style="font-size:20px"></asp:Label>

            </td>
        </tr>
        <tr style="text-align:right">
            <td>

                <asp:Button ID="Button1" runat="server" Text="Generate" CssClass="button4" style="font-size:20px" OnClick="Button1_Click"/>
                <br />

            </td>
        </tr>
    </table>


</asp:Content>
