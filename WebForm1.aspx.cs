using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using ExifLib;
public partial class WebForm1 : System.Web.UI.Page
{


    private void Page_Load(object sender, System.EventArgs e)
    {
        // Put user code to initialize the page here
    }
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        // CODEGEN: This call is required by the ASP.NET Web Form Designer.
        InitializeComponent();
        base.OnInit(e);
    }
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.Button1.Click += new System.EventHandler(this.Button1_Click);
        this.Load += new System.EventHandler(this.Page_Load);
    }
    #endregion



    protected void Button1_Click(object sender, EventArgs e)
    {
        TextBox1.Text = string.Empty;
        TextBox2.Text = string.Empty;
        TextBox3.Text = string.Empty;
       
        string strFileName;
        string strFilePath = string.Empty ;
        string strFolder;
        strFolder = Server.MapPath("images/");
        // Get the name of the file that is posted.
        strFileName = FileUpload1.PostedFile.FileName;
        strFileName = Path.GetFileName(strFileName);
        if (strFileName != "")
        {
            // Create the directory if it does not exist.
            if (!Directory.Exists(strFolder))
            {
                Directory.CreateDirectory(strFolder);
            }
            // Save the uploaded file to the server.
            strFilePath = strFolder + strFileName;
            if (File.Exists(strFilePath))
            {
                lblUploadResult.Text = strFileName + " already exists on the server!";
            }
            else
            {
                FileUpload1.PostedFile.SaveAs(strFilePath);
                lblUploadResult.Text = strFileName + " has been successfully uploaded.";
            }

            using (var reader = new ExifReader(strFilePath))
            {
                Double[] GpsLongArray;
                Double[] GpsLatArray;
                Double GpsLongDouble;
                Double GpsLatDouble;
                try
                {
                    if (reader.GetTagValue<Double[]>(ExifTags.GPSLongitude, out GpsLongArray)
                             && reader.GetTagValue<Double[]>(ExifTags.GPSLatitude, out GpsLatArray))
                    {
                        GpsLongDouble = GpsLongArray[0] + GpsLongArray[1] / 60 + GpsLongArray[2] / 3600;
                        GpsLatDouble = GpsLatArray[0] + GpsLatArray[1] / 60 + GpsLatArray[2] / 3600;

                        TextBox1.Text = (GpsLongDouble.ToString());
                        TextBox2.Text = (GpsLatDouble.ToString());
                    }
                    DateTime datePictureTaken;
                    if (reader.GetTagValue<DateTime>(ExifTags.DateTimeOriginal,
                                                    out datePictureTaken))
                    {
                        TextBox3.Text = datePictureTaken.ToString();
                    }
                }
                catch { lblUploadResult.Text = "Ảnh Không Hợp Lệ."; }


            }
        }
        else
        {
            lblUploadResult.Text = "Click 'Browse' to select the file to upload.";
        }
        // Display the result of the upload.
        frmConfirmation.Visible = true;
        Image1.ImageUrl = "~/images/"+ strFileName;
    }
}