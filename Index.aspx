<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="dothi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <%--<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" />--%>
<link rel="stylesheet" href="resource/css/index/card.css" />
    <style>
.chart {float:left;}
.chart1, .chart3{margin-right:6px;}
.chart3 div, .chart4 div{margin-top:6px;}
.chart1, .chart2{position: relative;}
.chart1-child{position: absolute; left:273px; top: 165px;}
.chart2-child{position: absolute; left:245px; top: 145px;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Row Box-->
<div class="row">

        <div class="col-xl-3 col-md-6 mb-4">
            <div class="card border-left-primary shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">Xe đang về (tấn)</div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800">
                                <asp:Label ID="lblxedangve" runat="server" Text="0"></asp:Label></div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-car fa-2x text-gray-300"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <div class="col-xl-3 col-md-6 mb-4">
            <div class="card border-left-primary shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">Tổng nhập ngày (tấn)</div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800">
                                <asp:Label ID="lblMiaNhapNgay" runat="server" Text="0"></asp:Label></div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-calendar fa-2x text-gray-300"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-xl-3 col-md-6 mb-4">
            <div class="card border-left-success shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-success text-uppercase mb-1">Xe chờ cân</div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800">
                                <asp:Label ID="lblXeCan" runat="server" Text="Label"></asp:Label></div>
                        </div>
                        <div class="col-auto">
                             <i class="fas fa-car fa-2x text-gray-300"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-xl-3 col-md-6 mb-4">
            <div class="card border-left-info shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-info text-uppercase mb-1">Xe chờ cẩu</div>
                            <div class="row no-gutters align-items-center">
                                <div class="col-auto">
                                    <div class="h5 mb-0 mr-3 font-weight-bold text-gray-800">
                                        <asp:Label ID="lblXeCau" runat="server" Text="Label"></asp:Label></div>
                                </div>
                                <div class="col">
                                    <div class="progress progress-sm mr-2">
                                        <div class="progress-bar bg-info" role="progressbar" style="width: 90%" aria-valuenow="90" aria-valuemin="0" aria-valuemax="100"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-car fa-2x text-gray-300"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-xl-3 col-md-6 mb-4">
            <div class="card border-left-warning shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-warning text-uppercase mb-1">Tổng xe đã về trong ngày</div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800">
                                <asp:Label ID="lblXeRa" runat="server" Text="Label"></asp:Label></div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-comments fa-2x text-gray-300"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

<!-- Chart-->
    <div id="chartFull">
<div class="chart1 chart">
    <asp:Chart ID="chartMiaNhapNgay" runat="server" Height="427px" Width="747px" 
        BackColor="224, 224, 224" oninit="chartMiaNhapNgay_Init">
        <Series>
            <asp:Series ChartType="Doughnut" Name="datapie2" 
                Font="VNI-Times, 9.749999pt, style=Bold, Italic" IsValueShownAsLabel="True" 
                Label="#VALX: #VAL{N0}" Legend="Legend1" LegendText="#VALX" 
                CustomProperties="PieLabelStyle=Outside"
                ToolTip="Chiếm: #PERCENT{P}" BorderColor="White" BorderWidth="2" IsVisibleInLegend="False" LabelToolTip="#VALX: #VAL{N0}">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1" BackColor="Transparent" BackImageTransparentColor="Silver">
            </asp:ChartArea>
        </ChartAreas>
        <Legends>
            <asp:Legend Name="Legend1" Font="VNI-Times, 9.749999pt, style=Bold" IsTextAutoFit="False" Alignment="Center" BackColor="224, 224, 224" TitleFont="Microsoft Sans Serif, 9.75pt, style=Bold">
            </asp:Legend>
        </Legends>
        <Titles>
            <asp:Title Name="Title1" Alignment="TopCenter" Font="Segoe UI, 10pt, style=Underline" ToolTip="Nhấp vào xem chi tiết" Url="~/NhapMia_CT.aspx">
            </asp:Title>
        </Titles>
    </asp:Chart>
    <div class="chart1-child">
        <asp:Chart ID="Chart5" runat="server" Height="130px" Width="180px" 
            BackColor="Transparent" BackSecondaryColor="Blue" Palette="None" 
            oninit="Chart5_Init" PaletteCustomColors="Gray; Gainsboro" >
            <Series>
                <asp:Series ChartType="Pie" Font="VNI-Times, 8.25pt" 
                                 
                    LabelBorderDashStyle="NotSet" LegendText="#VALX:#VAL" 
                    Name="data5" BackImageTransparentColor="White" IsValueShownAsLabel="True" 
                    Label="#VALX\n#PERCENT" BorderWidth="2" BorderColor="White">
                    
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1" BackColor="Transparent">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>
</div>
<div class="chart2 chart">
    <asp:Chart ID="chartLuyKe" runat="server" Height="427px" Width="747px" 
            BackColor="224, 224, 224" oninit="chartLuyKe_Init" >
        <Series>
            <asp:Series ChartType="Doughnut" Font="VNI-Times, 9.749999pt, style=Bold, Italic" 
                IsValueShownAsLabel="True" Label="#VALX: #VAL{N0}" 
                LabelBorderDashStyle="NotSet" Legend="Legend1" LegendText="#VALX: (#PERCENT)" 
                Name="datapie" CustomProperties="DoughnutRadius=50, PieLabelStyle=Outside" BorderColor="White" BorderWidth="2" IsVisibleInLegend="False" LabelToolTip="#VALX: #VAL{N0}" ToolTip="Chiếm: #PERCENT{P}">
                <SmartLabelStyle AllowOutsidePlotArea="Yes" CalloutBackColor="Turquoise" MovingDirection="Center" MaxMovingDistance="1000" />
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1" BackColor="224, 224, 224">
            </asp:ChartArea>
        </ChartAreas>
        <Legends>
            <asp:Legend Font="VNI-Times, 9.749999pt, style=Bold" IsTextAutoFit="False" Name="Legend1" AutoFitMinFontSize="8" Alignment="Center" BackColor="224, 224, 224" LegendStyle="Column">
            </asp:Legend>
        </Legends>
        <Titles>
            <asp:Title Name="Title1" Alignment="TopCenter" Font="Segoe UI, 10pt" 
                Url="~/NhapMia_TH.aspx?LuyKe=1" ToolTip="Nhấp vào xem chi tiết">
            </asp:Title>
        </Titles>
    </asp:Chart>
    <div class="chart2-child">
        <asp:Chart ID="Chart6" runat="server" Height="170px" Width="235px" 
            BackColor="Transparent" BackSecondaryColor="Blue" Palette="None" 
            oninit="Chart6_Init" PaletteCustomColors="Gray; Gainsboro" >
            <Series>
                <asp:Series ChartType="Pie" Font="VNI-Times, 8.25pt" 
                                 
                    LabelBorderDashStyle="NotSet" LegendText="#VALX:#VAL" 
                    Name="data6" BackImageTransparentColor="White" IsValueShownAsLabel="True" 
                    Label="#VALX\n#PERCENT" BorderColor="White" BorderWidth="2">
                    
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1" BackColor="Transparent">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>
</div> 
<div class="chart3 chart">
    <div>
    <asp:Chart ID="chartMiaNhap10Ngay" runat="server" OnDataBound="Page_Load" 
        Height="210px" Width="747px" BackColor="224, 224, 224" 
        style="margin-bottom: 0px" oninit="chartMiaNhap10Ngay_Init">
    <Series>
        <asp:Series IsValueShownAsLabel="True" ChartArea="ChartArea1" 
            Color="0, 192, 0" Label="#VAL{N0}" Legend="Legend1" Font="Microsoft Sans Serif, 7pt, style=Bold" 
            ChartType="StackedColumn" Name="muaban" BorderColor="White" CustomProperties="PointWidth=0.6">
        </asp:Series>
        <asp:Series ChartArea="ChartArea1" Legend="Legend1" Name="dautu" 
            ChartType="StackedColumn" Font="Microsoft Sans Serif, 7pt, style=Bold" 
            Label="#VAL{N0}" BorderColor="White" CustomProperties="PointWidth=0.6">
        </asp:Series>
        <asp:Series ChartArea="ChartArea1" ChartType="Point" Legend="Legend1" 
            Name="Series3" Font="Segoe UI, 8.25pt, style=Bold" 
            Label="#VAL{N0}" LabelForeColor="Red">
        </asp:Series>
        <asp:Series ChartArea="ChartArea1" ChartType="Line" 
            Font="Microsoft Sans Serif, 8.25pt, style=Bold" 
            LabelForeColor="Red" Legend="Legend1" Name="Series4" Enabled="False">
        </asp:Series>
    </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartArea1" BackColor="White" BackImageTransparentColor="224, 224, 224">
            <AxisY IsLabelAutoFit="False">
                <MajorGrid LineColor="Gainsboro" />
                <LabelStyle Font="Microsoft Sans Serif, 6.75pt" />
            </AxisY>
            <AxisX IsLabelAutoFit="False">
                <MajorGrid LineColor="Gainsboro" />
                <LabelStyle Font="Microsoft Sans Serif, 6.75pt" />
            </AxisX>
            <AxisX2 IsLabelAutoFit="False">
                <LabelStyle Font="Microsoft Sans Serif, 6.75pt" />
            </AxisX2>
            <AxisY2 IsLabelAutoFit="False">
                <LabelStyle Font="Microsoft Sans Serif, 6.75pt" />
            </AxisY2>
        </asp:ChartArea>
    </ChartAreas>
    <Legends>
        <asp:Legend Name="Legend1" BackColor="Transparent">
        </asp:Legend>
    </Legends>
    <Titles>
        <asp:Title BorderColor="Transparent" Font="Segoe UI, 9.75pt, style=Bold" Name="title1" Text="Biểu đồ mía nhập 10 ngày gần nhất" 
            Alignment="TopCenter" BackColor="Transparent">
        </asp:Title>
    </Titles>
    </asp:Chart>
    </div>
    <div>
    <asp:Chart ID="chartSLNhapTheoHuyen" runat="server" OnDataBound="Page_Load" 
        Height="210px" Width="747px" BackColor="224, 224, 224" 
        style="margin-bottom: 0px" oninit="chartSLNhapTheoHuyen_Init">
        <Series>
            <asp:Series ChartArea="ChartArea1" ChartType="Line" Legend="Legend1" 
                MarkerSize="6" MarkerStyle="Square" Name="P Yên" 
                ToolTip="#VALX: #VAL{N0}" IsValueShownAsLabel="True">
            </asp:Series>
            <asp:Series ChartArea="ChartArea1" ChartType="Line" Legend="Legend1" 
                MarkerSize="6" MarkerStyle="Square" Name="Đăklak" 
                ToolTip="#VALX: #VAL{N0}">
            </asp:Series>
            <asp:Series ChartArea="ChartArea1" ChartType="Line" Legend="Legend1" 
                MarkerSize="6" MarkerStyle="Square" Name="N Thuận" 
                ToolTip="#VALX: #VAL{N0}">
            </asp:Series>
            <asp:Series ChartArea="ChartArea1" ChartType="Line" Legend="Legend1" 
                MarkerSize="6" MarkerStyle="Square" Name="K Hòa" 
                ToolTip="#VALX: #VAL{N0}">
            </asp:Series>
            <asp:Series BorderDashStyle="Dot" BorderWidth="2" ChartArea="ChartArea1" 
                ChartType="Spline" Color="Black" Legend="Legend1" Name="BQ Giá">
            </asp:Series>
        </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartArea1" BackColor="White" BackImageTransparentColor="224, 224, 224">
            <AxisY IntervalAutoMode="VariableCount" IsLabelAutoFit="False">
                <MajorGrid LineColor="Gainsboro" />
                <LabelStyle Font="Microsoft Sans Serif, 7pt" />
            </AxisY>
            <AxisX LineColor="Gray" IntervalAutoMode="VariableCount" 
                TitleFont="Microsoft Sans Serif, 7pt" IsLabelAutoFit="False">
                <MajorGrid LineColor="Gainsboro" />
                <LabelStyle Font="VNI-Helve, 6.75pt" />
                <ScaleBreakStyle Spacing="1" BreakLineStyle="None" />
            </AxisX>
            <AxisX2 IsLabelAutoFit="False">
                <LabelStyle Font="Microsoft Sans Serif, 6.75pt" />
            </AxisX2>
        </asp:ChartArea>
    </ChartAreas>
    <Legends>
        <asp:Legend Name="Legend1" BackColor="Transparent">
        </asp:Legend>
    </Legends>
    <Titles>
        <asp:Title BorderColor="Transparent" Font="Segoe UI, 10pt, style=Bold" Name="title1" Text="Biểu đồ giá mua mía cơ bản BQ" 
            Alignment="TopCenter" BackColor="Transparent">
        </asp:Title>
    </Titles>
    </asp:Chart>
    </div>
</div> 
<div class="chart4 chart">      
    <%-- Chart CCS--%>
    <div>
    <asp:Chart ID="chartCCS10Ngay" runat="server" OnDataBound="Page_Load" 
        Height="210px" Width="747px"  BackColor="224, 224, 224" 
            oninit="chartCCS10Ngay_Init">
    <Series>
        <asp:Series Name="CCS" ChartArea="ChartArea1" Color="Red" Legend="Legend1" 
            ChartType="Line" XValueMember="ngay" YValueMembers="CCSBQ" 
            MarkerStyle="Square" MarkerSize="6" ToolTip="#VAL{N2}" 
            Font="Microsoft Sans Serif, 8.25pt">
        </asp:Series>
        
    </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartArea1" BackColor="White">
            <AxisY IntervalAutoMode="VariableCount" IntervalType="Number" IsLabelAutoFit="False">
                <MajorGrid LineColor="Gainsboro" />
                <LabelStyle Font="Microsoft Sans Serif, 6.75pt" />
            </AxisY>
            <AxisX IntervalAutoMode="VariableCount" IsLabelAutoFit="False">
                <MajorGrid LineColor="Gainsboro" />
                <LabelStyle TruncatedLabels="True" Font="Microsoft Sans Serif, 6.75pt" />
            </AxisX>
        </asp:ChartArea>
    </ChartAreas>
    <Legends>
        <asp:Legend Name="Legend1" BackColor="Transparent">
        </asp:Legend>
    </Legends>
    <Titles>
        <asp:Title BorderColor="Transparent" Font="Segoe UI, 10pt, style=Bold" Name="title1" Text="Biểu đồ CCS Bình quân gia quyền lũy kế" 
            ShadowColor="Red" BackColor="Transparent">
        </asp:Title>
    </Titles>
    </asp:Chart>
    </div>
    <%-- chart Rac--%>
    <div>
    <asp:Chart ID="chartRac10Ngay" runat="server" OnDataBound="Page_Load" 
        Height="210px" Width="747px"  BackColor="224, 224, 224" 
            oninit="chartRac10Ngay_Init">
    <Series>
        <asp:Series Name="Rác" ChartArea="ChartArea1" 
            Color="0, 192, 0" Legend="Legend1" ChartType="Line" 
            XValueMember="ngay" YValueMembers="RACBQ" MarkerStyle="Square" 
            MarkerSize="6" ToolTip="#VAL{N2}">
        </asp:Series>
        
    </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartArea1" BackColor="White">
            <AxisY IntervalAutoMode="VariableCount" IsLabelAutoFit="False">
                <MajorGrid LineColor="Gainsboro" />
                <LabelStyle Font="Microsoft Sans Serif, 6.75pt" />
            </AxisY>
            <AxisX IntervalAutoMode="VariableCount" IsLabelAutoFit="False">
                <MajorGrid LineColor="Gainsboro" />
                <LabelStyle Font="Microsoft Sans Serif, 6.75pt" />
            </AxisX>
        </asp:ChartArea>
    </ChartAreas>
    <Legends>
        <asp:Legend Name="Legend1" BackColor="Transparent">
        </asp:Legend>
    </Legends>
    <Titles>
        <asp:Title BorderColor="Transparent" Font="Segoe UI, 9.75pt, style=Bold" Name="title1" Text="Biểu đồ Rác Bình quân gia quyền lũy kế" 
            ShadowColor="Red" BackColor="Transparent">
        </asp:Title>
    </Titles>
    </asp:Chart>
    </div>
</div>
</div>        
             
</asp:Content>