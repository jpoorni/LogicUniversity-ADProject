<%@ Page Title="" Language="C#" MasterPageFile="~/StoreClerk.Master" AutoEventWireup="true" CodeBehind="GenerateDisbursementList.aspx.cs" Inherits="Team8_ADProjectLUStationerySystem.StoreClerk1.GenerateDisbursementList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:80%; margin-left:5%; text-align:left; height: 100px;">
            <td>
                <h3>Disbursement List</h3>
            </td>
        </tr>
      </table>
     <table style="width:80%; margin-left:5%; text-align:left; height: 200px;">
          <tr>
             <td style="width: 40%">
                 <asp:Label ID="Label2" runat="server" Text="Retrieval No: " style="font-size:20px"></asp:Label>
             </td>
             <td>
                 <asp:DropDownList ID="DropDownList1" runat="server" CssClass="dropdown1" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True" >
                 </asp:DropDownList>
             </td>
              <td>
                   &nbsp;</td>
         </tr>
         </table>
    <asp:GridView ID="GenrateDisbursementGridView" runat="server" style="font-size:20px" CssClass="mGrid" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="departmentName" HeaderText="Department Name" />
            <asp:TemplateField HeaderText="Collection Date">
                <ItemTemplate>
                    <asp:TextBox ID="tbDate" runat="server" TextMode="Date" OnTextChanged="tbDate_TextChanged"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("departmentCode")%>' />
                    <asp:LinkButton ID="lbNew" runat="server" OnClick="lbNew_Click">Generate</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
