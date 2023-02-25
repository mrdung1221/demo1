using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class admin_PhanQuyen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["TaiKhoan"] == null)
        {
            Response.Redirect("~/DangNhap.aspx");
        }
        else
        {
            string key = "pqnd";
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

            VietSugar.Quyen q=new VietSugar.Quyen();
            griPhanQuyen.DataSource = q.DanhSach();
            griPhanQuyen.DataBind();
        }
    }
    protected void griUser_SelectedIndexChanged(object sender, EventArgs e)
    {

        VietSugar.PhanQuyen p = new VietSugar.PhanQuyen();
        p.TaiKhoan = griUser.SelectedValue.ToString();
        lblTaiKhoan.Text = p.TaiKhoan;
        DataTable data = p.DanhSach();
        
        // Reset checkbox
        foreach (GridViewRow gv_row in griPhanQuyen.Rows)
        {
            CheckBox chkQuyen = gv_row.FindControl("chkQuyen") as CheckBox;
            chkQuyen.Checked = false;
        }

        if (data.Rows.Count == 0)
            return;

        foreach (DataRow dt_row in data.Rows)
        {
            foreach (GridViewRow gv_row in griPhanQuyen.Rows)
            {
                CheckBox chkQuyen = gv_row.FindControl("chkQuyen") as CheckBox;
                //string maq = gv_row.Cells[2].Text;
                string maq = griPhanQuyen.DataKeys[gv_row.RowIndex]["MaQuyen"].ToString();

                if (dt_row["MaQuyen"].ToString() == maq)
                {
                    chkQuyen.Checked = true;
                    break;
                }
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        VietSugar.PhanQuyen p = new VietSugar.PhanQuyen();
        p.TaiKhoan = lblTaiKhoan.Text;
        p.Xoa();

        foreach (GridViewRow gv_row in griPhanQuyen.Rows)
        {
            CheckBox chkQuyen = gv_row.FindControl("chkQuyen") as CheckBox;
            if (chkQuyen.Checked)
            {
                p.MaQuyen = griPhanQuyen.DataKeys[gv_row.RowIndex]["MaQuyen"].ToString();
                p.Them();
            }
        }
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Save Successfully')", true);
    }
}