using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Security.Cryptography;

public partial class DangNhap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie userInfo = Request.Cookies["bcinfo"];
        if (userInfo != null)
        {
            VietSugar.User dn = new VietSugar.User();
            dn.TaiKhoan = Decrypt(userInfo["t"].ToString()); // Giải mã cookie tài khoản
            dn.MatKhau = Decrypt(userInfo["m"].ToString());
            if (dn.DangNhap())
            {
                if (dn.TrangThai) // nếu user không bị khóa
                {
                    Session["TaiKhoan"] = dn.TaiKhoan;
                    Session["HoTen"] = dn.HoTen;
                    Response.Redirect("~/Index.aspx");
                }
            }
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (txtTaiKhoan.Text.Trim() == "")
        {
            txtTaiKhoan.Focus();
            return;
        }
        if (txtMatKhau.Text.Trim() == "")
        {
            txtMatKhau.Focus();
            return;
        }

        // Check SQL Injection
        string tendangnhap = "", matkhau = "";
        if (txtTaiKhoan.Text.Trim().Replace("'", "") == "")
            tendangnhap = "";
        else
            tendangnhap = RemoveSQLIj(txtTaiKhoan.Text.Trim().Replace("'", ""));

        if (txtMatKhau.Text.Trim() == "")
            matkhau = "";
        else
            matkhau = RemoveSQLIj(txtMatKhau.Text.Trim());

        VietSugar.User dn = new VietSugar.User();
        dn.TaiKhoan = tendangnhap.Trim();
        dn.MatKhau = matkhau.Trim();

        if (dn.DangNhap())
        {
            if (dn.TrangThai) // nếu user không bị khóa
            {
                Session["TaiKhoan"] = dn.TaiKhoan;
                Session["HoTen"] = dn.HoTen;

                // lưu Cookie
                HttpCookie userInfo = new HttpCookie("bcinfo");
                userInfo["t"] = Encrypt(dn.TaiKhoan); // Cookie tài khoản được mã hóa
                userInfo["m"] = Encrypt(dn.MatKhau); // Cookie mật khẩu
                userInfo.Expires = DateTime.Now.AddDays(7);
                //userInfo.Expires.Add(new TimeSpan(0, 1, 0));
                Response.Cookies.Add(userInfo);

                Response.Redirect("~/Index.aspx");
            }
            else
            {
                lblThongBao.Text = "Tài khoản đã bị khóa";
                lblThongBao.Visible = true;
            }
        }
        else
        {
            lblThongBao.Text = "Tài khoản hoặc mật khẩu không đúng";
            lblThongBao.Visible = true;
        }
    }

    public string RemoveSQLIj(string str)
    {
        if (str == null) str = "";
        string resu = str.Replace("--", "");
        resu = resu.Replace("'", "");
        resu = resu.Replace(";", "");
        resu = resu.Replace(",", "");
        //  resu = str.Replace("\\", "");
        //  resu = str.Replace("/", "");
        resu = resu.Replace(Convert.ToChar(13).ToString(), "");
        return resu;
    }

    public static string Encrypt(string toEncrypt)
    {
        bool useHashing = true;
        byte[] keyArray;
        string key = "bcvsg012";
        byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

        if (useHashing)
        {
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
        }
        else
            keyArray = UTF8Encoding.UTF8.GetBytes(key);

        TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
        tdes.Key = keyArray;
        tdes.Mode = CipherMode.ECB;
        tdes.Padding = PaddingMode.PKCS7;

        ICryptoTransform cTransform = tdes.CreateEncryptor();
        byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

        return Convert.ToBase64String(resultArray, 0, resultArray.Length);
    }

    public static string Decrypt(string toDecrypt)
    {
        bool useHashing = true;
        byte[] keyArray;
        string key = "bcvsg012";
        byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

        if (useHashing)
        {
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
        }
        else
            keyArray = UTF8Encoding.UTF8.GetBytes(key);

        TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
        tdes.Key = keyArray;
        tdes.Mode = CipherMode.ECB;
        tdes.Padding = PaddingMode.PKCS7;

        ICryptoTransform cTransform = tdes.CreateDecryptor();
        byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

        return UTF8Encoding.UTF8.GetString(resultArray);
    }
}