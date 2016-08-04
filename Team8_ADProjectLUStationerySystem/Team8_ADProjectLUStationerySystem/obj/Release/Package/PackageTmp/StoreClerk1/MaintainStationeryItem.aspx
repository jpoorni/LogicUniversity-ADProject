<%@ Page Title="" Language="C#" MasterPageFile="~/StoreClerk.Master" AutoEventWireup="true" CodeFile="MaintainStationeryItem.aspx.cs" Inherits="Team8_ADProjectLUStationerySystem.StoreClerk1.MaintainStationeryItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       
     <table style="width:80%; margin-left:5%; text-align:left; height: 100px;">
        <tr>
            <td>
                <h3>View Stationery Catalogue</h3>
            </td>
        </tr>
      </table>
  

    <table style="width:80%; margin-left:5%; text-align:left; height: 200px;">
         <tr>

             
             <td style="width: 40%">
                 <asp:Label ID="Label1" runat="server" Text="Search By Category: " style="font-size:20px"></asp:Label>
             </td>
             <td>
                 <asp:DropDownList ID="CategoryDropDown" runat="server" CssClass="dropdown1" OnSelectedIndexChanged="CategoryDropDown_SelectedIndexChanged" AutoPostBack="True">
                     <asp:ListItem>Any</asp:ListItem>
                     <asp:ListItem>Clip</asp:ListItem>
                     <asp:ListItem>Envelope</asp:ListItem>
                     <asp:ListItem>Eraser</asp:ListItem>
                     <asp:ListItem>Exercise</asp:ListItem>
                     <asp:ListItem>File</asp:ListItem>
                     <asp:ListItem>Pen</asp:ListItem>
                     <asp:ListItem>Puncher</asp:ListItem>
                     <asp:ListItem>Pad</asp:ListItem>
                     <asp:ListItem>Paper</asp:ListItem>
                     <asp:ListItem>Ruler</asp:ListItem>
                     <asp:ListItem>Scissors</asp:ListItem>
                     <asp:ListItem>Tape</asp:ListItem>
                     <asp:ListItem>Sharpener</asp:ListItem>
                     <asp:ListItem>Shorthand</asp:ListItem>
                     <asp:ListItem>Tacks</asp:ListItem>
                     <asp:ListItem>Transparency</asp:ListItem>
                     <asp:ListItem>Tray</asp:ListItem>
                     <asp:ListItem>Stapler</asp:ListItem>
                 </asp:DropDownList>
             </td>
             <td>

             </td>
         </tr>
          <tr>
             <td style="width: 40%">
                 <asp:Label ID="Label2" runat="server" Text="Search By Item Name: " style="font-size:20px"></asp:Label>
             </td>
             <td>
                 <asp:DropDownList ID="ItemNameDropDown" runat="server" CssClass="dropdown1" OnSelectedIndexChanged="ItemNameDropDown_SelectedIndexChanged" AutoPostBack="True">
                 </asp:DropDownList>
             </td>
              <td>
                   
              </td>
         </tr>
        <tr>
            <td></td>
            <td>
            </td>
            <td><asp:Button ID="SearchBtn" runat="server" Text="Search" CssClass="button4" OnClick="SearchBtn_Click" OnClientClick="SearchBtn_Click"  /></td>
        </tr>
         </table>
         <table style= "width:80%; margin-left:5%; text-align:left; height: 200px;">
            <tr>
                <td>
                    <asp:GridView ID="CatalogueGridview" runat="server"  CssClass="mGrid" style="font-size:20px" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="itemDescription" HeaderText="Item Name" />
                            <asp:BoundField DataField="reorderLevel" HeaderText="Reorder Level" />
                            <asp:BoundField DataField="reorderQuantity" HeaderText="Reorder Quantity" />
                            <asp:BoundField DataField="uom" HeaderText="Unit of Measure" />
                            <asp:BoundField DataField="tenderPrice" HeaderText="Price" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("itemCode")%>' />
                                    <asp:LinkButton ID="lbEdit" runat="server" OnClick="lbEdit_Click">Edit</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
     </asp:GridView>
                </td>
            </tr>
             <tr align="right">
                 <td>
                     &nbsp;</td>
             </tr>
         </table>
</asp:Content>

