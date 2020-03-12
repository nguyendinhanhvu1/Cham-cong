<%@ Page Title="Trang đăng nhập" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="divlogin">
    <%if (Request.Cookies["Account"] == null)
      { %>
        <table cellpadding="10"> 
            <tr style="width : 160px">
                <td style="font-weight:bolder; text-align :center">Tài khoản :</td>
                <td>
                    <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="font-weight:bolder; text-align :center">Mật khẩu :</td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:CheckBox ID="chkSave" runat="server" Font-Size="Small"
                        Text="Ghi nhớ" />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnLogin" runat="server" Text="Đăng nhập" Width="90px" 
                        onclick="btnLogin_Click" />
                </td>
                <td align="center">
                    <asp:Button ID="btnCancel" runat="server" Text="Làm lại" Width="90px" 
                        onclick="btnCancel_Click" />
                </td>
            </tr>
        </table>
        <%}
      else
      {%>
        <p> Chào mừng <%=Request.Cookies["Account"]["Username"].ToString()%> đã quay trở lại! </p>
        <%} %>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Label ID="lblStt" runat="server"></asp:Label> &nbsp;
    <asp:Button ID="btnlogout" runat="server" Text="Đăng xuất" onclick="btnlogout_Click"/>
</asp:Content>



