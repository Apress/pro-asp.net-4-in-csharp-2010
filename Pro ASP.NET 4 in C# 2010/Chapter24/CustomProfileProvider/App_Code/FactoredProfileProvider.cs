using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Profile;
using System.Data.SqlClient;
using System.Collections.Specialized;


public class FactoredProfileProvider : ProfileProvider 
{
	private string name;
	public override string Name
	{
		get { return name; }
	}

	private string connectionString;
	public string ConnectionString
	{
		get { return connectionString; }
	}

	private string updateProcedure;
	public string UpdateUserProcedure
	{
		get { return updateProcedure; }
	}

	private string getProcedure;
	public string GetUserProcedure
	{
		get { return getProcedure; }
	}

	// System.Configuration.Provider.ProviderBase.Initialize Method
	public override void Initialize(string name, NameValueCollection config)
	{
		// Initialize values from web.config.
		this.name = name;
			
		ConnectionStringSettings connectionStringSettings = ConfigurationManager.
			ConnectionStrings[config["connectionStringName"]];
		if (connectionStringSettings == null ||
			connectionStringSettings.ConnectionString.Trim() == "")
		{
			throw new HttpException("You must supply a connection string.");
		}
		else
		{
			connectionString = connectionStringSettings.ConnectionString;
		}

		updateProcedure = config["updateUserProcedure"];
		if (updateProcedure.Trim() == "")
		{
			throw new HttpException("You must specify a stored procedure to use for updates.");
		}

		getProcedure = config["getUserProcedure"];
		if (getProcedure.Trim() == "")
		{
			throw new HttpException("You must specify a stored procedure to use for retrieving individual user records.");
		}
	}
	
	public override int DeleteProfiles(string[] usernames)
	{
		throw new Exception("The method or operation is not implemented.");
	}

	public override int DeleteProfiles(ProfileInfoCollection profiles)
	{
		throw new Exception("The method or operation is not implemented.");
	}

	public override int DeleteInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
	{
		throw new Exception("The method or operation is not implemented.");
	}

	public override ProfileInfoCollection FindInactiveProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
	{
		throw new Exception("The method or operation is not implemented.");
	}

	public override ProfileInfoCollection FindProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
	{	
		throw new Exception("The method or operation is not implemented.");
	}

	public override ProfileInfoCollection GetAllInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
	{
		throw new Exception("The method or operation is not implemented.");
	}

	public override ProfileInfoCollection GetAllProfiles(ProfileAuthenticationOption authenticationOption, int pageIndex, int pageSize, out int totalRecords)
	{
		throw new Exception("The method or operation is not implemented.");
	}

	public override int GetNumberOfInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
	{
		throw new Exception("The method or operation is not implemented.");
	}

	public override string ApplicationName
	{
		get
		{
			throw new Exception("The method or operation is not implemented.");
		}
		set
		{
			throw new Exception("The method or operation is not implemented.");
		}
	}

	public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection properties)
	{
		// If you want to mimic the behavior of the SqlProfileProvider,
		// you should also update the database with the last activity time
		// whenever this method is called.

		// This collection will store the retrieved values.
		SettingsPropertyValueCollection values = new SettingsPropertyValueCollection();

		// Prepare the command.
		// The only non-configurable assumption in this code is
		// that the stored procedure accepts a parameter named
		// @UserName. You could add additional configuration attributes
		// to make this detail configurable.
		SqlConnection con = new SqlConnection(connectionString);
		SqlCommand cmd = new SqlCommand(getProcedure, con);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add(new SqlParameter("@UserName", (string)context["UserName"]));
		
		try
		{
			con.Open();
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

			// Get the first row.
			reader.Read();
			
			// Look for every requested value.
			foreach (SettingsProperty property in properties)
			{                
				SettingsPropertyValue value = new SettingsPropertyValue(property);
				
				// Non-matching users are allowed
				// (properties are kept, but no values are added).
				if (reader.HasRows)
				{
					value.PropertyValue = reader[property.Name];
				}
				values.Add(value);
			}
			reader.Close();
		}
		finally
		{
			con.Close();
		}

		return values;
	}

	public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection values)
	{
		// If you want to mimic the behavior of the SqlProfileProvider,
		// you should also update the database with the last update time
		// whenever this method is called.

		// Prepare the command.
		SqlConnection con = new SqlConnection(connectionString);
		SqlCommand cmd = new SqlCommand(updateProcedure, con);
		cmd.CommandType = CommandType.StoredProcedure;

		// Add the parameters.
		// The assumption is that every property maps exactly
		// to a single stored procedure parameter name.
		foreach (SettingsPropertyValue value in values)
		{
            // You could check value.IsDirty here and only save
            // the record if at least one value has changed.

			cmd.Parameters.Add(new SqlParameter(value.Name, value.PropertyValue));
		}
		// Again, this code assumes the stored procedure accepts a parameter named
		// @UserName.
		cmd.Parameters.Add(new SqlParameter("@UserName", (string)context["UserName"]));


		// Execute the command.
		try
		{
			con.Open();
			cmd.ExecuteNonQuery();
		}
		finally
		{
			con.Close();
		}
	}
}
