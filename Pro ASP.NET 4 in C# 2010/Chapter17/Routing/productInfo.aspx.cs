using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class productInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string productID = (string)Page.RouteData.Values["productID"];
        lblInfo.Text = "You requested " + productID;
    }
}