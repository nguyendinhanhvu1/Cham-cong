<%@ Page Title="Chi tiết chấm công" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChiTietChamCong.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

    <asp:Label ID="lblStt" runat="server"></asp:Label> &nbsp;
    <asp:Button ID="btnlogout" runat="server" Text="Đăng xuất" onclick="btnlogout_Click"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p style="text-align:center;font-size:large;font-weight:bolder">Quản lý chấm công nhân viên</p>
    <br />
    <div id="divemp">
        <table>
            <tr>
                <td style="text-align:center">Mã nhân viên : </td>
                <td>
                    <asp:TextBox ID="txtInfo" runat="server"></asp:TextBox> </td>
            </tr>
            <tr>
                <td>Ngày tháng : &nbsp
                    <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Calendar ID="cdnDateTime" runat="server" BackColor="#FFFFCC" 
                        BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" 
                        Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" 
                        ShowGridLines="True" Width="220px" 
                        onselectionchanged="cdnDateTime_SelectionChanged">
                        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                        <OtherMonthDayStyle ForeColor="#CC9966" />
                        <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                        <SelectorStyle BackColor="#FFCC66" />
                        <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" 
                            ForeColor="#FFFFCC" />
                        <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                    </asp:Calendar>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                        <asp:Button ID="btnSearch" runat="server" Text="Tìm kiếm" 
                            onclick="btnSearch_Click" /></td>
                <td colspan="2" align="center">
                        <asp:Button ID="btnback" runat="server" Text="Quay lại" 
                            onclick="btnback_Click" /></td>
            </tr>
        </table>
        <br />
        <asp:Table ID="tblInfo" runat="server" BorderWidth="1px" >
            <asp:TableRow>
                <asp:TableCell>Mã nhân viên : </asp:TableCell>
                <asp:TableCell Width="170px"> 
                    <asp:Label ID="lblId" runat="server"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Họ tên :</asp:TableCell>
                <asp:TableCell Width="170px">
                    <asp:Label ID="lblName" runat="server"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Ngày :</asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblDate" runat="server"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Thông tin chấm công :</asp:TableCell>
                <asp:TableCell>
                    <asp:RadioButtonList ID="rdoCC" runat="server">
                        <asp:ListItem Value="1">Một ngày công</asp:ListItem>
                        <asp:ListItem Value="2">Không ngày công</asp:ListItem>
                        <asp:ListItem Value="3">Nửa ngày công</asp:ListItem>
                    </asp:RadioButtonList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" >
                    <p style="text-align:center">
                    <asp:Button ID="btnDelete" runat="server" Text="Xóa" Width="85px" onclick="btnDelete_Click"/>&nbsp
                    <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật" Width="85px" onclick="btnUpdate_Click"/></p>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </div>
</asp:Content>

