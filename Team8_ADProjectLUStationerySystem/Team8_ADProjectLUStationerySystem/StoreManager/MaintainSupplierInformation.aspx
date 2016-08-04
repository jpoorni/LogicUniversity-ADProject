<%@ Page Title="" Language="C#" MasterPageFile="~/StoreManagerMaster.Master" AutoEventWireup="true" CodeBehind="MaintainSupplierInformation.aspx.cs" Inherits="Team8_ADProjectLUStationerySystem.StoreManager.MaintainSupplierInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <script type="text/javascript">
          function uns() {
              alert("Rank can't be same!");
              window.location = "MaintainSupplierInformation.aspx";
          }
      </script>

    <script type="text/javascript">
        function s() {
            alert("Successful!");
            window.location = "MaintainSupplierInformation.aspx";
        }
      </script>
    <table style="width:85%; margin-left:10%; text-align:left; height: 100px;">
        <tr>
            <td>
                <h3>Maintain Supplier Information</h3>
            </td>
        </tr>
      </table>

    <table style="width:85%; margin-left:10%; text-align:left; height: 231px;">
        <tr>
            <td>
             <asp:GridView ID="SupplierGridView" runat="server" OnRowDataBound="AdjustStationeryGridView_RowDataBound" CssClass="mGrid" style="font-size:20px" AutoGenerateColumns="False">
                 <Columns>
                     <asp:BoundField DataField="supplierCode" HeaderText="Supplier Code" />
                     <asp:BoundField DataField="gstRegistrationNumber" HeaderText="GST Registration Number" />
                     <asp:BoundField DataField="supplierName" HeaderText="Supplier Name" />
                     <asp:BoundField DataField="contactName" HeaderText="Contact Person" />
                     <asp:BoundField DataField="phoneNo" HeaderText="Contact Number" />
                     <asp:BoundField DataField="faxNo" HeaderText="Fax Number" />
                     <asp:BoundField DataField="address" HeaderText="Address" />
                     <asp:TemplateField HeaderText="Priority ">
                         <ItemTemplate>
                             <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("supplierRank")%>' />
                             <asp:DropDownList ID="ddlRank" runat="server" AutoPostBack="True" >
                                 <asp:ListItem Value="1">First</asp:ListItem>
                                 <asp:ListItem Value="2">Second</asp:ListItem>
                                 <asp:ListItem Value="3">Third</asp:ListItem>
                                 <asp:ListItem Value="0">BackUp</asp:ListItem>
                             </asp:DropDownList>
                         </ItemTemplate>
                     </asp:TemplateField>
                 </Columns>
             </asp:GridView>
            </td>
        </tr>
        <tr align="right">
            <td >
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <asp:Button ID="Button1" runat="server" Text="Save" CssClass="button4" OnClick="Button1_Click"/>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <asp:Button ID="Button2" runat="server" Text="Cancel" CssClass="button4" OnClick="Button2_Click"/>
            </td>
        </tr>
    </table>
</asp:Content>
