using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class dientich : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            VietSugar.DienTich dt = new VietSugar.DienTich();
            GridView1.DataSource = dt.DanhSach();
            
            //GridViewHelper 
            GridViewHelper helper = new GridViewHelper(this.GridView1);
            //helper.RegisterGroup("UserLog", true, true);
            //helper.RegisterSummary("Ma_vmia", SummaryOperation.Sum, "UserLog");
            //helper.RegisterSummary("DT_DoDac1", SummaryOperation.Sum, "UserLog");

            helper.RegisterGroup("UserLog", true, true);
            helper.GroupHeader += new GroupEvent(helper_GroupHeader);

            
            //helper.RegisterSummary("Ma_vmia", SummaryOperation.Sum, "UserLog");
            helper.RegisterSummary("DT_DoDac1", SummaryOperation.Sum, "UserLog");
            
            helper.GroupSummary += new GroupEvent(helper_GroupSummary);
            
            

            GridView1.DataBind();
        }
    }
    private void helper_GroupSummary(string groupName, object[] values, GridViewRow row)
    {
        row.BackColor = Color.Bisque;
        row.ForeColor = Color.Blue;
        row.Font.Bold = true;
        row.Cells[0].HorizontalAlign = HorizontalAlign.Left;
        row.Cells[0].Text = "Cộng";
    }
    private void helper_GroupHeader(string groupName, object[] values, GridViewRow row)
    {
        row.BackColor = Color.LightBlue;
        row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
        //row.Cells[0].Text = "&nbsp;&nbsp;" + row.Cells[0].Text;
    }

    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
        TableHeaderCell cell = new TableHeaderCell();
        cell.Text = "STT";
        cell.ColumnSpan = 1;
        row.Controls.Add(cell);

        cell = new TableHeaderCell();
        cell.Text = "Nhóm 1";
        cell.ColumnSpan = 2;
        row.Controls.Add(cell);

        cell = new TableHeaderCell();
        cell.ColumnSpan = 3;
        cell.Text = "Nhóm 2";
        row.Controls.Add(cell);

        row.BackColor = ColorTranslator.FromHtml("#3AC0F2");
        GridView1.HeaderRow.Parent.Controls.AddAt(0, row);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        VietSugar.DienTich dt = new VietSugar.DienTich();
        GridView1.DataSource = dt.DanhSach();
        GridView1.DataBind();
    }
}