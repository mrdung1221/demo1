<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BieuDo_CCSRac.aspx.cs" Inherits="BieuDo_CCSRac" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript" src="https://canvasjs.com/assets/script/jquery-1.11.1.min.js"></script>
<script src="https://canvasjs.com/assets/script/canvasjs.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="chartContainer" style="height: 300px; width: 100%;"></div>
    <span class="tenxe"></span><br />
    <span id="gio" style="display: none;"></span><br />
    <br />
    <br />
    <div id="chartRacContainer" style="height: 300px; width: 100%;"></div>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <script type="text/javascript">

        window.onload = function () {
            var thongbao = document.getElementById('<%=Label1.ClientID%>');
            alert(thongbao.innerHTML);
            var dps = [];   //dataPoints.  { label: "Số xe 1", y: 3.86 },{ label: "Số xe 2", y: 3.76 },{ label: "Số xe 3", y: 3.77 }
            var dps_rac = [];

            var chart = new CanvasJS.Chart("chartContainer", {
                title: {
                    text: "Tỷ lệ CCS"
                },
                data: [{
                    type: "spline",
                    dataPoints: dps
                }]
            });
            var chart_rac = new CanvasJS.Chart("chartRacContainer", {
                title: {
                    text: "Tỷ lệ Rác"
                },
                data: [{
                    type: "spline",
                    dataPoints: dps_rac
                }]
            });

            chart.render();
            chart_rac.render();

            var xVal;
            var yVal;
            var updateInterval = 2000;

            function GetChartInfo() {
                $.ajax({
                    type: "POST",
                    url: "BieuDo_CCSRac.aspx/GetChartInfo",
                    data: '{time_ccs:"' + $('#gio').text() + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess
                });
            };

            function OnSuccess(response) {
                var info = response.d;
                $(info).each(function () {
                    if (this.coly > 0) {
                        xVal = this.colx;
                        yVal = this.coly;
                        $(".tenxe").html(this.colx);
                        $("#gio").html(this.gio);
                        dps.push({ label: xVal, y: yVal });
                        chart.render();
                    }

                });
            }

            function GetChartRac() {
                $.ajax({
                    type: "POST",
                    url: "chartrac.aspx/GetChartInfo",
                    data: '{gioxeva:"' + $('#gio_rac').text() + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess_Rac,
                    failure: function (response) {
                        alert(response.d);
                    },
                    error: function (response) {
                        alert(response.d);
                    }
                });
            };

            function OnSuccess_Rac(response) {
                var info = response.d;
                $(info).each(function () {
                    if (this.coly > 0) {
                        xVal = this.colx;
                        yVal = this.coly;
                        $(".tenxe_rac").html(this.colx);
                        $("#gio_rac").html(this.gio);
                        dps_rac.push({ label: xVal, y: yVal });
                        chart_rac.render();
                    }

                });
            }

            setInterval(function () { GetChartInfo() }, updateInterval);
            setInterval(function () { GetChartRac() }, updateInterval);

        };

        
</script>

    <span class="tenxe_rac"></span><br />
    <span id="gio_rac" style="display: none;"></span><br />
</asp:Content>