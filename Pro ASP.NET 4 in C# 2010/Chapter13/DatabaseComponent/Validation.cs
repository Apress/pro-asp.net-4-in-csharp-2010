using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseComponent
{
    public partial class Employee
    {
        partial void OnLastNameChanging(string value)
        {
            if (value.Length < 3)
                throw new ArgumentException("' " + value + "' is too short. The last name must be three characters.");
        }
    }	
}
