<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TongHopXe.aspx.cs" Inherits="TongHopXe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
@font-face {
  src: url(resource\font\vnitimes.ttf);
}

</style>
  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">    
    <asp:Chart ID="Chart1" runat="server" Width="1400px">
     
        <Series>
            <asp:Series Name="Số lượng xe TB về nhà máy theo giờ" BorderColor="Red" BorderWidth="2" ChartType="Line" Font="Microsoft Sans Serif, 10pt, style=Bold" IsValueShownAsLabel="True" Legend="Legend1" MarkerStyle="Square"></asp:Series>
            <asp:Series BorderColor="Red" ChartArea="ChartArea1" ChartType="Point" Legend="Legend1" Name="Series2" Enabled="False">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1" BackColor="ButtonFace" BorderColor="Window" ShadowColor="Gray">
                <AxisY>
                    <MajorGrid LineColor="Gainsboro" />
                </AxisY>
                <AxisX IntervalAutoMode="VariableCount" IntervalType="Number" IsLabelAutoFit="False">
                    <MajorGrid LineColor="Gainsboro" />
                </AxisX>
            </asp:ChartArea>
        </ChartAreas>
        <Legends>
            <asp:Legend Name="Legend1">
            </asp:Legend>
        </Legends>
        <Titles>
            <asp:Title Font="Segoe UI, 10pt, style=Bold" Name="Title1" Text="Tổng hợp xe mía về bình quân theo từng giờ(24 giờ)">
            </asp:Title>
        </Titles>
    </asp:Chart>
    <asp:DropDownList ID="DropDownList1" runat="server" Font-Names="VNI-Helve" OnLoad="DropDownList1_Load" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="149px" AutoPostBack="True" OnInit="DropDownList1_Init"></asp:DropDownList>
    <asp:Chart ID="Chart2" runat="server" OnLoad="Chart2_Load" Width="1420px" Height="371px" style="margin-bottom: 0px">
        <Series>
            <asp:Series Name="Số xe về nhà máy" ChartType="Line" Legend="Legend1" MarkerStyle="Square" ToolTip="#VALX: #VAL xe"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
                <AxisY IntervalAutoMode="VariableCount" IntervalType="Number" IsLabelAutoFit="False">
                    <MajorGrid LineColor="Gainsboro" />
                </AxisY>
                <AxisX IntervalAutoMode="VariableCount" IsLabelAutoFit="False">
                    <MajorGrid LineColor="Gainsboro" />
                </AxisX>
            </asp:ChartArea>
        </ChartAreas>
        <Legends>
            <asp:Legend Name="Legend1">
            </asp:Legend>
        </Legends>
        <Titles>
            <asp:Title Font="Segoe UI, 10pt, style=Bold" Name="Title1" Text="Biểu đồ xe mía về nhà máy theo ngày(lũy kế)">
            </asp:Title>
        </Titles>
    </asp:Chart>
    <asp:Chart ID="Chart3" runat="server" OnInit="Chart3_Init" Width="1182px" style="margin-top: 6px">
        <Series>
            <asp:Series Name="Thời gian xe qoay đầu(giờ)" ChartType="Bar" CustomProperties="PointWidth=0.4" Font="VNI-Helve, 9.749999pt, style=Bold" IsValueShownAsLabel="True" Legend="Legend1" LabelFormat="{0:0.##}"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
                <AxisY IntervalAutoMode="VariableCount" TitleFont="VNI-Helve, 8.249999pt" IsLabelAutoFit="False">
                    <MajorGrid LineColor="Gainsboro" />
                    <LabelStyle Font="VNI-Times, 8.25pt" />
                </AxisY>
                <AxisX IntervalAutoMode="VariableCount" LineColor="Gainsboro" TitleFont="VNI-Times, 8.25pt" IsLabelAutoFit="False">
                    <MajorGrid LineColor="Gainsboro" />
                    <LabelStyle Font="VNI-Times, 8.25pt" />
                </AxisX>
            </asp:ChartArea>
        </ChartAreas>
        <Legends>
            <asp:Legend Name="Legend1">
            </asp:Legend>
        </Legends>
        <Titles>
            <asp:Title Font="Microsoft Sans Serif, 10pt, style=Bold" Name="Title1" Text="Thời gian quay vòng xe">
            </asp:Title>
        </Titles>
    </asp:Chart>
</asp:Content>