<%@ Page Title="Chi tiết nhân sự" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChiTietNV.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Label ID="lblStt" runat="server"></asp:Label> &nbsp;
    <asp:Button ID="btnlogout" runat="server" Text="Đăng xuất" onclick="btnlogout_Click"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p style="text-align:center;font-size:large;color:Red;font-weight:bolder;">
    <asp:Label ID="lblThongTin" runat="server" Text="Thông tin nhân viên"></asp:Label></p>
    <br />
    <div id="divemp">
        <table style="border : 1px solid Black">
            <tr>
                <td style="width:100px;text-align:center">Mã Nhân Viên :</td>
                <td style="width:250px;text-align:center">
                    <asp:Label ID="lblId" runat="server" Text=""></asp:Label> </td>
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
                        ControlToValidate="txtName" ErrorMessage="Dữ liệu nhập vào không hợp lệ" 
                        ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width:100px;text-align:center">Phòng Ban : </td>
                <td style="width:250px;text-align:center">
                    <asp:DropDownList ID="ddlPhongBan" runat="server" Width="200px" 
                        DataSourceID="SqlDataSource" DataTextField="TEN_PHONG">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:Assignment_ducttpt00033 %>" 
                        SelectCommand="SELECT [TEN_PHONG] FROM [PHONG_BAN]"></asp:SqlDataSource>
                    <asp:RequiredFieldValidator ID="reqValRoom" runat="server" 
                        ControlToValidate="ddlPhongBan" ErrorMessage="Dữ liệu nhập không hợp lệ" 
                        ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center;width:350px">
                    <asp:Button ID="btnUpdate" runat="server" Text="Sửa" Width="60px" 
                        onclick="btnUpdate_Click"/> &nbsp
                    <asp:Button ID="btnDelete" runat="server" Text="Xóa" Width="60px" 
                        onclick="btnDelete_Click" />&nbsp
                    <asp:Button ID="btnBack" runat="server" Text="Quay lại" Width="60px" 
                        onclick="btnBack_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

