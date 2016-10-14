using System.Linq;
using System.Web.UI.WebControls.Expressions;
using NorthwindModel;


public class QueryExtenderMethods {

    public static IQueryable<Employee> FilterEmployees(IQueryable<Employee> data) {

        return from d in data
               where d.City == "London" && d.Country == "UK"
               select d;
    }
}