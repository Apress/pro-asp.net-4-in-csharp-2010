using System;
using System.Collections.Generic;
using System.Linq;
using NorthwindModel;

public partial class StoredProcedure : System.Web.UI.Page {

    protected void Page_Load(object sender, EventArgs e) {

        NorthwindEntities db = new NorthwindEntities();

        IEnumerable<Customers_By_City_Result> results =
            from c in db.Customers_By_City("London")
            select c;

        GridView1.DataSource = results;
        GridView1.DataBind();
    }
}