using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
    private const string LanguageSessionKey = "CurrentLanguage";

    protected override void InitializeCulture()
    {
        base.InitializeCulture();

        if (Session[_Default.LanguageSessionKey] != null)
        {
            // Set the current culture for the page
            Page.UICulture = Session[_Default.LanguageSessionKey].ToString();
            Page.Culture = Session[_Default.LanguageSessionKey].ToString();
        }
    }

    protected void SwitchCommand_Click(object sender, EventArgs e)
    {
        if (LanguageList.SelectedIndex >= 0)
        {
            Session[_Default.LanguageSessionKey] = LanguageList.SelectedValue;
            Response.Redirect(Request.Url.ToString());
        }
    }
}
