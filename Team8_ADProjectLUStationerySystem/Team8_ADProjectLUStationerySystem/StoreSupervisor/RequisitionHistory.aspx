<%@ Page Title="" Language="C#" MasterPageFile="~/StoreSupervisorMaster.Master" AutoEventWireup="true" CodeFile="RequisitionHistory.aspx.cs" Inherits="Team8_ADProjectLUStationerySystem.StoreSupervisor.RequisitionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   

        <table style="width:85%; margin-left:10%; text-align:left; height: 100px;">
        <tr>
            <td>
                <h3>Requisition History</h3>
            </td>
        </tr>
      </table>

    <table style="width:85%; margin-left:10%; text-align:left; height: 231px;">
        <tr>
            <td style="width: 162px">
                
                <asp:Label ID="Label4" runat="server" Text="Status:" style="font-size:20px" ></asp:Label>
                
            </td>
            <td class="modal-sm" style="width: 543px">

                 <asp:DropDownList ID="DropDownList2" runat="server" CssClass="dropdown1" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                     <asp:ListItem Value="0">All</asp:ListItem>
                     <asp:ListItem Value="2000">Made</asp:ListItem>
                     <asp:ListItem Value="2001">Approve</asp:ListItem>
                     <asp:ListItem Value="2002">Unapprove</asp:ListItem>
                     <asp:ListItem Value="2003">process</asp:ListItem>
                     <asp:ListItem Value="2004">Retrieval</asp:ListItem>
                     <asp:ListItem Value="2005">Retrieval-Confirm</asp:ListItem>
                     <asp:ListItem Value="2006">Disbursement</asp:ListItem>
                     <asp:ListItem Value="2007">Disbursement-Confirm</asp:ListItem>
                     <asp:ListItem Value="2008">Outstanding</asp:ListItem>
                 </asp:DropDownList>

            </td>
            <td>

            </td>
        </tr>
        <tr>
            <td style="width: 162px">
                <asp:Label ID="Label5" runat="server" Text="Month:" style="font-size:20px"></asp:Label>
            </td>
            <td class="modal-sm" style="width: 543px">
                 <asp:DropDownList ID="DropDownList3" runat="server" CssClass="dropdown1" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                     <asp:ListItem Value="0">All</asp:ListItem>
                     <asp:ListItem Value="1">Jan</asp:ListItem>
                     <asp:ListItem Value="2">Feb</asp:ListItem>
                     <asp:ListItem Value="3">Mar</asp:ListItem>
                     <asp:ListItem Value="4">Apr</asp:ListItem>
                     <asp:ListItem Value="5">May</asp:ListItem>
                     <asp:ListItem Value="6">Jun</asp:ListItem>
                     <asp:ListItem Value="7">Jul</asp:ListItem>
                     <asp:ListItem Value="8">Aug</asp:ListItem>
                     <asp:ListItem Value="9">Sep</asp:ListItem>
                     <asp:ListItem Value="10">Oct</asp:ListItem>
                     <asp:ListItem Value="11">Nov</asp:ListItem>
                     <asp:ListItem Value="12">Dec</asp:ListItem>
                 </asp:DropDownList>
            </td>
            <td></td>
        </tr>
        <tr >
            <td style="width: 162px">

            </td>
            <td style="width: 543px;">
                &nbsp;</td>
            <td align ="right">
                &nbsp;</td>
        </tr>
    </table>
    <p>&nbsp;</p>
    <table style="width:85%; margin-left:10%; text-align:left; height: 231px;">
        <tr>
            <td>
               
                <asp:GridView ID="RequisitionHistoryGridView" runat="server" CssClass="mGrid" style="font-size:20px" AutoGenerateColumns="False"  >
                    <Columns>
                        <asp:BoundField DataField="requisitionId" HeaderText="Requisition ID" />
                        <asp:BoundField DataField="departmentCode" HeaderText="Department Code" />
                        <asp:BoundField DataField="requisitionDate" HeaderText="Requisition Date" DataFormatString="{0:dd/MM/yyyy}"/>
                        <asp:BoundField DataField="selfCollection" HeaderText="Self-Collection" />
                        <asp:TemplateField HeaderText="View">
                            <ItemTemplate>
                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("requisitionId")%>' />
                                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Preview</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:Label ID="Label1" runat="server" Text="No Record!"></asp:Label>

            </td>
        </tr>
    </table>
    <br />
</asp:Content>
