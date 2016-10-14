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

public partial class CrossPageTarget : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (PreviousPage != null)
		{
			if (!PreviousPage.IsValid)
			{
				Response.Redirect(Request.UrlReferrer.AbsolutePath + "?err=true");
			}
			else
			{
				lbl.Text = "You came from a page titled " +
					 PreviousPage.Header.Title + "<br />";
				CrossPageSource prevPage = PreviousPage as CrossPageSource;

				if (prevPage != null)
				{
                    lbl.Text += "You typed in this: " + prevPage.TextBoxContent + "<br />";
				}

				if (PreviousPage.IsCrossPagePostBack)
				{
                    lbl.Text += "The page was posted directly";
				}
				else
				{
                    lbl.Text += "You used Server.Transfer()";
				}
			}
		}
	}
}