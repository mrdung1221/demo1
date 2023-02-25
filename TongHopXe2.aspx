<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TongHopXe2.aspx.cs" Inherits="TongHopXe2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Chart ID="Chart1" runat="server" Width="1149px">
                <Series>
                    <asp:Series Name="Số lượng xe TB về nhà máy theo giờ" BorderColor="Red" BorderWidth="2" ChartType="Line" Font="Microsoft Sans Serif, 10pt, style=Bold" IsValueShownAsLabel="True" Legend="Legend1"></asp:Series>
                    <asp:Series BorderColor="Red" ChartArea="ChartArea1" ChartType="Point" Legend="Legend1" Name="Series2">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1" BackColor="ButtonFace" BorderColor="Window" ShadowColor="Gray">
                        <AxisX IntervalAutoMode="VariableCount" IntervalType="Number" IsLabelAutoFit="False">
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
                <Legends>
                    <asp:Legend Name="Legend1">
                    </asp:Legend>
                </Legends>
            </asp:Chart>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    </form>
</body>
</html>
