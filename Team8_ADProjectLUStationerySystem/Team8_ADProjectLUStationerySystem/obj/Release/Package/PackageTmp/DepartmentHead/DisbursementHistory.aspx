<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="DisbursementHistory.aspx.cs" Inherits="Team8_ADProjectLUStationerySystem.DepartmentHead.DisbursementHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
     <table style="width:80%; margin-left:10%; text-align:left; height: 100px;">
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
                <asp:TextBox ID="DateToTb" runat="server" CssClass="tb1" style="font-size:20px" TextMode="Date" AutoPostBack="True" OnTextChanged="DateToTb_TextChanged"></asp:TextBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td style="width: 162px">
                &nbsp;</td>
            <td class="modal-sm" style="width: 543px">
                
            </td>
            <td align="right"><asp:Button ID="SubmitBtn" runat="server" Text="Search" style="font-size:20px" OnClick="SubmitBtn_Click" /></td>
        </tr>
        </table>
    <p>
        <asp:Label ID="LabelMessage" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
    </p>
    <table style="width:85%; margin-left:10%; text-align:left; height: 231px;">
        <tr>
            <td>

                <asp:GridView ID="DisbursementListGridView" runat="server" CssClass="mGrid" style="font-size:20px" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="DisbursementListGridView_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="Disbursement ID">
                            <ItemTemplate>
                                 <asp:Label ID="Label3" runat="server" Text='<%# Eval("DisbursementId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Department Name">
                             <ItemTemplate>
                                 <asp:Label ID="Label1" runat="server" Text='<%# Eval("DepartmentName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Collection Date">
                             <ItemTemplate>
                                 <asp:Label ID="Label2" runat="server" Text='<%# Eval("CollectionDate","{0:M-dd-yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                             <ItemTemplate>
                                 <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Preview</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </td>
        </tr>
    </table>
    
</ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
