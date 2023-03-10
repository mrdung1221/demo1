using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using System.Drawing;

public partial class NhapMia_KH_CT : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["TaiKhoan"] == null)
        {
            Response.Redirect("~/DangNhap.aspx");
        }
        else
        {
            string key = "ctkh";
            string taikhoan = Session["TaiKhoan"].ToString();
            VietSugar.User u = new VietSugar.User();
            if (u.CheckQuyen(taikhoan, key) == false)
                Response.Redirect("~/CanhBao.aspx");
        }

        if (!IsPostBack)
        {
            VietSugar.MiaNguyenLieu mia = new VietSugar.MiaNguyenLieu();
            mia.MaChuMia = Request.QueryString["MaCMia"];
            
            data = mia.NhapMiaKHCT();
            if (data.Rows.Count > 0)
            {
                GridView1.DataSource = data;

                GridViewHelper helper = new GridViewHelper(this.GridView1);
                helper.RegisterGroup("tenhuyen", true, true);
                helper.GroupHeader += new GroupEvent(helper_GroupHeader);
                helper.RegisterSummary("tl_tho", SummaryOperation.Sum, "tenhuyen");
                helper.RegisterSummary("tl_tinh", SummaryOperation.Sum, "tenhuyen");
                helper.RegisterSummary("so_ccs", SaveQuantity, GetCCSBinhQuan, "tenhuyen");
                helper.RegisterSummary("tl_rac", SaveQuantity, GetRacBinhQuan, "tenhuyen");
                helper.GroupSummary += new GroupEvent(helper_GroupSummary);

                GridView1.DataBind();

                //Tính toltal trong datatable, hiển thị trên gridview
                Decimal TotalTho = Convert.ToDecimal(data.Compute("SUM(tl_tho)", string.Empty));
                lblTho.Text = String.Format("{0:0,0}", TotalTho) + " Kg";
                //Decimal TotalTinh = Convert.ToDecimal(data.Compute("SUM(tl_tinh)", "tram = 'PhuùYeân'"));
                Decimal TotalTinh = Convert.ToDecimal(data.Compute("SUM(tl_tinh)", string.Empty));
                lblTinh.Text = String.Format("{0:0,0}", TotalTinh) + " Kg";

                Decimal TotalCCSNhap = Convert.ToDecimal(data.Compute("SUM(ccs_nhap)", string.Empty));
                decimal CCS_BQ = TotalCCSNhap / TotalTinh;
                lblCCS.Text = Math.Round(CCS_BQ, 2).ToString();

                Decimal TotalRacTho = Convert.ToDecimal(data.Compute("SUM(rac_tho)", string.Empty));
                decimal Rac_BQ = TotalRacTho / TotalTho;
                lblRac.Text = Math.Round(Rac_BQ, 3).ToString();

                lblXe.Text = data.Rows.Count.ToString() + " xe";

            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }
    }

    DataTable data;

    protected void btnGetData_Click(object sender, EventArgs e)
    {
        
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TableCell statusCell = e.Row.Cells[12];
            string cellValue,loai_chay;
            cellValue = statusCell.Text.Trim();
            loai_chay = cellValue.Substring(cellValue.Length - 1, 1);
            if (IsNumeric(loai_chay))
            {
                statusCell.Text = loai_chay;
            }
            else
                statusCell.Text = "0";


            VietSugar.KhachHang kh = new VietSugar.KhachHang();
            kh.ma_lnm = GridView1.DataKeys[e.Row.RowIndex].Values[0].ToString();
            kh.ng_lnm = DateTime.Parse(GridView1.DataKeys[e.Row.RowIndex].Values[1].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            HyperLink lnkXemAnh = (e.Row.FindControl("lnkXemAnh") as HyperLink);
            if (!kh.CheckExist())
                lnkXemAnh.Visible = false;
        }
    }
    
    private List<string> arr_group = new List<string>();
    private void helper_GroupHeader(string groupName, object[] values, GridViewRow row)
    {
        row.BackColor = Color.LightBlue;
        row.Font.Bold = true;
        row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
        //row.Cells[0].Text = "&nbsp;&nbsp;" + row.Cells[0].Text;
        arr_group.Add(row.Cells[0].Text);
    }
    private void helper_GroupSummary(string groupName, object[] values, GridViewRow row)
    {
        row.BackColor = Color.Bisque;
        row.ForeColor = Color.Blue;
        row.Font.Bold = true;
        row.Cells[0].HorizontalAlign = HorizontalAlign.Left;
        row.Cells[0].Text = "Tổng";
    }
    public bool IsNumeric(string value)
    {
        return value.All(char.IsNumber);
    }
    private List<int> mQuantities = new List<int>();
    private void SaveQuantity(string column, string group, object value)
    {
        //mQuantities.Add(Convert.ToInt32(value));
        //Label1.Text = value.ToString();
    }

    int number = 0;
    private object GetCCSBinhQuan(string column, string group)
    {
        decimal CCS_BQ = 0;

        if (data.Rows.Count > 0)
        {
            Decimal TotalTinh = Convert.ToDecimal(data.Compute("SUM(tl_tinh)", "tenhuyen = '" + arr_group[number] + "'"));
            Decimal TotalCCSNhap = Convert.ToDecimal(data.Compute("SUM(ccs_nhap)", "tenhuyen = '" + arr_group[number] + "'"));
            CCS_BQ = TotalCCSNhap / TotalTinh;
            number++;
        }
        
        return Math.Round(CCS_BQ, 2);
    }

    int number2 = 0;
    private object GetRacBinhQuan(string column, string group)
    {
        decimal Rac_BQ = 0;

        if (data.Rows.Count > 0)
        {
            Decimal TotalTho = Convert.ToDecimal(data.Compute("SUM(tl_tho)", "tenhuyen = '" + arr_group[number2] + "'"));
            Decimal TotalRac = Convert.ToDecimal(data.Compute("SUM(rac_tho)", "tenhuyen = '" + arr_group[number2] + "'"));
            Rac_BQ = TotalRac / TotalTho;
            number2++;
        }

        return Math.Round(Rac_BQ, 3);
    }

}