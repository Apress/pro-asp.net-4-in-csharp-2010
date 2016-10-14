using System;
using System.Xml;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Resources;
using System.Globalization;
using System.Xml.Xsl;
using System.IO;

public partial class Default_aspx : System.Web.UI.Page
{
    // Page events are wired up automatically to methods 
    // with the following names:
    // Page_Load, Page_AbortTransaction, Page_CommitTransaction,
    // Page_DataBinding, Page_Disposed, Page_Error, Page_Init, 
    // Page_Init Complete, Page_Load, Page_LoadComplete, Page_PreInit
    // Page_PreLoad, Page_PreRender, Page_PreRenderComplete, 
    // Page_SaveStateComplete, Page_Unload

    protected void Page_Load(object sender, EventArgs e)
    {
        // These are simple string resources
        LegendFirstname.Text = Resources.MyResourceStrings.LegendFirstname;
        LegendLastname.Text = Resources.MyResourceStrings.LegendLastname;
        LegendAge.Text = Resources.MyResourceStrings.LegendAge;
    }

    protected void GenerateAction_Click(object sender, EventArgs e)
    {
        // Now get the XML file and the XSL/T template 
        // for report generation from the resources
        string XmlTemplate = Resources.MyResourceStrings.XmlTemplate;
        string XslTemplate = Resources.MyResourceStrings.ReportTemplate;

        // Load the XmlTemplate into a DOM and initalize its properties
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(XmlTemplate);
        doc.SelectSingleNode(".//Firstname").InnerText = TextFirstname.Text;
        doc.SelectSingleNode(".//Lastname").InnerText = TextLastname.Text;
        doc.SelectSingleNode(".//Age").InnerText = TextAge.Text;

        // Prepare XmlTextReader for loading the
        // XSL/T stylesheet and then create an XslTransform 
        // object for the XSL/T transformation
        XmlTextReader ReaderForXsl = new XmlTextReader(
                                         new StringReader(XslTemplate));
        XslTransform transform = new XslTransform();
        transform.Load(ReaderForXsl);

        // Now initialize the properties of 
        // the XML control on the page
        DocumentXml.DocumentContent = doc.OuterXml;
        DocumentXml.Transform = transform;
    }
}