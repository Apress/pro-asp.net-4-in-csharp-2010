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
using System.Collections.Generic;

public partial class LinqToXmlQuery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string xmlFile = Server.MapPath("DvdList2.xml");
        XDocument doc = XDocument.Load(xmlFile);
        
        //IEnumerable<XElement> matches = from DVD in doc.Descendants("DVD")
        //              where (int)DVD.Attribute("ID") < 3
        //              select DVD.Element("Title");

        var matches = from DVD in doc.Descendants("DVD")
                      orderby (decimal)DVD.Element("Price") descending
                      select new
                      {
                          Movie = (string)DVD.Element("Title"),
                          Price = (decimal)DVD.Element("Price")
                      };
        gridTitles.DataSource = matches;
        gridTitles.DataBind();


        //var matches = from title in doc.Root.Elements("DVD").Elements("Title")
        //              select (string)title;

        gridTitles.DataSource = matches;
        gridTitles.DataBind();
        
    }
}
