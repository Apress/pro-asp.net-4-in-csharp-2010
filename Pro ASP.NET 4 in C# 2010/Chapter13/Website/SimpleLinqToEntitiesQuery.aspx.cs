using System;
using System.Linq;
using NorthwindModel;

public partial class SimpleLinqToEntitiesQuery : System.Web.UI.Page {

    protected void Page_Load(object sender, EventArgs e) {

        NorthwindEntities db = new NorthwindEntities();

        var results = from p in db.Products
                      where p.Discontinued == false
                      select new {
                          ID = p.ProductID,
                          Name = p.ProductName
                      };

        GridView1.DataSource = results;
        GridView1.DataBind();
    }
}