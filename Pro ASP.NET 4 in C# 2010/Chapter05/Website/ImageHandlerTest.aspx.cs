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
using System.IO;

public partial class ImageHandlerTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtUrl.Text = Request.Url.Scheme + "://"
            + Request.Url.Authority + Request.Url.Segments[0]
            + Request.Url.Segments[1] + "Images/360.gif";
    }
}
