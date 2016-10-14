<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Prototype.aspx.cs" Inherits="Prototype" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    Employee = function Employee(first, last)
    {
        // The private section.
        this._firstName = first;
        this._lastName = last;
    }
    
    // The public section.
    Employee.prototype.set_FirstName = function(first) {
       this._firstName = first;
    }       
    Employee.prototype.get_FirstName = function() {
       return this._firstName;
    }    
    Employee.prototype.set_LastName = function(last) {
       this._lastName = last;
    }    
    Employee.prototype.get_LastName = function() {
       return this._lastName;
    }


    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <script type="text/javascript">
    var emp = new Employee("Joe", "Higgens");
    var name = emp.get_FirstName() + " " + emp.get_LastName();
    alert(name);
    </script>
    </div>
    </form>
</body>
</html>
