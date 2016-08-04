<%@ Page Title="" Language="C#" MasterPageFile="~/StoreClerk.Master" AutoEventWireup="true" CodeBehind="ReceiveOrder.aspx.cs" Inherits="Team8_ADProjectLUStationerySystem.StoreClerk1.ReceiveOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div><h4>Receive Purchase Order</h4></div>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width:85%; margin-left:10%; text-align:left; height: 100px;">
                <tr>
                    <td>
                        <asp:Label ID="purchaseOrderNo" runat="server"  style="font-size:20px">Purchase Order:</asp:Label>
                        &nbsp;
                        </td>
                    <td><asp:DropDownList ID="ddlPurchaseOrder" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlPurchaseOrder_SelectedIndexChanged" CssClass="dropdown1">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label" runat="server"  style="font-size:20px">Status</asp:Label>:</td><td>
                
                
                            <asp:Label ID="lblPOstatus" runat="server" style="font-size:20px"></asp:Label></td>
                      
                   </tr>
                    
            </table>
            <table style="width:85%; margin-left:10%; text-align:left; height: 100px;">
                <tr align="center">
                    <td>
                        <asp:Label ID="lblStatus" runat="server" CssClass="label-warning" style="font-size:20px" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
            <asp:GridView ID="gvOrderDetail" runat="server" AutoGenerateColumns="false" DataKeyNames="purchaseDetail_Id" CssClass="mGrid" style="font-size:15px">
                <Columns>
                    <asp:TemplateField HeaderText="S No">
                        <ItemTemplate>
                            <%#: ((GridViewRow)Container).RowIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="purchaseorderno" HeaderText="PO No" ReadOnly="True" SortExpression="purchaseorderno"/>
                    <asp:BoundField DataField="itemCode" HeaderText="Item Code" ReadOnly="True" SortExpression="itemCode"/>
                    <asp:BoundField DataField="orderedQuantity" HeaderText="Ordered Quantity" ReadOnly="True" SortExpression="orderedQuantity"/>
                    <asp:BoundField DataField="price" HeaderText="Price" ReadOnly="True" DataFormatString="{0:c}" SortExpression="price"/>
                    <asp:BoundField DataField="amount" HeaderText="Amount" ReadOnly="True" DataFormatString="{0:c}" SortExpression="amount"/>
                    <asp:TemplateField HeaderText="Received Quantity">
                        <ItemTemplate>
                            <asp:TextBox ID="txtReceivedQty" runat="server" EnableViewState="false" 
                                Text='<%# Bind("receivedQuantity")%>' MaxLength="4" ReadOnly="false">     
                            </asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
                    </td>
                </tr>

            </table>
            
                        
            <br />
            <div style="height:10px"></div>
            <asp:Button ID="btnReceiveDelivery" runat="server" Text="Receive Delivery" OnClick="btnReceiveDelivery_Click" CssClass="button4" style="font-size:20px"/>
            <asp:Button ID="btnRejectDelivery" runat="server" Text="Reject Delivery" OnClick="btnRejectDelivery_Click" CssClass="button4" style="font-size:20px"/>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlPurchaseOrder" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>         
</asp:Content>
