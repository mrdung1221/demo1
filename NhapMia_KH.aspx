<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NhapMia_KH.aspx.cs" Inherits="NhapMia_KH" %>

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
.page-count td {padding-right: 10px;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="timkiem">
    <span class="tieude">Sản lượng mía theo khách hàng</span>
    <br />
    <br />
    <asp:Panel ID="panel1" runat="server" CssClass="right" 
                        DefaultButton="btnGetData">
        
        <asp:Label ID="Label1" runat="server" Text="Tên khách hàng: "></asp:Label>
        <asp:TextBox ID="txtHoTen" runat="server"></asp:TextBox>
        <asp:Button ID="btnGetData" runat="server" Text="Thực hiện" 
            onclick="btnGetData_Click"/>
        <br />
        <asp:Label ID="lblTotal" runat="server" Text="Label" Visible="False"></asp:Label>
    </asp:Panel>
    
</div>
<br />
<asp:GridView ID="GridView1" runat="server" BorderColor="#6699FF" 
        CssClass="danhsach" AutoGenerateColumns="False" AllowPaging="True" 
        onpageindexchanging="GridView1_PageIndexChanging" PageSize="100" >
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:TemplateField HeaderText="STT">
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
            <HeaderStyle Width="40px" />
        </asp:TemplateField>
        <asp:BoundField DataField="ma_cmia" HeaderText="Mã khách hàng">
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="fullname" HeaderText="Tên khách hàng" />
        <asp:BoundField DataField="soxe" HeaderText="Số xe" >
        <HeaderStyle Width="60px" />
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="tl_tho" HeaderText="TL Thô" 
            DataFormatString="{0:0,0.0}" >
        <HeaderStyle Width="100px" />
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="tl_tinh" HeaderText="TL Tinh" 
            DataFormatString="{0:0,0.0}" >
        <HeaderStyle Width="100px" />
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="ccs_bq" HeaderText="CCS BQ" 
            DataFormatString="{0:0.00}" >
        <HeaderStyle Width="80px" />
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="ccs_max" HeaderText="CCS max" >
        <HeaderStyle Width="80px" />
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="ccs_min" HeaderText="CCS min" >
        <HeaderStyle Width="80px" />
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="rac_bq" HeaderText="Rác BQ" 
            DataFormatString="{0:0.00}" >
        <HeaderStyle Width="80px" />
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:HyperLink ID="HyperLink5" runat="server" 
                    NavigateUrl='<%# Eval("ma_cmia", "~/NhapMia_KH_CT.aspx?MaCMia={0}") %>'>Xem chi tiết</asp:HyperLink>
            </ItemTemplate>
            <HeaderStyle Width="100px" />
            <ItemStyle HorizontalAlign="Center" />
        </asp:TemplateField>
    </Columns>
    <HeaderStyle BackColor="#33CC33" Font-Bold="True" ForeColor="Black" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" CssClass="page-count" Font-Bold="True" />
    <RowStyle BackColor="#EFF3FB" CssClass="RowGrid" />
    
</asp:GridView>
   
</asp:Content>