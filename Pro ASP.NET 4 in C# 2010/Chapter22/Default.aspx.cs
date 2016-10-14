using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Principal;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User is WindowsPrincipal)
        {
            // First of all, output some user information

            WindowsPrincipal principal = (WindowsPrincipal)User;
            lblInfo.Text += "<br><b>Power user? </b>";
            lblInfo.Text += principal.IsInRole(
              WindowsBuiltInRole.PowerUser).ToString();

            WindowsIdentity identity = (WindowsIdentity)principal.Identity;
            lblInfo.Text += "<br><b>Token: </b>";
            lblInfo.Text += identity.Token.ToString();
            lblInfo.Text += "<br><b>Guest? </b>";
            lblInfo.Text += identity.IsGuest.ToString();
            lblInfo.Text += "<br><b>System? </b>";
            lblInfo.Text += identity.IsSystem.ToString();

            // Next get the roles for the user
            lblInfo.Text += "<hr/>";
            lblInfo.Text += "<h2>Roles:</h2>";

            foreach (IdentityReference SIDRef in identity.Groups)
            {
                lblInfo.Text += "<br/>---";

                try
                {
                    // Get the system-code for the SID
                    SecurityIdentifier sid = (SecurityIdentifier)SIDRef.Translate(typeof(SecurityIdentifier));
                    lblInfo.Text += "<br><b>SID (code): </b></br>";
                    lblInfo.Text += sid.Value;
                }
                catch (Exception ex)
                {
                    lblInfo.Text += "Unable to translate reference: " + SIDRef.Value;
                }

                try
                {
                    // Get the human-readable SID
                    NTAccount account = (NTAccount)SIDRef.Translate(typeof(NTAccount));
                    lblInfo.Text += "<br><b>SID (human-readable): </b></br>";
                    lblInfo.Text += account.Value;
                }
                catch (Exception ex)
                {
                    lblInfo.Text += "Unable to translate sid: " + ex.Message;
                }
            }
        }
    }
}
