<%@ Page Title="" Language="C#" MasterPageFile="~/StoreSupervisorMaster.Master" AutoEventWireup="true" CodeBehind="DisbursementHistory.aspx.cs" Inherits="Team8_ADProjectLUStationerySystem.StoreSupervisor.DisbursementHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <table style="width:85%; margin-left:10%; text-align:left; height: 100px;">
        <tr>
            <td>
                <h3>Disbursement History</h3>
            </td>
        </tr>
      </table>

    <table style="width:85%; margin-left:10%; text-align:left; height: 231px;">
        <tr>
            <td style="width: 162px">
                
                <asp:Label ID="Label4" runat="server" Text="Date From:" style="font-size:20px" ></asp:Label>
                
            </td>
            <td class="modal-sm" style="width: 543px">

                <asp:TextBox ID="DateFromTb" runat="server" CssClass="tb1" style="font-size:20px" TextMode="Date"></asp:TextBox>

            </td>
            <td>

            </td>
        </tr>
        <tr>
            <td style="width: 162px">
                <asp:Label ID="Label5" runat="server" Text="Date To:" style="font-size:20px"></asp:Label>
            </td>
            <td class="modal-sm" style="width: 543px">
                <asp:TextBox ID="DateToTb" runat="server" CssClass="tb1" style="font-size:20px" TextMode="Date"></asp:TextBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td style="width: 162px">

            </td>
            <td style="width: 543px"></td>
            <td>
                <asp:Button ID="SubmitBtn" runat="server" Text="Submit" style="font-size:20px" CssClass="button4" OnClick="SubmitBtn_Click"/>
            </td>
        </tr>
        </table>
      <table style="width:85%; margin-left:10%; text-align:left; height: 100px;">
        <tr>
            <td>
    <asp:GridView ID="DisbursementGridView" AllowPaging="True" style="font-size:20px" CssClass="mGrid" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="disbursementId" HeaderText="Disbursement ID" />
            <asp:BoundField DataField="departmentCode" HeaderText="Department Code" />
            <asp:BoundField DataField="employeeId" HeaderText="Employee ID" />
            <asp:BoundField DataField="collectionId" HeaderText="Collection ID" />
            <asp:BoundField DataField="collectionDate" HeaderText="Collection Date" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="status" HeaderText="Status" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("disbursementId")%>'/>
                    <asp:LinkButton ID="lbView" runat="server" OnClick="lbView_Click">View</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
                 </tr></td></table>
</asp:Content>
