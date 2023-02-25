using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_User : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["TaiKhoan"] == null)
        {
            Response.Redirect("~/DangNhap.aspx");
        }
        else
        {
            string key = "qltk";
            string taikhoan = Session["TaiKhoan"].ToString();
            VietSugar.User u = new VietSugar.User();
            if (u.CheckQuyen(taikhoan, key) == false)
                Response.Redirect("~/CanhBao.aspx");
        }

        if (!IsPostBack)
        {
            VietSugar.User user = new VietSugar.User();
            griUser.DataSource = user.DanhSach();
            griUser.DataBind();            
        }
    }
    protected void btnBoQua_Click(object sender, EventArgs e)
    {
        btnThemMoi.Visible = true;
        pnlCapNhat.Visible = false;
    }
    protected void btnThemMoi_Click(object sender, EventArgs e)
    {

        
        pnlCapNhat.Visible = true;
        btnThemMoi.Visible = false;
        btnThem.Visible = true;
        btnXoa.Visible = false;
        btnSua.Visible = false;
        txtHoTen.Text = "";
        txtBoPhan.Text = "";
        txtChucVu.Text = "";
        txtTaiKhoan.Text = "";
        txtMatKhau.Text = "";
        chkTrangThai.Checked = true;
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        VietSugar.User user = new VietSugar.User();
        user.TaiKhoan = txtTaiKhoan.Text.Trim();
        user.HoTen = txtHoTen.Text;
        user.MatKhau = txtMatKhau.Text;
        user.BoPhan = txtBoPhan.Text;
        user.ChucVu = txtChucVu.Text;
        //user.TrangThai = chkTrangThai.Checked ? true : false;

        user.Them();       
        griUser.DataSource = user.DanhSach();
        griUser.DataBind();
        pnlCapNhat.Visible = false;
        btnThemMoi.Visible = true;
    }
    protected void griUser_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlCapNhat.Visible = true;
        btnThemMoi.Visible = false;
        btnThem.Visible = false;
        btnXoa.Visible = true;
        btnSua.Visible = true;
        VietSugar.User user = new VietSugar.User();
        user.TaiKhoan = griUser.SelectedValue.ToString();
        user.CT();

        txtTaiKhoan.Text = user.TaiKhoan;
        txtHoTen.Text = user.HoTen;
        //txtMatKhau.Text = user.MatKhau;
        txtBoPhan.Text = user.BoPhan;
        txtChucVu.Text = user.ChucVu;
        chkTrangThai.Checked = user.TrangThai;
    }

    protected void btnXoa_Click(object sender, EventArgs e)
    {
        VietSugar.User user = new VietSugar.User();
        user.TaiKhoan = txtTaiKhoan.Text.Trim();
        user.Xoa();
        griUser.DataSource = user.DanhSach();
        griUser.DataBind();
        pnlCapNhat.Visible = false;
        btnThemMoi.Visible = true;
    }
    protected void btnSua_Click(object sender, EventArgs e)
    {
        VietSugar.User user = new VietSugar.User();
        user.TaiKhoan = txtTaiKhoan.Text.Trim();
        user.HoTen = txtHoTen.Text;
        
        user.BoPhan = txtBoPhan.Text;
        user.ChucVu = txtChucVu.Text;
        user.TrangThai = chkTrangThai.Checked ? true : false;
        user.Sua();
        //Sửa mật khẩu
        if (txtMatKhau.Text.Trim() != "")
        {
            user.CT();
            if (String.Compare(user.MatKhau, txtMatKhau.Text) != 0)
            {
                user.MatKhau = txtMatKhau.Text;
                user.SuaMatKhau();
            }
        }
            
        griUser.DataSource = user.DanhSach();
        griUser.DataBind();
        pnlCapNhat.Visible = false;
        btnThemMoi.Visible = true;
    }
}