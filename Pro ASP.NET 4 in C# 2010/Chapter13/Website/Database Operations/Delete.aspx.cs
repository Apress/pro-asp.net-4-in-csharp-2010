using System;
using System.Collections.Generic;
using System.Linq;
using NorthwindModel;

public partial class Database_Operations_Delete : System.Web.UI.Page {

    protected void Page_Load(object sender, EventArgs e) {

        NorthwindEntities db = new NorthwindEntities();

        IEnumerable<Order_Detail> ods = from o in db.Order_Details
                                        where o.OrderID == 10248
                                        select o;

        foreach (Order_Detail od in ods) {
            db.Order_Details.DeleteObject(od);
        }

        db.SaveChanges();
    }
}