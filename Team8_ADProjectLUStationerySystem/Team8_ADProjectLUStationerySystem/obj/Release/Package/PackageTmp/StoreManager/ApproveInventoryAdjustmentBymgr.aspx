<%@ Page Title="" Language="C#" MasterPageFile="~/StoreManagerMaster.Master" AutoEventWireup="true" CodeBehind="ApproveInventoryAdjustmentBymgr.aspx.cs" Inherits="Team8_ADProjectLUStationerySystem.StoreManager.ApproveInventoryAdjustmentBymgr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h3>Inventory Adjustment List</h3>
    <p>&nbsp;</p>
    &nbsp;
    &nbsp;
    &nbsp;

    <script type="text/javascript">

        function ShoeHide(img, div) {
            var current = $('#' + div).css('display');
            if (current == 'none') {
                $('#' + div).show('slow');
                $(img).attr('src', '../images/minus.png');
            }
            else {
                $('#' + div).hide('slow');
                $(img).attr('src', '../images/plus.png');
            }
        }
</script>
    <table style="width:80%; margin-left:10%; text-align:left; height: 231px;">
        <tr>
        <td>
            <asp:HiddenField ID="hdfid" runat="server" />
          <asp:ScriptManager ID="ScriptManager" runat="server">
    </asp:ScriptManager>
             <div onscroll="true">
            <asp:UpdatePanel runat="server" ID="pnlAdjustment">
                
                <ContentTemplate>

           <asp:GridView ID="gdvAdjustment" runat="server" AutoGenerateColumns="False"
                DataKeyNames="adjustmentId"  GridLines="None"
                         CssClass="mGrid" style="font-size:20px" OnRowDataBound="gdvAdjustment_RowDataBound" OnRowCommand="gdvAdjustment_RowCommand" >
          <HeaderStyle BackColor="LightBlue" />
            <Columns>
          
             <asp:TemplateField>
            <ItemTemplate>
                <img src="../images/plus.png" 
                    onclick="ShoeHide(this, 'tr<%# Eval("adjustmentId") %>')" />
            </ItemTemplate>
        </asp:TemplateField>

           <asp:BoundField DataField="adjustmentId" HeaderText="Adjustment ID"   />  
            <asp:BoundField DataField="adjustDate" HeaderText="Adjustment Date" DataFormatString="{0:dd/MM/yyyy} "/>  
            <%--<asp:BoundField DataField="totalAmount" HeaderText="Adjusted Amount"  DataFormatString="{0:c}" />--%>   
             <asp:BoundField DataField="employee.employeeName" HeaderText="Request Person"/>
              <asp:ButtonField ButtonType="Button" CommandName="ApproveComm" Text="Approve" HeaderText="Approve" >
            </asp:ButtonField>
              <asp:ButtonField ButtonType="Button" CommandName="RejectComm" Text="Reject" HeaderText="Reject" >
            </asp:ButtonField>
               
           
            <asp:TemplateField HeaderText ="">
            <ItemTemplate >
            <%# Myrow(Eval("adjustmentId")) %>   
             <asp:UpdatePanel runat="server" ID="pnlAdjustmentDetails">
                 <ContentTemplate>      
         <asp:GridView ID="gdvAdjustmentDetails" runat="server" DataKeyNames="adjustmentId" AutoGenerateColumns="False" CssClass="mGrid" style="font-size:20px"   GridLines="None">
             <HeaderStyle BackColor="LightBlue" />
         <Columns>
          
            <asp:BoundField DataField="itemCode" HeaderText="Item Code" />  
            <asp:BoundField DataField="adjustmentQuantity" HeaderText="Adjustment Quantity" />  
             <asp:BoundField DataField="adjustmentAmount" HeaderText="Adjustment Amount"  DataFormatString="{0:c}"  />
              <asp:BoundField DataField="type" HeaderText="Adjustment Type"/>
              <asp:BoundField DataField="reason" HeaderText="Reason" />
                
                    </Columns>
             </asp:GridView>
                    </ContentTemplate> 
             </asp:UpdatePanel>
                     </ItemTemplate>
                </asp:TemplateField>
               
        </Columns>
    </asp:GridView>
              </ContentTemplate>
           </asp:UpdatePanel>
                 </div>
        
        </td>
            </tr>
        <p></p>
          &nbsp;
    &nbsp;
        &nbsp;
        <tr>
            <td style="height: 41px">
                
                
                
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                
              

            </td>
        </tr>
        <tr>
            <td style="height: 47px">

              
                
            </td>
        </tr>
        <tr>
            <td style="align-content;">

              
                 <asp:Button ID="btnApproveAll" runat="server" Text="ApproveAll" CssClass="button4" style="font-size:20px" OnClick="btnApproveAll_Click" Visible="false"/>
                <asp:Button ID="btnRejectAll" runat="server" Text="Reject All" CssClass="button4" style="font-size:20px" OnClick="btnRejectAll_Click" Visible ="false" />
               
                </td>
                <td>
             

            </td>
        </tr>

        </table>

    
    <br />
    <br />
    
</asp:Content>
