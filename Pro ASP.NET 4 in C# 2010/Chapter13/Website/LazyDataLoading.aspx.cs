using System;
using System.Collections.Generic;
using System.Linq;
using NorthwindModel;

public partial class LazyDataLoading : System.Web.UI.Page {

    protected void Page_Load(object sender, EventArgs e) {

        NorthwindEntities db = new NorthwindEntities();

        IEnumerable<Customer> custs = from c in db.Customers
                                      where c.City == "London" && c.Country == "UK"
                                      select c;

        List<string> names = new List<string>();

        foreach (Customer c in custs) {
            if (c.Orders.Count() > 2) {
                names.Add(c.CompanyName);
            }
        }

        GridView1.DataSource = names;
        GridView1.DataBind();
    }
}