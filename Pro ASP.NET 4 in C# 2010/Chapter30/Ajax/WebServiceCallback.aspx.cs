using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class WebServiceCallback : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void cmdOK_Click(object sender, EventArgs e)
    {
        lblInfo.Text = "You selected territory ID #" + Request.Form["lstTerritories"];

        // Reset the region list box (because the territory list box will be empty).
        lstRegions.SelectedIndex = 0;
    }
}
