<%@ Page Title="" Language="C#" MasterPageFile="~/StoreClerk.Master" AutoEventWireup="true" CodeFile="StockCards.aspx.cs" Inherits="Team8_ADProjectLUStationerySystem.StoreClerk1.StockCards" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<head runat="server">
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
            left:600px;
            top:300px;
        }
    .auto-style1 {
        width: 140px;
        height: 128px;
    }
    .auto-style2 {
        height: 128px;
    }
    .ItemPanel{
        position:fixed; left:600px;
            top:300px;
    }
    </style>
    </head>


    <table style="width:80%; margin-left:5%; text-align:left; height: 100px;">
        <tr>
            <td>
                <h3>Existing stockist</h3>
            </td>
        </tr>
      </table>
   
    <table style="width:80%; margin-left:5%; text-align:left; height: 200px;">       
        <tr >
            <td class="auto-style1">
                
                <asp:Label ID="Label5" runat="server" Text="Stationery Item: " style="font-size:20px"></asp:Label>
                
            </td>
            <td class="auto-style2">
                

                 <asp:TextBox ID="txtItemDescription" runat="server" CssClass="tb2" style="Font-Size:20px"  Enabled="false"></asp:TextBox>  
                
                <asp:ImageButton ID="SearchBtn" runat="server" Height="23px" ImageUrl="~/images/search.png" Width="26px" />
                
            </td>
            
            
              

      
        </table>

        
    <div id="divpopup" style="position: fixed;">
    <asp:UpdatePanel ID="ItemPanel" runat="server" style ="position:fixed; left:600px;top:300px;">
       <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlCategory" EventName="SelectedIndexChanged"/>
            <asp:PostBackTrigger ControlID="gdvCatelogueItem" />
           <%--UpdateMode="Conditional" --%>
       </Triggers>
    <ContentTemplate>
    <asp:Label  runat="server" Text=" Category" style="color:white; font-size:15px" CssClass="fa-align-left"></asp:Label>
    <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="true" style="font-size:15px" CssClass="dropdown1" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"
     >
    </asp:DropDownList>

        
         <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/remove.png" style="left:auto" OnClick="ImageButton1_Click"/>
         <br>
   
        <asp:Label ID="lblCat" runat="server" CssClass="fa-align-center" style="color:white; font-size:26px" Text="Catalogue Item List"></asp:Label>
        <asp:GridView ID="gdvCatelogueItem" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="mGrid" style="font-size:15px;width: 192px; height: 220px" OnRowCommand="gdvCatelogueItem_RowCommand" OnSelectedIndexChanged="gdvCatelogueItem_SelectedIndexChanged" >
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








    <table style="width:80%; margin-left:5%; text-align:left; height: 150px; margin-top: 0px;">
        <tr>
            
            <td style="width: 400px; text-align: center;">
            <asp:Image ID="StockCardImage" runat="server" Height="200px" Width="200px"  />
                </td>
            <td>
                <br />
                <asp:Label ID="itemCode" runat="server" Visible="False"></asp:Label>
                <br />
                <asp:Label ID="Label6" runat="server" Text="Bin Number: " style="font-size:20px" Visible="False"></asp:Label>
                <asp:Label ID="BinNoLbl" runat="server" style="font-size:20px"></asp:Label>
                <br />
                <asp:Label ID="InStock" runat="server" style="font-size:20px" Visible="False" CssClass ="Red">Item is not in stock.</asp:Label>
            </td>
        </tr>
                
      
        </table>
    <table style="width:80%; margin-left:5%; text-align:left; height: 231px;">
            
        <tr>
            <td>
                <asp:GridView ID="StockCardGridView" runat="server" CssClass="mGrid" style="font-size:20px" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="transactionDate" HeaderText="Transaction Date" />
                        <asp:BoundField DataField="transactionType" HeaderText="Task" />
                        <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                        <asp:BoundField DataField="balance" HeaderText="Balance Quantity" />
                    </Columns>
                </asp:GridView> 
                <%--<asp:Button ID="AdjustInventoryBtn" runat="server" Text="Adjust Inventory" CssClass="button4" style ="font-size:20px"/>--%>
                <br />
            </td>
        </tr>
        <tr align="right">
              <td>
                <asp:Button ID="MakePurchaseOrderBtn" runat="server" Text="Make Purchase Order" CssClass="button4" style ="font-size:20px" Visible="False" OnClick="MakePurchaseOrderBtn_Click"/>
                    </td>
        </tr>
                
    </table>
  
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground"  PopupControlID="divpopup"  TargetControlID="SearchBtn"
       PopupDragHandleControlID="ItemPanel" OnLoad="Page_Load"  RepositionMode="RepositionOnWindowResizeAndScroll" ></ajaxToolkit:ModalPopupExtender>
  
</asp:Content>
