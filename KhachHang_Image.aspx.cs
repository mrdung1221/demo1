using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class KhachHang_Image : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            VietSugar.KhachHang kh = new VietSugar.KhachHang();
            kh.ma_lnm = Request.QueryString["ma_lnm"];
            kh.ng_lnm = Request.QueryString["ng_lnm"];

            kh.CT();

            imgTH.ImageUrl = "https://image.vietsugar.com.vn:448/images/thuhoach/" + kh.hinhTH;
            imgBoc.ImageUrl = "https://image.vietsugar.com.vn:448/images/boc/" + kh.hinhBoc;
            imgVC.ImageUrl = "https://image.vietsugar.com.vn:448/images/vanchuyen/" + kh.hinhVC;
        }
    }
}