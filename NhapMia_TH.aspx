<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NhapMia_TH.aspx.cs" Inherits="NhapMia_TH" %>

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
.center_img{display:block; margin-left:auto;margin-right:auto;}
.RowGrid:hover{background-color: #7fffd4!important;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="timkiem">
    <span class="tieude">Tổng hợp mía nhập</span>
    <br />
    <br />
    <asp:Panel ID="panel1" runat="server" CssClass="right" 
                        DefaultButton="btnGetData">
        <asp:RadioButton ID="radNgay" runat="server" GroupName="thoigian" 
            Checked="False" Text="Ngày" oncheckedchanged="radNgay_CheckedChanged" AutoPostBack="True" />
        <asp:RadioButton ID="radNhieuNgay" runat="server" GroupName="thoigian" 
            Text="Nhiều ngày" AutoPostBack="True" 
            oncheckedchanged="radNhieuNgay_CheckedChanged" />
        <asp:RadioButton ID="radThang" runat="server" GroupName="thoigian" Text="Tháng" 
            AutoPostBack="True" oncheckedchanged="radThang_CheckedChanged" />
        <asp:RadioButton ID="radLuyKe" runat="server" GroupName="thoigian" 
            Text="Lũy kế" AutoPostBack="True" oncheckedchanged="radLuyKe_CheckedChanged" />
        <br />
        <br />
        <asp:TextBox ID="txtTuNgay" runat="server" type="date"></asp:TextBox>
        <asp:TextBox ID="txtDenNgay" runat="server" type="date" Visible="False"></asp:TextBox>
        <asp:DropDownList ID="dropThang" runat="server" ToolTip="Tháng" Visible="False">
            <asp:ListItem Text="Tháng" Selected="True" />
            <asp:ListItem Text="1" />
            <asp:ListItem Text="2" />
            <asp:ListItem Text="3" />
            <asp:ListItem Text="4" />
            <asp:ListItem Text="5" />
            <asp:ListItem Text="6" />
            <asp:ListItem Text="7" />
            <asp:ListItem Text="8" />
            <asp:ListItem Text="9" />
            <asp:ListItem Text="10" />
            <asp:ListItem Text="11" />
            <asp:ListItem Text="12" />
        </asp:DropDownList>
        <asp:TextBox ID="txtYear" runat="server" Width="60px" placeholder="Năm" 
            ToolTip="Năm" Visible="False"></asp:TextBox>
        <asp:Label ID="lblLuyKe" runat="server" Text="Label" Visible="False"></asp:Label>
        <asp:Button ID="btnGetData" runat="server" Text="Thực hiện" 
            onclick="btnGetData_Click"/>
    </asp:Panel>
    
    <%--<br />
    <asp:Label ID="Label1" runat="server" Text="Trọng lượng thô: "></asp:Label> 
    <asp:Label ID="lblTho" runat="server" ForeColor="Red"></asp:Label>
    <asp:Label ID="Label2" runat="server" Text=" - Trọng lượng tinh: "></asp:Label>
    <asp:Label ID="lblTinh" runat="server" ForeColor="Red"></asp:Label>
    <asp:Label ID="Label3" runat="server" Text=" - CCS bình quân: "></asp:Label>
    <asp:Label ID="lblCCS" runat="server" ForeColor="Red"></asp:Label>
    <asp:Label ID="Label4" runat="server" Text=" - Tỷ lệ Rác bình quân: "></asp:Label>
    <asp:Label ID="lblRac" runat="server" ForeColor="Red"></asp:Label>
    <asp:Label ID="Label5" runat="server" Text=" - Số xe: "></asp:Label>
    <asp:Label ID="lblXe" runat="server" ForeColor="Red"></asp:Label>--%>
</div>
<br />
<asp:GridView ID="GridView1" runat="server" BorderColor="#6699FF" 
        CssClass="danhsach" AutoGenerateColumns="False" ShowFooter="True" 
        onrowdatabound="GridView1_RowDataBound" >
    <AlternatingRowStyle BackColor="White" />
    <Columns>


        <%--<asp:TemplateField HeaderText="Tiền mía">
            <ItemTemplate>
                <asp:Label Text='<%#Bind("tienmia","{0:0,0}") %>' ID="lblTienMia" runat="server" />
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label Text="" ID="lblTongTien" runat="server" />
            </FooterTemplate>
            <FooterStyle HorizontalAlign="Right" />
            <HeaderStyle Width="120px" />
            <ItemStyle HorizontalAlign="Right" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Hỗ trợ 1">
            <ItemTemplate>
                <asp:Label Text='<%#Bind("hotro1","{0:0,0}") %>' ID="lblHoTro1" runat="server" />
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label Text="" ID="lblHoTro1" runat="server" />
            </FooterTemplate>
            <FooterStyle HorizontalAlign="Right" />
            <HeaderStyle Width="120px" />
            <ItemStyle HorizontalAlign="Right" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Hỗ trợ 2">
            <ItemTemplate>
                <asp:Label Text='<%#Bind("hotro2","{0:0,0}") %>' ID="lblHoTro2" runat="server" />
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label Text="" ID="lblHoTro2" runat="server" />
            </FooterTemplate>
            <FooterStyle HorizontalAlign="Right" />
            <HeaderStyle Width="120px" />
            <ItemStyle HorizontalAlign="Right" />
        </asp:TemplateField>--%>
        <asp:TemplateField HeaderText="Tên huyện">
            <ItemTemplate>
                <asp:Label Text='<%#Bind("tenhuyen") %>' ID="Label6" runat="server" />
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label Text="Tổng" ID="Label7" runat="server" />
            </FooterTemplate>
            <HeaderStyle Width="110px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Số Xe">
            <ItemTemplate>
                <asp:Label Text='<%#Bind("sochuyen") %>' ID="lblChuyen" runat="server" />
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label Text="" ID="lblTongChuyen" runat="server" />
            </FooterTemplate>
            <FooterStyle HorizontalAlign="Right" />
            <HeaderStyle Width="60px" />
            <ItemStyle HorizontalAlign="Right" />
        </asp:TemplateField>
        <asp:BoundField DataField="tl_bq" HeaderText="Trọng lượng BQ" 
            DataFormatString="{0:0,0}" >        
        <HeaderStyle Width="60px" />
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:TemplateField HeaderText="Slg Tự do&lt;br /&gt;( Kg )">
            <ItemTemplate>
                <asp:Label Text='<%#Bind("slg_tudo","{0:#,0}") %>' ID="lblTuDo" runat="server" />
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label Text="" ID="lblTongTuDo" runat="server" />
            </FooterTemplate>
            <FooterStyle HorizontalAlign="Right" />
            <HeaderStyle Width="80px" />
            <ItemStyle HorizontalAlign="Right" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Slg Đầu tư&lt;br /&gt;( Kg )">
            <ItemTemplate>
                <asp:Label Text='<%#Bind("slg_dautu","{0:#,0}") %>' ID="lblDauTu" runat="server" />
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label Text="" ID="lblTongDauTu" runat="server" />
            </FooterTemplate>
            <FooterStyle HorizontalAlign="Right" />
            <HeaderStyle Width="100px" />
            <ItemStyle HorizontalAlign="Right" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Thô&lt;br /&gt;( Kg )">
            <ItemTemplate>
                <asp:Label Text='<%#Bind("tho","{0:0,0}") %>' ID="lblTho" runat="server" />
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label Text="" ID="lblTongTho" runat="server" />
            </FooterTemplate>
            <FooterStyle HorizontalAlign="Right" />
            <HeaderStyle Width="100px" />
            <ItemStyle HorizontalAlign="Right" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Tinh&lt;br /&gt;( Kg )">
            <ItemTemplate>
                <asp:Label Text='<%#Bind("tinh","{0:0,0}") %>' ID="lblTinh" runat="server" />
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label Text="" ID="lblTongTinh" runat="server" />
            </FooterTemplate>
            <FooterStyle HorizontalAlign="Right" />
            <HeaderStyle Width="100px" />
            <ItemStyle HorizontalAlign="Right" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CCS BQ">
            <ItemTemplate>
                <asp:Label Text='<%#Bind("ccsBQ","{0:0.00}") %>' ID="lblCCS" runat="server" />
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label Text="" ID="lblTongCCS" runat="server" />
            </FooterTemplate>
            <FooterStyle HorizontalAlign="Right" />
            <HeaderStyle Width="60px" />
            <ItemStyle HorizontalAlign="Right" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CCS Min">
            <ItemTemplate>
                <asp:Label Text='<%#Bind("ccs_min") %>' ID="Labe1" runat="server" />
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label Text="" ID="lblCCSMin" runat="server" />
            </FooterTemplate>
            <FooterStyle HorizontalAlign="Right" />
            <HeaderStyle Width="50px" />
            <ItemStyle HorizontalAlign="Right" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CCS Max">
            <ItemTemplate>
                <asp:Label Text='<%#Bind("ccs_max") %>' ID="Labe2" runat="server" />
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label Text="" ID="lblCCSMax" runat="server" />
            </FooterTemplate>
            <FooterStyle HorizontalAlign="Right" />
            <HeaderStyle Width="50px" />
            <ItemStyle HorizontalAlign="Right" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Rác BQ">
            <ItemTemplate>
                <asp:Label Text='<%#Bind("racbq","{0:0.000}") %>' ID="lblRac" runat="server" />
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label Text="" ID="lblTongRac" runat="server" />
            </FooterTemplate>
            <FooterStyle HorizontalAlign="Right" />
            <HeaderStyle Width="60px" />
            <ItemStyle HorizontalAlign="Right" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Rác Min">
            <ItemTemplate>
                <asp:Label Text='<%#Bind("rac_min") %>' ID="Labe4" runat="server" />
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label Text="" ID="lblRacMin" runat="server" />
            </FooterTemplate>
            <FooterStyle HorizontalAlign="Right" />
            <HeaderStyle Width="50px" />
            <ItemStyle HorizontalAlign="Right" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Rác Max">
            <ItemTemplate>
                <asp:Label Text='<%#Bind("rac_max") %>' ID="Labe3" runat="server" />
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label Text="" ID="lblRacMax" runat="server" />
            </FooterTemplate>
            <FooterStyle HorizontalAlign="Right" />
            <HeaderStyle Width="50px" />
            <ItemStyle HorizontalAlign="Right" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Tổng tiền mía&lt;br /&gt;cơ bản">
            <ItemTemplate>
                <asp:Label Text='<%#Bind("tongtien","{0:0,0}") %>' ID="lblTongTien" runat="server" />
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label Text="" ID="lblTongTongTien" runat="server" />
            </FooterTemplate>
            <FooterStyle HorizontalAlign="Right" />
            <HeaderStyle Width="130px" />
            <ItemStyle HorizontalAlign="Right" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Đơn giá mía cơ bản&lt;br /&gt;bình quân">
            <ItemTemplate>
                <asp:Label Text='<%#Bind("dongiaBQ","{0:0,0}") %>' ID="lbldongiaBQ" runat="server" />
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label Text="" ID="lblTongDonGiaCBBQ" runat="server" />
            </FooterTemplate>
            <FooterStyle HorizontalAlign="Right" />
            <HeaderStyle Width="100px" />
            <ItemStyle HorizontalAlign="Right" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Tiền tăng thêm">
            <ItemTemplate>
                <asp:Label Text='<%#Bind("chikhac","{0:0,0}") %>' ID="Label2" runat="server" />
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label Text="" ID="lblTongChiKhac" runat="server" />
            </FooterTemplate>
            <FooterStyle HorizontalAlign="Right" />
            <HeaderStyle Width="110px" />
            <ItemStyle HorizontalAlign="Right" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Tổng tiền mua mía">
            <ItemTemplate>
                <asp:Label Text='<%#Bind("tongtienmia","{0:0,0}") %>' ID="Label3" runat="server" />
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label Text="" ID="lblTongTienMia" runat="server" />
            </FooterTemplate>
            <FooterStyle HorizontalAlign="Right" />
            <HeaderStyle Width="120px" />
            <ItemStyle HorizontalAlign="Right" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Tổng đơn giá bình quân">
            <ItemTemplate>
                <asp:Label Text='<%#Bind("tongdongiabq","{0:0,0}") %>' ID="Label4" runat="server" />
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label Text="" ID="lblTongDonGiaBQ" runat="server" />
            </FooterTemplate>
            <FooterStyle HorizontalAlign="Right" />
            <HeaderStyle Width="80px" />
            <ItemStyle HorizontalAlign="Right" />
        </asp:TemplateField>
    </Columns>
    <FooterStyle BackColor="#FFF" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#33CC33" Font-Bold="True" ForeColor="Black" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#EFF3FB" CssClass="RowGrid" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
</asp:GridView>
    
    
    <div style="margin: 15px auto;width: 1500px;">
    <div style="float:left;margin-right: 3px;margin-left: 5px;">
        
        <asp:Chart ID="Chart1" runat="server" Width="495px" 
            BackColor="WhiteSmoke">
            <Series>
                <asp:Series Name="Sản lượng Tinh (tấn)" ChartArea="ChartArea1" 
                    MarkerStyle="Square" XValueMember="tenhuyen" XValueType="String" 
                    YValueMembers="tinh" IsValueShownAsLabel="True" LabelFormat="{0:#,0}" 
                    CustomProperties="PointWidth=0.2" Font="Segoe UI, 6.5pt, style=Bold" 
                    Legend="Legend1">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                    <AxisY LineColor="LightGray" IsLabelAutoFit="False" IntervalAutoMode="VariableCount">
                        <MajorGrid LineColor="LightGray" />
                        <LabelStyle Font="Microsoft Sans Serif, 7pt" />
                    </AxisY>
                    <AxisX Interval="1" IsLabelAutoFit="False">
                        <MajorGrid LineColor="LightGray" />
                        <LabelStyle Font="VNI-Times, 8.25pt" />
                    </AxisX>
                </asp:ChartArea>
            </ChartAreas>
            <Legends>
                <asp:Legend Alignment="Center" Docking="Top" LegendStyle="Row" Name="Legend1" 
                    BackColor="Transparent">
                </asp:Legend>
            </Legends>
        </asp:Chart>
    </div>

    <div style="float:left;margin-right: 3px;">
        
            <asp:Chart ID="Chart2" runat="server" Width="495px" 
                BackColor="WhiteSmoke">
                <Series>
                    <asp:Series Name="CCS BQ" ChartArea="ChartArea1" 
                        MarkerStyle="Square" XValueMember="tenhuyen" XValueType="String" 
                        YValueMembers="ccsBQ" IsValueShownAsLabel="True" LabelFormat="{0:#,0.00}" 
                        CustomProperties="PointWidth=0.5" Font="Segoe UI, 6.5pt, style=Bold" 
                        Color="255, 128, 0" Legend="Legend1">
                    </asp:Series>
                    <asp:Series ChartArea="ChartArea1" Name="Rác BQ"
                    MarkerStyle="Square" XValueMember="tenhuyen" XValueType="String" 
                        YValueMembers="racbq" IsValueShownAsLabel="True" LabelFormat="{0:#,0.00}" 
                        CustomProperties="PointWidth=0.5" Font="Segoe UI, 6.5pt, style=Bold" 
                        Color="#FFCC99" Legend="Legend1">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                        <AxisY LineColor="LightGray" IsLabelAutoFit="False" IntervalAutoMode="VariableCount">
                            <MajorGrid LineColor="LightGray" />
                            <MajorGrid LineColor="LightGray"></MajorGrid>
                            <LabelStyle Font="Microsoft Sans Serif, 7pt" />
                        </AxisY>
                        <AxisX Interval="1" IsLabelAutoFit="False">
                            <MajorGrid LineColor="LightGray" />
                                <MajorGrid LineColor="LightGray"></MajorGrid>

                            <LabelStyle Font="VNI-Times, 8.25pt" />
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
                <Legends>
                    <asp:Legend Name="Legend1" BackColor="Transparent" 
                        LegendStyle="Row" TableStyle="Wide" Alignment="Center" Docking="Top">
                    </asp:Legend>
                </Legends>
            </asp:Chart>
        </div>

        <div style="">
        
            <asp:Chart ID="Chart3" runat="server" Width="495px" 
                BackColor="WhiteSmoke" Palette="Bright">
                <Series>
                    <asp:Series Name="Đơn giá mía cơ bản BQ" ChartArea="ChartArea1" 
                        MarkerStyle="Square" XValueMember="tenhuyen" XValueType="String" 
                        YValueMembers="dongiaBQ" IsValueShownAsLabel="True" LabelFormat="{0:#,0}" 
                        CustomProperties="PointWidth=0.5" Font="Segoe UI, 6.5pt, style=Bold" 
                        Color="255, 224, 192" Legend="Legend1">
                    </asp:Series>
                    <asp:Series ChartArea="ChartArea1" Name="Đơn giá mua mía BQ(CB + TT)"
                    MarkerStyle="Square" XValueMember="tenhuyen" XValueType="String" 
                        YValueMembers="tongdongiabq" IsValueShownAsLabel="True" LabelFormat="{0:#,0}" 
                        CustomProperties="PointWidth=0.5" Font="Segoe UI, 6.5pt, style=Bold" 
                        Color="192, 192, 255" Legend="Legend1">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                        <AxisY LineColor="LightGray" IntervalAutoMode="VariableCount" 
                            IsLabelAutoFit="False">
                            <MajorGrid LineColor="LightGray" />
                            <MajorGrid LineColor="LightGray"></MajorGrid>
                            <LabelStyle Font="Microsoft Sans Serif, 7pt" />
                        </AxisY>
                        <AxisX Interval="1" IsLabelAutoFit="False">
                            <MajorGrid LineColor="LightGray" />
                                <MajorGrid LineColor="LightGray"></MajorGrid>

                            <LabelStyle Font="VNI-Times, 8.25pt" />
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
                <Legends>
                    <asp:Legend Name="Legend1" BackColor="Transparent" 
                        LegendStyle="Row" TableStyle="Wide" Alignment="Center" Docking="Top">
                    </asp:Legend>
                </Legends>
            </asp:Chart>
        </div>
    </div>
    <br />
</asp:Content>