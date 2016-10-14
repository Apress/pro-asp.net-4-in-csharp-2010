using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NorthwindModel;

public partial class Database_Operations_Update : System.Web.UI.Page {

    protected void Page_Load(object sender, EventArgs e) {

        NorthwindEntities db = new NorthwindEntities();

        Customer cust = (from c in db.Customers
                        where c.CustomerID == "LAWN"
                        select c).Single();

        cust.ContactName = "John Smith";
        cust.Fax = "(800) 123 1234";

        db.SaveChanges();
    }
}