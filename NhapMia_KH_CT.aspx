<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NhapMia_KH_CT.aspx.cs" Inherits="NhapMia_KH_CT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
@font-face {
  src: url(resource\font\vnitimes.ttf);
}
.content{background-color: #c4c4c9;}
.danhsach{font-family:VNI-Times,VNI-Helve;}
.danhsach th{font-family:Calibri,Arial}
.content table{margin: 0 auto;border-collapse: inherit;}
.timkiem {text-align: center;padding-top: 20px;}
.tieude{font-size: x-large;font-weight: 700;color: navy;}
.timkiem span{color: Blue;}
.RowGrid:hover{background-color: #7fffd4!important;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="timkiem">
    <span class="tieude">Khách hàng chi tiết</span>
    <br />
    <br />
    
    <asp:Label ID="Label1" runat="server" Text="Trọng lượng thô: "></asp:Label> 
    <asp:Label ID="lblTho" runat="server" ForeColor="Red"></asp:Label>
    <asp:Label ID="Label2" runat="server" Text=" - Trọng lượng tinh: "></asp:Label>
    <asp:Label ID="lblTinh" runat="server" ForeColor="Red"></asp:Label>
    <asp:Label ID="Label3" runat="server" Text=" - CCS bình quân: "></asp:Label>
    <asp:Label ID="lblCCS" runat="server" ForeColor="Red"></asp:Label>
    <asp:Label ID="Label4" runat="server" Text=" - Tỷ lệ Rác bình quân: "></asp:Label>
    <asp:Label ID="lblRac" runat="server" ForeColor="Red"></asp:Label>
    <asp:Label ID="Label5" runat="server" Text=" - Số xe: "></asp:Label>
    <asp:Label ID="lblXe" runat="server" ForeColor="Red"></asp:Label>
</div>
<br />
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        onrowdatabound="GridView1_RowDataBound" BorderColor="#6699FF" 
        CssClass="danhsach" DataKeyNames="ma_lnm,ng_lnm" >
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="STT" HeaderText="STT"/>
        <asp:BoundField DataField="ma_pnm" HeaderText="Phiếu cân" />
        <asp:BoundField DataField="sohd" HeaderText="Số HĐ" />
        <asp:BoundField DataField="fullname" HeaderText="Tên khách hàng" />
        <asp:BoundField DataField="tenhuyen" HeaderText="Tên huyện" />
        <asp:BoundField DataField="so_xevc" HeaderText="Số xe" >
        <HeaderStyle Width="100px" />
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="gioxeva" HeaderText="Giờ xe vào" 
            DataFormatString="{0:dd-MM-yy HH:mm}" >
        <HeaderStyle Width="120px" />
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="gioxera" HeaderText="Giờ xe ra" 
            DataFormatString="{0:dd-MM-yy HH:mm}" >
        <HeaderStyle Width="120px" />
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="tl_tho" HeaderText="Thô&lt;br /&gt;( Kg )" 
            DataFormatString="{0:#,0}" HtmlEncode="False">
        <HeaderStyle Width="80px" />
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="tl_tinh" HeaderText="Tinh&lt;br /&gt;( Kg )" 
            DataFormatString="{0:#,0}" HtmlEncode="False">
        <HeaderStyle Width="80px" />
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="so_ccs" HeaderText="CCS" >
        <HeaderStyle Width="60px" />
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="tl_rac" HeaderText="Tỷ lệ rác" >
        <HeaderStyle Width="60px" />
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="loaichay" HeaderText="Mía cháy" >
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="giongmia" HeaderText="Tên giống" >
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="loaigoc" HeaderText="Loại gốc" >
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="ma_rmia" HeaderText="Mã ruộng mía" >
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="tuoimia" HeaderText="Tuổi mía&lt;br /&gt;( tháng )" 
            HtmlEncode="False" >
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:HyperLink ID="lnkXemAnh" runat="server" 
                    NavigateUrl='<%# string.Format("~/KhachHang_Image.aspx?ma_lnm={0}&ng_lnm={1}",Eval("ma_lnm"),Eval("ng_lnm","{0:yyyy/MM/dd}")) %>' 
                    Text="Xem ảnh"></asp:HyperLink>
            </ItemTemplate>
            <HeaderStyle Width="100px" />
            <ItemStyle HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:BoundField DataField="ccs_nhap" HeaderText="ccs nhap" Visible="False" />
    </Columns>
    <FooterStyle BackColor="#FFF" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#33CC33" Font-Bold="True" ForeColor="Black" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#EFF3FB" CssClass="RowGrid" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
</asp:GridView>

</asp:Content>