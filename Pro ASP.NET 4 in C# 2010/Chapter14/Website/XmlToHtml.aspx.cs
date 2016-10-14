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
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Xml;
using System.IO;

public partial class XmlToHtml : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		string xslFile = Server.MapPath("DvdList.xsl");
		string xmlFile = Server.MapPath("DvdList.xml");
		string htmlFile = Server.MapPath("DvdList.htm");

		XslCompiledTransform transf = new XslCompiledTransform();
		transf.Load(xslFile);
		transf.Transform(xmlFile, htmlFile);

		// Create an XPathDocument.
		XPathDocument xdoc = new XPathDocument(new XmlTextReader(xmlFile));

		// Create an XPathNavigator.
        XPathNavigator xnav = xdoc.CreateNavigator();

		// Transform the XML
        MemoryStream ms = new MemoryStream();
        XsltArgumentList args = new XsltArgumentList();
        transf.Transform(xnav, args, ms);
           
		// Go the the content and write it.
        StreamReader r = new StreamReader(ms);
        ms.Position = 0;
		Response.Write(r.ReadToEnd());
        r.Close();
    }
}
