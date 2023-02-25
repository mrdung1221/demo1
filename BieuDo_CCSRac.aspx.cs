using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

public partial class BieuDo_CCSRac : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        VietSugar.Chart c = new VietSugar.Chart();
    }
    [WebMethod]

    public static List<ChartInfo> GetChartInfo(string time_ccs)
    {
        VietSugar.Chart c = new VietSugar.Chart();

        if (time_ccs == "" || time_ccs == null)
        {
            time_ccs = DateTime.Now.ToString("yyyy-MM-dd") + " 06:00:00";
            //time_ccs = "2022-03-10 06:00:00";
        }

        c.time_ccs = time_ccs;
        c.GetCCS();

        time_ccs = c.gio.ToString("yyyy-MM-dd HH:mm:ss");
        List<ChartInfo> chart = new List<ChartInfo>();
        chart.Add(new ChartInfo
        {
            colx = c.soxe,
            coly = c.ccs,
            gio = time_ccs
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