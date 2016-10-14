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

public partial class Anonymous : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!Page.IsPostBack)
			LoadProfile();
		
    }
	protected void cmdSave_Click(object sender, EventArgs e)
	{
		Profile.Address = new Address(txtName.Text, txtStreet.Text, txtCity.Text, txtZip.Text, txtState.Text, txtCountry.Text);
	}
	protected void txt_TextChanged(object sender, EventArgs e)
	{

	}
	protected void cmdLogin_Click(object sender, EventArgs e)
	{
		Profile.Address = new Address(txtName.Text, txtStreet.Text, txtCity.Text, txtZip.Text, txtState.Text, txtCountry.Text);

		// User will be forced to log in when accessing this secured page.
		// After logging in, the data shown is the user-specific data,
		// which is migrated from the anonymous profile.
		Response.Redirect("../ComplexTypes.aspx");
	}

	private void LoadProfile()
	{
		txtName.Text = Profile.Address.Name;
		txtStreet.Text = Profile.Address.Street;
		txtCity.Text = Profile.Address.City;
		txtZip.Text = Profile.Address.ZipCode;
		txtState.Text = Profile.Address.State;
		txtCountry.Text = Profile.Address.Country;
	}
}
