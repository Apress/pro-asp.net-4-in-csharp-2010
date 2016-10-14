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

public partial class AsyncDataReaderRefactored : System.Web.UI.Page
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

    private IAsyncResult BeginTask(object sender, EventArgs e,
        AsyncCallback cb, object state)
    {
        // Check the cache.
        if (Cache["Employees"] != null)
        {
            return new AsyncQueryResult((DataTable)Cache["Employees"],
                cb, state);
        }

        // Create the command.
        string connectionString = WebConfigurationManager.ConnectionStrings
            ["NorthwindAsync"].ConnectionString;
        con = new SqlConnection(connectionString);
        cmd = new SqlCommand("SELECT * FROM Employees", con);

        return new AsyncQueryResult(cmd, cb, state);
    }

    private DataTable table;

    // This method fires when IAsyncResult indicates the task is complete.
    private void EndTask(IAsyncResult ar)
    {
        AsyncQueryResult completedSync = (AsyncQueryResult)ar;

        try
        {
            table = completedSync.Result;

            // Store it in the cache, if needed.
            if (!ar.CompletedSynchronously)
            {
                Cache.Insert("Employees", table, null,
                DateTime.Now.AddMinutes(5), TimeSpan.Zero);
            }
        }
        catch (Exception err)
        {
            lblError.Text = "An error occurred. <br />";

            // Typically, you wouldn't display the underlying
            // error message.
            // This is a debugging/testing aid.
            lblError.Text += err.Message;
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
