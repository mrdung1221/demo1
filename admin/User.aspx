<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="admin_User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .style5
        {
            text-align: left;
            height: 19px;
        }
        .style3
        {
            width: 150px;
            height: 19px;
            text-align: right;
        }
        .style4
        {
            height: 19px;
        }
        .style6
        {
            width: 150px;
            text-align: right;
            height: 22px;
        }
        .style7
        {
            height: 22px;
        }
        .style2
        {
            width: 150px;
            text-align: right;
        }
        .style8
        {
            width: 150px;
            text-align: right;
            height: 21px;
        }
        .style9
        {
            height: 21px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        &nbsp;<asp:GridView ID="griUser" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="TaiKhoan" 
            onselectedindexchanged="griUser_SelectedIndexChanged">
            <Columns>
                <asp:CommandField HeaderText="Cập nhật" SelectText="Chọn" 
                    ShowSelectButton="True" />
                
                <asp:BoundField DataField="TaiKhoan" HeaderText="Tài khoản" />
                <asp:BoundField DataField="HoTen" HeaderText="Họ và tên" />
                <asp:BoundField DataField="BoPhan" HeaderText="Bộ phận" />
                <asp:BoundField DataField="TrangThai" HeaderText="Trạng Thái" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:LinkButton ID="btnThemMoi" runat="server" Font-Underline="False" 
            onclick="btnThemMoi_Click" Font-Overline="False" 
    style="font-size: x-large">Thêm mới</asp:LinkButton>
        <asp:Panel ID="pnlCapNhat" runat="server" Visible="False">
            <table cellpadding="0" cellspacing="0" class="style1" align="left" 
                style="height: 215px; width: 800px">
                <tr>
                    <td class="style5" colspan="2">
                        Cập nhật</td>
                </tr>
                <tr>
                    <td class="style6">
                        Tài khoản</td>
                    <td class="style7">
                        &nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtTaiKhoan" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        Mật khẩu</td>
                    <td class="style7">
                        &nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtMatKhau" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        Họ Tên</td>
                    <td>
                        &nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtHoTen" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        Bộ phận</td>
                    <td>
                        &nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtBoPhan" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        Chức vụ</td>
                    <td>
                        &nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtChucVu" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
               <tr>
                    <td class="style2">
                        Trạng thái</td>
                    <td>
                        &nbsp;&nbsp;&nbsp;
                        <asp:CheckBox ID="chkTrangThai" runat="server" />
                    </td>
                </tr>
               
                
                <tr>
                    <td class="style2">
                        &nbsp;</td>
                    <td>
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnThem" runat="server" onclick="btnThem_Click" 
                            style="height: 26px" Text="Thêm" Width="65px" />
                        <asp:Button ID="btnXoa" runat="server" onclick="btnXoa_Click" Text="Xóa" 
                            Width="65px" />
                        <asp:Button ID="btnSua" runat="server" onclick="btnSua_Click" Text="Sửa" 
                            Width="65px" />
                        <asp:Button ID="btnBoQua" runat="server" onclick="btnBoQua_Click" Text="Bỏ qua" 
                            Width="65px" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    
</asp:Content>