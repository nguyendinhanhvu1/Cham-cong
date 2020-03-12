<%@ Page Title="Quản lý nhân viên" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="QuanLyNV.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Label ID="lblStt" runat="server"></asp:Label> &nbsp;
    <asp:Button ID="btnlogout" runat="server" Text="Đăng xuất" onclick="btnlogout_Click"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="divemp">
        <p style="text-align:center"><asp:Label ID="lblDetail" runat="server" 
                Text="Danh sách nhân viên" Font-Bold="True" Font-Size="Large"></asp:Label></p>
                <br />
                <div style="text-align:right">
                    <asp:ImageButton Height="50px" 
                        ImageUrl="~/Images/add.png" Width="50px" 
                        runat="server" ID="imgAdd" onclick="imgAdd_Click" />
                        <br />
                    <asp:GridView ID="grvEmployee" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                        GridLines="None" DataSourceID="ObjectDataSource"  
                        onselectedindexchanged="grvEmployee_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="EmployeeID" HeaderText="Mã nhân viên" 
                                SortExpression="EmployeeID" />
                            <asp:BoundField DataField="Name" HeaderText="Họ tên" SortExpression="Name" />
                            <asp:BoundField DataField="Room" HeaderText="Phòng Ban" SortExpression="Room" />
                            <asp:CommandField ButtonType="Button" SelectText="Xem" 
                                ShowSelectButton="True" />
                        </Columns>
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#000000" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#000000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSource" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetEmployee" 
            TypeName="EmployeeDB" DataObjectTypeName="Employee" 
            UpdateMethod="UpdateEmployee" DeleteMethod="DeleteEmployee"></asp:ObjectDataSource>
    </div>
</asp:Content>

