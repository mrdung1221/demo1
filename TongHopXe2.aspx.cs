using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;

public partial class TongHopXe2 : System.Web.UI.Page
{
    DataTable dulieu;
    VietSugar.getdata vsg = new VietSugar.getdata();
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

        dulieu = new DataTable();
        dulieu.Columns.Add("Soxe");
        dulieu.Columns.Add("gio");
        DataTable dt, dt3 = new DataTable();
        //VietSugar.getdata vsg = new VietSugar.getdata();
        string cmd = "select min(ng_lnm) as min, max(ng_lnm) as max from nlnhapmia where year(gioxeve)<>1900 ";
        dt = vsg.sqlcmd_ex(cmd);
        DateTime tim = DateTime.Parse(dt.Rows[0]["min"].ToString());
        DateTime tim2 = DateTime.Parse(dt.Rows[0]["max"].ToString());
        vonglap(tim, tim2);
        GridView1.DataSource = dulieu;
        GridView1.DataBind();
        Chart1.DataSource = dulieu;
        Chart1.Series[0].XValueMember = "gio";
        Chart1.Series[0].YValueMembers = "Soxe";
 
        Chart1.Series[1].YValueMembers = "Soxe";

    }
    protected void vonglap(DateTime ngaymin, DateTime ngaymax)
    {
        string cmd = "select count(distinct ng_lnm) as soluong from nlnhapmia where tl_xeva > 0";
        DataTable dt;
        dt = vsg.sqlcmd_ex(cmd);
        int slg = int.Parse(dt.Rows[0]["soluong"].ToString());
        for (int k = 1; k <= 24; k++)
        {
            int demxe = 0;
            DateTime ngaysql = ngaymin;
            int demngay = 0;
            while (ngaysql < ngaymax)
            {
               
                string ThoiGian = "";
                string dm1 = ngaysql.ToString("MM-dd-yyyy");
                switch (k)
                {
                    case 1:
                        ThoiGian = " and gioxeve>='" + dm1 + " 00:00' and gioxeve<'" + dm1 + " 01:00'";
                        break;
                    case 2:
                        ThoiGian = " and gioxeve>='" + dm1 + " 01:01' and gioxeve<='" + dm1 + " 02:00'";
                        break;
                    case 3:
                        ThoiGian = " and gioxeve>='" + dm1 + " 02:01' and gioxeve<='" + dm1 + " 03:00'";
                        break;
                    case 4:
                        ThoiGian = " and gioxeve>='" + dm1 + " 03:01' and gioxeve<='" + dm1 + " 04:00'";
                        break;
                    case 5:
                        ThoiGian = " and gioxeve>='" + dm1 + " 04:01' and gioxeve<='" + dm1 + " 05:00'";
                        break;
                    case 6:
                        ThoiGian = " and gioxeve>='" + dm1 + " 05:01' and gioxeve<='" + dm1 + " 06:00'";
                        break;
                    case 7:
                        ThoiGian = " and gioxeve>='" + dm1 + " 06:01' and gioxeve<='" + dm1 + " 07:00'";
                        break;
                    case 8:
                        ThoiGian = " and gioxeve>='" + dm1 + " 07:01' and gioxeve<='" + dm1 + " 08:00'";
                        break;
                    case 9:
                        ThoiGian = " and gioxeve>='" + dm1 + " 08:01' and gioxeve<='" + dm1 + " 09:00'";
                        break;
                    case 10:
                        ThoiGian = " and gioxeve>='" + dm1 + " 09:01' and gioxeve<='" + dm1 + " 10:00'";
                        break;
                    case 11:
                        ThoiGian = " and gioxeve>='" + dm1 + " 10:01' and gioxeve<='" + dm1 + " 11:00'";
                        break;
                    case 12:
                        ThoiGian = " and gioxeve>='" + dm1 + " 11:01' and gioxeve<='" + dm1 + " 12:00'";
                        break;
                    case 13:
                        ThoiGian = " and gioxeve>='" + dm1 + " 12:01' and gioxeve<='" + dm1 + " 13:00'";
                        break;
                    case 14:
                        ThoiGian = " and gioxeve>='" + dm1 + " 13:01' and gioxeve<='" + dm1 + " 14:00'";
                        break;
                    case 15:
                        ThoiGian = " and gioxeve>='" + dm1 + " 14:01' and gioxeve<='" + dm1 + " 15:00'";
                        break;
                    case 16:
                        ThoiGian = " and gioxeve>='" + dm1 + " 15:01' and gioxeve<='" + dm1 + " 16:00'";
                        break;
                    case 17:
                        ThoiGian = " and gioxeve>='" + dm1 + " 16:01' and gioxeve<='" + dm1 + " 17:00'";
                        break;
                    case 18:
                        ThoiGian = " and gioxeve>='" + dm1 + " 17:01' and gioxeve<='" + dm1 + " 18:00'";
                        break;
                    case 19:
                        ThoiGian = " and gioxeve>='" + dm1 + " 18:01' and gioxeve<='" + dm1 + " 19:00'";
                        break;
                    case 20:
                        ThoiGian = " and gioxeve>='" + dm1 + " 19:00' and gioxeve<'" + dm1 + " 20:00'";
                        break;
                    case 21:
                        ThoiGian = " and gioxeve>='" + dm1 + " 20:01' and gioxeve<='" + dm1 + " 21:00'";
                        break;
                    case 22:
                        ThoiGian = " and gioxeve>='" + dm1 + " 21:01' and gioxeve<='" + dm1 + " 22:00'";
                        break;
                    case 23:
                        ThoiGian = " and gioxeve>='" + dm1 + " 22:01' and gioxeve<='" + dm1 + " 23:00'";
                        break;
                    case 24:
                        ThoiGian = " and gioxeve>='" + dm1 + " 23:01' and gioxeve<='" + dm1 + " 23:59'";
                        break;

                }
                demngay = demngay + 1;
                DataTable dlsql;
                VietSugar.getdata vsg1 = new VietSugar.getdata();
                string cmdsql1 = "select count(*)as soxe from nlnhapmia where code_dk = '1111'  " + ThoiGian + "  ";
                dlsql = vsg1.sqlcmd_ex(cmdsql1);
                foreach (DataRow dr in dlsql.Rows)
                {
                    //dulieu.Rows.Add(dr.ItemArray);
                    demxe = demxe + int.Parse(dlsql.Rows[0]["soxe"].ToString());
                }
                
                ngaysql = ngaysql.AddDays(1);
            }
            dulieu.Rows.Add(demxe / slg, k);
            //i++;
        }
    }
}