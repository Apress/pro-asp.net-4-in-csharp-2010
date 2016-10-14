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
using System.Text;

public partial class LinqToXml : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WriteXML();
        ReadXML();
    }

    private void WriteXML()
    {
        XDocument doc = new XDocument(
          new XDeclaration("1.0", "utf-8", "yes"),
		  new XComment("Created: " + DateTime.Now.ToString()),
	      new XElement("DvdList",
              new XElement("DVD",
                  new XAttribute("ID", "1"),
                  new XAttribute("Category", "Science Fiction"),
                  new XElement("Title", "The Matrix"),
                  new XElement("Director", "Larry Wachowski"),
                  new XElement("Price", "18.74"),
                  new XElement("Starring",
                      new XElement("Star", "Keanu Reeves"),
                      new XElement("Star", "Laurence Fishburne")
                  )
              ),
              new XElement("DVD",
                  new XAttribute("ID", "2"),
                  new XAttribute("Category", "Drama"),
                  new XElement("Title", "Forrest Gump"),
                  new XElement("Director", "Robert Zemeckis"),
                  new XElement("Price", "23.99"),
                  new XElement("Starring",
                      new XElement("Star", "Tom Hanks"),
                      new XElement("Star", "Robin Wright")
                  )
              ),
              new XElement("DVD",
                  new XAttribute("ID", "3"),
                  new XAttribute("Category", "Horror"),
                  new XElement("Title", "The Others"),
                  new XElement("Director", "Alejandro Amenábar"),
                  new XElement("Price", "22.49"),
                  new XElement("Starring",
                      new XElement("Star", "Nicole Kidman"),
                      new XElement("Star", "Christopher Eccleston")
                  )
              ),
              new XElement("DVD",
                  new XAttribute("ID", "4"),
                  new XAttribute("Category", "Mystery"),
                  new XElement("Title", "Mulholland Drive"),
                  new XElement("Director", "David Lynch"),
                  new XElement("Price", "25.74"),
                  new XElement("Starring",
                      new XElement("Star", "Laura Harring")
                  )
              ),
              new XElement("DVD",
                  new XAttribute("ID", "5"),
                  new XAttribute("Category", "Science Fiction"),
                  new XElement("Title", "A.I. Artificial Intelligence"),
                  new XElement("Director", "Steven Spielberg"),
                  new XElement("Price", "23.99"),
                  new XElement("Starring",
                      new XElement("Star", "Haley Joel Osment"),
                      new XElement("Star", "Jude Law")
                  )
              )
           )
        );

        doc.Save(Server.MapPath("DvdList2.xml"));
    }

    private void ReadXML()
    {
        // Create the reader.
        string xmlFile = Server.MapPath("DvdList2.xml");
        XDocument doc = XDocument.Load(xmlFile);

        StringBuilder str = new StringBuilder();
        foreach (XElement element in doc.Element("DvdList").Elements())
        {
                str.Append("<ul><b>");            
                str.Append((string)element.Element("Title"));
                str.Append("</b><li>");
            str.Append((string)element.Element("Director"));
                str.Append("</li><li>");
            str.Append(String.Format("{0:C}", (decimal)element.Element("Price")));
                str.Append("</li></ul>");
        }        
        
        lblXml.Text = str.ToString();

    }
}
