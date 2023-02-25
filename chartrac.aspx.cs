using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;

public partial class chartrac : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]

    public static List<ChartInfo> GetChartInfo(string gioxeva)
    {
        VietSugar.Chart c = new VietSugar.Chart();

        if (gioxeva == "" || gioxeva == null)
        {
            gioxeva = DateTime.Now.ToString("yyyy-MM-dd") + " 06:00:00";
            //gioxeva = "2022-03-10 06:00:00";
        }

        c.gioxeva = gioxeva;
        c.GetTyLeRac();

        gioxeva = c.gio.ToString("yyyy-MM-dd HH:mm:ss");
        List<ChartInfo> chart = new List<ChartInfo>();
        chart.Add(new ChartInfo
        {
            colx = c.soxe,
            coly = c.tl_rac,
            gio = gioxeva
        });


        return chart;
    }
    public class ChartInfo
    {
        public string colx { get; set; }
        public float coly { get; set; }
        public string gio { get; set; }
    }
}