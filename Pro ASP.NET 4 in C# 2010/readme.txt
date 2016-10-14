
---------------------------
General Notes - Data Access
---------------------------

Many of the examples in this book use SQL Server. In most cases, it is
assumed that you are using SQL Server Express. However, you can modify
the connection string in the <connectionStrings> section of the
web.config file to use a different database, such as the full version
of SQL Server.

Many of the examples that use data access require the Northwind or Pubs
sample databases. To install these databases, you can use the provided
SQL scripts:

* Use InstNwnd.sql if you don't already have the Northwind database.
* Use InstNwnd.sql if you don't already have the Pubs database.
* Use EmployeesProcedures.sql to install the stored procedures for seleting,
insert, updating, deleting, and paging Employees records.


-----------------------
Chapter 17 - Navigation
-----------------------

The custom navigation provider assumes certain navigation tables and
a GetSiteMap stored procedure.

* Use SiteMap.sql to install the table and stored procedure
* Modify the connection string in the web.config file as required.


---------------------------------
Chapter 20 - Forms Authentication
---------------------------------

The examples in this chapter assume you are using SQL Server Express.

1.) Open the web.config file in the Chapter20\SimpleForms directory.
2.) Review the connection string with the name MyLoginDb and update it
    if your SQL Server Express instance has a different instance name.
3.) Open the Chapter20\SimpleForms.sln Visual Studio Solution with
    Visual Studio.
4.) Open Server Explorer in Visual Studio.
5.) Connect to the file-based database Chapter20\App_Data\CredStore.mdf to
    review the user name and password combinations you can use for the
    log-in page.


-----------------------
Chapter 21 - Membership
-----------------------

The examples in this chapter assume you are using SQL Server Express.

1.) Open the Visual Studio solution Membership.sln in Visual Studio.
2.) Create an aspnetdb database using aspnet_regsql.exe as described in
    Chapter 21.
3.) Review the connection strings in the <connectionStrings> configuration
    section of the web.config files of all projects in the solution.
    Update the data source property if you are not using SQL Server Express or
    you use your own instance name for SQL Server.
4.) Perform the following steps for each web site in the solution:
  4.1) Create users for Chapter21\Membership in the ASP.NET Configuration (WAT).
  4.2) Create users for Chapter21\MembershipAPI in the ASP.NET Configuration (WAT).


-----------------------------------
Chapter 22 - Windows Authentication
-----------------------------------

1.) Share the directory Chapter22 as a virtual Directory/Web Application in
    the IIS management console. Use the name "WinAuth" for the
    Virtual Directory/Web Application.
2.) Disable anonymous access and enable Windows Authentication through the IIS
    management console.


------------------
Chapter 23 - Roles
------------------

1.) Open the solution Chapter23\RolesDemo.sln in Visual Studio.
2.) Open the ASP.NET Configuration (WAT) for the project Chapter23\RolesDemo.
3.) Create three roles named "Admin", "Contributor", "Reader" and "Designer"
    through the WAT.
4.) Create some users and assign them to the roles you just created.
5.) Run the application and test it.
6.) Share the directory Chapter23\WinRoles as Virtual Directory/Web Application
    using the IIS management console.
7.) Disable anonymous access and enable Windows Authentication for the virtual
    directory.


---------------------
Chapter 24 - Profiles
---------------------

The custom profile provider assumes certain site map tables in the 
aspnet database.

* Use ProfileProvider.sql to install the Users table and stored procedures.
* Modify the connection string in the web.config file as required.


-------------------------
Chapter 25 - Cryptography
-------------------------

The examples in this chapter assume you are using SQL Server Express.

1.) Open the solution Chapter25\Cryptography.sln in Visual Studio
2.) Open web.config file of the web site Chapter25\EncryptionSamples.
3.) Update the connection string DemoSql if you do not use SQL Server Express
    with the instance name SQLEXPRESS.


--------------------------------------
Chapter 26 - Custom Memberhip Provider
--------------------------------------

The examples in this chapter assume you are using SQL Server Express.

1.) Open the solution Chapter26\CustomProviders.sln in Visual Studio.
2.) Open the web.config file of the Chapter26\TestXmlProvider web site
3.) Search for the XmlMembership membership provider configuration in the
    <membership> configuration section.
4.) Update the fileName attribute to point to a location where you have write
    access rights.
    If you share the directory through IIS, the user of the application pool
    (e.g. Network Service) needs to have write permissions for this directory.
5.) Search for the XmlRoles roles provider configuration in the <roleManager>
    configuration section.
6.) Update the fileName attribute to point to a location where you have write
    access rights.
    If you share the directory through IIS, the user of the application pool
    (e.g. Network Service) needs to have write permissions for this directory.


----------------------
Chapter 31 - Web Parts
----------------------

1.) Open the solution Chapter30\WebParts.sln in Visual Studio.
2.) Update the data source property of every connection string in the web.config
    files of the web sites in the solution to point to your SQL Server instance.


-------------------------
Chapter 32 - ASP.NET AJAX
-------------------------

The autocomplete web service uses the Employees table from the Northwind database.
* Use the InstNwnd.sql script if you don't already have the Northwind database.
* Modify the connection string in the web.config file as required.

The ApplicationServices project uses SQL Server Express for authentication.
If you are using the full version of SQL Server you need to create the database
using aspnet_regsql.exe, remove the standard connection string by using
<remove name="LocalSqlServer"/>, and add a new connection string with the name
"LocalSqlServer" and the correct connection string.
