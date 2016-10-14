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

public partial class Frame1 : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}
	protected void Button1_Click(object sender, EventArgs e)
	{

		string url = "http://www.google.com";
        string frameScript = "<script type='text/javascript'>" +
		"window.parent.content.location='" + url + "';</script>";
		Page.ClientScript.RegisterStartupScript(this.GetType(), "FrameScript", frameScript);

	}
}
