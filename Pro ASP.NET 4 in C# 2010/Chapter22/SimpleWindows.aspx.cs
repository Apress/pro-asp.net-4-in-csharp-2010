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
using System.Security.Principal;

public partial class SimpleWindows : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.IsAuthenticated)
        {
            // Display generic identity information.
            lblInfo.Text = "<b>Name: </b>" + User.Identity.Name;
            //lblInfo.Text += "<br><b>Authenticated With: </b>";

            if (User is WindowsPrincipal)
            {
                WindowsPrincipal principal = (WindowsPrincipal)User;
                //lblInfo.Text += "<br><b>Power user? </b>";
                //lblInfo.Text += principal.IsInRole(
                //  WindowsBuiltInRole.PowerUser).ToString();

                WindowsIdentity identity = principal.Identity as WindowsIdentity;
                lblInfo.Text += "<br><b>Token: </b>";
                lblInfo.Text += identity.Token.ToString();
                lblInfo.Text += "<br><b>Guest? </b>";
                lblInfo.Text += identity.IsGuest.ToString();
                lblInfo.Text += "<br><b>System? </b>";
                lblInfo.Text += identity.IsSystem.ToString();
            }

        }
    }
}
