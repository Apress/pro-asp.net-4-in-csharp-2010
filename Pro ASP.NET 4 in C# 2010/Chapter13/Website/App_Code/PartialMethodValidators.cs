using System;

namespace NorthwindModel {

    public partial class Employee {

        partial void OnLastNameChanging(string value) {
            if (value.Length < 3) {
                throw new ArgumentException(String.Format("'{0}' is too short. " + 
                 "The last name must be three characters", value));
            }
        }
    }
}