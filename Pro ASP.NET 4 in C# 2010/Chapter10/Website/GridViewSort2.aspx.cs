using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class GridViewSort2 : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
			  
	}
	protected void Page_PreRender(object sender, EventArgs e)
	{
		
	}


	protected void gridEmployees_SelectedIndexChanged(object sender, EventArgs e)
	{
		// Save selected index
        if (gridEmployees.SelectedIndex != -1)
		{
            ViewState["SelectedValue"] = gridEmployees.SelectedValue.ToString();
		}

	}

    protected void gridEmployees_DataBound(object sender, EventArgs e)
	{
		String selectedValue = (String)ViewState["SelectedValue"];
		if (selectedValue == null)
		{
			return;
		}

		// Determine if the selected row is visible and re-select it
        foreach (GridViewRow row in gridEmployees.Rows)
		{
            String keyValue = gridEmployees.DataKeys[row.RowIndex].Value.ToString();
			if (keyValue == selectedValue)
			{
                gridEmployees.SelectedIndex = row.RowIndex;
			}
		}

	}
	protected void lstSorts_SelectedIndexChanged(object sender, EventArgs e)
	{
        gridEmployees.Sort(lstSorts.SelectedValue, SortDirection.Ascending);
	}
}
