<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeMaster.Master"  AutoEventWireup="true" CodeFile="ViewStationeryCatalogue.aspx.cs" Inherits="Team8_ADProjectLUStationerySystem.Employee.ViewStationeryCatalogue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <table style="width:80%; margin-left:10%; text-align:left; height: 100px;">
        <tr>
            <td>
                <h3>Stationery Catalogue</h3>
            </td>
        </tr>
      </table>


    <table style="width:80%; margin-left:10%; text-align:left; height: 120px;">
         <tr>
             <td style="width: 40%">
                 <asp:Label ID="Label1" runat="server" Text="Search By Category: " style="font-size:20px"></asp:Label>
             </td>
             <td>
                 <asp:DropDownList ID="DropDownList1" runat="server" CssClass="dropdown1" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AppendDataBoundItems="True">
                     <asp:ListItem Value="4000">Select</asp:ListItem>
                 </asp:DropDownList>
             </td>
             <td>

             </td>
         </tr>
          </table>
         <table style="width:80%; margin-left:10%; text-align:left; height: 200px;">
            <tr>
                <td>
                    <asp:GridView ID="Gridview1" runat="server"  CssClass="mGrid" style="font-size:20px" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField HeaderText="Item Name">
                                 <ItemTemplate>
                                     <asp:Label ID="Label6" runat="server" Text='<%# Eval("itemDescription") %>'></asp:Label>
                                </ItemTemplate>
                                 <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Reorder Level">
                                 <ItemTemplate>
                                     <asp:Label ID="Label7" runat="server" Text='<%# Eval("reorderLevel") %>'></asp:Label>
                                </ItemTemplate>
                                 <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Reorder Quantity">
                                 <ItemTemplate>
                                     <asp:Label ID="Label8" runat="server" Text='<%# Eval("reorderQuantity") %>'></asp:Label>
                                </ItemTemplate>
                                 <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Unit of Measure">
                                 <ItemTemplate>
                                     <asp:Label ID="Label4" runat="server" Text='<%# Eval("uom") %>'></asp:Label>
                                </ItemTemplate>
                                 <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                           
                        </Columns>
     </asp:GridView>
                </td>
            </tr>

         </table>

             </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
