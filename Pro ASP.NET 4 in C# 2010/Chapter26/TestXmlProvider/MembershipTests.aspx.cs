using System;
using System.Data;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class ManageUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    private void WriteUsers(MembershipUserCollection users)
    {
        StringBuilder Info = new StringBuilder();

        foreach (MembershipUser SingleUser in users)
        {
            Info.AppendFormat("{0} ({1})<BR>", 
                SingleUser.UserName, SingleUser.Email);
        }

        ResultsLabel.Text = Info.ToString();
    }

    private void WriteUserDetails(MembershipUser singleUser)
    {
        StringBuilder Info = new StringBuilder();

        Info.AppendFormat("{0}<br>", singleUser.UserName);
        Info.AppendFormat("{0}<br>", singleUser.Email);
        Info.AppendFormat("{0}<br>", singleUser.CreationDate);
        Info.AppendFormat("{0}<br>", singleUser.Comment);

        ResultsLabel.Text = Info.ToString();
    }

    protected void DeleteUser_Click(object sender, EventArgs e)
    {
        if (Membership.DeleteUser(UserNameText.Text))
        {
            ResultsLabel.Text = "Successfully deleted user!";
        }
        else
        {
            ResultsLabel.Text = "Unable to delete user!";
        }
    }
    
    protected void FindByName_Click(object sender, EventArgs e)
    {
        MembershipUserCollection Users = Membership.FindUsersByName(UserNameText.Text);
        WriteUsers(Users);
    }
    
    protected void FindByEmail_Click(object sender, EventArgs e)
    {
        MembershipUserCollection Users = Membership.FindUsersByEmail(UserNameText.Text);
        WriteUsers(Users);
    }
    
    protected void GetAllUsers_Click(object sender, EventArgs e)
    {
        MembershipUserCollection Users = Membership.GetAllUsers();
        WriteUsers(Users);        
    }
    
    protected void GetUser_Click(object sender, EventArgs e)
    {
        WriteUserDetails(Membership.GetUser(UserNameText.Text));
    }
    
    protected void GetUserNameByEmail_Click(object sender, EventArgs e)
    {
        ResultsLabel.Text = Membership.GetUserNameByEmail(UserNameText.Text);
    }
    
    protected void UpdateUser_Click(object sender, EventArgs e)
    {
        MembershipUser SingleUser = Membership.GetUser(UserNameText.Text);
        SingleUser.Comment = "Updated on " + DateTime.Now.ToString();
        Membership.UpdateUser(SingleUser);
    }
}
