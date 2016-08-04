<%@ Page Title="" Language="C#" MasterPageFile="~/StoreClerk.Master" AutoEventWireup="true" CodeBehind="RetrievalList.aspx.cs" Inherits="Team8_ADProjectLUStationerySystem.StoreClerk1.RetrievalList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<table style="width:85%; margin-left:10%; text-align:left; height: 100px;">
        <tr>
            <td>
                <h3>Retrieval List</h3>
            </td>
        </tr>
      </table>
     <table style="width:85%; margin-left:10%; text-align:left; height: 200px;">
         
          <tr>
             <td style="width: 40%">
                 <asp:Label ID="Label2" runat="server" Text="Retrieval No: " style="font-size:20px"></asp:Label>
             </td>
             <td>
                 <asp:DropDownList ID="DropDownList1" runat="server" CssClass="dropdown1" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                 </asp:DropDownList>
             </td>
              <td>
                   
              </td>
         </tr>
         <tr>
             <td style="width: 40%">
                 <asp:Label ID="Label3" runat="server" Text="Status: " style="font-size:20px"></asp:Label>
             </td>
             <td>
                  <asp:Label ID="Label4" runat="server" Text="" style="font-size:20px"></asp:Label>
             </td>
              <td>
                   
              </td>
         </tr>
         <tr>
             <td style="width: 40%">
                 <asp:Label ID="Label1" runat="server" Text="Choose Action: " style="font-size:20px"></asp:Label>
             </td>
             <td>
                 <asp:RadioButton ID="RadioButton1" runat="server" Text="View" style="font-size:20px" GroupName="Action" Enabled="False" />
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:RadioButton ID="RadioButton2" runat="server" Text="Update" style="font-size:20px"  GroupName="Action" Enabled="False"/>
             </td>
             <td>
                 <asp:Button ID="btnProcess" runat="server" Text="Next" CssClass="Button" OnClick="btnProcess_Click" style="font-size:20px" />
             </td>
         </tr>
         <tr>
             <td style="width: 40%">
                 <asp:LinkButton ID="lbNew" runat="server" OnClick="lbNew_Click" style="font-size:20px" >Generate New Retrieval</asp:LinkButton>
             </td>
             <td>
             </td>
             <td>
             </td>
         </tr>
       
         </table>
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

    <asp:GridView ID="UpdateGridView" runat="server" style="font-size:20px" CssClass="mGrid" OnRowDataBound="UpdateGridView_RowDataBound" AutoGenerateColumns="False" Visible="False">
                    <Columns>
                <asp:BoundField DataField="itemCode" HeaderText="Item" />
                    <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("itemCode")%>'/>
                        <asp:GridView ID="DepartmentGridView" runat="server" AutoGenerateColumns="False" >
                            <Columns>
                                <asp:BoundField DataField="departmentId" HeaderText="Department Id" />
                                <asp:BoundField DataField="needQuantity" HeaderText="Need Quantity" />
                                <asp:TemplateField HeaderText="Actual Quantity">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("retrievalId")%>'/>
                                        <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("itemCode")%>'/>
                                        <asp:HiddenField ID="HiddenField3" runat="server" Value='<%# Eval("departmentId")%>'/>
                                        <asp:HiddenField ID="HiddenField4" runat="server" Value='<%# Eval("needQuantity")%>'/>
                                        <asp:HiddenField ID="HiddenField5" runat="server" Value='<%# Eval("actualQuantity")%>'/>
                                        <asp:TextBox ID="tbActqty" runat="server" Text='<%# Eval("actualQuantity")%>'
                                            OnTextChanged="tbActqty_TextChanged" AutoPostBack="True"></asp:TextBox>
                                        <asp:LinkButton ID="lbSave" runat="server" OnClick="lbSave_Click">Save</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
                </asp:GridView>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BtnSubmit" runat="server" Text="Confirm" OnClick="BtnSubmit_Click" Visible="False" style="font-size:20px" CssClass="button4" />
                 &nbsp;&nbsp;
                 <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click" Visible="False" style="font-size:20px" CssClass="button4"/>
                </td></tr></table>

</asp:Content>
