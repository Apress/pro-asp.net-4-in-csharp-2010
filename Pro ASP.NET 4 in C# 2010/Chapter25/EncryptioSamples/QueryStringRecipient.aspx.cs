using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class QueryStringRecipient : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Deserialize the encrypted query string
        EncryptedQueryString QueryString =
            new EncryptedQueryString(Request.QueryString["data"]);

        // Write information to the screen
        StringBuilder Info = new StringBuilder();
        foreach (String key in QueryString.Keys)
        {
            Info.AppendFormat("{0} = {1}<br>", key, QueryString[key]);
        }
        QueryStringLabel.Text = Info.ToString();
    }
}
