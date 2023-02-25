<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GiongMia_TH.aspx.cs" Inherits="GiongMia_TH" %>

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
    <span class="tieude">Tổng hợp chất lượng giống mía</span>
    
</div>
<br />
<asp:GridView ID="GridView1" runat="server" BorderColor="#6699FF" 
        CssClass="danhsach" AutoGenerateColumns="False" ShowFooter="True" >
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:TemplateField HeaderText="STT">
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
            <HeaderStyle Width="40px" />
        </asp:TemplateField>
        <asp:BoundField DataField="GiongMia" HeaderText="Giống mía" >
        <HeaderStyle Width="140px" />
        </asp:BoundField>
        <asp:BoundField DataField="ccsbq" HeaderText="CCS BQ" DataFormatString="{0:#,0.00}" >
        <HeaderStyle Width="80px" />
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="slgtinh" HeaderText="SL Tinh&lt;br /&gt;( tấn )" 
            DataFormatString="{0:#,0.00}" HtmlEncode="False" >
        <HeaderStyle Width="100px" />
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="tong_dt" 
            HeaderText="Tổng diện tích&lt;br /&gt;( hecta )" DataFormatString="{0:#,0.00}" 
            HtmlEncode="False" >
        <HeaderStyle Width="100px" />
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="nsuat" HeaderText="Năng suất&lt;br /&gt;( tấn )" 
            DataFormatString="{0:#,0.00}" HtmlEncode="False" >
        <HeaderStyle Width="80px" />
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
    </Columns>
    <EditRowStyle BackColor="#2461BF" />
    <FooterStyle BackColor="Bisque" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#33CC33" Font-Bold="True" ForeColor="Black" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#EFF3FB" CssClass="RowGrid" />
</asp:GridView>
    
    <div class="timkiem">
    <span class="tieude">Năng suất giống mía</span>
    </div>
    <asp:Chart ID="Chart1" runat="server" Width="1000px" CssClass="center_img">
        <Series>
            <asp:Series Name="Series1" ChartArea="ChartArea1" ChartType="Line" 
                MarkerStyle="Square" XValueMember="GiongMia" XValueType="String" 
                YValueMembers="nsuat" IsValueShownAsLabel="True" LabelFormat="{0:#,0.00}" 
                Font="Segoe UI, 8.25pt, style=Bold">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
                <AxisY LineColor="LightGray">
                    <MajorGrid LineColor="LightGray" />
                </AxisY>
                <AxisX Interval="1">
                    <MajorGrid LineColor="LightGray" />
                </AxisX>
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
    <br />
</asp:Content>