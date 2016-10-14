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

public partial class PageProcessor_Target : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		// Simulate a slow page loading (wait 5 seconds).
		System.Threading.Thread.Sleep(5000);
    }
}
