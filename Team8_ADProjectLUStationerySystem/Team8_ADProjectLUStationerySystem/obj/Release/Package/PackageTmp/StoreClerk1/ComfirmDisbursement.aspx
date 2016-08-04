<%@ Page Title="" Language="C#" MasterPageFile="~/StoreClerk.Master" AutoEventWireup="true" CodeBehind="ComfirmDisbursement.aspx.cs" Inherits="Team8_ADProjectLUStationerySystem.StoreClerk1.ComfirmDisbursement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <table style="width:85%; margin-left:5%; text-align:left; height: 100px;">
        <tr>
            <td>
                <h3>Adjust Inventory</h3>
            </td>
        </tr>
      </table>

    <table style="width:85%; margin-left:5%; text-align:left; height: 231px;">
        <tr>
            <td style="width: 162px">
                
                <asp:Label ID="Label4" runat="server" Text="Disbursement ID" style="font-size:20px" ></asp:Label>
                
            </td>
            <td class="modal-sm" style="width: 543px">
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="dropdown1" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" >
                 </asp:DropDownList>
            </td>
            <td align ="right">
                &nbsp;</td>

             </tr>
    </table>
    <asp:GridView ID="GridView1" style="font-size:20px" CssClass="mGrid" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="disbursementId" HeaderText="Disbursement ID" />
            <asp:BoundField DataField="itemCode" HeaderText="Item Code" />
            <asp:BoundField DataField="reqQuantity" HeaderText="Required Quantity" />
            <asp:TemplateField HeaderText="Quantity Received">
                <ItemTemplate>
                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("disbursementId")%>'/>
                    <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("itemCode")%>'/>
                    <asp:HiddenField ID="HiddenField3" runat="server" Value='<%# Eval("reqQuantity")%>'/>
                    <asp:HiddenField ID="HiddenField4" runat="server" Value='<%# Eval("receivedQuantity")%>'/>
                    <asp:TextBox ID="tbActqty" runat="server" Text='<%# Eval("receivedQuantity")%>' AutoPostBack="True" OnTextChanged="tbActqty_TextChanged"></asp:TextBox>
                    <asp:LinkButton ID="lbSave" runat="server" OnClick="lbSave_Click">Save</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnConfirm" runat="server" Text="Confirm" OnClick="btnConfirm_Click" style="font-size:20px" CssClass="button4" Visible="False"/>
</asp:Content>
