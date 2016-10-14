using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Caching;


public class NorthwindDB
{
	private string connectionString;

	public NorthwindDB()
	{
		// Get connection string from web.config.
		connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
	}

	public DataSet GetCategoriesProductsDataSet()
	{
		Cache cache = HttpContext.Current.Cache;
		DataSet ds;

		// Check the cache.
		if (cache["Northwind"] != null)
		{
			ds = (DataSet)cache["Northwind"];
		}
		else
		{
			// Create the DataSet.
			ds = CreateCategoriesProductsDataSet();

			// Cache the DataSet for five minutes.
			cache.Insert("Northwind", ds, null, DateTime.Now.AddMinutes(5), TimeSpan.Zero);
		}
		return ds;
	}

	private DataSet CreateCategoriesProductsDataSet()
	{
		SqlConnection con = new SqlConnection(connectionString);
		DataSet ds = new DataSet();

		string sqlProducts = "SELECT * FROM Products";
		string sqlCategories = "SELECT * FROM Categories";
		SqlDataAdapter da = new SqlDataAdapter(sqlCategories, con);

		// Fill the DataSet.
		try
		{
			con.Open();
			da.Fill(ds, "Categories");
			da.SelectCommand.CommandText = sqlProducts;
			da.Fill(ds, "Products");
		}
		catch (Exception err)
		{
			throw new ApplicationException("Data error.");
		}
		finally
		{
			con.Close();
		}
		return ds;
	}
}

