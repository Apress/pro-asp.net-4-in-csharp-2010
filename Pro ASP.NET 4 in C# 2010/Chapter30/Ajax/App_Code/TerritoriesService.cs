using System;
using System.Linq;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

/// <summary>
/// Summary description for TerritoriesService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
 [System.Web.Script.Services.ScriptService]
public class TerritoriesService : System.Web.Services.WebService
{

    [WebMethod()]
    public List<Territory> GetTerritoriesInRegion(int regionID)
    {
        SqlConnection con = new SqlConnection(
          WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString);
        SqlCommand cmd = new SqlCommand(
            "SELECT * FROM Territories WHERE RegionID=@RegionID", con);
        cmd.Parameters.Add(new SqlParameter("@RegionID", SqlDbType.Int, 4));
        cmd.Parameters["@RegionID"].Value = regionID;

        List<Territory> territories = new List<Territory>();
        try
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                territories.Add(new Territory(
                  reader["TerritoryID"].ToString(),
                  reader["TerritoryDescription"].ToString()));
            }
            reader.Close();
        }
        catch (SqlException err)
        {
            // Mask errors.
            throw new ApplicationException("Data error.");
        }
        finally
        {
            con.Close();
        }
        return territories;
    }
}

public class Territory
{
    public string ID;
    public string Description;

    public Territory(string id, string description)
    {
        this.ID = id;
        this.Description = description;
    }

    public Territory() { }
}


