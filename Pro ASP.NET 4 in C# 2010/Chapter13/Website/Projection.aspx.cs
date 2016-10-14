using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Collections.Generic;
using DatabaseComponent;

public partial class Projection : System.Web.UI.Page
{
    private EmployeeDB db = new EmployeeDB();

    protected void Page_Load(object sender, EventArgs e)
    {
        List<EmployeeDetails> employees = db.GetEmployees();

        // Anonymous type.
        var matches = from employee in employees
                  select new {First = employee.FirstName, Last = employee.LastName};

        // Change the type.
        //IEnumerable<EmployeeName> matches = from employee in employees
        //              select new EmployeeName { FirstName = employee.FirstName, LastName = employee.LastName };

        // Explicit syntax.        
        //var matches = employees        
        //   .Where(employee => employee.LastName.StartsWith("D"))
        //   .Select(employee => new { First = employee.FirstName, Last = employee.LastName });

        gridEmployees.DataSource = matches;
        gridEmployees.DataBind();
    }
}
