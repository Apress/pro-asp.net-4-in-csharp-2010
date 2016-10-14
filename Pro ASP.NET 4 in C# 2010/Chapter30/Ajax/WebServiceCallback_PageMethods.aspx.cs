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
using System.Web.Services;
using System.Collections.Generic;

public partial class WebServiceCallback_PageMethods : System.Web.UI.Page
{
    protected void cmdOK_Click(object sender, EventArgs e)
    {
        lblInfo.Text = "You selected territory ID #" + Request.Form["lstTerritories"];

        // Reset the region list box (because the territory list box will be empty).
        lstRegions.SelectedIndex = 0;
    }

    [WebMethod()]
    [System.Web.Script.Services.ScriptMethod()] 
    public static List<Territory> GetTerritoriesInRegion(int regionID)
    {
        // Farm the work out to the web service class.
        TerritoriesService service = new TerritoriesService();
        return service.GetTerritoriesInRegion(regionID);
    }
}
