<%@ Page Title="" Language="C#" MasterPageFile="~/StoreClerk.Master" AutoEventWireup="true" CodeBehind="OrderListForStoreClerk.aspx.cs" Inherits="Team8_ADProjectLUStationerySystem.StoreClerk1.OrderListForStoreClerk" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
    <table style="width:85%; margin-left:10%; text-align:left; height: 50px;">
        <tr>
            <td>
                <h3>Purchase Order List</h3>
            </td>
        </tr>
      </table>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width:85%; margin-left:10%; text-align:left; height: 100px;">
       
        <tr>
            <td style="width: 240px"> 
                        <asp:Label ID="Label2" runat="server" Text="Start Date:" style="font-size:20px"></asp:Label></td><td>
                        <asp:TextBox ID="txtStartDate" runat="server" AutoPostBack="True" TextMode="Date" CssClass="tb2" style="Font-Size:20px"></asp:TextBox>
                    </td>
            </tr>
             <tr>
            <td style="width: 240px">
                        <asp:Label ID="Label3" runat="server" Text="End Date:" style="font-size:20px"></asp:Label></td><td>
                        <asp:TextBox ID="txtEndDate" runat="server" AutoPostBack="True" TextMode="Date" CssClass="tb2" style="Font-Size:20px"></asp:TextBox>
                    </td>
            <td align ="right">
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="button4" style="font-size:20px"/>
            </td>
        </tr>
            </table>
            <div>
                <fieldset>
                    <div>
                        <asp:RadioButtonList ID="rdostatus" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="All" Value="all" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Pending" Value="pending"></asp:ListItem>
                            <asp:ListItem Text="Approved" Value="approved"></asp:ListItem>
                            <asp:ListItem Text="Rejected" Value="rejected"></asp:ListItem>
                            <asp:ListItem Text="Completed" Value="completed"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </fieldset>
            </div>           
            <div style="height:40px"></div>
            <table style="width:85%; margin-left:10%; text-align:left; height: 231px;">
                <tr>
                    <td>
            <asp:GridView ID="gvOrderList" runat="server" DataKeyNames="purchaseorderno" 
        AutoGenerateColumns="false" OnRowDataBound="gvOrderListInfo_RowDataBound" GridLines="None" 
             CssClass="mGrid" style="font-size:20px" OnRowCommand="gvOrderList_RowCommand">
        <HeaderStyle BackColor="#2E8B57" Font-Bold="true" ForeColor="White" />
        <RowStyle BackColor="#E1E1E1" />
        <AlternatingRowStyle BackColor="White" />
        <HeaderStyle BackColor="#2E8B57" Font-Bold="true" ForeColor="White" />

            <Columns>
                <asp:TemplateField ItemStyle-Width="20px">
                    <ItemTemplate>
                        <a href="JavaScript:divexpandcollapse('div<%# Eval("purchaseorderno") %>');">
                            <img id="imgdiv<%# Eval("purchaseorderno") %>" width="9px" border="0" src="../images/plus.png" />
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="purchaseorderno" HeaderText="PO NO#" HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="totalamount" HeaderText="Amount" DataFormatString="{0:c}" HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="purchaseDate" HeaderText="PO Date" DataFormatString="{0:d}" HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="supplierCode" HeaderText="Supplier" HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="status" HeaderText="Status" HeaderStyle-HorizontalAlign="Left" />
                <asp:ButtonField ButtonType="Button" CommandName="Reorder" Text="Reorder"/>
                <asp:TemplateField>
                    <ItemTemplate>
                        <tr>
                            <td colspan="100%">
                                <div id="div<%# Eval("purchaseorderno") %>" style="display: none; position: relative; left: 15px; overflow: auto">
                                    <asp:GridView ID="gvOrderDetail" runat="server" AutoGenerateColumns="false" CssClass="mGrid">
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
                                            </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
