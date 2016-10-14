using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class LoginTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // Create test user.
            if (Membership.GetUser("test") == null)
            {
                MembershipCreateStatus status;
                Membership.CreateUser("test", "test99!", "", "Why should you not panic?", "This is only a test.", true, out status);
                if (status != MembershipCreateStatus.Success)
                {
                    lblInfo.InnerHtml = "Attempt to create user \"test\" failed with " + status.ToString();
                    return;
                }

                // Place test user in role. 
                if (!Roles.RoleExists("Administrator"))
                {
                    Roles.CreateRole("Administrator");
                    Roles.AddUserToRole("test", "Administrator");
                }

                // Assign profile values.
                ProfileCommon profile = Profile.GetProfile("test");
                profile.FirstName = "Tester";
                profile.LastName = "Smith";
                profile.CustomerCode = "540-SLJTE";
                profile.Save();
            }           
        }
    }
}
