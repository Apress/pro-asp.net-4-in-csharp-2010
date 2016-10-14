using System;
using System.Collections.Generic;
using System.Linq;
using NorthwindModel;

public partial class FilteringTooLate : System.Web.UI.Page {

    protected void Page_Load(object sender, EventArgs e) {

NorthwindEntities db = new NorthwindEntities();

IEnumerable<Customer> custs = from c in db.Customers
                                where c.Country == "UK"
                                select c;

IEnumerable<Customer> results = from c in custs
                                where c.City == "London"
                                select c;

GridView1.DataSource = results;
GridView1.DataBind();
    }
}