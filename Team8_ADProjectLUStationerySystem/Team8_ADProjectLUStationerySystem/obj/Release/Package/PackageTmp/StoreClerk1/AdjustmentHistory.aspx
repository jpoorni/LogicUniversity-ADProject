<%@ Page Title="" Language="C#" MasterPageFile="~/StoreClerk.Master" AutoEventWireup="true" CodeBehind="AdjustmentHistory.aspx.cs" Inherits="Team8_ADProjectLUStationerySystem.StoreClerk1.AdjustmentHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<table style="width:85%; margin-left:10%; text-align:left; height: 100px;">
        <tr>
            <td>
                <h3>ADJUSTMENT History</h3>
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
    <asp:GridView ID="AdjustmentGridView"  style="font-size:20px" CssClass="mGrid" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="adjustmentId" HeaderText="adjustmentId" />
            <asp:BoundField DataField="totalAmount" HeaderText="totalAmount" />
            <asp:BoundField DataField="status" HeaderText="status" />
            <asp:BoundField DataField="authorizedPerson" HeaderText="authorizedPerson" />
            <asp:BoundField DataField="employeeId" HeaderText="employeeId" />
            <asp:BoundField DataField="adjustDate" HeaderText="adjustDate" DataFormatString="{0:dd/MM/yyyy}"/>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("adjustmentId")%>'/>
                    <asp:LinkButton ID="lbView" runat="server" OnClick="lbView_Click">View</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView> </tr></td></table>
</asp:Content>
