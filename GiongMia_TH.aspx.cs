using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using System.Drawing;

public partial class GiongMia_TH : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["TaiKhoan"] == null)
        {
            Response.Redirect("~/DangNhap.aspx");
        }
        else
        {
            string key = "thgm";
            string taikhoan = Session["TaiKhoan"].ToString();
            VietSugar.User u = new VietSugar.User();
            if (u.CheckQuyen(taikhoan, key) == false)
                Response.Redirect("~/CanhBao.aspx");
        }

        if (!IsPostBack)
        {
            VietSugar.ChatLuong cl = new VietSugar.ChatLuong();
            GridView1.DataSource = cl.GiongMia();
            GridView1.DataBind();

            Chart1.DataSource = cl.GiongMia();
            Chart1.DataBind();
        }
    }
    
}