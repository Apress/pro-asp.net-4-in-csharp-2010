using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.Common;
using System.Web.Configuration;

/// <summary>
/// Summary description for SqlSiteMapProvider
/// </summary>
public class SqlSiteMapProvider : StaticSiteMapProvider 
{

	// Track the connection string, provider name, and stored procedure name.
	private string connectionString;
	private string providerName;
	private string storedProcedure;
    private int cacheTime;

	private bool initialized = false;
	public virtual bool IsInitialized
	{
		get { return initialized; }
	}
    
	public override void Initialize(string name, System.Collections.Specialized.NameValueCollection attributes)
    {
        if (!IsInitialized)
        {
            base.Initialize(name, attributes);

            // Retrieve the web.config settings.
            providerName = attributes["providerName"];
            connectionString = attributes["connectionString"];
            storedProcedure = attributes["storedProcedure"];
            cacheTime = Int32.Parse(attributes["cacheTime"]);

            if (String.IsNullOrEmpty(providerName))
                throw new ArgumentException("The provider name was not found.");
            else if (String.IsNullOrEmpty(connectionString))
                throw new ArgumentException("The connection string was not found.");
            else if (String.IsNullOrEmpty(storedProcedure))
                throw new ArgumentException("The stored procedure name was not found.");

            initialized = true;
        }
    }

	public override SiteMapNode BuildSiteMap()
	{
        SiteMapNode rootNode;

		// Since the class is exposed to multiple pages,
		// use locking to make sure that the site map is not rebuilt by more than one
		// page at the same time.
		lock (this)
		{
            rootNode = HttpContext.Current.Cache["rootNode"] as SiteMapNode;
            if (rootNode == null)
            {                
        		Clear();

				// Get all the data (using provider-agnostic code).
				DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

				// Use this factory to create a connection.
				DbConnection con = provider.CreateConnection();
				con.ConnectionString = connectionString;

				// Create the command.
				DbCommand cmd = provider.CreateCommand();
				cmd.CommandText = storedProcedure;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Connection = con;
                
				// Creat the DataAdapter.
				DbDataAdapter adapter = provider.CreateDataAdapter();
				adapter.SelectCommand = cmd;

				// Get the results in a DataSet
				// (a DataReader won't work because we need back-and-forth
				// navigation).
				// (Error handling code would be appropriate here.)
				DataSet ds = new DataSet();
				adapter.Fill(ds, "SiteMap");
				DataTable dtSiteMap = ds.Tables["SiteMap"];

				// Now navigate the DataSet to create the SiteMap.
				// We won't check for all the possible error conditions
				// (like duplicate root nodes).

				// Get the root node.
				DataRow rowRoot = dtSiteMap.Select("ParentID IS NULL")[0];
				
				rootNode = new SiteMapNode(this,
					rowRoot["Url"].ToString(), rowRoot["Url"].ToString(),
					rowRoot["Title"].ToString(), rowRoot["Description"].ToString());
				string rootID = rowRoot["ID"].ToString();
                AddNode(rootNode);

				// Fill down the hierarchy.
				AddChildren(rootNode, rootID, dtSiteMap);

                HttpContext.Current.Cache.Insert("rootNode", rootNode,
                  null, DateTime.Now.AddSeconds(cacheTime), TimeSpan.Zero);
			}
		}
		return rootNode;
	}


	private void AddChildren(SiteMapNode rootNode, string rootID, DataTable dtSiteMap)
	{
		DataRow[] childRows = dtSiteMap.Select("ParentID = " + rootID);
		foreach (DataRow row in childRows)
		{
			SiteMapNode childNode = new SiteMapNode(this,
              row["Url"].ToString(), row["Url"].ToString(),
			  row["Title"].ToString(), row["Description"].ToString());
			string rowID = row["ID"].ToString();

			// Use the SiteMapNode AddNode method to add
			// the SiteMapNode to the ChildNodes collection.
			AddNode(childNode, rootNode);

			// Check for children in this node.
			AddChildren(childNode, rowID, dtSiteMap);
		}
	}

	protected override SiteMapNode GetRootNodeCore()
	{
		return BuildSiteMap();
	}

	public override SiteMapNode RootNode
	{
		get	{ return BuildSiteMap(); }
	}

	protected override void Clear()
	{
		lock (this)
		{
            HttpContext.Current.Cache.Remove("rootNode");
			base.Clear();
		}
	}

}
