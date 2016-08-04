<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeList.aspx.cs" Inherits="Team8_ADProjectLUStationerySystem.DepartmentHead.EmployeeList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">





    &nbsp;<table style="width:80%; margin-left:5%; text-align:left; height: 100px;">
        <tr>
            <td>
                <h3>Employee List</h3>
            </td>
        </tr>
      </table>
<p>&nbsp;</p> 
     <table style="width:80%; margin-left:5%; text-align:left; height: 231px;">
        <tr>
            <td>
               
                <asp:GridView ID="GridView1" runat="server" CssClass="mGrid" style="font-size:20px"  AutoGenerateColumns="False" >
                    <Columns>
                        <asp:BoundField DataField="employeeName" HeaderText="Employee Name" />
                        <asp:BoundField DataField="phoneNumber" HeaderText="Contact Number" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HiddenField ID="HiddenField1" runat="server"  Value='<%# Eval("employeeId") %>'/>
                                <asp:LinkButton ID="delegate"  runat="server" OnClick="delegate_Click" >Delegate</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
               
            </td>
        </tr>
      </table>
</asp:Content>
