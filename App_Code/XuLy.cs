using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace VietSugar
{
    public class DungChung
    {
        public static string ChuoiKetNoi = @"Data Source=server2;Initial Catalog=KSCDB;USER ID = sa; PASSWORD = anhtrong";
        public static int num_nhom = 0;
        public static string _thoigian = "";
        //public static string ChuoiKetNoi = @"Data Source=webserver;Initial Catalog=KSCDB;USER ID = sa; PASSWORD = sa!@#A";
    }
    public class ChayLenhSQL
    {
        public string sqlCommand;
        
        public DataTable KetQua()
        {
            SqlConnection BaoVe = new SqlConnection(DungChung.ChuoiKetNoi);
            DataTable dataTable = new DataTable();
            try
            {
                if (BaoVe.State == ConnectionState.Closed)
                {
                    BaoVe.Open();
                }
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand, BaoVe);
                sqlDataAdapter.Fill(dataTable);
                if (BaoVe.State != ConnectionState.Closed)
                {
                    BaoVe.Close();
                }
            }
            catch (Exception)
            {
            }
            return dataTable;
        }
    }

    public class MiaNguyenLieu
    {

        public string GioXeRa;
        public string ThoiGian;
        public DateTime NgayBatDau;
        public DateTime NgayKetThuc;
        public string HoTen;
        public string MaChuMia;
        public int SoXe;
        public int Tong_ra;

        public DataTable NhapMiaCT()
        {
            SqlConnection BaoVe = new SqlConnection(DungChung.ChuoiKetNoi);
            //string query = "select ROW_NUMBER() OVER (PARTITION BY tenhuyen ORDER BY rtrim(tenhuyen)) AS [STT], gioxera, ma_pnm,sohd,fullname,rtrim(tenhuyen) tenhuyen,so_xevc,giongmia,nm.ma_rmia,((tl_xeva-tl_xera)/1000) as tl_tho," +
            //                "((tl_xeva-tl_xera)-((tl_xeva-tl_xera)*tl_rac/100))/1000 as tl_tinh," +
            //                "so_ccs,tl_rac,pl_gia as loaichay,loaigoc, DATEDIFF(month,ngay_trong,ng_pnm) as tuoimia," +
            //                "((tl_xeva-tl_xera)-((tl_xeva-tl_xera)*tl_rac/100)) *so_ccs as ccs_nhap , " +
            //                "((tl_xeva-tl_xera)* tl_rac)/1000 as rac_tho" +
            //                " from nlnhapmia nm inner join AccCustomers ac on nm.ma_cmia =ac.masokh " +
            //                "inner join nlruongmia rm on nm.ma_rmia=rm.ma_rmia " +
            //                "inner join nlvungmia vm on nm.ma_vmia=vm.ma_vmia " +
            //                "where " + ThoiGian +
            //                " and so_ccs>0 and tl_xera>0 and tl_rac>1" +
            //                " order by rtrim(tenhuyen) asc";
            string query = " select ROW_NUMBER() OVER (PARTITION BY tenhuyen ORDER BY rtrim(tenhuyen),gioxera) AS [STT], " +
                           " case when sl.Tong_ccsbq = 0 OR sl.Tong_slnhap = 0 then 0 " +
                           " else cast(round(sl.Tong_ccsbq/sl.Tong_slnhap,2)  as decimal(10,2)) end  as so_ccs_VT " +
                           " , gioxeva,gioxera,Time_Khoan, ma_pnm,sohd,fullname,rtrim(tenhuyen) tenhuyen,nm.so_xevc,giongmia,nm.ma_rmia,(tl_xeva-tl_xera) as tl_tho, " +
                           " cast((tl_xeva - tl_xera) - (tl_xeva - tl_xera) * tl_rac / 100 as decimal(10,0)) as tl_tinh, " +
                           " so_ccs,tl_rac,pl_gia as loaichay,rm.loaigoc, DATEDIFF(month,ngay_trong,ng_pnm) as tuoimia, " +
                           " ((tl_xeva-tl_xera)-((tl_xeva-tl_xera)*tl_rac/100)) *so_ccs as ccs_nhap ,  " +
                           " (tl_xeva-tl_xera)* tl_rac as rac_tho " +
                           ",nm.ma_lnm,nm.ng_lnm" +
                           "  from nlnhapmia nm inner join AccCustomers ac on nm.ma_cmia =ac.masokh  " +
                           " inner join nlruongmia rm on nm.ma_rmia=rm.ma_rmia  " +
                           " inner join nlvungmia vm on nm.ma_vmia=vm.ma_vmia  " +
                           " inner join NLchitietvc vc on nm.ma_lnm=vc.ma_lnm and nm.ng_lnm=vc.ng_lnm  " +
                           " FULL JOIN NLSlgMiaNhap_CT sl on sl.Ma_rmia= nm.ma_rmia and sl.VuMia='2021-2022'" +
                            "where " + ThoiGian +
                            " and so_ccs>0 and tl_xera>0 and tl_rac>1" +
                            " order by rtrim(tenhuyen) asc, gioxera";

            SqlDataAdapter XeTai = new SqlDataAdapter(query, BaoVe);
            //"where gioxera>='" + GioXeRa + " 06:00' and gioxera<'" + GioXeRaAdd + " 06:00'"+
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            XeTai.Fill(ThungChua);
            BaoVe.Close();
            return ThungChua;
        }
        public void Get_NgayBatDau()
        {
            SqlConnection BaoVe = new SqlConnection(DungChung.ChuoiKetNoi);
            string query = "select TOP 1 gioxera from nlnhapmia where so_ccs>0 and tl_xera>0 and tl_rac>1 order by gioxera asc";

            SqlCommand Lenh = BaoVe.CreateCommand();
            Lenh.CommandText = query;
            BaoVe.Open();
            SqlDataReader docDL;
            docDL = Lenh.ExecuteReader();

            if (docDL.Read())
            {
                NgayBatDau = DateTime.Parse(docDL["gioxera"].ToString());
            }
            BaoVe.Close();
        }
        public void Get_NgayKetThuc()
        {
            SqlConnection BaoVe = new SqlConnection(DungChung.ChuoiKetNoi);
            string query = "select TOP 1 gioxera from nlnhapmia where so_ccs>0 and tl_xera>0 and tl_rac>1 order by gioxera desc";

            SqlCommand Lenh = BaoVe.CreateCommand();
            Lenh.CommandText = query;
            BaoVe.Open();
            SqlDataReader docDL;
            docDL = Lenh.ExecuteReader();

            if (docDL.Read())
            {
                NgayKetThuc = DateTime.Parse(docDL["gioxera"].ToString());
            }
            BaoVe.Close();
        }
        public DataTable NhapMiaKH()
        {
            if (HoTen==null)
                HoTen = "";
            SqlConnection BaoVe = new SqlConnection(DungChung.ChuoiKetNoi);
            string query = "select ma_cmia,fullname,soxe,tl_tho,tl_tinh,ccs_bq,ccs_max,ccs_min,rac_bq from(" +
                            "select ma_cmia, count(ma_cmia) soxe, sum(tl_xeva-tl_xera)/1000 as tl_tho," +
                            "sum((tl_xeva-tl_xera)-((tl_xeva-tl_xera)*tl_rac/100))/1000 as tl_tinh," +
                            "sum(((tl_xeva-tl_xera)-((tl_xeva-tl_xera)*tl_rac/100)) *so_ccs)/sum((tl_xeva-tl_xera)-((tl_xeva-tl_xera)*tl_rac/100)) as ccs_bq," +
                            "max(so_ccs) ccs_max, min(so_ccs) ccs_min," +
                            "(SUM((tl_xeva - tl_xera) * tl_rac) / SUM(tl_xeva - tl_xera)) as rac_bq " +
                            "from nlnhapmia where so_ccs>0 and tl_xera>0 and tl_rac>1 " +
                            "group by ma_cmia"+
                            ") nm inner join AccCustomers ac on nm.ma_cmia =ac.masokh "+
                            "where fullname like '%" + HoTen + "%'" +
                            " order by firstname asc";
            SqlDataAdapter XeTai = new SqlDataAdapter(query, BaoVe);
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            XeTai.Fill(ThungChua);
            BaoVe.Close();
            return ThungChua;
        }

        public DataTable NhapMiaKHCT()
        {
            SqlConnection BaoVe = new SqlConnection(DungChung.ChuoiKetNoi);
            string query = "select ROW_NUMBER() OVER (PARTITION BY tenhuyen ORDER BY rtrim(tenhuyen),gioxeva) AS [STT],ma_pnm,sohd,fullname,rtrim(tenhuyen) tenhuyen,"+
                            "so_xevc,giongmia,nm.ma_rmia,gioxeva,gioxera,ma_lnm,ng_lnm," +
                            "tl_xeva-tl_xera as tl_tho," +
                            "cast((tl_xeva - tl_xera) - (tl_xeva - tl_xera) * tl_rac / 100 as decimal(10,0)) as tl_tinh," +
                            "so_ccs,tl_rac,pl_gia as loaichay,loaigoc, DATEDIFF(month,ngay_kyhd,ng_pnm) as tuoimia," +
                            "((tl_xeva-tl_xera)-((tl_xeva-tl_xera)*tl_rac/100)) *so_ccs as ccs_nhap , " +
                            "(tl_xeva-tl_xera)* tl_rac as rac_tho" +
                            " from nlnhapmia nm inner join AccCustomers ac on nm.ma_cmia =ac.masokh " +
                            "inner join nlruongmia rm on nm.ma_rmia=rm.ma_rmia " +
                            "inner join nlvungmia vm on nm.ma_vmia=vm.ma_vmia " +
                            "where nm.ma_cmia='" + MaChuMia +"'"+
                            " and so_ccs>0 and tl_xera>0 and tl_rac>1" +
                            " order by rtrim(tenhuyen) asc,gioxeva asc";
            SqlDataAdapter XeTai = new SqlDataAdapter(query, BaoVe);
            //"where gioxera>='" + GioXeRa + " 06:00' and gioxera<'" + GioXeRaAdd + " 06:00'"+
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            XeTai.Fill(ThungChua);
            BaoVe.Close();
            return ThungChua;
        }

        public void XeChoCan()
        {
            SqlConnection BaoVe = new SqlConnection(DungChung.ChuoiKetNoi);
            string query = "Select COUNT(*) As Tong_vao  From NLChitietvc Where Segment In(20,30,40) and Complete = 0";

            SqlCommand Lenh = BaoVe.CreateCommand();
            Lenh.CommandText = query;
            BaoVe.Open();
            SqlDataReader docDL;
            docDL = Lenh.ExecuteReader();

            if (docDL.Read())
            {
                SoXe = int.Parse(docDL["Tong_vao"].ToString());
            }
            BaoVe.Close();
        }
        public void XeChoCau()
        {
            SqlConnection BaoVe = new SqlConnection(DungChung.ChuoiKetNoi);
            string query = "Select COUNT(*) As XeCau  From NLChitietvc Where Segment In(50,60,70) and Complete = 0";

            SqlCommand Lenh = BaoVe.CreateCommand();
            Lenh.CommandText = query;
            BaoVe.Open();
            SqlDataReader docDL;
            docDL = Lenh.ExecuteReader();

            if (docDL.Read())
            {
                SoXe = int.Parse(docDL["XeCau"].ToString());
            }
            BaoVe.Close();
        }

        public void XeCanRa()
        {
            SqlConnection BaoVe = new SqlConnection(DungChung.ChuoiKetNoi);

            DateTime DateNow = DateTime.Now;
            string fromDay, toDay, thoigian = "";
            if (DateNow.Hour <= 6)
            {
                fromDay = DateNow.AddDays(-1).ToString("yyyy-MM-dd");
                toDay = DateNow.ToString("yyyy-MM-dd");
                thoigian = "gio_xv>='" + fromDay + " 06:00' and gio_xv<'" + toDay + " 06:00'";
            }
            else if (DateNow.Hour > 6)
            {
                fromDay = DateNow.ToString("yyyy-MM-dd");
                toDay = DateNow.AddDays(1).ToString("yyyy-MM-dd");
                thoigian = "gio_xv>='" + fromDay + " 06:00' and gio_xv<'" + toDay + " 06:00'";
            }

            string query = "select count(*) as Tong_ra From NLChitietvc where "+thoigian+" and msginfo!='Huy Lenh'";

            SqlCommand Lenh = BaoVe.CreateCommand();
            Lenh.CommandText = query;
            BaoVe.Open();
            SqlDataReader docDL;
            docDL = Lenh.ExecuteReader();

            if (docDL.Read())
            {
                Tong_ra = int.Parse(docDL["Tong_ra"].ToString());
            }
            BaoVe.Close();
        }
        
        public string test()
        {
            
            string query = "";

            return query;
        }

    }
    public class KhachHang
    {
        public string ma_lnm;
        public string ng_lnm;

        public string ngaygioTH;
        public string hinhTH;
        public string K_TH;
        public string V_TH;
        public string ngaygioBoc;
        public string hinhBoc;
        public string K_Boc;
        public string V_Boc;
        public string ngaygioVC;
        public string hinhVC;
        public string K_VC;
        public string V_VC;

        public string ngayUpTH;
        public string ngayUpBoc;
        public string ngayUpVC;

        public void CT()
        {
            SqlConnection BaoVe = new SqlConnection(DungChung.ChuoiKetNoi);
            string query = "select * from UpAnh"
                            + " where ma_lnm=@ma_lnm and ng_lnm=@ng_lnm";

            SqlCommand Lenh = BaoVe.CreateCommand();
            Lenh.CommandText = query;
            Lenh.Parameters.Add("@ma_lnm", SqlDbType.VarChar).Value = ma_lnm;
            Lenh.Parameters.Add("@ng_lnm", SqlDbType.VarChar).Value = ng_lnm;
            BaoVe.Open();
            SqlDataReader docDL;
            docDL = Lenh.ExecuteReader();
            if (docDL.Read())
            {
                ngaygioTH = DateTime.Parse(docDL["ngaygioTH"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                hinhTH = docDL["hinhTH"].ToString();
                K_TH = docDL["K_TH"].ToString();
                V_TH = docDL["V_TH"].ToString();

                ngaygioBoc = DateTime.Parse(docDL["ngaygioBoc"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                hinhBoc = docDL["hinhBoc"].ToString();
                K_Boc = docDL["K_Boc"].ToString();
                V_Boc = docDL["V_Boc"].ToString();

                ngaygioVC = DateTime.Parse(docDL["ngaygioVC"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                hinhVC = docDL["hinhVC"].ToString();
                K_VC = docDL["K_VC"].ToString();
                V_VC = docDL["V_VC"].ToString();

                ngayUpTH = DateTime.Parse(docDL["ngayUpTH"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                ngayUpBoc = DateTime.Parse(docDL["ngayUpBoc"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                ngayUpVC = DateTime.Parse(docDL["ngayUpVC"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            }
            BaoVe.Close();
        }

        public bool CheckExist()
        { 
            SqlConnection BaoVe = new SqlConnection(DungChung.ChuoiKetNoi);
            string query = "select * from UpAnh"
                            + " where ma_lnm=@ma_lnm and ng_lnm=@ng_lnm";

            SqlCommand Lenh = BaoVe.CreateCommand();
            Lenh.CommandText = query;
            Lenh.Parameters.Add("@ma_lnm", SqlDbType.VarChar).Value = ma_lnm;
            Lenh.Parameters.Add("@ng_lnm", SqlDbType.VarChar).Value = ng_lnm;
            BaoVe.Open();
            SqlDataReader docDL;
            docDL = Lenh.ExecuteReader();
            if (docDL.Read())
            {
                BaoVe.Close();
                return true;
            }
            BaoVe.Close();
            return false;
        }
    }
    public class ChatLuong
    {

        public string GioXeRa;
        public string ThoiGian;
        public DateTime NgayBatDau;
        public DateTime NgayKetThuc;
        public string HoTen;
        public string MaChuMia;

        public DataTable GiongMia()
        {
            SqlConnection BaoVe = new SqlConnection(DungChung.ChuoiKetNoi);
            string query = "select GiongMia,tong_dt,slgtinh,ccsbq,nsuat from (" +
                        "select a.GiongMia,sum(rm1.dientich)as tong_dt,tinh/1000 as slgtinh,a.ccsbq,(tinh/1000)/sum(rm1.dientich) as nsuat from " +
                        "(select SUM(((tl_xeva - tl_xera) - (tl_xeva - tl_xera) * tl_rac / 100)) as tinh," +
                        "SUM(((tl_xeva - tl_xera) - (tl_xeva - tl_xera) * tl_rac / 100) * so_ccs) / SUM((tl_xeva - tl_xera) - (tl_xeva - tl_xera) * tl_rac / 100) as ccsbq,GiongMia " +
                        "from NLnhapmia nm inner join NLruongmia rm on nm.ma_rmia = rm.ma_rmia where so_ccs>0 and rm.SoHD like '%DTMB%' group by giongmia)a " +
                        "inner join NLruongmia rm1 on rm1.GiongMia  = a.GiongMia where rm1.SoHD like '%DTMB%' group by a.GiongMia,a.ccsbq,a.tinh " +
                        ") b where tong_dt>10 order by nsuat desc";
            SqlDataAdapter XeTai = new SqlDataAdapter(query, BaoVe);
            //"where gioxera>='" + GioXeRa + " 06:00' and gioxera<'" + GioXeRaAdd + " 06:00'"+
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            XeTai.Fill(ThungChua);
            BaoVe.Close();
            return ThungChua;
        }
    }

    public class DienTich
    {

        public DataTable DanhSach()
        {
            SqlConnection BaoVe = new SqlConnection(DungChung.ChuoiKetNoi);
            SqlDataAdapter XeTai = new SqlDataAdapter("select ROW_NUMBER() OVER (PARTITION BY userlog ORDER BY userlog) AS [STT],VuMia,Ma_cmia,Ma_vmia,SoHDong,UserLog,DT_DoDac1 from DTMiaDTu_TH where vumia like '2021-2022' and month(ngaykyhd)=4 ORDER BY userlog", BaoVe);
            //SqlDataAdapter XeTai = new SqlDataAdapter("select Ma_cmia as STT,VuMia,Ma_cmia,Ma_vmia,SoHDong,UserLog,DT_DoDac1 from DTMiaDTu_TH where vumia like '2021-2022' ORDER BY userlog", BaoVe);
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            XeTai.Fill(ThungChua);
            BaoVe.Close();
            return ThungChua;
        }
    }
    public class User
    {
        public string TaiKhoan;
        public string MatKhau;
        public string HoTen;
        public string BoPhan;
        public string ChucVu;
        public bool TrangThai;

        public bool DangNhap()
        {
            SqlConnection BaoVe = new SqlConnection(DungChung.ChuoiKetNoi);
            string query = "select * from BC_User"
                            + " where TaiKhoan = @TaiKhoan and MatKhau = @MatKhau";

            SqlCommand Lenh = BaoVe.CreateCommand();
            Lenh.CommandText = query;
            Lenh.Parameters.Add("@TaiKhoan", SqlDbType.VarChar).Value = TaiKhoan;
            Lenh.Parameters.Add("@MatKhau", SqlDbType.NVarChar).Value = MatKhau;
            BaoVe.Open();
            SqlDataReader docDL;
            docDL = Lenh.ExecuteReader();

            if (docDL.Read())
            {
                TaiKhoan = docDL["TaiKhoan"].ToString();
                MatKhau = docDL["MatKhau"].ToString();
                HoTen = docDL["HoTen"].ToString();
                TrangThai = bool.Parse(docDL["TrangThai"].ToString());
                BaoVe.Close();
                return true;
            }
            BaoVe.Close();
            return false;
        }
        public bool CheckQuyen(string taikhoan, string key)
        {
            VietSugar.PhanQuyen p = new VietSugar.PhanQuyen();
            p.TaiKhoan = taikhoan;
            DataTable data = p.DanhSach();
            foreach (DataRow row in data.Rows)
            {
                if (row["MaQuyen"].ToString() == key)
                    return true;
            }

            return false;
        }
        public void CheckTrangThai()
        {
            SqlConnection BaoVe = new SqlConnection(DungChung.ChuoiKetNoi);
            string query = "select * from BC_User"
                            + " where TaiKhoan = @TaiKhoan";

            SqlCommand Lenh = BaoVe.CreateCommand();
            Lenh.CommandText = query;
            Lenh.Parameters.Add("@TaiKhoan", SqlDbType.VarChar).Value = TaiKhoan;
            BaoVe.Open();
            SqlDataReader docDL;
            docDL = Lenh.ExecuteReader();

            if (docDL.Read())
            {
                TrangThai = bool.Parse(docDL["TrangThai"].ToString());
                BaoVe.Close();
            }
            BaoVe.Close();
        }
        public DataTable DanhSach()
        {
            SqlConnection BaoVe = new SqlConnection(DungChung.ChuoiKetNoi);
            SqlDataAdapter XeTai = new SqlDataAdapter("select * from BC_User", BaoVe);
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            XeTai.Fill(ThungChua);
            BaoVe.Close();
            return ThungChua;
        }

        public void Them()
        {
            SqlConnection BaoVe = new SqlConnection(DungChung.ChuoiKetNoi);
            string query = "INSERT INTO BC_User (HoTen,TaiKhoan,MatKhau,BoPhan,ChucVu)"
                            + " values (@HoTen, @TaiKhoan,@MatKhau,@BoPhan,@ChucVu) ";

            SqlCommand Lenh = BaoVe.CreateCommand();
            Lenh.CommandText = query;
            Lenh.Parameters.Add("@Hoten", SqlDbType.NVarChar).Value = HoTen;
            Lenh.Parameters.Add("@TaiKhoan", SqlDbType.VarChar).Value = TaiKhoan;
            Lenh.Parameters.Add("@MatKhau", SqlDbType.NVarChar).Value = MatKhau;
            Lenh.Parameters.Add("@BoPhan", SqlDbType.NVarChar).Value = BoPhan;
            Lenh.Parameters.Add("@ChucVu", SqlDbType.NVarChar).Value = ChucVu;

            BaoVe.Open();
            Lenh.ExecuteNonQuery();
            BaoVe.Close();
        }

        public void CT()
        {            
            SqlConnection BaoVe = new SqlConnection(DungChung.ChuoiKetNoi);
            string query = "select * from BC_User"
                            + " where TaiKhoan=@TaiKhoan";

            SqlCommand Lenh = BaoVe.CreateCommand();
            Lenh.CommandText = query;
            Lenh.Parameters.Add("@TaiKhoan", SqlDbType.VarChar).Value = TaiKhoan;
            BaoVe.Open();
            SqlDataReader docDL;
            //Danh sách các tham số tra trong thủ tục lưu trữ SQL tương ứng
            docDL = Lenh.ExecuteReader();
            if (docDL.Read())
            {
                HoTen = docDL["Hoten"].ToString();
                TaiKhoan = docDL["TaiKhoan"].ToString();
                MatKhau = docDL["MatKhau"].ToString();
                BoPhan = docDL["BoPhan"].ToString();
                ChucVu = docDL["ChucVu"].ToString();
                TrangThai = bool.Parse(docDL["TrangThai"].ToString());
            }
        }

        public void Xoa()
        {
            SqlConnection BaoVe = new SqlConnection(DungChung.ChuoiKetNoi);
            string query = "delete from BC_User where TaiKhoan = @TaiKhoan";

            SqlCommand Lenh = BaoVe.CreateCommand();
            Lenh.CommandText = query;
            Lenh.Parameters.Add("@TaiKhoan", SqlDbType.VarChar).Value = TaiKhoan;

            BaoVe.Open();
            Lenh.ExecuteNonQuery();
            BaoVe.Close();
        }
        public void Sua()
        {
            SqlConnection BaoVe = new SqlConnection(DungChung.ChuoiKetNoi);
            string query = "update BC_User set HoTen=@HoTen,BoPhan=@BoPhan,ChucVu=@ChucVu,TrangThai=@TrangThai"
                            + " where TaiKhoan=@TaiKhoan";

            SqlCommand Lenh = BaoVe.CreateCommand();
            Lenh.CommandText = query;
            //Khai bao cac tham so
            Lenh.Parameters.Add("@TaiKhoan", SqlDbType.VarChar).Value = TaiKhoan;
            Lenh.Parameters.Add("@Hoten", SqlDbType.NVarChar).Value = HoTen;
            Lenh.Parameters.Add("@BoPhan", SqlDbType.NVarChar).Value = BoPhan;
            Lenh.Parameters.Add("@ChucVu", SqlDbType.NVarChar).Value = ChucVu;
            Lenh.Parameters.Add("@TrangThai", SqlDbType.Bit).Value = TrangThai;
            BaoVe.Open();
            Lenh.ExecuteNonQuery();
            BaoVe.Close();
        }
        public void SuaMatKhau()
        {
            SqlConnection BaoVe = new SqlConnection(DungChung.ChuoiKetNoi);
            string query = "update BC_User set MatKhau=@MatKhau where TaiKhoan=@TaiKhoan";

            SqlCommand Lenh = BaoVe.CreateCommand();
            Lenh.CommandText = query;
            //Khai bao cac tham so
            Lenh.Parameters.Add("@TaiKhoan", SqlDbType.VarChar).Value = TaiKhoan;
            Lenh.Parameters.Add("@MatKhau", SqlDbType.NVarChar).Value = MatKhau;
            
            BaoVe.Open();
            Lenh.ExecuteNonQuery();
            BaoVe.Close();
        }

        private DataTable returnNull(DataTable dt)
        {
            if (dt == null) return dt;
            else
            {
                if (dt.Rows.Count == 0) return null;
                else return dt;
            }
        }
    }

    public class Quyen
    {
        public string MaQuyen;
        public string TenQuyen;
        public DataTable DanhSach()
        {
            SqlConnection BaoVe = new SqlConnection(DungChung.ChuoiKetNoi);
            SqlDataAdapter XeTai = new SqlDataAdapter("select * from BC_Quyen", BaoVe);
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            XeTai.Fill(ThungChua);
            BaoVe.Close();
            return ThungChua;
        }
    }
    public class PhanQuyen
    {
        public string MaQuyen;
        public string TaiKhoan;
        
        public DataTable DanhSach()
        {
            SqlConnection BaoVe = new SqlConnection(DungChung.ChuoiKetNoi);
            SqlDataAdapter XeTai = new SqlDataAdapter("select * from BC_PhanQuyen where TaiKhoan='"+ TaiKhoan+"'", BaoVe);
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            XeTai.Fill(ThungChua);
            BaoVe.Close();
            return ThungChua;
        }
        public void Xoa()
        {
            SqlConnection BaoVe = new SqlConnection(DungChung.ChuoiKetNoi);
            //Khai bao thu tuc luu tru
            string query = "delete from BC_PhanQuyen where TaiKhoan = @TaiKhoan";

            SqlCommand Lenh = BaoVe.CreateCommand();
            Lenh.CommandText = query;
            Lenh.Parameters.Add("@TaiKhoan", SqlDbType.VarChar).Value = TaiKhoan;

            BaoVe.Open();
            Lenh.ExecuteNonQuery();
            BaoVe.Close();
        }
        public void Them()
        {
            SqlConnection BaoVe = new SqlConnection(DungChung.ChuoiKetNoi);
            string query = "INSERT INTO BC_PhanQuyen (TaiKhoan,MaQuyen)"
                            + " values (@TaiKhoan,@MaQuyen)";

            SqlCommand Lenh = BaoVe.CreateCommand();
            Lenh.CommandText = query;
            Lenh.Parameters.Add("@TaiKhoan", SqlDbType.VarChar).Value = TaiKhoan;
            Lenh.Parameters.Add("@MaQuyen", SqlDbType.VarChar).Value = MaQuyen;

            BaoVe.Open();
            Lenh.ExecuteNonQuery();
            BaoVe.Close();
        }
    }

    public class Chart
    {
        public int colx;
        public int coly;
        public string time_ccs;
        public DateTime gio;
        public string soxe;
        public float ccs;
        public string gioxeva;
        public float tl_rac;

        //public DataTable DanhSach()
        //{
        //    SqlConnection BaoVe = new SqlConnection(DungChung.ChuoiKetNoi);
        //    SqlDataAdapter XeTai = new SqlDataAdapter("select * from BC_Chart", BaoVe);
        //    DataTable ThungChua = new DataTable();
        //    BaoVe.Open();
        //    XeTai.Fill(ThungChua);
        //    BaoVe.Close();
        //    return ThungChua;
        //}

        public void GetCCS()
        {
            SqlConnection BaoVe = new SqlConnection(DungChung.ChuoiKetNoi);
            string query = "select top 1 * from NLnhapmia nm " +
                            "inner join nlccsdata cs on nm.ma_pnm=cs.ma_pnm and nm.ng_pnm=cs.ng_pnm " +
                            "where time_ccs>@time_ccs and time_ccs<=@end_time and nm.so_ccs>0 " +
                            "order by time_ccs asc";

            DateTime convert_time = DateTime.Parse(time_ccs);
            string end_time = convert_time.AddDays(1).ToString("yyyy-MM-dd") + " 06:00:00";

            SqlCommand Lenh = BaoVe.CreateCommand();
            Lenh.CommandText = query;
            Lenh.Parameters.Add("@time_ccs", SqlDbType.VarChar).Value = time_ccs;
            Lenh.Parameters.Add("@end_time", SqlDbType.VarChar).Value = end_time;
            BaoVe.Open();
            SqlDataReader docDL;
            docDL = Lenh.ExecuteReader();

            if (docDL.Read())
            {
                gio = DateTime.Parse(docDL["time_ccs"].ToString());
                soxe = docDL["so_xevc"].ToString();
                ccs = float.Parse(docDL["so_ccs"].ToString());
            }
            BaoVe.Close();
        }

        public void DanhSach()
        {
            SqlConnection BaoVe = new SqlConnection(DungChung.ChuoiKetNoi);
            DateTime DateNow = DateTime.Now;
            string fromDay, toDay, thoigian = "";
            if (DateNow.Hour <= 6)
            {
                fromDay = DateNow.AddDays(-1).ToString("yyyy-MM-dd");
                toDay = DateNow.ToString("yyyy-MM-dd");
                thoigian = "time_ccs>='" + fromDay + " 06:00' and time_ccs<'" + toDay + " 06:00'";
            }
            else if (DateNow.Hour > 6)
            {
                fromDay = DateNow.ToString("yyyy-MM-dd");
                toDay = DateNow.AddDays(1).ToString("yyyy-MM-dd");
                thoigian = "time_ccs>='" + fromDay + " 06:00' and time_ccs<'" + toDay + " 06:00'";
            }

            string query = "select * from NLnhapmia nm " +
                            "inner join nlccsdata cs on nm.ma_pnm=cs.ma_pnm and nm.ng_pnm=cs.ng_pnm " +
                            "where time_ccs>@time_ccs and time_ccs<=@end_time and nm.so_ccs>0 " +
                            "order by time_ccs asc";

            DateTime convert_time = DateTime.Parse(time_ccs);
            string end_time = convert_time.AddDays(1).ToString("yyyy-MM-dd") + " 06:00:00";

            SqlCommand Lenh = BaoVe.CreateCommand();
            Lenh.CommandText = query;
            Lenh.Parameters.Add("@time_ccs", SqlDbType.VarChar).Value = time_ccs;
            Lenh.Parameters.Add("@end_time", SqlDbType.VarChar).Value = end_time;
            BaoVe.Open();
            SqlDataReader docDL;
            docDL = Lenh.ExecuteReader();

            if (docDL.Read())
            {
                gio = DateTime.Parse(docDL["time_ccs"].ToString());
                soxe = docDL["so_xevc"].ToString();
                ccs = float.Parse(docDL["so_ccs"].ToString());
            }
            BaoVe.Close();
        }

        public void GetTyLeRac()
        {
            SqlConnection BaoVe = new SqlConnection(DungChung.ChuoiKetNoi);
            string query = "select top 1 * from nlnhapmia " +
                            "where gioxeva>@gioxeva and gioxeva<=@end_time and tl_rac>1 " +
                            "order by gioxeva asc";

            DateTime convert_time = DateTime.Parse(gioxeva);
            string end_time = convert_time.AddDays(1).ToString("yyyy-MM-dd") + " 06:00:00";

            SqlCommand Lenh = BaoVe.CreateCommand();
            Lenh.CommandText = query;
            Lenh.Parameters.Add("@gioxeva", SqlDbType.VarChar).Value = gioxeva;
            Lenh.Parameters.Add("@end_time", SqlDbType.VarChar).Value = end_time;
            BaoVe.Open();
            SqlDataReader docDL;
            docDL = Lenh.ExecuteReader();

            if (docDL.Read())
            {
                gio = DateTime.Parse(docDL["gioxeva"].ToString());
                soxe = docDL["so_xevc"].ToString();
                tl_rac = float.Parse(docDL["tl_rac"].ToString());
            }
            BaoVe.Close();
        }

    }

    public class getdata
    {

        public DataTable sqlcmd_ex(string cmdsql)
        {
            SqlConnection BaoVe = new SqlConnection(DungChung.ChuoiKetNoi);
            SqlDataAdapter XeTai = new SqlDataAdapter(cmdsql, BaoVe);
            DataTable ThungChua = new DataTable();
            BaoVe.Open();
            XeTai.Fill(ThungChua);
            BaoVe.Close();
            return ThungChua;
        }
    }
}