<%@ Page Title="Quản lý chấm công" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="QuanLyChamCong.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Label ID="lblStt" runat="server"></asp:Label> &nbsp; &nbsp;
    <asp:Button ID="btnlogout" runat="server" Text="Đăng xuất" onclick="btnlogout_Click"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="features">
        <p style="text-align:center"><asp:Label ID="lblDetail" runat="server"></asp:Label></p>
        <br />
        <div style="width:205px;float:left">
            <asp:ImageButton ID="imgChamCong" runat="server" Height="205px" Width="205px" 
                ImageUrl="~/Images/QLCC.jpg" onclick="imgChamCong_Click" /><br />
            <p style="text-align: center"><asp:Label ID="lblChamCong" runat="server" Text="Quản lý chấm công" ></asp:Label></p>
        </div>
        <div style="width:205px;float:left;margin-left:20px">
            <asp:ImageButton ID="imgThongKe" runat="server" Height="205px" Width="205px" 
                ImageUrl="~/Images/TK.JPG" onclick="imgThongKe_Click" /><br />
            <p style="text-align: center"><asp:Label ID="lblThongKe" runat="server" Text="Thống kê" ></asp:Label></p>
        </div>
    </div>
</asp:Content>

