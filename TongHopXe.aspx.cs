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

public partial class TongHopXe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Chart1.DataSource = XeTheoGio();
        Chart1.Series[0].XValueMember = "gio";
        Chart1.Series[0].YValueMembers = "Soxe";
 
        Chart1.Series[1].YValueMembers = "Soxe";
    }
    protected DataTable XeTheoGio()
    {
        VietSugar.getdata vsg = new VietSugar.getdata();
        DataTable dulieu = new DataTable();
        dulieu.Columns.Add("Soxe");
        dulieu.Columns.Add("gio");
        DateTime DateNow = DateTime.Now;
        string toDay;
        toDay = DateNow.ToString("yyyy-MM-dd");

        string cmd = "select count(distinct ng_lnm) as soluong from nlnhapmia where code_dk = '1111' and ng_lnm< '" + toDay + "'" ;
        DataTable dt_slg = vsg.sqlcmd_ex(cmd);
        int slg = int.Parse(dt_slg.Rows[0]["soluong"].ToString());
        string ThoiGian = "";
        int demxe = 0;
        DataTable dl_demxe;
        
        for (int hour = 1; hour <= 24; hour++)
        {
            ThoiGian = " and DATEPART(hour, gioxeve) >= " + (hour - 1).ToString() + " and DATEPART(hour, gioxeve) <" + hour;
            cmd = "select count(*)as soxe from nlnhapmia where code_dk = '1111'  " + ThoiGian ;
            dl_demxe = vsg.sqlcmd_ex(cmd);
            demxe = int.Parse(dl_demxe.Rows[0]["soxe"].ToString());

            dulieu.Rows.Add(demxe / slg, hour);
        }
        
        return dulieu;
    }

    protected void Chart2_Load(object sender, EventArgs e)
    {
        string tinh = "%%";
        string cmd7 = "select count(*)as soxe,ng_pnm from nlnhapmia nm " +
            " inner join nlvungmia vm on nm.ma_vmia =  vm.ma_vmia where year(gioxeve)>2000 and tentinh like '" + tinh + "' group by ng_pnm order by ng_pnm";
        VietSugar.getdata data6 = new VietSugar.getdata();
        DataTable data = data6.sqlcmd_ex(cmd7);
        Chart2.DataSource = data;

        Chart2.Series[0].XValueMember = "ng_pnm";
        Chart2.Series[0].YValueMembers = "soxe";
        // string cmd7 = "select count(*)as soxe,ng_pnm from nlnhapmia where code_dk ='1111' group by ng_pnm order by ng_pnm";
        // VietSugar.getdata data6 = new VietSugar.getdata();
        // DataTable data = data6.sqlcmd_ex(cmd7);
        // Chart2.DataSource = data;
        //// Chart2.ChartAreas[0].AxisY.Minimum = 900;
        // Chart2.Series[0].XValueMember = "ng_pnm";
        // Chart2.Series[0].YValueMembers = "soxe";

    }

    protected void DropDownList1_Load(object sender, EventArgs e)
    {
        //string cmd7 = "select distinct tentinh as tinh from nlnhapmia nm " +
        //    " inner join nlvungmia vm on nm.ma_vmia =  vm.ma_vmia where code_dk ='1111' ";
        //VietSugar.getdata data6 = new VietSugar.getdata();
        //DataTable data = data6.sqlcmd_ex(cmd7);
        //DropDownList1.DataSource = data;
        //DropDownList1.DataTextField = "Tinh";
        //DropDownList1.DataValueField = "Tinh";
        //DropDownList1.DataBind();
        //Chart2.ChartAreas[0].AxisY.Minimum = 900;

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
       string tinh = DropDownList1.SelectedItem.ToString();
        string qrdk = tinh;
        if(tinh == "ALL")
        {
            qrdk = "%%";
        }    
        string cmd7 = "select count(*)as soxe,ng_pnm from nlnhapmia nm " +
            " inner join nlvungmia vm on nm.ma_vmia =  vm.ma_vmia where code_dk ='1111' and tentinh like '" + qrdk + "'    group by ng_pnm order by ng_pnm";
        VietSugar.getdata data6 = new VietSugar.getdata();
        DataTable data = data6.sqlcmd_ex(cmd7);
        Chart2.DataSource = data;

        Chart2.Series[0].XValueMember = "ng_pnm";
        Chart2.Series[0].YValueMembers = "soxe";
        // Response.Redirect(Request.RawUrl);
    }



    protected void DropDownList1_Init(object sender, EventArgs e)
    {
        string cmd7 = "select distinct tentinh as tinh from nlnhapmia nm " +
            " inner join nlvungmia vm on nm.ma_vmia =  vm.ma_vmia where code_dk ='1111' ";
        VietSugar.getdata data6 = new VietSugar.getdata();
        DataTable data = data6.sqlcmd_ex(cmd7);
        data.Rows.Add("ALL");
        DropDownList1.DataSource = data;
        DropDownList1.DataTextField = "Tinh";
        DropDownList1.DataValueField = "Tinh";
        DropDownList1.DataBind();
    }

    protected void Chart3_Init(object sender, EventArgs e)
    {
        string cmd7 = "select cast((avg(DATEDIFF(MINUTE, gioxeve, gioxera)))  as decimal(10, 2))/ 60 as giobq, " +
            " tenhuyen from nlnhapmia nm inner join nlvungmia vm on nm.ma_vmia = vm.ma_vmia "+
            "where tl_xera > 0 group by tenhuyen";
        VietSugar.getdata data6 = new VietSugar.getdata();
        DataTable data = data6.sqlcmd_ex(cmd7);
        Chart3.DataSource = data;

        Chart3.Series[0].XValueMember = "tenhuyen";
        Chart3.Series[0].YValueMembers = "giobq";
    }
}