<%@ Page Title="" Language="C#" MasterPageFile="~/StoreClerk.Master" AutoEventWireup="true" CodeBehind="CreateOrder.aspx.cs" Inherits="Team8_ADProjectLUStationerySystem.StoreClerk1.CreateOrder" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <head></head>
    <script type="text/javascript">
        function validateQuantity() {
            var txtVal = document.getElementById("<%=txtQty.ClientID%>").value;

            if (txtVal >= 10 && txtVal <= 1500) {
                return true;
            }
            else
                alert('Quantity must be between 10-1500');
            return false;
        }

    </script>
    
    <!--Style For Modal PopupExtender-->
<style>
.modalBackground
        {
            background-color:Gray;
            filter:alpha(opacity=50);
            opacity:0.7;
        }
.pnlBackGround
        {
         position:fixed;
            top:10%;
            left:10px;
            width:300px;
            height:125px;
            text-align:center;
            background-color:White;
            border:solid 3px black;
        }
.divpopup
        {

            position: fixed;
            z-index: 10001;
            left: 220px;
            top: 300px;
            background: transparent;
            border: none;
        }
    .auto-style1 {
        width: 29%;
    }
</style>
    
      <table style="width:85%; margin-left:10%; text-align:left; height: 100px;">
        <tr>
            <td>
                <h3>Create Purchase Order</h3>
            </td>
        </tr>
      </table>
    
    <asp:UpdatePanel ID="SupplierPanel" runat="server">
        <ContentTemplate>
            <table style="width:85%; margin-left:10%; text-align:left; height: 231px;">
                <tr>
                    <td style="width: 131px">
                        <asp:Label ID="Label8" runat="server" Text="Supplier:"  style="font-size:20px"></asp:Label>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlSupplier" runat="server" AutoPostBack="true"  style="font-size:20px"  CssClass="dropdown1" OnSelectedIndexChanged="ddlSupplier_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>    
                </tr>
                <tr>
                    <td style="width: 131px">
                        <asp:Label ID="Label2" runat="server" Text="Address:"  style="font-size:20px"></asp:Label>
                        </td>
                    <td>
                        <asp:Label ID="lblAddress" runat="server" style="width:10px; font-size:20px"></asp:Label>
                    </td>
                </tr>
            </table>
        </ContentTemplate>            
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlSupplier" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>

    
    <table style="width:85%; margin-left:10%; text-align:left; height: 231px;">
        
        <tr>
            <td class="auto-style1">
                
                <asp:Label ID="Label1" runat="server" Text="Stationery Item :" style="font-size:20px"></asp:Label>
                
            </td>
            <td style="width: 65%">
                 <asp:TextBox ID="txtItemDescription" runat="server" CssClass="tb1" style="Font-Size:20px" Enabled="false"></asp:TextBox>  
                <asp:ImageButton ID="imgbtnDetail"  runat="server" ImageUrl="~/images/search.png" width="37px" Height="26px" BorderStyle="None" BorderWidth="5px"/>
            </td>
            <td>
                </td>
           
        </tr>
        <tr>
            <td class="auto-style1">
                 <asp:Label ID="Label3" runat="server" Text="Unit of Measure (UoM):" style="font-size:20px"></asp:Label>
            </td>
            <td style="width: 47%">
                 <asp:Label ID="lblUoM" runat="server" style="font-size:20px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                 <asp:Label ID="Label5" runat="server" Text="Quantity to be Ordered:" style="font-size:20px"></asp:Label>
            </td>
            <td style="width: 65%">
                <asp:TextBox ID="txtQty" runat="server"  CssClass="tb1" style="Font-Size:20px"></asp:TextBox>
                </br>
                <asp:Label ID="lblErrorMsg" runat="server"  ForeColor="Red" style="font-size:20px"></asp:Label>
            </td>
            <td>
            </td>            
         </tr>
        <tr>
            <td class="auto-style1"> </td>
            <td></td>
            <td>
               <asp:Button ID="btnAdd" runat="server" Text="Add" style="font-size:20px" CssClass="button4" OnClick="btnAdd_Click" OnClientClick="javascript:return validateQuantity();"/>
            </td>
        </tr>
    </table>
    <div id="divpopup" style="position: fixed;">
    <asp:UpdatePanel ID="ItemPanel" runat="server"  style ="position:fixed; left:600px;top:300px;">
       <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlCategory" EventName="SelectedIndexChanged"/>
            <asp:PostBackTrigger ControlID="gdvCatelogueItem" />
           <%--UpdateMode="Conditional" --%>
       </Triggers>
    <ContentTemplate>
    <asp:Label  runat="server" Text=" Category" style="color:white; font-size:15px" CssClass="fa-align-left"></asp:Label>
    <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="true" style="font-size:15px" CssClass="dropdown1"
     OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" >
    </asp:DropDownList>
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/remove.png" style="left:auto" OnClick="ImageButton1_Click"/>
         <br>
   
        <asp:Label ID="lblCat" runat="server" CssClass="fa-align-center" style="color:white; font-size:26px" Text="Catelogue Item List"></asp:Label>
        <asp:GridView ID="gdvCatelogueItem" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="mGrid" OnRowCommand="gdvCatelogueItem_RowCommand" style="font-size:15px">
            <Columns>
                <asp:BoundField DataField="itemCode" HeaderText="Item Code" />
                <asp:BoundField DataField="itemDescription" HeaderText="Item Description" />
                <asp:BoundField DataField="reorderLevel" HeaderText="Reorder Level" />
                <asp:BoundField DataField="quantity" HeaderText="Balance" />
                <asp:BoundField DataField="tenderPrice" HeaderText="Balance" DataFormatString="{0:c}" />
                <asp:ButtonField ButtonType="Image" CommandName="ChooseComm" ImageUrl="~/images/chose.png">
                <ItemStyle HorizontalAlign="Center" Width="16px" />
                </asp:ButtonField>
            </Columns>
        </asp:GridView>
        <br>
      
    </ContentTemplate>                                 
    </asp:UpdatePanel>  
    </div>
    
         <asp:UpdatePanel ID="OrderPanel" runat="server">
        <ContentTemplate>

        <%--OrderCart GridView Show Here--%>
                    <div style="height:20px"></div>
                    <asp:GridView ID="gvOrderDetail" CssClass="mGrid" style="font-size:20px"  runat="server" AutoGenerateColumns="False" DataKeyNames="purchaseDetail_Id" OnRowCommand="gvOrderDetail_RowCommand"
                        AllowPaging="true" PageSize="5" OnPageIndexChanging="gvOrderDetail_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="S/No">
                                <ItemTemplate>
                                    <%#: ((GridViewRow)Container).RowIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="itemDescription" HeaderText="Item Description" ReadOnly="True" SortExpression="itemDescription"/>
                            <asp:BoundField DataField="orderedQuantity" HeaderText="Ordered Quantity" ReadOnly="True" SortExpression="orderedQuantity"/>
                            <asp:BoundField DataField="price" HeaderText="Price" ReadOnly="True" DataFormatString="{0:c}" SortExpression="price"/>
                            <asp:BoundField DataField="amount" HeaderText="Amount" ReadOnly="True" DataFormatString="{0:c}" SortExpression="amount"/>
                            <asp:ButtonField ButtonType="Link" CommandName="RemoveComm" Text="Remove">
                                <ItemStyle Width="16px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                            </asp:ButtonField>
                        </Columns>
                    </asp:GridView>
            <br />
            <div> 
                <p></p> 
                <strong> 
                    <asp:Label ID="LabelTotalText" runat="server" Text="Order Total Amount: "></asp:Label> 
                    <asp:Label ID="lblTotal" runat="server" EnableViewState="false"></asp:Label> 
                </strong>  
            </div>
            <div style="height:10px"></div>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCreate" runat="server" Text="Create Order" OnClick="btnCreate_Click" style="font-size:20px" CssClass="button4"/>&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCancel" runat="server" Text="Cancel Order" OnClick="btnCancel_Click" style="font-size:20px" CssClass="button4"/>
        </ContentTemplate>            
    </asp:UpdatePanel>

     <ajaxToolkit:ModalPopupExtender BackgroundCssClass="modalBackground" ID="MainExender" PopupControlID="divpopup" runat="server" TargetControlID="imgbtnDetail"
       PopupDragHandleControlID="ItemPanel" OnLoad="Page_Load"  RepositionMode="RepositionOnWindowResizeAndScroll" >
    </ajaxToolkit:ModalPopupExtender>
    
</asp:Content>
