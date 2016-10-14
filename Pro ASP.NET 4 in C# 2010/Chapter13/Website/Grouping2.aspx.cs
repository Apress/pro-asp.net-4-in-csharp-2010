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
using DatabaseComponent;
using System.Collections.Generic;

public partial class Grouping2 : System.Web.UI.Page
{    
    private ProductDB dbProduct = new ProductDB();

    protected void Page_Load(object sender, EventArgs e)
    {
        List<ProductDetails> products = dbProduct.GetProducts();
        var matches = from p in products
                      group p by p.CategoryID into g
                      select new
                      {
                          Category = g.Key,
                          MaximumPrice = g.Max(p => p.UnitPrice),
                          MinimumPrice = g.Min(p => p.UnitPrice),
                          AveragePrice = g.Average(p => p.UnitPrice)
                      }; 

        gridEmployees.DataSource = matches;
        gridEmployees.DataBind();

    }
}
