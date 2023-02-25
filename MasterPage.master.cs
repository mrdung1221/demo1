using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblHoTen.Text += Session["HoTen"].ToString();
        }
    }
    protected void lnkThoat_Click(object sender, EventArgs e)
    {
        Session["TaiKhoan"] = null;

        HttpCookie userInfo = Request.Cookies["bcinfo"];
        if (userInfo != null)
        {
            userInfo.Expires = DateTime.Now.AddDays(-7);
            Response.Cookies.Add(userInfo);
        }

        Response.Redirect("~/DangNhap.aspx");
    }
}
