<%@ Page Title="Thống kê chấm công" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ThongKe.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Label ID="lblStt" runat="server"></asp:Label> &nbsp;
    <asp:Button ID="btnlogout" runat="server" Text="Đăng xuất" onclick="btnlogout_Click"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="divemp">
     <p style="text-align:center;color:Red;font-size:large;font-weight:bolder">Thống kê chấm công</p>
     <br />
     <table>
        <tr>
            <td style="width:100px;text-align:center">Tháng : </td>
            <td>
                <asp:DropDownList ID="ddlMonth" runat="server">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center">
                <asp:Button ID="btnSearch" runat="server" Text="Thống kê" 
                    onclick="btnSearch_Click" />
            </td>
        </tr>
     </table>
     <br />
        <asp:GridView ID="grvThongKe" runat="server">
        </asp:GridView>
        <br />
        <asp:Button ID="btnBack" runat="server" Text="Quay lại" onclick="btnBack_Click" />
    </div>
</asp:Content>

