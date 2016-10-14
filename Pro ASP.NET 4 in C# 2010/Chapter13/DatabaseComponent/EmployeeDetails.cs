using System;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Data.Linq.Mapping;

namespace DatabaseComponent
{
    [Table(Name="Employees")]
	public class EmployeeDetails
	{		
        [Column(IsPrimaryKey=true)]
		public int EmployeeID {get; set;}

        [Column]
		public string FirstName {get; set;}

        [Column]
        public string LastName { get; set; }

        [Column]
		public string TitleOfCourtesy { get; set; }		

		public EmployeeDetails(int employeeID, string firstName, string lastName,
			string titleOfCourtesy)
		{
			EmployeeID = employeeID;
			FirstName = firstName;
			LastName = lastName;
			TitleOfCourtesy = titleOfCourtesy;
		}

		public EmployeeDetails(){}
	}

}
