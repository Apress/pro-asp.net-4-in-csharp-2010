using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NorthwindModel;

public partial class Database_Operations_InsertAssociated : System.Web.UI.Page {

    protected void Page_Load(object sender, EventArgs e) {
        
        NorthwindEntities db = new NorthwindEntities();

        Customer cust = new Customer {
            CustomerID = "LAWN",
            CompanyName = "Lawn Wranglers",
            ContactName = "Mr. Abe Henry",
            ContactTitle = "Owner",
            Address = "1017 Maple Leaf Way",
            City = "Ft. Worth",
            Region = "TX",
            PostalCode = "76104",
            Country = "USA",
            Phone = "(800) MOW-LAWN",
            Fax = "(800) MOW-LAWO",
            Orders = {
                new Order {
                    CustomerID = "LAWN",
                    EmployeeID = 4,
                    OrderDate = DateTime.Now,
                    RequiredDate = DateTime.Now.AddDays(7),
                    ShipVia = 3,
                    Freight = new Decimal(24.66),
                    ShipName = "Lawn Wranglers",
                    ShipAddress = "1017 Maple Leaf Way",
                    ShipCity = "Ft. Worth",
                    ShipRegion = "TX",
                    ShipPostalCode = "76104",
                    ShipCountry = "USA"
                }
            }
        };

        // add the new Customer 
        db.Customers.AddObject(cust);

        // save the changes
        db.SaveChanges();
    }
}