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
using System.Diagnostics;

public partial class SimpleAsyncPage : System.Web.UI.Page
{
    private string pageID;

    protected void Page_Load(object sender, EventArgs e)
    {        
        // Get a random identifier for page.
        Random rnd = new Random();
        pageID = String.Format("#{0} ", rnd.Next(0, 100));
                
        AddOnPreRenderCompleteAsync(new BeginEventHandler(BeginTask),
          new EndEventHandler(EndTask));

        Debug.WriteLine(pageID + "Page_Load ended: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
    }

    protected void Page_UnLoad(object sender, EventArgs e)
    {
        Debug.WriteLine(pageID + "Page_UnLoad: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
    }

    private System.Threading.ThreadStart start;

    private IAsyncResult BeginTask(object sender, EventArgs e, AsyncCallback cb, object state)
    {
        Debug.WriteLine(pageID + "Begin Task: " + System.Threading.Thread.CurrentThread.ManagedThreadId);

        start = new System.Threading.ThreadStart(DoSomethingSlow);
        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(10));
        return start.BeginInvoke(cb, state);
    }

    private void DoSomethingSlow()
    {
        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(30));
        Debug.WriteLine(pageID + "In Task: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
    }

    private void EndTask(IAsyncResult ar)
    {
        Debug.WriteLine(pageID + "End Task: " + System.Threading.Thread.CurrentThread.ManagedThreadId);

        start.EndInvoke(ar);
    }
}
