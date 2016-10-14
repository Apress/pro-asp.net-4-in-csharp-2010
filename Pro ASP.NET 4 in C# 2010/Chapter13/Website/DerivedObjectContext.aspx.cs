using System;
using NorthwindModel;

public partial class DerivedObjectContext : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        NorthwindEntities db = new NorthwindEntities();

        GridView1.DataSource = db.Products;
        GridView1.DataBind();
    }
}