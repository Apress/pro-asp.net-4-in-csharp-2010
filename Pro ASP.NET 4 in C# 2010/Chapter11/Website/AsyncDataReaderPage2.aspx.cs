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

public partial class AsyncDataReaderPage2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PageAsyncTask task = new PageAsyncTask(BeginTask, EndTask, null, null);
        Page.RegisterAsyncTask(task);               

    }

    // The ADO.NET objects need to be accessible in several different
    // event handlers, so they must be declared as member variables.
    private SqlConnection con;
    private SqlCommand cmd;
    private SqlDataReader reader;
   
    private IAsyncResult BeginTask(object sender, EventArgs e,
        AsyncCallback cb, object state)
    {
        // Create the command.
        string connectionString = WebConfigurationManager.ConnectionStrings
            ["NorthwindAsync"].ConnectionString;
        con = new SqlConnection(connectionString);
        cmd = new SqlCommand("SELECT * FROM Employees", con);

        // Attempt to open the connection.
        // This part is not asynchronous yet.
        try
        {
            con.Open();
        }
        catch
        {
            lblError.Text = "Connection could not be opened.";
            con.Close();
        }

        // Run the query asynchronously.
        // This method returns immediately, and provides ASP.NET
        // with the IAsyncResult object it needs to track progress.
        return cmd.BeginExecuteReader(cb, state);
    }

    // This method fires when IAsyncResult indicates the task is complete.
    private void EndTask(IAsyncResult ar)
    {
        // You can now retrieve the DataReader.        
        reader = cmd.EndExecuteReader(ar);
    }

    // Perform the data binding in the next stage of the page lifecycle.
    protected void Page_PreRenderComplete(object sender, EventArgs e)
    {
        grid.DataSource = reader;
        grid.DataBind();
        con.Close();
    }

    // Make sure the connection is closed in the event of an error.
    public override void Dispose()
    {
        if (con != null) con.Close();
        base.Dispose();
    }

    public void Timeout(IAsyncResult result)
    {
        if (con != null && con.State != ConnectionState.Closed)
            con.Close();

        lblError.Text = "Task timed out.";
    }


}
