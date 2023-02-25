using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using System.Drawing;

public partial class NhapMia_KH : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["TaiKhoan"] == null)
        {
            Response.Redirect("~/DangNhap.aspx");
        }
        else
        {
            string key = "dskh";
            string taikhoan = Session["TaiKhoan"].ToString();
            VietSugar.User u = new VietSugar.User();
            if (u.CheckQuyen(taikhoan, key) == false)
                Response.Redirect("~/CanhBao.aspx");
        }

        if (!IsPostBack)
        {
            VietSugar.MiaNguyenLieu mia = new VietSugar.MiaNguyenLieu();
            //mia.Get_NgayBatDau();
            //mia.Get_NgayKetThuc();
            //string fromDay, toDay;
            //fromDay = mia.NgayBatDau.ToString("yyyy-MM-dd HH:mm");
            //toDay = mia.NgayKetThuc.ToString("yyyy-MM-dd HH:mm");
            //mia.ThoiGian = "gioxera>='" + fromDay + "' and gioxera<'" + toDay + "'";
            GridView1.DataSource = mia.NhapMiaKH();
            GridView1.DataBind();

            DataTable data = mia.NhapMiaKH();
            Decimal soxe = Convert.ToDecimal(data.Compute("SUM(soxe)", string.Empty));
            Decimal TotalTho = Convert.ToDecimal(data.Compute("SUM(tl_tho)", string.Empty));
            Decimal TotalTinh = Convert.ToDecimal(data.Compute("SUM(tl_tinh)", string.Empty));
            lblTotal.Text = "xe " + soxe + " - tho: " + String.Format("{0:0,0.00}", TotalTho) + " tấn" + " - tinh: " + String.Format("{0:0,0.00}", TotalTinh) + " tấn";

            //GridView1.FooterStyle.BackColor = Color.Bisque;
            //GridView1.FooterStyle.ForeColor = Color.Blue;
        }
    }

    

    protected void btnGetData_Click(object sender, EventArgs e)
    {
        //if (txtHoTen.Text.Trim() == "")
        //    return;
        VietSugar.MiaNguyenLieu mia = new VietSugar.MiaNguyenLieu();
        mia.HoTen = UnicodeToVni(txtHoTen.Text.Trim());
        GridView1.DataSource = mia.NhapMiaKH();
        GridView1.DataBind();
    }



    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        VietSugar.MiaNguyenLieu mia = new VietSugar.MiaNguyenLieu();
        mia.HoTen = UnicodeToVni(txtHoTen.Text.Trim());
        GridView1.DataSource = mia.NhapMiaKH();
        GridView1.DataBind();
    }

    private string UnicodeToVni(string text)
    {
        if (txtHoTen.Text.Trim() == "")
            return "";

        string[] UNICODE = {
            "À", "Á", "Â", "Ã", "È", "É", "Ê", "Ì", "Í", "Ò",
            "Ó", "Ô", "Õ", "Ù", "Ú", "Ý", "à", "á", "â", "ã",
            "è", "é", "ê", "ì", "í", "ò", "ó", "ô", "õ", "ù",
            "ú", "ý", "Ă", "ă", "Đ", "đ", "Ĩ", "ĩ", "Ũ", "ũ",
            "Ơ", "ơ", "Ư", "ư", "Ạ", "ạ", "Ả", "ả", "Ấ", "ấ",
            "Ầ", "ầ", "Ẩ", "ẩ", "Ẫ", "ẫ", "Ậ", "ậ", "Ắ", "ắ",
            "Ằ", "ằ", "Ẳ", "ẳ", "Ẵ", "ẵ", "Ặ", "ặ", "Ẹ", "ẹ",
            "Ẻ", "ẻ", "Ẽ", "ẽ", "Ế", "ế", "Ề", "ề", "Ể", "ể",
            "Ễ", "ễ", "Ệ", "ệ", "Ỉ", "ỉ", "Ị", "ị", "Ọ", "ọ",
            "Ỏ", "ỏ", "Ố", "ố", "Ồ", "ồ", "Ổ", "ổ", "Ỗ", "ỗ",
            "Ộ", "ộ", "Ớ", "ớ", "Ờ", "ờ", "Ở", "ở", "Ỡ", "ỡ",
            "Ợ", "ợ", "Ụ", "ụ", "Ủ", "ủ", "Ứ", "ứ", "Ừ", "ừ",
            "Ử", "ử", "Ữ", "ữ", "Ự", "ự", "Ỳ", "ỳ", "Ỵ", "ỵ", 
            "Ỷ", "ỷ", "Ỹ", "ỹ"
            };
        string[] VNI = {
            "AØ", "AÙ", "AÂ", "AÕ", "EØ", "EÙ", "EÂ", "Ì" , "Í" , "OØ",
            "OÙ", "OÂ", "OÕ", "UØ", "UÙ", "YÙ", "aø", "aù", "aâ", "aõ",
            "eø", "eù", "eâ", "ì" , "í" , "oø", "où", "oâ", "oõ", "uø",
            "uù", "yù", "AÊ", "aê", "Ñ" , "ñ" , "Ó" , "ó" , "UÕ", "uõ",
            "Ô" , "ô" , "Ö" , "ö" , "AÏ", "aï", "AÛ", "aû", "AÁ", "aá",
            "AÀ", "aà", "AÅ", "aå", "AÃ", "aã", "AÄ", "aä", "AÉ", "aé",
            "AÈ", "aè", "AÚ", "aú", "AÜ", "aü", "AË", "aë", "EÏ", "eï",
            "EÛ", "eû", "EÕ", "eõ", "EÁ", "eá", "EÀ", "eà", "EÅ", "eå",
            "EÃ", "eã", "EÄ", "eä", "Æ" , "æ" , "Ò" , "ò" , "OÏ", "oï",
            "OÛ", "oû", "OÁ", "oá", "OÀ", "oà", "OÅ", "oå", "OÃ", "oã",
            "OÄ", "oä", "ÔÙ", "ôù", "ÔØ", "ôø", "ÔÛ", "ôû", "ÔÕ", "ôõ",
            "ÔÏ", "ôï", "UÏ", "uï", "UÛ", "uû", "ÖÙ", "öù", "ÖØ", "öø",
            "ÖÛ", "öû", "ÖÕ", "öõ", "ÖÏ", "öï", "YØ", "yø", "Î" , "î" ,
            "YÛ", "yû", "YÕ", "yõ"
             };

        for (int i = 0; i < UNICODE.Length; i++)
        {
            if (text.Contains(UNICODE[i]))
            {
                text = text.Replace(UNICODE[i], VNI[i]);
            }
        }
        return text;
    }
}