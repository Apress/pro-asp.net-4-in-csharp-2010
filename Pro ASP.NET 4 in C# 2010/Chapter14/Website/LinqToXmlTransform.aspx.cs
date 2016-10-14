using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class LinqToXmlTransform : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string xmlFile = Server.MapPath("DvdList2.xml");
        XDocument doc = XDocument.Load(xmlFile);

        XDocument newDoc = new XDocument(
          new XDeclaration("1.0", "utf-8", "yes"),          
          new XElement("Movies",
              from DVD in doc.Descendants("DVD")
              where (int)DVD.Attribute("ID") < 3
              select new XElement[] {
                 new XElement("Movie",
                   new XAttribute("Name", (string)DVD.Element("Title")),
                   DVD.Descendants("Star")
                 )
              }
          )
        );
                 
        lblXml.Text = Server.HtmlEncode(newDoc.ToString());
        
    }
}
