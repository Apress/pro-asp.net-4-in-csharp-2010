using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Linq;
using System.Web.Configuration;
using System.Linq;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace DatabaseComponent
{
    public class LinqNorthwindDB
    {
        private DataContext dataContext;

		public LinqNorthwindDB() : this(WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString)
		{}

		public LinqNorthwindDB(string connectionString)
		{		
            dataContext = new DataContext(connectionString);
            
            DataLoadOptions loadOptions = new DataLoadOptions();
            loadOptions.LoadWith<Customer>(customer => customer.Orders);

            // Use these load options to retrieve only a subset of order records.
            //loadOptions.AssociateWith<Customer>(customer => 
            //     from order in customer.Orders where order.OrderDate > new DateTime(1998,1,1) select order);

            dataContext.LoadOptions = loadOptions;
		}

        public IQueryable<EmployeeDetails> GetEmployees()
        {            
            return dataContext.GetTable<EmployeeDetails>();
        }

        public List<EmployeeDetails> GetEmployees(string lastName)
        {           
            IEnumerable<EmployeeDetails> matches = from employee in
               dataContext.GetTable<EmployeeDetails>()
               where employee.LastName == lastName
               select employee;
            try
            {
                return matches.ToList<EmployeeDetails>();
            }
            catch (SqlException err)
            {
                // Replace the error with something less specific.
                // You could also log the error now.
                throw new ApplicationException("Data error.");
            }
        }

        public EmployeeDetails GetEmployee(int ID)
        {
            // The no-expression appraoch.
            //return dataContext.GetTable<EmployeeDetails>()
            //    .Single(employee => employee.EmployeeID == ID);

            // The LINQ expression approach.
            var matches = from employee in dataContext.GetTable<EmployeeDetails>()
                          where employee.EmployeeID == ID
                          select employee;
            return matches.Single();
        }

        public int CountEmployees()
        {
            return dataContext.GetTable<EmployeeDetails>()
              .Count();
        }

        public List<Customer> GetCustomers()
        {
            // The no-expression approach.
            //return db.GetTable<Customer>().ToList<Customer>();

            // The LINQ expression approach.
            var matches = (from customer in dataContext.GetTable<Customer>()
                           select customer);                   
            return matches.ToList<Customer>();
        }

        public Order GetOrder(int ID)
        {
            // The no-expression approach.
            //Order or = dataContext.GetTable<Order>().Single<Order>(o => o.OrderID == ID);
            //return or;

            // The LINQ expression approach.
            var matches = from order in dataContext.GetTable<Order>()
                          where order.OrderID == ID
                          select order;
            return matches.Single();
        }


        public XDocument GetEmployeeXml()
        {
            XDocument doc = new XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XElement("Employees",
                  from employee in dataContext.GetTable<EmployeeDetails>()
                  select new XElement[] {
                   new XElement("Employee",
                   new XAttribute("ID", employee.EmployeeID),
                   new XElement("Name", employee.FirstName + " " + employee.LastName)
                 )
              })
            );
            return doc;
        }
    }
}
