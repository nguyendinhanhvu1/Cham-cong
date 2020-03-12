<%@ Page Title="Đăng nhập thất bại" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LoiDangNhap.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%if (Request.Cookies["Account"] == null)
  { %>
    <div style="text-align :center; font-size : large; margin-top : 10px">
        <p>Đăng nhập thất bại!</p>
        <p>Tài khoản hoặc mật khẩu không đúng!</p>
        <p>Vui lòng kiểm tra lại!</p>
        <p>Chờ 3s để quay lại trang đăng nhập</p>
    </div>
    <%}
  else
  {%>
    <p>Truy cập không hợp lệ! chờ 3s để quay lại trang đăng nhập</p>
    <%}%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

