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
using System.Xml.Schema;
using System.Xml;
using System.IO;

public partial class XmlValidation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

	private void MyValidateHandler(Object sender, ValidationEventArgs e)
	{
		lblStatus.Text += "Error: " + e.Message + "<br>";
	}
	protected void cmdValidate_Click(object sender, EventArgs e)
	{
		string filePath = "";
		if (optValid.Checked)
		{
			filePath = Server.MapPath("DvdList.xml");
		}
		else if (optInvalidData.Checked)
		{
			filePath += Server.MapPath("DvdListInvalid.xml");
		}

		lblStatus.Text = "";

		// Set the validation settings.
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.Schemas.Add("", Server.MapPath("DvdList.xsd"));
        settings.ValidationType = ValidationType.Schema;
        settings.ValidationEventHandler += MyValidateHandler;

        // Open the XML file.
        FileStream fs = new FileStream(filePath, FileMode.Open);

        // Create the validating reader.
        XmlReader r = XmlReader.Create(fs, settings);

		// Read through the document.
		while (r.Read())
		{
			// Process document here.
			// If an error is found, an exception will be thrown.
		}

		r.Close();

		lblStatus.Text += "<br />Complete.";
	}
}
