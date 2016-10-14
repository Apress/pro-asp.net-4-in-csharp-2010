using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Threading;


public class CompletedSyncResult : IAsyncResult
{  
    private Exception operationException;
    public Exception OperationException
    {
        get { return operationException; }
        set { operationException = value; }
    }

    private DataTable result;
    public DataTable Result
    {
        get
        {
            if (OperationException != null)
            {
                throw OperationException;
            }
            return result;
        }
        set { result = value; }
    }

    // Use in the case of data being ready.
    public CompletedSyncResult(DataTable result, AsyncCallback asyncCallback, object asyncState)
    {        
        state = asyncState;
        Result = result;
        
        // Code that triggers the callback, if it's used.
        if (asyncCallback != null)
        {
            asyncCallback(this);
        }
    }

    // Use in the case of error.
    public CompletedSyncResult(Exception operationException, AsyncCallback asyncCallback, object asyncState)
    {
        state = asyncState;
        OperationException = operationException;

        // Code that triggers the callback, if it's used.
        if (asyncCallback != null)
        {
            asyncCallback(this);
        }
    }

    private object state;
    object IAsyncResult.AsyncState
    {
        get { return state; }
    }

    WaitHandle IAsyncResult.AsyncWaitHandle
    {
        get { return null; }
    }

    bool IAsyncResult.CompletedSynchronously
    {
        get { return true; }
    }

    bool IAsyncResult.IsCompleted
    {
        get { return true; }
    }
}

