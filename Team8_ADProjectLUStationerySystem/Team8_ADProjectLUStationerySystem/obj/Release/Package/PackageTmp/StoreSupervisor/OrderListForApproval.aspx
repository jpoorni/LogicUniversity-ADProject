<%@ Page Title="" Language="C#" MasterPageFile="~/StoreSupervisorMaster.Master" AutoEventWireup="true" CodeBehind="OrderListForApproval.aspx.cs" Inherits="Team8_ADProjectLUStationerySystem.StoreSupervisor.OrderListForApproval" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function divexpandcollapse(divname) {
            var div = document.getElementById(divname);
            var img = document.getElementById('img' + divname);
            if (div.style.display == "none") {
                div.style.display = "inline";
                img.src = "../images/minus.png";
            } else {
                div.style.display = "none";
                img.src = "../images/plus.png";
            }
        }
    </script>
    <table style="width:85%; margin-left:10%; text-align:left; height: 100px;">
        <tr>
            <td>
                <h3>Approve Order List</h3>
            </td>
        </tr>
      </table>    

    <div><asp:Label ID="lblstatus" runat="server"></asp:Label></div>
    <table style="width:85%; margin-left:10%; text-align:left; height: 231px;">
        <tr>
            <td>


    <div>
        <asp:GridView ID="gvOrderList" runat="server" DataKeyNames="purchaseorderno" 
        AutoGenerateColumns="false" OnRowDataBound="gvOrderListInfo_RowDataBound" GridLines="None" 
             CssClass="mGrid" style="font-size:15px" OnRowCommand="gvOrderList_RowCommand">
        <HeaderStyle BackColor="#2E8B57" Font-Bold="true" ForeColor="White" />
        <RowStyle BackColor="#E1E1E1" />
        <AlternatingRowStyle BackColor="White" />
        <HeaderStyle BackColor="#2E8B57" Font-Bold="true" ForeColor="White" />

            <Columns>
                <asp:TemplateField ItemStyle-Width="20px">
                    <ItemTemplate>
                        <a href="JavaScript:divexpandcollapse('div<%# Eval("purchaseorderno") %>');">
                            <img id="imgdiv<%# Eval("purchaseorderno") %>" width:"9px" border="0" src="../images/plus.png" />
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="purchaseorderno" HeaderText="PO NO#" HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="totalamount" HeaderText="Amount" DataFormatString="{0:c}" HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="purchaseDate" HeaderText="PO Date" DataFormatString="{0:d}" HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="supplierCode" HeaderText="Supplier" HeaderStyle-HorizontalAlign="Left" />
                <asp:ButtonField ButtonType="Button" CommandName="Approve" Text="Approve"/>
                <asp:ButtonField ButtonType="Button" CommandName="Reject" Text="Reject"/>
                <asp:TemplateField>
                    <ItemTemplate>
                        <tr>
                            <td colspan="100%">
                                <div id="div<%# Eval("purchaseorderno") %>" style="display: none; position: relative; left: 15px; overflow: auto">
                                    <asp:GridView ID="gvOrderDetail" runat="server" AutoGenerateColumns="false" CssClass="mGrid" style="font-size:15px" BorderStyle="Double"  BorderColor="#df5015" GridLines="None" Width="600px">
                                    <HeaderStyle BackColor="#df5015" Font-Bold="true" ForeColor="White" />
                                    <RowStyle BackColor="#E1E1E1" />
                                    <AlternatingRowStyle BackColor="White" />
                                    <HeaderStyle BackColor="#df5015" Font-Bold="true" ForeColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="itemCode" HeaderText="Item Code" HeaderStyle-HorizontalAlign="Left" />
                                        <asp:BoundField DataField="orderedQuantity" HeaderText="Quantity" HeaderStyle-HorizontalAlign="Left" />
                                        <asp:BoundField DataField="price" HeaderText="Price" DataFormatString="{0:c}" HeaderStyle-HorizontalAlign="Left" />
                                        <asp:BoundField DataField="amount" HeaderText="Amount" DataFormatString="{0:c}" HeaderStyle-HorizontalAlign="Left" />                                    
                                    </Columns>
                                    </asp:GridView>
                                </div>
                                <div style="height:20px"></div>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div style="height:20px"></div>
    </div>

                            </td>
        </tr>
    </table>
</asp:Content>
