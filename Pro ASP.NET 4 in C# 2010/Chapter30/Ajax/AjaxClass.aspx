<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AjaxClass.aspx.cs" Inherits="AjaxClass" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>   
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        
            <script type="text/javascript">
    Type.registerNamespace("Business");
    
    Business.Employee = function(first, last)
    {
        // The private section.
        this._firstName = first;
        this._lastName = last;
    }
    
    // The public section.
    function Business$Employee$set_FirstName(first) {
       this._firstName = first;
    }       
    function Business$Employee$get_FirstName() {
       return this._firstName;
    }    
    function Business$Employee$set_LastName(last) {
       this._lastName = last;
    }    
    function Business$Employee$get_LastName() {
       return this._lastName;
    }
    Business.Employee.prototype = {
      set_FirstName: Business$Employee$set_FirstName,
      get_FirstName: Business$Employee$get_FirstName,
      set_LastName: Business$Employee$set_LastName,
      get_LastName: Business$Employee$get_LastName
    }; 
        
    
    Business.Employee.registerClass("Business.Employee");
    
    Business.SalesEmployee = function(first, last, salesDepartment)
    {
        Business.SalesEmployee.initializeBase(this, [first, last]);
        this._salesDepartment = salesDepartment;
    }    
    Business.SalesEmployee.prototype.get_SalesDepartment = function() {
        return this._salesDepartment;
    }   
    Business.SalesEmployee.prototype.dispose = function() {
        alert("Disposed");
    }   
    Business.SalesEmployee.registerClass("Business.SalesEmployee", Business.Employee, Sys.IDisposable);
    </script>
    
    <script type="text/javascript">
    //var emp = new Business.Employee("Joe", "Higgens");
    //var name = emp.get_FirstName() + " " + emp.get_LastName();
    //alert(name);
    
    //alert(Object.getTypeName(emp));
    
    var salesEmp = new Business.SalesEmployee("Joe", "Higgens", "Western");
    var desc = salesEmp.get_FirstName() + " " + salesEmp.get_LastName() + " " + salesEmp.get_SalesDepartment();
    alert(desc);
    salesEmp.dispose();
    </script>
    </div>
    </form>
</body>
</html>