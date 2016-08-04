<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DelegateAuthorisedPerson.aspx.cs" Inherits="Team8_ADProjectLUStationerySystem.DepartmentHead.DelegateAuthorisedPerson" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function undele() {
            if (confirm('Alert". End Delegatation successfully" ?'))
                window.location = "ApproveRequisitions.aspx";
        }
    </script>

    <script type="text/javascript">
        function dele() {
            if (confirm('Alert". Delegatation successfully" ?'))
                window.location = "ApproveRequisitions.aspx";
        }
    </script>
    <%-- <h3>Delegate Authorised Person</h3>--%>

    <table style="width:80%; margin-left:5%; text-align:left; height: 100px;">
        <tr>
            <td>
                <h3>Delegate Authorised Person</h3>
                <p></p>
            </td>
        </tr>
      </table>

    <div>
    <table style="width:80%; margin-left:5%; text-align:left; height: 231px;">
        <tr>
            <td>

                 <asp:Label ID="Label4" runat="server" Text="Employee Name: " style="font-size:20px"></asp:Label>

            </td>
            <td>

                 <asp:Label ID="EmployeeNameLb" runat="server"  style="font-size:20px"></asp:Label>

            </td>
        </tr>
        <tr>
            <td style="width:40%">
                 <asp:Label ID="Label2" runat="server" Text="Start Date: " style="font-size:20px"></asp:Label>
                &nbsp;</td>
            <td style="width:60%">
                <asp:TextBox ID="StartDateTb" runat="server" CssClass="tb1" style="font-size:20px" TextMode="Date"></asp:TextBox>
                <asp:TextBox ID="StartDateTb2" runat="server" CssClass="tb1" style="font-size:20px" Enabled="False"></asp:TextBox>
                     &nbsp;</td>
        </tr>
        <tr>
            <td style="width:40%">
                <asp:Label ID="Label3" runat="server" Text="End Date: " style="font-size:20px"></asp:Label>
                &nbsp;</td>
            <td style="width:60%">  <asp:TextBox ID="EndDateTb" runat="server" CssClass="tb1" style="font-size:20px" TextMode="Date"></asp:TextBox>
                <asp:TextBox ID="EndDateTb2" runat="server" CssClass="tb1" style="font-size:20px" Enabled="False"></asp:TextBox>
        &nbsp;</td>
        </tr>
        <tr> 
            <td style="width:40%">
                <asp:Label ID="Label1" runat="server" Text="Reason to delegate:" style="font-size:20px"></asp:Label>
               </td>
            <td style="width:60%"> <asp:DropDownList ID="ReasonDropDown" runat="server" CssClass="dropdown1" style="font-size:20px">
                <asp:ListItem>Medical Reasons</asp:ListItem>
                <asp:ListItem>Travel</asp:ListItem>
                <asp:ListItem>Business Trip</asp:ListItem>
                <asp:ListItem>Annual Leave</asp:ListItem>
        </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width:40%">
                &nbsp;</td>
            <td style="width:60%">
                <asp:Label ID="MessageLb" runat="server"  style="font-size:20px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:40%">
                &nbsp;</td>
            <td style="width:60%">
        <asp:Button ID="EndDelegationBtn" runat="server" Text="End delegation" CssClass="button4" style ="font-size:20px" OnClick="EndDelegationBtn_Click"/>
        &nbsp;
        <asp:Button ID="AssignBtn" runat="server" Text="Assign" CssClass="button4" style ="font-size:20px" OnClick="AssignBtn_Click"/>
        &nbsp;
        <asp:Button ID="CancelBtn" runat="server" Text="Cancel" CssClass="button4" style ="font-size:20px" OnClick="CancelBtn_Click"/>
            </td>
        </tr>
    </table>
         </div>
   <br />
   

    
    

</asp:Content>
