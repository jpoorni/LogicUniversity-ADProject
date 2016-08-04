<%@ Page Title="" Language="C#" MasterPageFile="~/StoreManagerMaster.Master" AutoEventWireup="true" CodeBehind="OrderTrendAnalysisReport.aspx.cs" Inherits="Team8_ADProjectLUStationerySystem.StoreManager.OrderTrendAnalysisReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <script type="text/javascript" >
        function printpage()
        {
            var getpanel = document.getElementById("<%= print.ClientID %>");
            var MainWindow = window.open("", "", "height = 500, width = 800");
            MainWindow.document.write("<html><head><title>PrintPage</title>");
            MainWindow.document.write("<head><body>");
            MainWindow.document.write(getpanel.innerHTML);
            MainWindow.document.write("</body></html>");
            MainWindow.document.close();
            setTimeout(function () {
                MainWindow.print();
            }, 500);
            return false;
            }
    </script>

      <script type ="text/css">
       .detailsView {
      text-align: center;
        margin: 0 auto;
    }

        .parent {
        display:inline-block;
        float: center;
}
.child {
        display:inline-block;
        float:right;
  
}
        </script>

    <table style="width:85%; margin-left:5%; text-align:left; height:80px;">
                    <tr><td>
                        <h3>Order Trend Analysis Report</h3>
                        </td></tr>
                </table>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

             <div><h5>&nbsp;</h5></div>
             <table style="width:85%; margin-left:5%; text-align:left; height:200px;">
                    
                <tr>
                    <td>
                       
    <div id="detailsView" visible="true" runat="server" style="width:78%; margin-left:10%; float:left; display: inline-block;background-color: #d3d3d3;border-radius:12px;height:140px; ">
        <table style="width:130px; margin-left:8%; text-align:left; height:100px;">
            <tr align ="center"><td> <div id ="parent">
        
            
                       
                            <asp:RadioButtonList ID="rdoyear1" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table" style="font-size:20px"/></div>  </td></tr><tr align ="center"><td>
                            <asp:DropDownList ID="ddlmth1" runat="server" CssClass="dropdown3" style="font-size:15px"></asp:DropDownList>   </div> </td></tr></table>
                                                                                  
               <td style="width: 10px">&nbsp;&nbsp;&nbsp;</td>
                    <td>
                    <div id="Div1" visible="true" runat="server" style="width:78%; margin-left:10%; float:left; display: inline-block;background-color: #d3d3d3;border-radius:12px;height:140px; ">
        <table style="width:130px; margin-left:8%; text-align:left; height:100px;"><tr align="center"><td>
        
                            <asp:RadioButtonList ID="rdoyear2" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table" style="font-size:20px"/>        </td></tr><tr align ="center"><td>                       
                            <asp:DropDownList ID="ddlmth2" runat="server" CssClass="dropdown3" style="font-size:15px"></asp:DropDownList></td></tr></table> </div> </td>
                        </div>
                      
                    </td><td style="width: 16px">&nbsp;&nbsp;&nbsp;</td>
                    <td> <div id="Div2" visible="true" runat="server" style="width:78%; margin-left:10%; float:left; display: inline-block;background-color: #d3d3d3;border-radius:12px;height:140px; ">
        <table style="width:130px; margin-left:8%; text-align:left; height:100px;"><tr align="center"><td>

                            <asp:RadioButtonList ID="rdoyear3" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table" style="font-size:20px"/>           </td></tr><tr align ="center"><td>                             
                            <asp:DropDownList ID="ddlmth3" runat="server" CssClass="dropdown3" style="font-size:15px"></asp:DropDownList></td></tr></table> </div> 
                        
                    </td>
               </table>    <tr align="center">
                    <td colspan="3" >
                         <table style="width:85%; margin-left:5%; text-align:left; height:200px;">
                    
                <tr>
                    <td >
                         
                               <asp:Label runat="server" ID="lable" Text="Stationery Item:" style="font-size:20px"></asp:Label>

                                        </td><td>  <asp:DropDownList ID="ddlItem" runat="server" style="font-size:20px" CssClass="dropdown1"></asp:DropDownList>
                                                                                                           
                                                                                                            </td><td align ="right">
                            <asp:Button ID="btnGenerate" runat="server" Text="Generate" OnClick="btnGenerate_Click" CssClass="button4" style="font-size:20px"/></td></tr>
                        
                     
                    </td>
                </tr>
                <tr>
                    <td>
                        
                            <asp:Label ID="lable0" runat="server" style="font-size:20px" Text="Show By:"></asp:Label></td><td>
                        
                                    <asp:RadioButtonList ID="shownby" runat="server" ViewStateMode="Disabled" RepeatDirection="Horizontal"  style="font-size:20px" Height="21px" Width="299px">
                                        <asp:ListItem Text="Quantity" Value="quantity" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Price" Value="price"></asp:ListItem>                                        
                                    </asp:RadioButtonList></td>
                             
                     
                    </td>
                </tr>
             </table>
            <asp:Button ID="Button1" runat="server" Text="Print" OnClientClick="return printpage()" CssClass="button4" style="font-size:20px"/>
            <asp:UpdatePanel ID="print" runat="server">
                <ContentTemplate>


            <asp:Label ID="lblStatus" runat="server" ForeColor="Red" style="font-size:20px"></asp:Label>
            <table align="center">
                    <tr align ="center">
                        <td >
                            <strong><asp:Label ID="label1" runat="server" ForeColor="#cc33ff" style="font-size:20px"></asp:Label></strong>
                        </td>
                        <td>
                            <asp:Label ID="label2" runat="server" style="font-size:20px"></asp:Label>
                            
                        </td>
                    </tr>
                </table>
            
            <asp:Panel ID="PanelQuantity" runat="server">
                <table style="width:85%; margin-left:5%; text-align:left; height:300px;">
                    
                <tr><td>
                <asp:GridView ID="GridViewQuantity" runat="server" AutoGenerateColumns="False" CssClass="mGrid">
                    <Columns>
                        <asp:TemplateField HeaderText="S/No">
                                <ItemTemplate>
                                    <%#: ((GridViewRow)Container).RowIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                        <asp:BoundField DataField="QData" HeaderText="Stationery Information :" ReadOnly="True"/>
                        <asp:BoundField DataField="Quantity" HeaderText="Total Ordered Quantity" ReadOnly="True"/>
                    </Columns>
                </asp:GridView>    </td></tr></table><table style="width:85%; margin-left:5%; text-align:left; height:300px;">
                    
                <tr><td>            
                    <asp:Chart ID="ChartQuantity" runat="server" Width="800px">
                        <Series>
                            
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartAreaQuantity"></asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
            </asp:Panel></td></tr></table> <table style="width:85%; margin-left:5%; text-align:left; height:200px;">
                    
                <tr><td>
            <asp:Panel ID="PanelPrice" runat="server">
                <asp:GridView ID="GridViewPrice" runat="server" AutoGenerateColumns="false" CssClass="mGrid">
                    <Columns>
                        <asp:TemplateField HeaderText="S NO">
                                <ItemTemplate>
                                    <%#: ((GridViewRow)Container).RowIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                        <asp:BoundField DataField="PData" HeaderText="Stationery Information :" ReadOnly="True"/>
                        <asp:BoundField DataField="Price" HeaderText="Total Ordered Price" ReadOnly="True" DataFormatString="{0:c}"/>
                    </Columns>
                </asp:GridView>
                    <asp:Chart ID="ChartPrice" runat="server" Width="500px">
                        <Series>                            
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartAreaPrice"></asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
            </asp:Panel></td></tr></table>
        </ContentTemplate>
    </asp:UpdatePanel>
                    </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
