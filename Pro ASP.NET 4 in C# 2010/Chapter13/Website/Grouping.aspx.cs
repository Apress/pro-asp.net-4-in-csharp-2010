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
using System.Collections.Generic;
using DatabaseComponent;


public partial class Grouping : System.Web.UI.Page
{
    private EmployeeDB dbEmployee = new EmployeeDB();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        List<EmployeeDetails> employees = dbEmployee.GetEmployees();

        var matches = from employee in employees
                      group employee by employee.TitleOfCourtesy into g
                      select g.Key;
        
        //var matches = from employee in employees                      
        //              group employee by employee.TitleOfCourtesy into g
        //              select new {Title = g.Key, Employees = g.Count()};              

        gridEmployees.DataSource = matches;
        gridEmployees.DataBind();

    }
}
