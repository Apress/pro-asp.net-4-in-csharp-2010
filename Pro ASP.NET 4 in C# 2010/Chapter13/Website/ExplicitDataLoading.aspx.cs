using System;
using System.Collections.Generic;
using System.Linq;
using NorthwindModel;

public partial class ExplicitDataLoading : System.Web.UI.Page {

    protected void Page_Load(object sender, EventArgs e) {

        NorthwindEntities db = new NorthwindEntities();
        db.ContextOptions.LazyLoadingEnabled = false;

        IEnumerable<Customer> custs = from c in db.Customers
                                      where c.Country == "UK"
                                      select c;

        foreach (Customer c in custs) {
            if (c.City == "London") {
                c.Orders.Load();
            }
        }

        List<Order> orders = new List<Order>();

        foreach (Customer c in custs) {
            if (c.Orders.IsLoaded) {
                orders.Add(c.Orders.First());
            }
        }

        GridView1.DataSource = orders;
        GridView1.DataBind();
    }
}