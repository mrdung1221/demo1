
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class dothi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["TaiKhoan"] == null)
        {
            Response.Redirect("~/DangNhap.aspx");
        }
        else
        {
            string key = "tc";
            string taikhoan = Session["TaiKhoan"].ToString();
            VietSugar.User u = new VietSugar.User();
            if (u.CheckQuyen(taikhoan, key) == false)
                Response.Redirect("~/CanhBao.aspx");
        }

        
        VietSugar.MiaNguyenLieu mia = new VietSugar.MiaNguyenLieu();
        mia.XeChoCan();
        lblXeCan.Text = mia.SoXe.ToString();
        mia.XeChoCau();
        lblXeCau.Text = mia.SoXe.ToString();
        mia.XeCanRa();
        lblXeRa.Text = mia.Tong_ra.ToString();
        lblXeRa.ToolTip = "23299\r\n13123\r\n44554";
        
    }

    protected void chartMiaNhapNgay_Init(object sender, EventArgs e)
    {
        try
        {
            //load data Tong mia nhap ngay
            DateTime DateNow = DateTime.Now;
            string fromDay, toDay, thoigian = "";
            if (DateNow.Hour <= 6)
            {
                fromDay = DateNow.AddDays(-1).ToString("yyyy-MM-dd");
                toDay = DateNow.ToString("yyyy-MM-dd");
                thoigian = "gioxera>='" + fromDay + " 06:00' and gioxera<'" + toDay + " 06:00'";
            }
            else if (DateNow.Hour > 6)
            {
                fromDay = DateNow.ToString("yyyy-MM-dd");
                toDay = DateNow.AddDays(1).ToString("yyyy-MM-dd");
                thoigian = "gioxera>='" + fromDay + " 06:00' and gioxera<'" + toDay + " 06:00'";
            }

            VietSugar.getdata data3 = new VietSugar.getdata();
            string HomNay = DateTime.Now.ToString("yyy-MM-dd");
            string cmd3 = "select sum(((tl_xeva-tl_xera)-((tl_xeva-tl_xera)*tl_rac/100))/1000) as tluong,rtrim(tenhuyen) as tenhuyen from nlnhapmia nm inner join nlvungmia vm on " +
                    " nm.ma_vmia = vm.ma_vmia where tl_xera >0 and tl_rac>1 and so_ccs>0 and "+thoigian+" group by tenhuyen";
            
            chartMiaNhapNgay.DataSource = data3.sqlcmd_ex(cmd3);
            int sum2 = Convert.ToInt32(data3.sqlcmd_ex(cmd3).Compute("SUM(tluong)", string.Empty));
            chartMiaNhapNgay.Series["datapie2"].XValueMember = "tenhuyen";
            chartMiaNhapNgay.Series["datapie2"].YValueMembers = "tluong";
            string bb = String.Format("{0:0,0.0}", sum2);
            chartMiaNhapNgay.Titles["Title1"].Text = "Tổng nhập trong ngày: " + bb + " tấn";
            chartMiaNhapNgay.Titles["Title1"].Font = new Font("Segoe UI", 10, System.Drawing.FontStyle.Bold | FontStyle.Underline);
            chartMiaNhapNgay.Titles["Title1"].ForeColor = Color.Black;

            //  chartMiaNhapNgay.Titles["Title1"].Alignment = ContentAlignment.TopCenter;
            //   chartMiaNhapNgay.Series[0]["PieLabelStyle"] = "outside";
            // chartMiaNhapNgay.ChartAreas[0].Area3DStyle.Enable3D = true;
            // Chart3.ChartAreas[0].Area3DStyle.Inclination = 50;
            lblMiaNhapNgay.Text = bb;

            
        }
        catch { }
        
    }
    protected void Chart5_Init(object sender, EventArgs e)
    {
        try
        {
            DateTime DateNow = DateTime.Now;
            string fromDay, toDay, thoigian = "";
            if (DateNow.Hour <= 6)
            {
                fromDay = DateNow.AddDays(-1).ToString("yyyy-MM-dd");
                toDay = DateNow.ToString("yyyy-MM-dd");
                thoigian = "gioxera>='" + fromDay + " 06:00' and gioxera<'" + toDay + " 06:00'";
            }
            else if (DateNow.Hour > 6)
            {
                fromDay = DateNow.ToString("yyyy-MM-dd");
                toDay = DateNow.AddDays(1).ToString("yyyy-MM-dd");
                thoigian = "gioxera>='" + fromDay + " 06:00' and gioxera<'" + toDay + " 06:00'";
            }

            VietSugar.getdata data5 = new VietSugar.getdata();
            string HomNay = DateTime.Now.ToString("yyy-MM-dd");
            
            string cmd5 = "select sum(((tl_xeva-tl_xera)-((tl_xeva-tl_xera)*tl_rac/100))/1000) as tluong,'DT' AS SHD from nlnhapmia nm inner join nlvungmia vm on " +
                " nm.ma_vmia = vm.ma_vmia inner join nlruongmia rm on rm.ma_rmia = nm.ma_rmia where tl_xera >0 and tl_rac>1 and so_ccs>0 and "+thoigian+" and SoHD NOT like '%HDMB%' " +
                " UNION " +
                " select sum((tl_xeva - tl_xera) / 1000) as tluong,'MB'  AS SHD from nlnhapmia nm inner" +
                " join nlvungmia vm on nm.ma_vmia = vm.ma_vmia inner  join nlruongmia rm on rm.ma_rmia = nm.ma_rmia where tl_xera >0 and tl_rac>1 and so_ccs>0 and SoHD like '%HDMB%' and "+thoigian+" ";
            Chart5.DataSource = data5.sqlcmd_ex(cmd5);
            Chart5.Series[0].XValueMember = "SHD";
            Chart5.Series[0].YValueMembers = "tluong";
            //Chart5.Series[0]["PieLabelStyle"] = "Outside";
            //Chart5.ChartAreas[0].Area3DStyle.Enable3D = true;
        }
        catch { }
    }
    protected void chartLuyKe_Init(object sender, EventArgs e)
    {
        try
        {
            VietSugar.getdata data2 = new VietSugar.getdata();
            string cmd2 = "select sum(((tl_xeva-tl_xera)-((tl_xeva-tl_xera)*tl_rac/100))/1000) as tluong,rtrim(tenhuyen) as tenhuyen from nlnhapmia nm inner join nlvungmia vm on " +
                    " nm.ma_vmia = vm.ma_vmia where tl_xera >0 and tl_rac>1 and so_ccs>0 group by tenhuyen";
            chartLuyKe.DataSource = data2.sqlcmd_ex(cmd2);
            int sum = Convert.ToInt32(data2.sqlcmd_ex(cmd2).Compute("SUM(tluong)", string.Empty));
            chartLuyKe.Series[0].XValueMember = "tenhuyen";
            chartLuyKe.Series[0].YValueMembers = "tluong";
            string aa = String.Format("{0:0,0.0}", sum);
            chartLuyKe.Titles["Title1"].Text = "Tổng trọng lượng lũy kế: " + aa + " tấn";
            chartLuyKe.Titles["Title1"].Font = new Font("Segoe UI", 10, System.Drawing.FontStyle.Bold | FontStyle.Underline);
            chartLuyKe.Titles["Title1"].ForeColor = Color.Black;
            //chartLuyKe.Titles["Title1"].Alignment = ContentAlignment.TopCenter;
            //chartLuyKe.Series[0]["PieLabelStyle"] = "Outside";
            //chartLuyKe.ChartAreas[0].Area3DStyle.Enable3D = true;
            //Chart2.ChartAreas[0].Area3DStyle.Inclination = 50;
        }
        catch { }
    }
    protected void Chart6_Init(object sender, EventArgs e)
    {
        VietSugar.getdata data6 = new VietSugar.getdata();
        string cmd6 = "select sum(((tl_xeva-tl_xera)-((tl_xeva-tl_xera)*tl_rac/100))/1000) as tluong,'DT' AS SHD from nlnhapmia nm inner join nlvungmia vm on " +
            " nm.ma_vmia = vm.ma_vmia inner join nlruongmia rm on rm.ma_rmia = nm.ma_rmia where tl_xera >0 and tl_rac>1 and so_ccs>0 and SoHD NOT like '%HDMB%' " +
            " UNION " +
            " select sum((tl_xeva - tl_xera) / 1000) as tluong,'MB'  AS SHD from nlnhapmia nm inner" +
            " join nlvungmia vm on nm.ma_vmia = vm.ma_vmia inner  join nlruongmia rm on rm.ma_rmia = nm.ma_rmia where tl_xera >0 and tl_rac>1 and so_ccs>0 and SoHD like '%HDMB%' ";
        Chart6.DataSource = data6.sqlcmd_ex(cmd6);
        Chart6.Series["data6"].XValueMember = "SHD";
        Chart6.Series["data6"].YValueMembers = "tluong";
        //Chart5.Series[0]["PieLabelStyle"] = "Outside";
        //Chart6.ChartAreas[0].Area3DStyle.Enable3D = true;
    }
    protected void chartMiaNhap10Ngay_Init(object sender, EventArgs e)
    {
        VietSugar.getdata data6 = new VietSugar.getdata();
        DataTable dt = new DataTable();
        dt.Columns.Add("dautu");
        dt.Columns.Add("muaban");
        dt.Columns.Add("tong");
        dt.Columns.Add("ng_pnm");
        dt.Columns.Add("ngay");
        string _cmd1 ="", _cmd2 = "";
        DateTime DateNow = DateTime.Now;
        for (int i = -9; i <= 0; i++)
        {
            string fromDay, toDay, thoigian = "";
            fromDay = DateNow.AddDays(i).ToString("yyyy-MM-dd");
            toDay = DateNow.AddDays(i+1).ToString("yyyy-MM-dd");
            thoigian = "gioxera>='" + fromDay + " 06:00' and gioxera<'" + toDay + " 06:00'";

            if (_cmd1 != "")
                _cmd1 += " union ";

            _cmd1 += "select IsNULL(sum(((tl_xeva-tl_xera)-((tl_xeva-tl_xera)*tl_rac/100))/1000),0) as dautu,0 as muaban,sum(((tl_xeva-tl_xera)-((tl_xeva-tl_xera)*tl_rac/100))/1000) as tong, " +
                    "'" + fromDay + "' as ng_pnm, '" + DateNow.AddDays(i).ToString("dd-MM") + "' as ngay from nlnhapmia nm inner join nlvungmia vm on " +
                    " nm.ma_vmia = vm.ma_vmia inner join nlruongmia rm on rm.ma_rmia = nm.ma_rmia where tl_xera >0 and tl_rac>1 and so_ccs>0 and SoHD NOT like '%HDMB%' and " +
            thoigian;

            // Mua bán
            if (_cmd2 != "")
                _cmd2 += " union ";

            _cmd2 += "select IsNULL(sum(((tl_xeva-tl_xera)-((tl_xeva-tl_xera)*tl_rac/100))/1000),0) as muaban," +
                    "'" + fromDay + "' as ng_pnm, '" + DateNow.AddDays(i).ToString("dd-MM") + "' as ngay from nlnhapmia nm inner join nlvungmia vm on " +
                    " nm.ma_vmia = vm.ma_vmia inner join nlruongmia rm on rm.ma_rmia = nm.ma_rmia where tl_xera >0 and tl_rac>1 and so_ccs>0 and SoHD  like '%HDMB%' and " +
                    thoigian;
        }
        _cmd1 += " order by ng_pnm";
        _cmd2 += " order by ng_pnm";
        DataTable datasql = data6.sqlcmd_ex(_cmd1);
        foreach (DataRow dr in datasql.Rows)
        {
            dt.Rows.Add(dr.ItemArray);
        }

        // Mua bán
        
        DataTable datasql2 = data6.sqlcmd_ex(_cmd2);
        if (datasql2.Rows.Count > 0)
        {
            DateTime _ng_pnm, _ng_pnm1;
            float muaban, dautu;
            for (int k = 0; k < datasql2.Rows.Count; k++)
            {
                muaban = float.Parse(datasql2.Rows[k]["muaban"].ToString());
                _ng_pnm = DateTime.Parse(datasql2.Rows[k][1].ToString().Trim());
                for (int y = 0; y < dt.Rows.Count; y++)
                {
                    dautu = float.Parse(dt.Rows[k]["dautu"].ToString());
                    _ng_pnm1 = DateTime.Parse(dt.Rows[y][3].ToString().Trim());
                    if (_ng_pnm == _ng_pnm1)
                    {
                        dt.Rows[y]["muaban"] = muaban;
                        dt.Rows[y]["tong"] = muaban + dautu;
                        break;
                    }
                }
            }
        }

        DataTable dt_ok = new DataTable();
        dt_ok.Columns.Add("dautu");
        dt_ok.Columns.Add("muaban");
        dt_ok.Columns.Add("tong");
        dt_ok.Columns.Add("ng_pnm");
        dt_ok.Columns.Add("ngay");
        foreach (DataRow row in dt.Rows)
        {
            float tong = float.Parse(row["tong"].ToString());
            if(tong >0)
                dt_ok.Rows.Add(row.ItemArray);
        }

        chartMiaNhap10Ngay.DataSource = dt_ok;
        chartMiaNhap10Ngay.Series[0].XValueMember = "ngay";
        chartMiaNhap10Ngay.Series[0].YValueMembers = "muaban";
        chartMiaNhap10Ngay.Series[1].XValueMember = "ngay";
        chartMiaNhap10Ngay.Series[1].YValueMembers = "dautu";
        chartMiaNhap10Ngay.Series[2].XValueMember = "ngay";
        chartMiaNhap10Ngay.Series[2].YValueMembers = "tong";
        chartMiaNhap10Ngay.Series[3].XValueMember = "ngay";
        chartMiaNhap10Ngay.Series[3].YValueMembers = "tong";

        chartMiaNhap10Ngay.Series[0].Name = "Mía tự do";
        chartMiaNhap10Ngay.Series[1].Name = "Mía đầu tư";
        chartMiaNhap10Ngay.Series[2].Name = "Tổng";
        chartMiaNhap10Ngay.Series[3].Name = " ";
    }
    protected void chartSLNhapTheoHuyen_Init(object sender, EventArgs e)
    {
        VietSugar.getdata data6 = new VietSugar.getdata();

        string cmd7 = "select tb,py,dl,nth,kh,d.ng_pnm,STR(DAY(d.ng_pnm),2)+'-'+STR(month(d.ng_pnm),2) as ngay from " +

                    "(select sum(gtchi_m)/ SUM((tl_xeva - tl_xera) - ((tl_xeva - tl_xera) * tl_rac) / 100) as TB,ng_pnm from nlnhapmia nm  " +
                    "inner join nlvungmia vm on nm.ma_vmia = vm.ma_vmia where  code_dk = '1111' group by ng_pnm)e  " +


                    "FULL OUTER JOIN (select sum(gtchi_m)/ SUM((tl_xeva - tl_xera) - ((tl_xeva - tl_xera) * tl_rac) / 100) as KH,ng_pnm from nlnhapmia nm  " +
                    "inner join nlvungmia vm on nm.ma_vmia = vm.ma_vmia where  vm.ma_pl not in ('NTH', 'DLK', 'PHY') and code_dk = '1111' group by ng_pnm)d  "+

                    "on d.ng_pnm = e.ng_pnm  " +

                    "FULL OUTER JOIN(select sum(gtchi_m) / SUM((tl_xeva - tl_xera) - ((tl_xeva - tl_xera) * tl_rac) / 100) as DL, ng_pnm from nlnhapmia nm   "+
                    "inner join nlvungmia vm on nm.ma_vmia = vm.ma_vmia where  vm.ma_pl = 'DLK' and code_dk = '1111' group  by ng_pnm)b "+
 
                    "on d.ng_pnm = b.ng_pnm  "+
                    "FULL OUTER JOIN(select sum(gtchi_m)/ SUM((tl_xeva - tl_xera) - ((tl_xeva - tl_xera) * tl_rac) / 100) as nth,ng_pnm from nlnhapmia nm  "+
                    "inner join nlvungmia vm on nm.ma_vmia = vm.ma_vmia where  vm.ma_pl = 'NTH' and code_dk = '1111'group by ng_pnm)c  "+

                    "on c.ng_pnm = d.ng_pnm   "+
                    "FULL OUTER JOIN(select sum(gtchi_m)/SUM((tl_xeva-tl_xera)-((tl_xeva-tl_xera)*tl_rac)/100) as py,ng_pnm from nlnhapmia nm  "+
                    "inner join nlvungmia vm on nm.ma_vmia = vm.ma_vmia where  vm.ma_pl = 'PHY' and code_dk = '1111' group by ng_pnm)a "+

                    "on d.ng_pnm = a.ng_pnm  "+
                    "order by d.ng_pnm ";

        DataTable data = data6.sqlcmd_ex(cmd7);
        chartSLNhapTheoHuyen.DataSource = data;
        chartSLNhapTheoHuyen.ChartAreas[0].AxisY.Minimum = 800;
        chartSLNhapTheoHuyen.Series[0].XValueMember = "ngay";
        chartSLNhapTheoHuyen.Series[0].YValueMembers = "py";
        chartSLNhapTheoHuyen.Series[1].XValueMember = "ngay";
        chartSLNhapTheoHuyen.Series[1].YValueMembers = "dl";
        chartSLNhapTheoHuyen.Series[2].XValueMember = "ngay";
        chartSLNhapTheoHuyen.Series[2].YValueMembers = "nth";
        chartSLNhapTheoHuyen.Series[3].XValueMember = "ngay";
        chartSLNhapTheoHuyen.Series[3].YValueMembers = "kh";
        chartSLNhapTheoHuyen.Series[4].XValueMember = "ngay";
        chartSLNhapTheoHuyen.Series[4].YValueMembers = "tb";
    }
    protected void chartCCS10Ngay_Init(object sender, EventArgs e)
    {
        try
        {
            //load data chart CCS
            VietSugar.getdata data4 = new VietSugar.getdata();
            string cmd4 = "select cast(sum(((tl_xeva-tl_xera)-((tl_xeva-tl_xera)*tl_rac/100))*so_ccs)/sum((tl_xeva-tl_xera)-((tl_xeva-tl_xera)*tl_rac/100)) as decimal(10,2)) as ccsbq,ng_pnm,STR(DAY(ng_pnm),2)+'-'+STR(month(ng_pnm),2) as ngay " +
                " from NLnhapmia where tl_xera >0 and tl_rac>1 and so_ccs>0  group by ng_pnm order by ng_pnm";

            chartCCS10Ngay.DataSource = data4.sqlcmd_ex(cmd4);
            double max = Convert.ToDouble(data4.sqlcmd_ex(cmd4).Compute("Max(ccsbq)", string.Empty));
            double min = Convert.ToDouble(data4.sqlcmd_ex(cmd4).Compute("Min(ccsbq)", string.Empty));
            //Chart4.Series["rac"].YValueMembers = "racbq";

            chartCCS10Ngay.ChartAreas[0].AxisY.Maximum = max + 0.02;
            chartCCS10Ngay.ChartAreas[0].AxisY.Minimum = min - 0.02;
        }
        catch { }
    }
    protected void chartRac10Ngay_Init(object sender, EventArgs e)
    {
        try
        {
            VietSugar.getdata dataRac = new VietSugar.getdata();
            string cmdRac = "select cast(sum(((tl_xeva-tl_xera))*tl_rac)/sum((tl_xeva-tl_xera)) as decimal(10,2)) as racbq,ng_pnm,STR(DAY(ng_pnm),2)+'-'+STR(month(ng_pnm),2) as ngay " +
                " from NLnhapmia where tl_xera >0 and tl_rac>1 and so_ccs>0  group by ng_pnm order by ng_pnm";
            chartRac10Ngay.DataSource = dataRac.sqlcmd_ex(cmdRac);
            double maxRac = Convert.ToDouble(dataRac.sqlcmd_ex(cmdRac).Compute("Max(racbq)", string.Empty));
            double minRac = Convert.ToDouble(dataRac.sqlcmd_ex(cmdRac).Compute("Min(racbq)", string.Empty));
            //Chart4.Series["rac"].YValueMembers = "racbq";
            chartRac10Ngay.ChartAreas[0].AxisY.Maximum = maxRac + 0.02;
            chartRac10Ngay.ChartAreas[0].AxisY.Minimum = minRac - 0.02;
        }
        catch { }
    }
}   