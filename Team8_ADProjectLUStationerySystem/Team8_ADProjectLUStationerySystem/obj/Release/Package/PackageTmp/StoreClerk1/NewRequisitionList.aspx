<%@ Page Title="" Language="C#" MasterPageFile="~/StoreClerk.Master" AutoEventWireup="true" CodeBehind="NewRequisitionList.aspx.cs" Inherits="Team8_ADProjectLUStationerySystem.StoreClerk1.NewRequisitionList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function divexpandcollapse(divname) {
            var div = document.getElementById(divname);
            var img = document.getElementById('img' + divname);
            if (div.style.display == "none") {
                div.style.display = "inline";
                img.src = "../images/minus.png";
            } else {
                div.style.display = "none";
                img.src = "../images/plus.png";
            }
        }
    </script>


      <table style="width:80%; margin-left:5%; text-align:left; height: 100px;">
        <tr>
            <td>
                <h3>New Requisition List</h3>
            </td>
        </tr>
      </table>

    <table style="width:85%; margin-left:5%; text-align:left; height: 231px;">
        
        <tr>
            <td width ="40%">


                <br />
                <asp:GridView ID="NewRequisitionGridView"  runat="server" DataKeyNames="requisitionId" CssClass="mGrid"  
                AutoGenerateColumns="False" OnRowDataBound="NewRequisitionGridView_RowDataBound"
                GridLines="None" style="font-size:20px" Visible="False" AllowPaging="True">
                    <HeaderStyle BackColor="#2E8B57" Font-Bold="true" ForeColor="White" />
        <RowStyle BackColor="#E1E1E1" />
        <AlternatingRowStyle BackColor="White" />
        <HeaderStyle BackColor="#2E8B57" Font-Bold="true" ForeColor="White" />
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="20px">
                            <ItemTemplate>
                        <a href="JavaScript:divexpandcollapse('div<%# Eval("requisitionId") %>');">
                            <img id="imgdiv<%# Eval("requisitionId") %>" width:"9px" border="0" src="../images/plus.png" />
                            </a>
                    </ItemTemplate>
                            <HeaderStyle Width="10px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("requisitionId")%>' />
                                <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" />
                            </ItemTemplate>
                            <HeaderStyle Width="10px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="requisitionId" HeaderText="Requisition ID" >
                        <ControlStyle Width="15px" />
                        <HeaderStyle Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="departmentCode" HeaderText="Department Code" >
                        <HeaderStyle Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="employeeId" HeaderText="Employee ID" >
                        <HeaderStyle Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="requisitionDate" HeaderText="Requisition Date" DataFormatString="{0:MM/dd/yyyy}" >
                        <HeaderStyle Width="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="selfCollection" HeaderText="Self-Collection" >
                        <HeaderStyle Width="12px" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <tr>
                            <td colspan="100%">
                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("requisitionId")%>'/>
                                <div id="div<%# Eval("requisitionId") %>" style="display: none; position: relative; left: 15px; overflow: auto">
                                <asp:GridView ID="DetailsGridView" runat="server" AutoGenerateColumns="False" CssClass="mGrid" style="font-size:20px" BorderStyle="Double"  
                                    BorderColor="#df5015" GridLines="None" Width="600px">
                                    <HeaderStyle BackColor="#df5015" Font-Bold="true" ForeColor="White" />
                                    <RowStyle BackColor="#E1E1E1" />
                                    <AlternatingRowStyle BackColor="White" />
                                    <HeaderStyle BackColor="#df5015" Font-Bold="true" ForeColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="itemCode" HeaderText="Item Code" />
                                        <asp:BoundField DataField="qtyNeeded" HeaderText="Quantity Needed" />
                                        <asp:BoundField DataField="qtyOutstaning" HeaderText="Outstanding Quantity" />
                                        <asp:BoundField DataField="outstandingField" HeaderText="Outstanding?" />
                                    </Columns>
                                </asp:GridView>
                                    </div>
                             <div style="height:20px"></div>
                           </td>
                        </tr>
                            </ItemTemplate>
                            <HeaderStyle Width="25px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <asp:Label ID="Label1" runat="server" Text="No requisitions to process." Visible="False" style="font-size:20px"></asp:Label>


                <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged1" Text="Select All" Visible="False" />
                <br />


                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;


                <asp:Button ID="Process" runat="server" OnClick="Process_Click" Text="Process" Visible="False" style="font-size:20px" CssClass="button4"/>


            </td>
            </tr>
        </table>
</asp:Content>
