<%@ Page Title="Trang quản trị" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TrangAdmin.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Label ID="lblStt" runat="server"></asp:Label> &nbsp;
    <asp:Button ID="btnlogout" runat="server" Text="Đăng xuất" onclick="btnlogout_Click"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="divft">
        <p><asp:Label ID="lblAbout" runat="server" Text="Label"></asp:Label></p>
        <br />
        <div style="width:205px;float:left">
        <asp:ImageButton ID="imgNhanVien" runat="server" Height="205px" Width="205px" 
                onclick="imgNhanVien_Click" /><br />
            <p style="text-align: center"><asp:Label ID="lblNhanVien" runat="server" Text="Quản lý nhân viên" ></asp:Label></p>
        </div>        
    </div>
</asp:Content>

