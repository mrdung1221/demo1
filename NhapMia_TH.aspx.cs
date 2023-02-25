using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using System.Drawing;

public partial class NhapMia_TH : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["TaiKhoan"] == null)
        {
            Response.Redirect("~/DangNhap.aspx");
        }
        else
        {
            string key = "thmn";
            string taikhoan = Session["TaiKhoan"].ToString();
            VietSugar.User u = new VietSugar.User();
            if (u.CheckQuyen(taikhoan, key) == false)
                Response.Redirect("~/CanhBao.aspx");
        }

        if (!IsPostBack)
        {
            string strLuyKe = Request.QueryString["LuyKe"];
            if (strLuyKe != null)
            {
                radLuyKe.Checked = !radLuyKe.Checked;
                LuyKe();
            }
            else 
            {
                radNgay.Checked = true;
                VietSugar.MiaNguyenLieu mia = new VietSugar.MiaNguyenLieu();
                CultureInfo provider = CultureInfo.InvariantCulture;
                DateTime DateNow = DateTime.Now;
                string fromDay, toDay, ThoiGian = "";
                if (DateNow.Hour <= 6)
                {
                    fromDay = DateNow.AddDays(-1).ToString("yyyy-MM-dd");
                    toDay = DateNow.ToString("yyyy-MM-dd");
                    ThoiGian = "and gioxera>='" + fromDay + " 06:00' and gioxera<'" + toDay + " 06:00'";

                    txtTuNgay.Text = DateNow.AddDays(-1).ToString("yyyy-MM-dd");
                }
                else if (DateNow.Hour > 6)
                {
                    fromDay = DateNow.ToString("yyyy-MM-dd");
                    toDay = DateNow.AddDays(1).ToString("yyyy-MM-dd");
                    ThoiGian = "and gioxera>='" + fromDay + " 06:00' and gioxera<'" + toDay + " 06:00'";

                    txtTuNgay.Text = DateNow.ToString("yyyy-MM-dd");
                }

                GetData(ThoiGian);
            }

            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            txtYear.Text = year;
            dropThang.SelectedValue = month;

            


            GridView1.FooterStyle.BackColor = Color.Bisque;
            GridView1.FooterStyle.ForeColor = Color.Blue;

        }
    }

    DataTable dt;

    protected void btnGetData_Click(object sender, EventArgs e)
    {
        //ClearText();
        VietSugar.MiaNguyenLieu mia = new VietSugar.MiaNguyenLieu();
        CultureInfo provider = CultureInfo.InvariantCulture;
        string ThoiGian = "";
        
        string fromDay, toDay, month, year;
        DateTime selectFromDate;

        if (radNgay.Checked)
        {
            if (txtTuNgay.Text.Trim() == "") return;
            selectFromDate = DateTime.ParseExact(txtTuNgay.Text, "yyyy-MM-dd", provider);
            fromDay = selectFromDate.ToString("yyyy-MM-dd");
            toDay = selectFromDate.AddDays(1).ToString("yyyy-MM-dd");
            ThoiGian = "and gioxera>'" + fromDay + " 06:00' and gioxera<='" + toDay + " 06:00'";
        }
        if (radNhieuNgay.Checked)
        {
            if (txtTuNgay.Text.Trim() == "") return;
            if (txtDenNgay.Text.Trim() == "") return;
            selectFromDate = DateTime.ParseExact(txtTuNgay.Text, "yyyy-MM-dd", provider);
            fromDay = selectFromDate.ToString("yyyy-MM-dd");
            DateTime selectToDate = DateTime.ParseExact(txtDenNgay.Text, "yyyy-MM-dd", provider);
            toDay = selectToDate.ToString("yyyy-MM-dd");
            ThoiGian = "and gioxera>'" + fromDay + " 06:00' and gioxera<='" + toDay + " 06:00'";
        }

        if (radThang.Checked)
        {
            month = dropThang.SelectedItem.ToString();
            int next_month;
            next_month = int.Parse(month)+1;
            year = txtYear.Text.Trim();
            //ThoiGian = "month(gioxera)=" + month + " and year(gioxera)=" + year;
            ThoiGian = "and gioxera>'" + year + "-" + month + "-01 06:00' and gioxera<='" + year + "-" + next_month + "-01 06:00'";
        }


        GetData(ThoiGian);
    }

    decimal total_chuyen = 0;
    decimal total_tho = 0;
    decimal total_tinh = 0;
    decimal total_dautu = 0;
    decimal total_tudo = 0;
    decimal total_ccsBQ = 0;
    decimal total_RacBQ = 0;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    Label lblChuyen = (e.Row.FindControl("lblChuyen") as Label);
        //    total_chuyen += Convert.ToDecimal(lblChuyen.Text);

        //    Label lblTho = (e.Row.FindControl("lblTho") as Label);
        //    total_tho += Convert.ToDecimal(lblTho.Text);

        //    Label lblTinh = (e.Row.FindControl("lblTinh") as Label);
        //    total_tinh += Convert.ToDecimal(lblTinh.Text);

        //    Label lblTuDo = (e.Row.FindControl("lblTuDo") as Label);
        //    total_tudo += Convert.ToDecimal(lblTuDo.Text);

        //    Label lblDauTu = (e.Row.FindControl("lblDauTu") as Label);
        //    total_dautu += Convert.ToDecimal(lblDauTu.Text);

        //    decimal tinh, ccs, rac, tho;
        //    tinh = Convert.ToDecimal(lblTinh.Text);
        //    Label lblCCS = (e.Row.FindControl("lblCCS") as Label);
        //    ccs = Convert.ToDecimal(lblCCS.Text);
        //    total_ccsBQ += (tinh * ccs);

        //    Label lblRac = (e.Row.FindControl("lblRac") as Label);
        //    rac = Convert.ToDecimal(lblRac.Text);
        //    tho = Convert.ToDecimal(lblTho.Text);
        //    total_RacBQ += (tho * rac);
        //}
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            total_chuyen = Convert.ToDecimal(dt.Compute("SUM(sochuyen)", string.Empty));
            Label lblTongChuyen = (e.Row.FindControl("lblTongChuyen") as Label);
            lblTongChuyen.Text =  total_chuyen.ToString();

            total_tho = Convert.ToDecimal(dt.Compute("SUM(tho)", string.Empty));
            Label lblTongTho = (e.Row.FindControl("lblTongTho") as Label);
            lblTongTho.Text = String.Format("{0:0,0}", total_tho);

            total_tinh = Convert.ToDecimal(dt.Compute("SUM(tinh)", string.Empty));
            Label lblTongTinh = (e.Row.FindControl("lblTongTinh") as Label);
            lblTongTinh.Text = String.Format("{0:0,0}", total_tinh);

            total_tudo = Convert.ToDecimal(dt.Compute("SUM(slg_tudo)", string.Empty));
            Label lblTongTuDo = (e.Row.FindControl("lblTongTuDo") as Label);
            lblTongTuDo.Text = String.Format("{0:0,0}", total_tudo);

            total_dautu = Convert.ToDecimal(dt.Compute("SUM(slg_dautu)", string.Empty));
            Label lblTongDauTu = (e.Row.FindControl("lblTongDauTu") as Label);
            lblTongDauTu.Text = String.Format("{0:0,0}", total_dautu);

            decimal tinh, ccs,tho,rac;
            foreach (DataRow row in dt.Rows)
            {
                tinh = decimal.Parse(row["tinh"].ToString());
                ccs = decimal.Parse(row["ccsBQ"].ToString());
                total_ccsBQ += tinh * ccs;

                tho = decimal.Parse(row["tho"].ToString());
                rac = decimal.Parse(row["racbq"].ToString());
                total_RacBQ += tho * rac;
            }

            Label lblTongCCS = (e.Row.FindControl("lblTongCCS") as Label);
            lblTongCCS.Text = String.Format("{0:0.00}", total_ccsBQ / total_tinh);

            Label lblTongRac = (e.Row.FindControl("lblTongRac") as Label);
            lblTongRac.Text = String.Format("{0:0.000}", total_RacBQ / total_tho);

            Label lblTongTongTien = (e.Row.FindControl("lblTongTongTien") as Label);
            lblTongTongTien.Text = String.Format("{0:0,0}", tongTongTien);

            Label lblTongDonGiaCBBQ = (e.Row.FindControl("lblTongDonGiaCBBQ") as Label);
            double tongDonGiaCBBQ = tongTongTien / (Decimal.ToDouble(total_tinh)/1000);
            lblTongDonGiaCBBQ.Text = String.Format("{0:0,0}", tongDonGiaCBBQ);

            decimal ccs_max = Convert.ToDecimal(dt.Compute("Max(ccs_max)", string.Empty));
            Label lblCCSMax = (e.Row.FindControl("lblCCSMax") as Label);
            lblCCSMax.Text = String.Format("{0:0.00}", ccs_max);
            decimal ccs_min = Convert.ToDecimal(dt.Compute("Min(ccs_min)", string.Empty));
            Label lblCCSMin = (e.Row.FindControl("lblCCSMin") as Label);
            lblCCSMin.Text = String.Format("{0:0.00}", ccs_min);

            decimal rac_max = Convert.ToDecimal(dt.Compute("Max(rac_max)", string.Empty));
            Label lblRacMax = (e.Row.FindControl("lblRacMax") as Label);
            lblRacMax.Text = String.Format("{0:0.00}", rac_max);
            decimal rac_min = Convert.ToDecimal(dt.Compute("Min(rac_min)", string.Empty));
            Label lblRacMin = (e.Row.FindControl("lblRacMin") as Label);
            lblRacMin.Text = String.Format("{0:0.00}", rac_min);

            decimal chikhac = Convert.ToDecimal(dt.Compute("Sum(chikhac)", string.Empty));
            Label lblTongChiKhac = (e.Row.FindControl("lblTongChiKhac") as Label);
            lblTongChiKhac.Text = String.Format("{0:0,0}", chikhac);

            decimal tienmia = Convert.ToDecimal(dt.Compute("Sum(tongtienmia)", string.Empty));
            Label lblTongTienMia = (e.Row.FindControl("lblTongTienMia") as Label);
            lblTongTienMia.Text = String.Format("{0:0,0}", tienmia);

            decimal TongDonGiaBQ = tienmia / (total_tinh / 1000);
            Label lblTongDonGiaBQ = (e.Row.FindControl("lblTongDonGiaBQ") as Label);
            lblTongDonGiaBQ.Text = String.Format("{0:0,0}", TongDonGiaBQ);
        }
    }

    double tongTongTien = 0;
    private void GetData(string ThoiGian)
    {
        DataTable dt2, dt3 = new DataTable();

        VietSugar.getdata vsg = new VietSugar.getdata();
        string cmd = "select rtrim(tenhuyen) as tenhuyen, count(*) as sochuyen, SUM(tl_xeva-tl_xera)/count(*) as tl_bq,0 as slg_tudo,0 as slg_dautu,0.1 as tongtien, " +
                "  SUM(tl_xeva - tl_xera) as tho, SUM(cast((tl_xeva - tl_xera) - (tl_xeva - tl_xera) * tl_rac / 100 as decimal(10,0))) as tinh," +
                " SUM(((tl_xeva - tl_xera) - (tl_xeva - tl_xera) * tl_rac / 100) * so_ccs) / SUM((tl_xeva - tl_xera) - (tl_xeva - tl_xera) * tl_rac / 100) as ccsBQ ," +
                " SUM((tl_xeva - tl_xera) * tl_rac) / SUM(tl_xeva - tl_xera) as racbq," +
                " SUM(CAST(CAST((CAST( cd_dgm*so_ccs  as decimal(10,0))* cast((tl_xeva - tl_xera)*(100-tl_rac)/100 as decimal(10,0)))/1000 as decimal(10,0))* (cd_perc/100)as decimal(10,0))) as tienmia," +
                "SUM(((tl_xeva - tl_xera) - (tl_xeva - tl_xera) * tl_rac / 100) * cd_mtg1)/1000 as hotro1," +
                "SUM(((tl_xeva - tl_xera) - (tl_xeva - tl_xera) * tl_rac / 100) * cd_mtg2)/1000 as hotro2" +
                ",max(so_ccs) ccs_max, min(so_ccs) ccs_min,max(tl_rac) rac_max, min(tl_rac) rac_min," +
                "sum(cast((cast((tl_xeva - tl_xera) - (tl_xeva - tl_xera) * tl_rac / 100 as decimal(10,0)) * (NM.vm_gvc + nm.vm_gbm + nm.vm_gbx )) / 1000 as  decimal(10,0) )) as chikhac" +
                "  from NLnhapmia nm inner join nlvungmia vm on vm.ma_vmia = nm.ma_vmia" +
                 " inner join nlruongmia rm on rm.ma_rmia = nm.ma_rmia where so_ccs>0 and tl_xera>0 and tl_rac>1 " + ThoiGian + " group by rtrim(tenhuyen)" +
                 " order by tenhuyen";
        dt = vsg.sqlcmd_ex(cmd);

        string cmd2 = " select SUM(cast((tl_xeva - tl_xera) - (tl_xeva - tl_xera) * tl_rac / 100 as decimal(10,0))) as slg_tudo, rtrim(tenhuyen) as tenhuyen   from NLnhapmia nm inner join nlvungmia vm on vm.ma_vmia = nm.ma_vmia " +
                        " inner join nlruongmia rm on rm.ma_rmia = nm.ma_rmia where so_ccs>0 and tl_xera>0 and tl_rac>1 and rm.loai_hd = 1 " + ThoiGian + " group by rtrim(tenhuyen) ";
        dt2 = vsg.sqlcmd_ex(cmd2);// slg tu do

        string cmd3 = " select SUM(cast((tl_xeva - tl_xera) - (tl_xeva - tl_xera) * tl_rac / 100 as decimal(10,0))) as slg_dautu, rtrim(tenhuyen) as tenhuyen   from NLnhapmia nm inner join nlvungmia vm on vm.ma_vmia = nm.ma_vmia " +
                        " inner join nlruongmia rm on rm.ma_rmia = nm.ma_rmia where so_ccs>0 and tl_xera>0 and tl_rac>1 and rm.loai_hd = 0 " + ThoiGian + " group by rtrim(tenhuyen) ";
        dt3 = vsg.sqlcmd_ex(cmd3);// slg đầu tư

        for (int k = 0; k < dt2.Rows.Count; k++)
        {
            float slg_tudo = float.Parse(dt2.Rows[k]["slg_tudo"].ToString());
            string tenhuyen = dt2.Rows[k]["tenhuyen"].ToString();
            for (int y = 0; y < dt.Rows.Count; y++)
            {
                float slgtinh = float.Parse(dt.Rows[y]["tinh"].ToString());
                string tenhuyen1 = dt.Rows[y]["tenhuyen"].ToString();
                if (tenhuyen == tenhuyen1)
                {
                    dt.Rows[y][3] = slg_tudo;
                    break;
                }
            }
        }
        for (int k = 0; k < dt3.Rows.Count; k++)
        {
            float slg_dautu = float.Parse(dt3.Rows[k]["slg_dautu"].ToString());
            string tenhuyen = dt3.Rows[k]["tenhuyen"].ToString();
            for (int y = 0; y < dt.Rows.Count; y++)
            {
                float slgtinh = float.Parse(dt.Rows[y]["tinh"].ToString());
                string tenhuyen1 = dt.Rows[y]["tenhuyen"].ToString();
                if (tenhuyen == tenhuyen1)
                {
                    // dt.Rows[y][3] = slg_tudo;
                    dt.Rows[y][4] = slg_dautu;
                }
            }
            
        }
        //Thêm tổng tiền = tiền mía + hỗ trợ 1 + hỗ trợ 2
        dt.Columns.Add("dongiaBQ", typeof(double));
        dt.Columns.Add("tongtienmia", typeof(double));
        dt.Columns.Add("tongdongiabq", typeof(double));
        double tongtien_muamia = 0, tongdongiabq=0;
        for (int k = 0; k < dt.Rows.Count; k++)
        {
            // dùng double sẽ hiện số đầy đủ, dùng float sẽ làm tròn số
            double tienmia = double.Parse(dt.Rows[k]["tienmia"].ToString());
            float hotro1 = float.Parse(dt.Rows[k]["hotro1"].ToString());
            float hotro2 = float.Parse(dt.Rows[k]["hotro2"].ToString());
            double tongtien = tienmia +hotro1 + hotro2;
            dt.Rows[k][5] = tongtien;
            // tính đơn giá bình quân
            float tinh = float.Parse(dt.Rows[k]["tinh"].ToString());
            double dongiaBQ = tongtien / (tinh/1000);
            dt.Rows[k]["dongiaBQ"] = dongiaBQ;

            tongTongTien += tongtien;

            tongtien_muamia = double.Parse(dt.Rows[k]["chikhac"].ToString()) + double.Parse(dt.Rows[k]["tienmia"].ToString());
            dt.Rows[k]["tongtienmia"] = tongtien_muamia;

            tongdongiabq = tongtien_muamia / (tinh / 1000);
            dt.Rows[k]["tongdongiabq"] = tongdongiabq;
        }

        GridView1.DataSource = dt;
        GridView1.DataBind();
        DataTable dt_tinh = new DataTable();
        dt_tinh.Columns.Add("tinh");
        dt_tinh.Columns.Add("tenhuyen");
        double tinh_kg = 0;
        foreach (DataRow row in dt.Rows)
        {
            tinh_kg = double.Parse(row["tinh"].ToString()) / 1000;
            dt_tinh.Rows.Add(tinh_kg, row["tenhuyen"]);
        }

        Chart1.DataSource = dt_tinh;
        Chart1.DataBind();
        Chart2.DataSource = dt;
        Chart2.ChartAreas[0].AxisY.Maximum = 15;
        Chart2.DataBind();

        DataTable dt_dongia = new DataTable();
        dt_dongia.Columns.Add("dongiaBQ");
        dt_dongia.Columns.Add("tongdongiabq");
        dt_dongia.Columns.Add("tenhuyen");
        double dongiaBQ2 = 0, tongdongiabq2=0;
        foreach (DataRow row in dt.Rows)
        {
            dongiaBQ2 = double.Parse(row["dongiaBQ"].ToString()) / 1000;
            tongdongiabq2 = double.Parse(row["tongdongiabq"].ToString()) / 1000;
            dt_dongia.Rows.Add(dongiaBQ2, tongdongiabq2, row["tenhuyen"]);
        }
        
        Chart3.DataSource = dt_dongia;
        Chart3.ChartAreas[0].AxisY.Maximum = 1700;
        Chart3.DataBind();
    }
    
    protected void radNhieuNgay_CheckedChanged(object sender, EventArgs e)
    {
        txtDenNgay.Visible = true;
        txtTuNgay.Visible = true;
        dropThang.Visible = false;
        txtYear.Visible = false;
        lblLuyKe.Visible = false;
        btnGetData.Visible = true;

        //ClearText();
    }
    protected void radThang_CheckedChanged(object sender, EventArgs e)
    {
        dropThang.Visible = true;
        txtYear.Visible = true;
        txtDenNgay.Visible = false;
        txtTuNgay.Visible = false;
        lblLuyKe.Visible = false;
        btnGetData.Visible = true;

        //ClearText();
    }
    protected void radLuyKe_CheckedChanged(object sender, EventArgs e)
    {
        LuyKe();
    }
    protected void radNgay_CheckedChanged(object sender, EventArgs e)
    {
        txtTuNgay.Visible = true;
        txtDenNgay.Visible = false;
        dropThang.Visible = false;
        txtYear.Visible = false;
        lblLuyKe.Visible = false;

        btnGetData.Visible = true;
        //ClearText();
    }

    private void LuyKe()
    {
        lblLuyKe.Visible = true;
        txtYear.Visible = false;
        txtDenNgay.Visible = false;
        txtTuNgay.Visible = false;
        dropThang.Visible = false;
        lblLuyKe.Text = "";
        btnGetData.Visible = false;

        VietSugar.MiaNguyenLieu mia = new VietSugar.MiaNguyenLieu();
        string fromDay, toDay;
        mia.Get_NgayBatDau();
        mia.Get_NgayKetThuc();
        fromDay = mia.NgayBatDau.ToString("yyyy-MM-dd HH:mm");
        toDay = mia.NgayKetThuc.ToString("yyyy-MM-dd HH:mm:ss");
        //ThoiGian = "gioxera>='" + fromDay + "' and gioxera<='" + toDay + "'";
        lblLuyKe.Visible = true;
        lblLuyKe.Text = "Tính lũy kế từ ngày: " + mia.NgayBatDau.ToString("dd-MM-yyyy HH:mm") + " đến ngày: " + mia.NgayKetThuc.ToString("dd-MM-yyyy HH:mm") + "<br />";

        GetData(string.Empty);
    }
    
    //public void ClearText()
    //{
    //    lblTho.Text = "";
    //    lblTinh.Text = "";
    //    lblCCS.Text = "";
    //    lblRac.Text = "";
    //    lblXe.Text = "";
    //}
}