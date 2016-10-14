using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DatabaseComponent;
using System.Collections.Generic;
using System.Linq;

public partial class LinqToDataSet : System.Web.UI.Page
{
    private EmployeeDB db = new EmployeeDB();

    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = db.GetEmployeesDataSet();

        var matches = from employee in ds.Tables["Employees"].AsEnumerable()
                      where employee.Field<string>("LastName").StartsWith("D")
                      select new { First = employee.Field<string>("FirstName"), Last = employee.Field<string>("LastName") };
        gridEmployees.DataSource = matches;

        //var matches = from employee
        //  in ds.Tables["Employees"].AsEnumerable()
        //              where employee.Field<string>("LastName").StartsWith("D")
        //              select employee;
        //gridEmployees.DataSource = matches.AsDataView();

        gridEmployees.DataBind();
    }
}
