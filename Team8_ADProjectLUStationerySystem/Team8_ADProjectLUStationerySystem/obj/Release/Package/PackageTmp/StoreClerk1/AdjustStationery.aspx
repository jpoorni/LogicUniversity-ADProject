<%@ Page Title="" Language="C#" MasterPageFile="~/StoreClerk.Master"  AutoEventWireup="true" CodeBehind="AdjustStationery.aspx.cs" Inherits="Team8_ADProjectLUStationerySystem.StoreClerk1.AdjustStationery" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%--<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
    left: 0;
    top: -1.5px;
    background: transparent;
    border: none;
}

    /*.auto-style1 {
        width: 47%;
        height: 104px;
    }
    .auto-style2 {
        width: 65%;
        height: 104px;
    }
    .auto-style3 {
        height: 104px;
    }*/

</style>

<script src="//code.jquery.com/jquery-1.12.0.min.js"></script>
    <script type="text/javascript">       
        $(function () {
            if ($('input[name="ctl00$MainContent$type"]:checked').val() === "rdbAdjustIn") {
                
                $('.lost').hide();
                $('.fgift').show();
            }
            else {
                $('.lost').show();
                $('.fgift').hide();
        
            }
            $('#MainContent_rdbAdjustIn').on('click', function () {
                $('.lost').hide();
                $('.fgift').show();
            });
            $('#MainContent_rdbAdjustOut').on('click', function () {
                $('.lost').show();
                $('.fgift').hide();
            });
           
        });

        <%--function validateQuantity() {
            var txtVal = document.getElementById("<%=txtQty.ClientID%>").value;

            if (txtVal >= 10 && txtVal <= 1500) {
                return true;
            }
            else
                document.getElementById("<%=lblchkRange.ClientID%>").Text = "Quantity must be between 10-1500";
                //alert('Quantity must be between 10-1500');
            return false;

            if ( txtVal.value = String)
            {

            }
        }--%>
        
      

  </script>

      <table style="width:85%; margin-left:10%; text-align:left; height: 100px;">
        <tr>
            <td>
                <h3>Adjust Inventory</h3>
            </td>
        </tr>
      </table>

    <table style="width:85%; margin-left:10%; text-align:left; height: 231px;">
        
        <tr>
            <td width ="40%">
                
                <asp:Label ID="Label1" runat="server" Text="Item Category:" style="font-size:20px"></asp:Label>
                
            </td>
            <td width = "65%">

             
                 <asp:TextBox ID="lblItemNo" runat="server" CssClass="tb1" style="font-size:20px" Enabled="false"></asp:TextBox> &nbsp;   <asp:ImageButton ID="imgbtnDetail"  runat="server" ImageUrl="~/images/search.png" width="37px" Height="26px" BorderStyle="None" BorderWidth="5px"/>
               <br />
                <asp:Label ID="lblINo" runat="server"  style="font-size:15px" ForeColor="Red"></asp:Label>

            </td>
            <td>
                </td>
           
        </tr>
        <tr>
            <td style="width: 47%">

                <asp:Label ID="Label2" runat="server" Text="Item Name:" style="font-size:20px"></asp:Label>
                
            </td>
            <td style="width: 65%">
                <asp:TextBox ID="lblItemName" runat="server" CssClass="tb1" style="font-size:20px" Enabled="false"></asp:TextBox>
                <br />
                <asp:Label ID="lblErrIName" runat="server"  style="font-size:15px" ForeColor="Red"></asp:Label>
                
            </td>
            <td>
                
            </td>
            
        </tr>
        <tr>
             <td style="width: 47%">

                 <asp:Label ID="Label3" runat="server" Text="Adjustment Type:" style="font-size:20px"></asp:Label>

            </td>
             <td style="width: 65%">

                    
                     <asp:RadioButton ID="rdbAdjustIn" Name="Adjust" style="font-size:20px"  Text="AdjustIn" runat="server" GroupName="type"  Checked="True"/>
                &nbsp;&nbsp;&nbsp;
                  <asp:RadioButton ID="rdbAdjustOut" Name="Adjust" style="font-size:20px" Text="AdjustOut" runat="server" GroupName="type" />
             

            </td>
            
             <td>

            </td>
        </tr>
        <tr>
            <td style="width: 47%">>

                 <asp:Label ID="Label4" runat="server" Text="Quantity to be Adjusted:" style="font-size:20px"></asp:Label>
                
            </td>
            <td style="width: 65%">
                <asp:TextBox ID="txtQty" runat="server" CssClass="tb1" style="font-size:20px"></asp:TextBox>
              <br />
                <asp:CompareValidator ID="cv" runat="server" ControlToValidate="txtQty" Type="Integer" Operator="DataTypeCheck" ErrorMessage="Value must be an integer or vale is out of range!" ForeColor="Red" />
                <br />
                <%--<asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Value should be between 1 and 1500!" ControlToValidate="txtQty" MaximumValue="1500" MinimumValue="1"></asp:RangeValidator>--%>
                <asp:Label ID="chkrange" runat="server" ForeColor="Red"></asp:Label>
                 <br />
                <asp:Label ID="lblErrorMsg" runat="server" Text="Label" style="font-size:15px" ForeColor="Red"></asp:Label>
              <br />
                <asp:Label ID="Label7" runat="server" ForeColor="Red"></asp:Label>
            
            </td>
            <td class="auto-style3">
            </td>
            
         </tr>
        <tr>
            <td style="width: 47%">

                 <asp:Label ID="Label5" runat="server" Text="Reasons for Adjustment:" style="font-size:20px" ></asp:Label>

            </td>
            <td style="width: 55%">
                <div class="fgift" id="divg">
                    <asp:RadioButton ID="rdbFreeGift" Text="Free Gift" runat="server" GroupName="reason" Checked="True" style="font-size:20px"  />
                </div>
                 
