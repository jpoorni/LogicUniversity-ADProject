<%@ Page Title="" Language="C#" MasterPageFile="~/StoreSupervisorMaster.Master" AutoEventWireup="true" CodeBehind="RetrievalForm.aspx.cs" Inherits="Team8_ADProjectLUStationerySystem.StoreSupervisor.RetrievalForm" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <table style="width:85%; margin-left:10%; text-align:left; height: 100px;">
        <tr>
            <td>
      <asp:GridView ID="RetrievalGridView" runat="server" style="font-size:20px" CssClass="mGrid" OnRowDataBound="RetrievalGridView_RowDataBound" AutoGenerateColumns="False" Visible="False">
                    <Columns>
                <asp:BoundField DataField="itemCode" HeaderText="Item" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("itemCode")%>'/>
                        <asp:GridView ID="DepartmentGridView" runat="server" AutoGenerateColumns="False" >
                            <Columns>
                                <asp:BoundField DataField="departmentId" HeaderText="Department Id" />
                                <asp:BoundField DataField="needQuantity" HeaderText="Need Quantity" />
                                <asp:BoundField DataField="actualQuantity" HeaderText="Actual Quantity" />
                            </Columns>
                        </asp:GridView>
                        
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
                </asp:GridView>
                </td></tr><tr><td align ="right">
        <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click" CssClass="button4" style ="font-size:20px"/>
    <CR:CrystalReportViewer ID="RetrievalListReport" runat="server" AutoDataBind="true" />
                </td></tr></table>
</asp:Content>
