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

public partial class NavigationNonHierarchicalControls : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!Page.IsPostBack)
		{
			lstChild.DataSource = SiteMap.CurrentNode.ParentNode.ChildNodes;
			lstParent.DataSource = SiteMap.CurrentNode.ParentNode.ParentNode.ChildNodes;
			lstChild.DataTextField = "Title";
			lstChild.DataValueField = "Url";
			lstParent.DataTextField = "Title";
			lstParent.DataValueField = "Url";
			this.DataBind();
		}

    }
	protected void Nav_SelectedIndexChanged(object sender, EventArgs e)
	{
		ListControl ctrl = (ListControl)sender;
		SiteMapNode node = SiteMap.Provider.FindSiteMapNode(ctrl.SelectedValue);
		Response.Redirect(node.Url);
	}


}
