using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using VietSugar;
public partial class upanh : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
      //  string ChuoiKetNoi = @"Data Source=mrdung;Initial Catalog=KSCDB;USER ID = sa; PASSWORD = 123456";
        SqlConnection connection = new SqlConnection(VietSugar.DungChung.ChuoiKetNoi);
       
        try
        {
            FileUpload img = (FileUpload)imgUpload;
            Byte[] imgByte = null;
            if (img.HasFile && img.PostedFile != null)
            {
                HttpPostedFile File = imgUpload.PostedFile;                //Create byte Array with file len
                imgByte = new Byte[File.ContentLength];                //force the control to load data in array
                File.InputStream.Read(imgByte, 0, File.ContentLength);
            }
            connection.Open();
           string stringsql = "INSERT INTO luuhinh1(empname,empimg) VALUES(@enm, @eimg) SELECT @@IDENTITY";
            SqlCommand cmd = new SqlCommand(stringsql, connection);
            cmd.Parameters.AddWithValue("@enm", txtEName.Text.Trim());
            cmd.Parameters.AddWithValue("@eimg", imgByte);
              int id = Convert.ToInt32(cmd.ExecuteScalar());
           // string id = txtEName.Text.Trim();
            lblResult.Text = String.Format("Employee ID is {0}", id);
            Image1.ImageUrl = "~/ShowImage.ashx?id=" + id;
        }
        catch { lblResult.Text = "There was an error"; }
        finally { connection.Close(); }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Image1.ImageUrl = "~/ShowImage.ashx?id=" + 1;
    }
  
    

}