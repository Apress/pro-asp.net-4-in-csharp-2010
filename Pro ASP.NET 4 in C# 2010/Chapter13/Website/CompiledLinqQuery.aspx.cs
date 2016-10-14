using System;
using System.Data.Objects;
using System.Linq;
using NorthwindModel;

public partial class CompiledLinqQuery : System.Web.UI.Page {
    Func<NorthwindEntities, string, IQueryable<Customer>> MyCompiledQuery;
    NorthwindEntities db;


    protected void Page_Load(object sender, EventArgs e) {

        MyCompiledQuery = CompiledQuery.Compile<NorthwindEntities, string, IQueryable<Customer>>(
            (context, city) => from c in context.Customers
                               where c.City == city
                               select c);

        db = new NorthwindEntities();

        GridView1.DataSource = MyCompiledQuery(db, "London");
        GridView1.DataBind();
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e) {

        GridView1.DataSource = MyCompiledQuery(db, DropDownList1.SelectedValue);
        GridView1.DataBind();
    }
}