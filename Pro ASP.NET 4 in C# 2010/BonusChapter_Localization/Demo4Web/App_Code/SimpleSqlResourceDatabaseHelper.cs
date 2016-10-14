namespace Apress.Localization
{
    using System;
    using System.Data;
    using System.Configuration;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    using System.Web.Compilation;
    using System.Resources;
    using System.Data.SqlClient;
    using System.Collections;
    using System.Web.UI.Design;
    using System.Globalization;
    using System.Collections.Specialized;

    internal class SimpleSqlResourceDatabaseHelper
    {
        private SqlConnection _ResConnection;
        private SqlCommand _GetResourceCmd;
        private SqlCommand _UpdateResourceCmd;
        private SqlCommand _InsertResourceCmd;
        private SqlCommand _CheckExistsCmd;

        public SimpleSqlResourceDatabaseHelper(string connString)
        {
            // Create the connection to the database
            _ResConnection = new SqlConnection(connString);
            //_ResConnection.ConnectionString = @"data source=(local)\SQL2005;Integrated Security=SSPI;initial catalog=SimpleResource";

            // Create a parameterized commmand for getting the resources
            _GetResourceCmd = new SqlCommand();
            _GetResourceCmd.Connection = _ResConnection;
            _GetResourceCmd.CommandText = "SELECT * FROM ResourceString WHERE LocaleID=@lid AND VirtualPath=@path";
            _GetResourceCmd.Parameters.Add("@lid", SqlDbType.NVarChar, 5);
            _GetResourceCmd.Parameters.Add("@path", SqlDbType.NVarChar, 250);

            // Create commands for updates
            _UpdateResourceCmd = new SqlCommand();
            _UpdateResourceCmd.Connection = _ResConnection;
            _UpdateResourceCmd.CommandText = "UPDATE ResourceString SET ResourceValue=@value" +
                                             " WHERE ResourceKey=@key AND LocaleID=@lid" +
                                             "   AND VirtualPath=@path";
            _UpdateResourceCmd.Parameters.Add("@value", SqlDbType.NVarChar, 250);
            _UpdateResourceCmd.Parameters.Add("@key", SqlDbType.NVarChar, 50);
            _UpdateResourceCmd.Parameters.Add("@lid", SqlDbType.NVarChar, 5);
            _UpdateResourceCmd.Parameters.Add("@path", SqlDbType.NVarChar, 250);

            // Create command for insert
            _InsertResourceCmd = new SqlCommand();
            _InsertResourceCmd.Connection = _ResConnection;
            _InsertResourceCmd.CommandText = "INSERT INTO ResourceString VALUES(@key, @lid, @value, @path)";
            _InsertResourceCmd.Parameters.Add("@value", SqlDbType.NVarChar, 250);
            _InsertResourceCmd.Parameters.Add("@key", SqlDbType.NVarChar, 50);
            _InsertResourceCmd.Parameters.Add("@lid", SqlDbType.NVarChar, 5);
            _InsertResourceCmd.Parameters.Add("@path", SqlDbType.NVarChar, 250);

            // Create command for existing-check
            _CheckExistsCmd = new SqlCommand();
            _CheckExistsCmd.Connection = _ResConnection;
            _CheckExistsCmd.CommandText = "SELECT COUNT(*) FROM ResourceString " +
                                          "WHERE ResourceKey=@key AND LocaleID=@lid" +
                                          "  AND VirtualPath=@path";
            _CheckExistsCmd.Parameters.Add("@key", SqlDbType.NVarChar, 50);
            _CheckExistsCmd.Parameters.Add("@lid", SqlDbType.NVarChar, 5);
            _CheckExistsCmd.Parameters.Add("@path", SqlDbType.NVarChar, 250);

        }

        public ListDictionary GetResources(string cultureName, string virtualPath)
        {
            // Default (neutral) culture?
            if ((cultureName == null) || (cultureName.Equals(string.Empty)))
                cultureName = "none";
            
            // Now get the resources from the database
            _ResConnection.Open();
            try
            {
                _GetResourceCmd.Parameters["@lid"].Value = cultureName;
                _GetResourceCmd.Parameters["@path"].Value = virtualPath;
                using (SqlDataReader reader = _GetResourceCmd.ExecuteReader())
                {
                    ListDictionary dict = new ListDictionary();

                    while (reader.Read())
                    {
                        dict.Add
                        (
                          reader["ResourceKey"].ToString(),
                          reader["ResourceValue"].ToString()
                        );
                    }

                    return dict;
                }
            }
            finally
            {
                _ResConnection.Close();
            }
        }

        public void AddResource(string virtualPath, string name, string value, string cultureName)
        {
            // Default (neutral) culture?
            if ((cultureName == null) || (cultureName.Equals(string.Empty)))
                cultureName = "none";

            // Next add / update the item in the database
            _ResConnection.Open();
            try
            {
                _CheckExistsCmd.Parameters["@key"].Value = name;
                _CheckExistsCmd.Parameters["@lid"].Value = cultureName;
                _CheckExistsCmd.Parameters["@path"].Value = virtualPath;
                int ret = (int)_CheckExistsCmd.ExecuteScalar();
                if (ret > 0)
                {
                    _UpdateResourceCmd.Parameters["@key"].Value = name;
                    _UpdateResourceCmd.Parameters["@lid"].Value = cultureName;
                    _UpdateResourceCmd.Parameters["@value"].Value = value;
                    _UpdateResourceCmd.Parameters["@path"].Value = virtualPath;
                    _UpdateResourceCmd.ExecuteNonQuery();
                }
                else
                {
                    _InsertResourceCmd.Parameters["@key"].Value = name;
                    _InsertResourceCmd.Parameters["@lid"].Value = cultureName;
                    _InsertResourceCmd.Parameters["@value"].Value = value;
                    _InsertResourceCmd.Parameters["@path"].Value = virtualPath;
                    _InsertResourceCmd.ExecuteNonQuery();
                }
            }
            finally
            {
                _ResConnection.Close();
            }
        }
    }

}
