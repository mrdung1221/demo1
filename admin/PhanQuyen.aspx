<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PhanQuyen.aspx.cs" Inherits="admin_PhanQuyen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
<asp:GridView ID="griUser" runat="server" AutoGenerateColumns="False" 
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
<br /><br />
<asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Large" 
        ForeColor="#CC3300">Tài khoản:</asp:Label>&nbsp;
<asp:Label ID="lblTaiKhoan" runat="server" Font-Bold="True" Font-Size="Large" 
        ForeColor="#CC3300"></asp:Label>
    <asp:GridView ID="griPhanQuyen" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="MaQuyen">
        <Columns>
            <asp:TemplateField HeaderText="Chọn">
                <ItemTemplate>
                    <asp:CheckBox ID="chkQuyen" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="TenQuyen" HeaderText="Tên Quyền" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="btnSave" runat="server" Text="Save" style="height: 26px" 
        Width="65px" onclick="btnSave_Click" />
    <asp:Label ID="Label1" runat="server" ></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" ></asp:Label>
</asp:Content>

