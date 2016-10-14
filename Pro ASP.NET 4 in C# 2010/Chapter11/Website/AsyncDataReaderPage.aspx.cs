using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class AsyncDataReaderPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Register the asynchronous methods for later use.
        // This method returns immediately.
        Page.AddOnPreRenderCompleteAsync(
            BeginTask, EndTask);
    }

    // The ADO.NET objects need to be accessible in several different
    // event handlers, so they must be declared as member variables.
    private SqlConnection con;
    private SqlCommand cmd;
    private DataTable table;

    private IAsyncResult BeginTask(object sender, EventArgs e,
        AsyncCallback cb, object state)
    {        
        // Check the cache.
        if (Cache["Employees"] != null)
        {
            return new CompletedSyncResult((DataTable)Cache["Employees"],
                cb, state);
        }

        // Create the command.
        string connectionString = WebConfigurationManager.ConnectionStrings
            ["NorthwindAsync"].ConnectionString;
        con = new SqlConnection(connectionString);
        cmd = new SqlCommand("SELECT * FROM Employees", con);

        // Open the connection.
        // This part is not asynchronous yet.
        try
        {
            con.Open();
        }
        catch (Exception err)
        {
            return new CompletedSyncResult(err, cb, state);
        }

        // Run the query asynchronously.
        // This method returns immediately and provides ASP.NET
        // with the IAsyncResult object it needs to track progress.
        return cmd.BeginExecuteReader(cb, state);
    }       

    // This method fires when IAsyncResult indicates the task is complete.
    private void EndTask(IAsyncResult ar)
    {        
        CompletedSyncResult completedSync = ar as CompletedSyncResult;
        if (completedSync != null)
        {
            try
            {
                table = completedSync.Result;
                lblError.Text = "Completed with data from the cache.";
            }
            catch (Exception err)
            {
                lblError.Text = "A connection error occurred.";
            }
        }
        else
        {
            try
            {
                SqlDataReader reader = cmd.EndExecuteReader(ar);

                table = new DataTable("Employees");
                table.Load(reader);
                Cache.Insert("Employees", table, null,
                DateTime.Now.AddMinutes(5), TimeSpan.Zero);
            }
            catch (SqlException err)
            {
                lblError.Text = "The query failed.";
            }
        }
    }

    // Perform the data binding in the next stage of the page lifecycle.
    protected void Page_PreRenderComplete(object sender, EventArgs e)
    {        
        grid.DataSource = table;
        grid.DataBind();
    }

    // Make sure the connection is closed in the event of an error.
    public override void Dispose()
    {
        if (con != null) con.Close();
        base.Dispose();
    }

}
