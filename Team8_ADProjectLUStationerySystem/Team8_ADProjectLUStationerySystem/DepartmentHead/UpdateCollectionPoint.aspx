<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateCollectionPoint.aspx.cs" Inherits="Team8_ADProjectLUStationerySystem.DepartmentHead.UpdateCollectionPoint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        function cp() {
            alert("'Change successfully'");
                window.location = "UpdateCollectionPoint.aspx";
        }
    </script>

    <table style="width:80%; margin-left:5%; text-align:left; height: 100px;">
        <tr>
            <td>
                <h3>Update Collection Point</h3>
            </td>
        </tr>
    </table>
     <table style="width:80%; margin-left:5%; text-align:left; height: 231px;">
         <tr>
             <td class="modal-sm" style="width: 298px">
                 <asp:Label ID="collectionPointLB" runat="server" Text="Cuurent Collection Point: " style ="font-size:20px"></asp:Label>
             </td>
             <td>
                 <asp:Label ID="CollectionPointTb" runat="server" style ="font-size:20px"></asp:Label>
             </td>
         </tr>
         <tr>
             <td class="modal-sm" style="width: 298px">
                 <asp:Label ID="repNameLB" runat="server" Text="Current Representative Name: " style ="font-size:20px" ></asp:Label>
             </td>
             <td>
                 <asp:Label ID="RepTb" runat="server" style ="font-size:20px" ></asp:Label>
             </td>
         </tr>
         </table>
    <table style="width:80%; margin-left:5%; text-align:left; height: 231px;">
        <tr>
            <td class="modal-sm" style="width: 295px">
                 <asp:Label ID="newCollectionPointLB" runat="server" Text="New Collection Point: " style ="font-size:20px" ></asp:Label>
             </td>
            <td >
    <asp:DropDownList ID="ddlCP" CssClass="dropdown1" runat="server" style="text-align: left;font-size:20px">
    </asp:DropDownList>
            </td>
        </tr>
        </table>
    <table style="width:80%; margin-left:5%; text-align:left; height: 231px;">
        <tr>
            <td style="width: 296px">
                 <asp:Label ID="newCollectionRepName" runat="server" Text="New Representative Name: " style ="font-size:20px" ></asp:Label>
            &nbsp;&nbsp;
                </td>
            <td>
    <asp:DropDownList ID="RepresentativeNameDropDown" CssClass="dropdown1" runat="server" style="text-align: left;font-size:20px">
    </asp:DropDownList>
                </td>

        </tr>
        <tr>
            <td style="width: 296px">
               
            </td>
            <td align ="right"> <asp:Button ID="UpdateBtn" runat="server" Text="Submit" CssClass="button4" style ="font-size:20px" OnClick="UpdateBtn_Click"/>
    &nbsp;
    <asp:Button ID="CancelBtn" runat="server" Text="Cancel" CssClass="button4" style ="font-size:20px" OnClick="CancelBtn_Click"/></td>
        </tr>
    </table>








</asp:Content>
