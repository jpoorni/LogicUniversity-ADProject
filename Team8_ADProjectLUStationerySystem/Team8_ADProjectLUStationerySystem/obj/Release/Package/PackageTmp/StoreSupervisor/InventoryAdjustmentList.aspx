<%@ Page Title="" Language="C#" MasterPageFile="~/StoreSupervisorMaster.Master" AutoEventWireup="true" CodeBehind="ApproveInventoryAdjustment.aspx.cs" Inherits="Team8_ADProjectLUStationerySystem.StoreClerk1.ApproveInventoryAdjustment" %>
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
            <asp:BoundField DataField="adjustDate" HeaderText="Adjustment Date"  />  
            <asp:BoundField DataField="totalAmount" HeaderText="Adjusted Amount" />  
           
        
             
           
            <asp:TemplateField HeaderText ="Request Person">
            <ItemTemplate >
                     <%# Eval("employee.employeeName") %>
             <%# MyNewRow(Eval("adjustmentId")) %>   
             <asp:UpdatePanel runat="server" ID="pnlAdjustmentDetails">
                 <ContentTemplate>      
         <asp:GridView ID="gdvAdjustmentDetails" runat="server" DataKeyNames="adjustmentId" AutoGenerateColumns="False" CssClass="mGrid" style="font-size:20px"   GridLines="None">
             <HeaderStyle BackColor="LightBlue" />
         <Columns>
          
            <asp:BoundField DataField="itemCode" HeaderText="Item Code" />  
            <asp:BoundField DataField="adjustmentQuantity" HeaderText="Adjustment Quantity" />  
             <asp:BoundField DataField="adjustmentAmount" HeaderText="Adjustment Amount"  />
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

        </td>
            </tr>
        <p></p>
          &nbsp;
    &nbsp;
        &nbsp;
        <tr>
            <td style="height: 41px">
                
                
                
            </td>
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
            <td style="align-content">

             
                 <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="button4" style="font-size:20px" />
               
                </td>
                <td>
             

            </td>
        </tr>

        </table>

    
    <br />
    <br />
    
</asp:Content>
