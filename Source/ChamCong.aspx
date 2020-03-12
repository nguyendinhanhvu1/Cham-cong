<%@ Page Title="Trang chấm công" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChamCong.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Label ID="lblStt" runat="server"></asp:Label> &nbsp;
    <asp:Button ID="btnlogout" runat="server" Text="Đăng xuất" onclick="btnlogout_Click"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<p style="text-align:center;color:Red;font-size:large;font-weight:bolder">
    <asp:Label ID="lblDetail" runat="server" ></asp:Label></p>
    <asp:GridView ID="grvRoll" runat="server" AutoGenerateColumns="False" 
        DataSourceID="ObjectDataSource">
        <Columns>
            <asp:BoundField DataField="EmployeeID" HeaderText="Mã Nhân Viên" 
                SortExpression="EmployeeID" />
            <asp:BoundField DataField="Name" HeaderText="Họ Tên" SortExpression="Name" />
            <asp:TemplateField HeaderText="Chấm Công">
                <ItemTemplate>
                    <asp:RadioButtonList ID="rdoListChamCong" runat="server">
                        <asp:ListItem Selected="True" Value="2">Có mặt</asp:ListItem>
                        <asp:ListItem Value="3">Vắng mặt</asp:ListItem>
                    </asp:RadioButtonList>
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetEmployee" 
        TypeName="Manage">
        <SelectParameters>
            <asp:SessionParameter Name="room" SessionField="Room" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <p style="text-align:center">
        <asp:Button ID="btnSave" runat="server" Text="Lưu" Width="100px" 
            onclick="btnSave_Click" /></p>
</asp:Content>

