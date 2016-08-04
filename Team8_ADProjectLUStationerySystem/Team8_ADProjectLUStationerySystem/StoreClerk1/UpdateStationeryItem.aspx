<%@ Page Title="" Language="C#" MasterPageFile="~/StoreClerk.Master" AutoEventWireup="true" CodeFile="UpdateStationeryItem.aspx.cs" Inherits="Team8_ADProjectLUStationerySystem.StoreClerk1.UpdateStationeryItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      
    <table style="width:85%; margin-left:10%; text-align:left; height: 100px;">
        <tr>
            <td>
                <h3>Update Stationery Items</h3>
            </td>
        </tr>
      </table>
    <table style="width:85%; margin-left:10%; text-align:left; height: 350px;">
        <tr align="left">
            <td  style="width: 314px">
                
                <asp:Image ID="Image1" runat="server" />
                
            </td>
            <td>
                
                <asp:Label ID="ItemNoLbl" runat="server" style="font-size:20px"></asp:Label>
                <br />
                <asp:Label ID="ItemCatLbl" runat="server" style="font-size:20px"></asp:Label>
                <br />
                
                <br />
                <br />

                <br />

                <br />

            </td>
        </tr>
      
        <tr>
            <td style="width: 314px">
                <asp:Label ID="Label1" runat="server" Text="Item Name: " style="font-size:20px"></asp:Label>
            </td>
            <td>

                <asp:TextBox ID="TextBox1" runat="server" CssClass="tb1" AutoPostBack="True"></asp:TextBox>

            </td>
        </tr>
        &nbsp;&nbsp;&nbsp;
         <tr>
            <td style="width: 314px">
                 <asp:Label ID="Label5" runat="server" Text="Reorder Level: " style="font-size:20px"></asp:Label>
            </td>
            <td>

                <asp:TextBox ID="TextBox5" runat="server" CssClass="tb1" AutoPostBack="True"></asp:TextBox>

            </td>
        </tr>
                <tr>
            <td style="width: 314px">
                 <asp:Label ID="Label6" runat="server" Text="Reorder Quantity: " style="font-size:20px"></asp:Label>
            </td>
            <td>

                <asp:TextBox ID="TextBox6" runat="server" CssClass="tb1" AutoPostBack="True"></asp:TextBox>

            </td>
        </tr>
                <tr>
            <td style="width: 314px">
                 <asp:Label ID="Label7" runat="server" Text="UOM: " style="font-size:20px"></asp:Label>
            </td>
            <td>

                <asp:TextBox ID="TextBox7" runat="server" CssClass="tb1" AutoPostBack="True"></asp:TextBox>

            </td>
        </tr>
                <tr>
            <td style="width: 314px">
                 <asp:Label ID="Label8" runat="server" Text="Tender Price: " style="font-size:20px"></asp:Label>
            </td>
            <td>

                <asp:TextBox ID="TextBox8" runat="server" CssClass="tb1" AutoPostBack="True"></asp:TextBox>

                <br />

                <br />

            </td>
        </tr>
        <tr>
            <td style="width: 314px">
                 <asp:Label ID="Label2" runat="server" Text="Bin: " style="font-size:20px"></asp:Label>
            </td>
            <td>

                <asp:TextBox ID="TextBox2" runat="server" CssClass="tb1" AutoPostBack="True"></asp:TextBox>

                <br />

                <br />

            </td>
        </tr>
    </table>
    <table style="width:85%; margin-left:10%; text-align:left; height: 50px;">
    <tr align="right">
        <td >

            <asp:Button ID="Button1" runat="server" Text="Update" CssClass="button4" OnClick="Button1_Click"/>
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="Cancel" CssClass="button4" OnClick="Button2_Click"/>

        </td>
    </tr>
    </table>
</asp:Content>
