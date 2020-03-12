<%@ Page Title="Thêm nhân viên" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ThemNV.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Label ID="lblStt" runat="server"></asp:Label> &nbsp;
    <asp:Button ID="btnlogout" runat="server" Text="Đăng xuất" onclick="btnlogout_Click"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p style="text-align:center;font-size:large;font-weight:bolder;color:Red">Thêm mới nhân viên</p>
    <div id="divemp">
        <table style="border : 1px solid Black">
            <tr>
                <td style="width:100px;text-align:center">Mã Nhân Viên :</td>
                <td style="width:250px;text-align:center">
                    <asp:TextBox ID="txtId" runat="server" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqValId" runat="server" 
                        ControlToValidate="txtId" ErrorMessage="Mã nhân viên không hợp lệ" 
                        ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width:100px;text-align:center">Họ và tên :</td>
                <td style="width:250px;text-align:center">
                    <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqValName" runat="server" 
                        ControlToValidate="txtName" ErrorMessage="Dữ liệu nhập vào không hợp lệ" 
                        ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width:100px;text-align:center">Địa chỉ :</td>
                <td style="width:250px;text-align:center">
                    <asp:TextBox ID="txtAddress" runat="server" Height="60px" TextMode="MultiLine" 
                        Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqValAddress" runat="server" 
                        ControlToValidate="txtAddress" ErrorMessage="Địa chỉ không hợp lệ" 
                        ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width:100px;text-align:center">Số điện thoại :</td>
                <td style="width:250px;text-align:center">
                <asp:TextBox ID="txtPhone" runat="server" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqValPhone" runat="server" 
                        ControlToValidate="txtPhone" ErrorMessage="Dữ liệu nhập vào không hợp lệ" 
                        ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width:100px;text-align:center">Phòng Ban : </td>
                <td style="width:250px;text-align:center">
                    <asp:DropDownList ID="ddlPhongBan" runat="server" DataSourceID="SqlDataSource" 
                        DataTextField="TEN_PHONG">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:Assignment_ducttpt00033 %>" 
                        SelectCommand="SELECT [TEN_PHONG] FROM [PHONG_BAN] ORDER BY [TEN_PHONG]">
                    </asp:SqlDataSource>
                    <asp:RequiredFieldValidator ID="reqValRoom" runat="server" 
                        ControlToValidate="ddlPhongBan" ErrorMessage="Dữ liệu không hợp lệ" 
                        ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center;width:350px">
                    <asp:Button ID="btnInsert" runat="server" Text="Thêm mới" Width="80px" 
                        onclick="btnInsert_Click" /> &nbsp
                    <asp:Button ID="btnCancel" runat="server" Text="Quay lại" Width="80px" 
                        onclick="btnCancel_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

