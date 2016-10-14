using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DatabaseComponent;

public partial class IterativeVsDeclarative : System.Web.UI.Page
{
    private EmployeeDB db = new EmployeeDB();

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void cmdForeach_Click(object sender, EventArgs e)
    {
        // Get the full collection of employees from a helper method.
        List<EmployeeDetails> employees = db.GetEmployees();

        // Find the matching employees.
        List<EmployeeDetails> matches = new List<EmployeeDetails>();
        foreach (EmployeeDetails employee in employees)
        {
            if (employee.LastName.StartsWith("D"))
            {
                matches.Add(employee);
            }
        }

        gridEmployees.DataSource = matches;
        gridEmployees.DataBind();
    }

    protected void cmdLinq_Click(object sender, EventArgs e)
    {
        List<EmployeeDetails> employees = db.GetEmployees();
        
        // Implicit syntax.
        IEnumerable<EmployeeDetails> matches = from employee in employees
                  where employee.LastName.StartsWith("D")
                  select employee;

        gridEmployees.DataSource = matches;
        gridEmployees.DataBind();
    }

    private class EmployeeName
    {
        public string FirstName
        { get; set; }

        public string LastName
        { get; set; }
    }

}
