using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class ViewStateObjects : System.Web.UI.Page
{
	protected void cmdSave_Click(object sender, EventArgs e)
	{
		// Put the text in the Dictionary.
		var textToSave = new Dictionary<string,string>();
        SaveAllText(Page.Controls, textToSave, true);

		// Store the entire collection in view state.
        ViewState["ControlText"] = textToSave;
	}

	private void SaveAllText(ControlCollection controls, Dictionary<string,string> textToSave, bool saveNested)
	{
		foreach (Control control in controls)
		{
			if (control is TextBox)
			{
				// Add the text to the Dictionary.
				textToSave.Add(control.ID, ((TextBox)control).Text);
			}
			if ((control.Controls != null) && saveNested)
			{
				SaveAllText(control.Controls, textToSave, true);
			}
		}
	}

	protected void cmdRestore_Click(object sender, EventArgs e)
	{
		if (ViewState["ControlText"] != null)
		{
			// Retrieve the Dictionary.
			var savedText = (Dictionary<string, string>)ViewState["ControlText"];

            // Display all the text by looping through the Dictionary.
			lblResults.Text = "";
			foreach (KeyValuePair<string, string> item in savedText)
			{
				lblResults.Text += item.Key + " = " + item.Value + "<br />";
			}
		}
	}
}
