using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace DatabaseComponent
{     
    public class ProductDB
    {
        private string connectionString;

		public ProductDB()
		{
			// Get connection string from web.config.
			connectionString = WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
		}
		public ProductDB(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public List<ProductDetails> GetProducts()
		{
			SqlConnection con = new SqlConnection(connectionString);
			SqlCommand cmd = new SqlCommand("SELECT * FROM Products", con);			
    				
			// Create a collection for all the employee records.
			List<ProductDetails> products = new List<ProductDetails>();

			try 
			{
				con.Open();
				SqlDataReader reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					ProductDetails product = new ProductDetails(
						(int)reader["ProductID"], (string)reader["ProductName"],
						(decimal)reader["UnitPrice"], (int)reader["CategoryID"]);
					products.Add(product);
				}
				reader.Close();
				
				return products;
			}
			catch (SqlException err) 
			{
				// Replace the error with something less specific.
				// You could also log the error now.
				throw new ApplicationException("Data error.");
			}
			finally 
			{
				con.Close();			
			}
		}
    }
}
