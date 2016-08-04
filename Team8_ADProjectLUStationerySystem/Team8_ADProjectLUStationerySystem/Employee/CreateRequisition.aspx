<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeMaster.Master" AutoEventWireup="true" CodeBehind="CreateRequisition.aspx.cs" Inherits="Team8_ADProjectLUStationerySystem.Employee.CreateRequisition" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  

        
      <table style="width:80%; margin-left:5%; text-align:left; height: 100px;">
        <tr>
            <td>
                <h3>Create New Requisition List</h3>
            </td>
        </tr>
      </table>
<p>&nbsp;</p> 
     <table style="width:80%; margin-left:5%; text-align:left; height: 200px;">
         <tr>
             <td style="width: 169px">
                 <asp:Label ID="Label5" runat="server" Text="Item Name: " style="font-size:20px"></asp:Label>
             </td>
              <td style="width: 495px">
                 <asp:DropDownList ID="DropDownList1" runat="server" CssClass="dropdown1">
                 </asp:DropDownList>
             </td>
              <td></td>
         </tr>
         <tr>
             <td style="width: 169px">
                 <asp:Label ID="Label6" runat="server" Text="Quantity: " style="font-size:20px"></asp:Label>
             </td>
             <td style="width: 495px">
                 <asp:TextBox ID="TextBox2" runat="server" CssClass="tb1" CausesValidation="True" TextMode="Number" ></asp:TextBox>
                 &nbsp;<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="Enter Quantity 1-50" ForeColor="#CC0000" MaximumValue="50" MinimumValue="1" Type="Integer" ValidationGroup="A"></asp:RangeValidator>
                 <br />
                 <br />
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="Enter Quanty 1-50" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                 <br />
             </td>
             <td align="right">                 <asp:Button ID="Button4" runat="server" Text="Add" CssClass="button4" Width="93px" OnClick="Button1_Click" ValidationGroup="A"  />
                 
                 &nbsp;</td>
         </tr>     
     </table>
    <table style="width:80%; margin-left:5%; text-align:left; height: 200px;">
         <tr>
             <td>
                  <asp:GridView ID="GridView1" runat="server"  CssClass="mGrid" style="font-size:20px" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                      <Columns>
                          
                          <asp:TemplateField HeaderText="Description">
                              <ItemTemplate>
                                  <asp:Label ID="Label2" runat="server" Text='<%# Eval("itemDescription") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Quantity">
                              <ItemTemplate>
                            
                                  <asp:TextBox ID="TextBox1" runat="server" TextMode="Number" Text='<%# Eval("qtyNeeded") %>'></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox1" ErrorMessage="*" ForeColor="Red" ValidationGroup="E"></asp:RequiredFieldValidator>
                                  <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="TextBox1" ErrorMessage="Enter Quantity 1-50" ForeColor="#CC0000" MaximumValue="50" MinimumValue="1" Type="Integer" ValidationGroup="E"></asp:RangeValidator>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:CommandField ShowEditButton="True" ValidationGroup="E" />
                          <asp:CommandField ShowDeleteButton="True" />
                      </Columns>
                  </asp:GridView>
             </td>
         </tr>  
        </table>
    <table style="width:80%; margin-left:5%; text-align:left; height: 50px;">
        <tr>
            <td style="width: 422px">

                

                <asp:CheckBox ID="CheckBox1" runat="server" Text="Self Collection"   style="font-size:20px" />

                

            </td>
            <td align="right">

                <asp:Button ID="Button2" runat="server" Text="Clear" CssClass="button4" OnClick="Button2_Click" Width="69px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button3" runat="server" Text="Submit" CssClass="button4" OnClick="Button3_Click"/>

            </td>
        </tr>

    </table>

    
    </asp:Content>
