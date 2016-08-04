<%@ Page Title="" Language="C#" MasterPageFile="~/StoreClerk.Master" AutoEventWireup="true" CodeFile="RetrievalHistory.aspx.cs" Inherits="Team8_ADProjectLUStationerySystem.StoreClerk1.RetrievalHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table style="width:85%; margin-left:10%; text-align:left; height: 100px;">
        <tr>
            <td>
                <h3>Retrieval History</h3>
            </td>
        </tr>
      </table>
    <table style="width:85%; margin-left:10%; text-align:left; height: 231px;">
        <tr>
            <td style="width: 167px">
                <asp:Label ID="lbItem" runat="server" Text="Item: " style="font-size:20px"></asp:Label>
            </td>
            <td style="width: 601px">
                <asp:DropDownList ID="ddlItem" runat="server" CssClass="dropdown1"  AutoPostBack="True"></asp:DropDownList>
            </td>
            <td></td>
        </tr>
        <tr>
            <td style="width: 167px">
                <asp:Label ID="lbDep" runat="server" Text="Department: " style="font-size:20px"></asp:Label>
            </td>
            <td style="width: 601px">
                <asp:DropDownList ID="ddlDep" runat="server" CssClass="dropdown1" AutoPostBack="True"></asp:DropDownList>
            </td>
            <td align ="right">
                <asp:Button ID="btnSearch" runat="server" Text="Search" style="font-size:20px" CssClass="button4" OnClick="btnSearch_Click"/>
            </td>
        </tr>
        <tr >
            <td style="width: 167px">
                &nbsp;</td>
            <td style="width: 601px">
                 &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    &nbsp;
    &nbsp;
  <table style="width:85%; margin-left:10%; text-align:left; height: 100px;">
        <tr>
            <td>

                <asp:GridView ID="GridView1" runat="server" style="font-size:20px" CssClass="mGrid" AutoGenerateColumns="False" >
                    <Columns>
                        <asp:BoundField DataField="retrievalId" HeaderText="Retrieval ID" />
                        <asp:BoundField DataField="itemCode" HeaderText="Item Code" />
                        <asp:BoundField DataField="departmentId" HeaderText="Department ID" />
                        <asp:BoundField DataField="needQuantity" HeaderText="Quantity Needed" />
                        <asp:BoundField DataField="actualQuantity" HeaderText="Actual Quantity" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("retrievalId")%>' />
                        <asp:LinkButton ID="lbView" runat="server" OnClick="lbView_Click">View</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

    <asp:Label ID="Label1" runat="server" Text="No Record!" Visible="False" style="font-size:20px" ></asp:Label>


    &nbsp;
                </td></tr></table>

</asp:Content>
