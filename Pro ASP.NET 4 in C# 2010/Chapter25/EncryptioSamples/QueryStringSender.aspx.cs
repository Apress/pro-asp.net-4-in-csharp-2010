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

public partial class QueryStringSender : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void SendCommand_Click(object sender, EventArgs e)
    {
        EncryptedQueryString QueryString = new EncryptedQueryString();

        QueryString.Add("MyData", MyData.Text);
        QueryString.Add("MyTime", DateTime.Now.ToLongTimeString());
        QueryString.Add("MyDate", DateTime.Now.ToLongDateString());

        Response.Redirect("QueryStringRecipient.aspx?data=" + QueryString.ToString());
    }
}
