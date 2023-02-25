using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataSource = GetTable();
        GridView1.DataBind();
    }

    static DataTable GetTable()
    {
        // Step 2: here we create a DataTable.
        // ... We add 4 columns, each with a Type.
        DataTable table = new DataTable();
        table.Columns.Add("Dosage", typeof(int));
        table.Columns.Add("Drug", typeof(string));
        table.Columns.Add("Diagnosis", typeof(string));
        table.Columns.Add("Date", typeof(DateTime));

        // Step 3: here we add rows.
        table.Rows.Add(25, "Drug A", "Disease A", DateTime.Now);
        table.Rows.Add(50, "Drug Z", "Problem Z", DateTime.Now);
        table.Rows.Add(10, "Drug Q", "Disorder Q", DateTime.Now);
        table.Rows.Add(21, "Medicine A", "Diagnosis A", DateTime.Now);
        return table;
    }
}