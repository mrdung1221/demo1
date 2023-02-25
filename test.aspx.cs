using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string now = DateTime.Now.ToString("yyyy-MM-dd") + " 06:00:00";
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('"+now+"')", true);
        DateTime time = DateTime.Parse(now);
        Label1.Text = time.ToString("yyyy-MM-dd HH:mm:ss");
    }
}