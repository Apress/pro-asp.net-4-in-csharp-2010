using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NorthwindModel;

public partial class Database_Operations_Insert : System.Web.UI.Page {

    protected void Page_Load(object sender, EventArgs e) {

        NorthwindEntities db = new NorthwindEntities();

        //Customer cust = new Customer() {
        //    CustomerID = "LAWN",
        //    CompanyName = "Lawn Wranglers",
        //    ContactName = "Mr. Abe Henry",
        //    ContactTitle = "Owner",
        //    Address = "1017 Maple Leaf Way",
        //    City = "Ft. Worth",
        //    Region = "TX",
        //    PostalCode = "76104",
        //    Country = "USA",
        //    Phone = "(800) MOW-LAWN",
        //    Fax = "(800) MOW-LAWO"
        //};

        Customer cust = Customer.CreateCustomer("LAWN", "Lawn Wranglers");
        cust.ContactName = "Mr. Abe Henry";
        cust.ContactTitle = "Owner";
        cust.Address = "1017 Maple Leaf Way";
        cust.City = "Ft. Worth";
        cust.Region = "TX";
        cust.PostalCode = "76104";
        cust.Country = "USA";
        cust.Phone = "(800) MOW-LAWN";
        cust.Fax = "(800) MOW-LAWO";

        db.Customers.AddObject(cust);

        db.SaveChanges();
    }
}