&nbsp;&nbsp;&nbsp;
                <div class="lost" id="givd">

                     <asp:RadioButton ID="rdbDamage" Text="Damage" runat="server" GroupName="reason" style="font-size:20px"  />

            &nbsp;&nbsp;
                  <asp:RadioButton ID="rdbLost" Text="Lost /Oversight" runat="server" GroupName="reason" style="font-size:20px" />
                </div>
                
            </td>
            <td></td>
            <tr>
                <td> </td>
                <td></td>
            <td style="width: 55%">
                
                <asp:Button ID="btnAdd" runat="server" Text="Add" style="font-size:20px" CssClass="button4" OnClick="btnAdd_Click"/>
            </td>
            </tr>
        </tr>
    </table>
    <asp:HiddenField ID="hdfcatID" runat="server" />
    <asp:HiddenField ID="hdfadjID" runat="server" />
     <asp:ScriptManager ID="ScriptManager1" runat="server">
         
    </asp:ScriptManager>
    <div id="divpopup" style="position: fixed;">

       
        <%--style="position:fixed;left:600px; top:300px;"--%>
    <asp:UpdatePanel ID="updpnlCatelogueItem" runat="server" style="position:fixed;left:600px; top:300px;" >
       <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlCategory" EventName="SelectedIndexChanged"/>
            <asp:PostBackTrigger ControlID="gdvCatelogueItem" />
          
       </Triggers>
    <ContentTemplate>
    <asp:Label  runat="server" Text=" Category" style="color:white; font-size:20px" CssClass="fa-align-left"></asp:Label>
        &nbsp; 
    <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="true" style="font-size:15px" CssClass="dropdown1"
     OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" >
    </asp:DropDownList>
         <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/remove.png" style="left:auto" OnClick="ImageButton1_Click"/>
         <br>
        
        <asp:Label ID="lblCat" runat="server" CssClass="fa-align-center" style="color:white; font-size:26px" Text="Catelogue Item List"></asp:Label>
        <asp:GridView ID="gdvCatelogueItem" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="mGrid" OnRowCommand="gdvCatelogueItem_RowCommand" PageSize="5" style="font-size:20px" AllowPaging="true" OnPageIndexChanging="gdvCatelogueItem_PageIndexChanging1" >
            <Columns>
                <asp:BoundField DataField="itemCode" HeaderText="Item Code" />
                <asp:BoundField DataField="itemDescription" HeaderText="Item Description" />
                <asp:BoundField DataField="reorderLevel" HeaderText="Reorder Level" />
                <asp:BoundField DataField="reorderQuantity" HeaderText="Reorder Quantity" />
                <asp:BoundField DataField="quantity" HeaderText="Balance Quantity" />
                <asp:BoundField DataField="uom" HeaderText="UOM" />
                <asp:ButtonField ButtonType="Image" CommandName="ChooseComm" ImageUrl="~/images/chose.png">
                <ItemStyle HorizontalAlign="Center" Width="16px" />
                </asp:ButtonField>
            </Columns>
        </asp:GridView>
        <br>
      
    </ContentTemplate>                                 
    </asp:UpdatePanel>  
       
    </div>
    
         <asp:UpdatePanel ID="updpnlAdjustment" runat="server">
 
        <ContentTemplate>
            
            <asp:GridView ID="gdvAdjustmentList" CssClass="mGrid" style="font-size:20px" runat="server" AutoGenerateColumns="False" OnRowCommand="gdvAdjustmentList_RowCommand" AllowPaging="true" OnPageIndexChanging="gdvAdjustmentList_PageIndexChanging" PageSize="3" >
         
             <Columns>
          
            <asp:BoundField DataField="itemCode" HeaderText="Item Code" />  
            <asp:BoundField DataField="adjustmentQuantity" HeaderText="Adjustment Quantity" />  
             <asp:BoundField DataField="adjustmentAmount" HeaderText="Adjustment Amount" />
              <asp:BoundField DataField="type" HeaderText="Adjustment Type" />
              <asp:BoundField DataField="reason" HeaderText="Reason"/>
                <asp:ButtonField ButtonType="Image" CommandName="RemoveComm" ImageUrl="~/images/remove.png">
                <ItemStyle Width="16px" HorizontalAlign="Center"></ItemStyle>
            </asp:ButtonField>
        </Columns>
    </asp:GridView>        
        </ContentTemplate>
    </asp:UpdatePanel>

  
    <table style="width:80%; margin-left:10%; text-align:left; height: 231px;">

        <tr>
            <td>
                <asp:updatepanel  ID="updAmt" runat="server" >
              <Triggers>
          
            <asp:PostBackTrigger ControlID="gdvAdjustmentList" />
          
            </Triggers>
                    <ContentTemplate>
                        <asp:Label ID="Label8" runat="server" Text="Total Amount Adjustment: " style="font-size:20px"></asp:Label>

                <asp:Label ID="AmtAdjustmentLbl" runat="server" style="font-size:20px"></asp:Label>
                        <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                
                </asp:updatepanel>
               

            </td>
            <td align ="right">
                <asp:Button ID="btnConfirmAdj" runat="server" Text="Request for Authorization"  CssClass="button4" style="font-size:20px" OnClick="btnConfirmAdj_Click" />
            </td>
        </tr>
    </table>

     <ajaxToolkit:ModalPopupExtender BackgroundCssClass="modalBackground" ID="MainExender" PopupControlID="divpopup" runat="server" TargetControlID="imgbtnDetail"
       PopupDragHandleControlID="updpnlAdjustment"  BehaviorID ="mpebehavior" OnLoad="Page_Load" RepositionMode="RepositionOnWindowResizeAndScroll">
    </ajaxToolkit:ModalPopupExtender>

</asp:Content>
