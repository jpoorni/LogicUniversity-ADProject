<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApproveRequisitions.aspx.cs" Inherits="Team8_ADProjectLUStationerySystem.DepartmentHead.ApproveRequisitions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   

     <table style="width:80%; margin-left:10%; text-align:left; height: 100px;">
        <tr>
            <td>
                <h3>Requisitions for Approval</h3>
            </td>
        </tr>
      </table>
     <table style="width:80%; margin-left:10%; text-align:left; height: 200px;">
       
         <tr>
          <td>
             <asp:GridView ID="GridView1" runat="server"  CssClass="mGrid" style="font-size:20px" AutoGenerateColumns="False">
                 <Columns>
                     <asp:TemplateField HeaderText="Requisition No">
                         <ItemTemplate>
                             <asp:Label ID="Label1" runat="server" Text='<%# Eval("RequisitionId") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Employee Name">
                         <ItemTemplate>
                             <asp:Label ID="Label2" runat="server" Text='<%# Eval("EmployeeName") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Requisition Date">
                         <ItemTemplate>
                             <asp:Label ID="Label3" runat="server" Text='<%# Eval("RequisitionDate","{0:M-dd-yyyy}") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="View Details">
                         <ItemTemplate>
                             <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Details</asp:LinkButton>
                         </ItemTemplate>
                     </asp:TemplateField>
                 </Columns>
             </asp:GridView>
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <asp:Label ID="LabelMessage" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
             </td>
         </tr> 
     </table>
   <br />
    <div id="detailsView" visible="false" runat="server" style="width:80%; margin-left:10%; text-align:left; background-color: #d3d3d3;border-radius:12px">
      <table id="table1" runat="server" style="width:80%; margin-left:10%; text-align:left; height: 200px;">
       <tr>
           <td align="left">
               <h4> Stationery Requisition Details</h4>
           </td>
       </tr>
         <tr>
          <td>
             <asp:GridView ID="GridView2" runat="server"  CssClass="mGrid" style="font-size:20px" AutoGenerateColumns="False">
                 <Columns>
                     <asp:TemplateField HeaderText="Item Description">
                         <ItemTemplate>
                             <asp:Label ID="Label4" runat="server" Text='<%# Eval("ItemDescription") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Quantity">
                         <ItemTemplate>
                             <asp:Label ID="Label5" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="UOM">
                         <ItemTemplate>
                             <asp:Label ID="Label6" runat="server" Text='<%# Eval("Uom") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                 </Columns>
             </asp:GridView>
             </td>
         </tr> 
          <tr>
              <td align="center">
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Button ID="Button1" runat="server" Text="Approve" CssClass="button4" OnClick="Button1_Click"/>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Button ID="Button2" runat="server" Text="Reject"  CssClass="button4" OnClick="Button2_Click" />

              &nbsp;&nbsp;
                  <asp:Button ID="Button3" runat="server" CssClass="button4" Height="35px" OnClick="Button3_Click" Text="Cancel" Width="86px" />
                  <br />

              </td>
          </tr>
     </table>
        <br />
        </div>
        
</asp:Content>
