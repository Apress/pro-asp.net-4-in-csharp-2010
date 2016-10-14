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
using System.Text;
using System.Web.Configuration;

public partial class UseCustomSettings_aspx : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		StringBuilder builder = new StringBuilder();

        // This throws an error in Windows Vista when Visual Studio is not running as an administrator.
        // To resolve, right-click the Visual Studio shortcut in the Start menu and choose Run As Administrator.
		OrderService custSection = (OrderService)WebConfigurationManager.GetSection("orderService");

		lblInfo.Text += "Retrieved service information...<br />" +
		  "<b>Location (computer):</b> " + custSection.Location.Computer +
		  "<br /><b>Available:</b> " + custSection.Available.ToString() +
		  "<br /><b>Timeout:</b> " + custSection.PollTimeout.ToString() + "<br /><br />";

    }
}
