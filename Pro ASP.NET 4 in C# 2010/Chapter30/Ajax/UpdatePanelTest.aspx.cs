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

public partial class UpdatePanelTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Uncomment to test slow postbacks.
        //if (IsPostBack)
        //    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(10));


        // Uncomments to test error handling.
        //if (IsPostBack)
        //    throw new ApplicationException("This operation failed.");

        Label1.Text = DateTime.Now.ToLongTimeString();
        Label2.Text = DateTime.Now.ToLongTimeString();
        Label3.Text = DateTime.Now.ToLongTimeString();
    }
    
}
