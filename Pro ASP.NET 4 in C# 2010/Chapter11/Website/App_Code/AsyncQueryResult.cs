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
using System.Data.SqlClient;


public class AsyncQueryResult : IAsyncResult
{  
    private Exception operationException;
    public Exception OperationException
    {
        get { return operationException; }
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

            if (asyncQueryResult != null)
            {
                try
                {
                    SqlDataReader reader = cmdQuery.EndExecuteReader(asyncQueryResult);
                    result = new DataTable("Employees");
                    result.Load(reader);
                    reader.Close();
                }
                finally
                {
                    cmdQuery.Connection.Close();                    
                }
            }
            return result;
        }
    }

    // Use these objects if the task is being performed
    // asynchronously with BeginExecuteReader().
    private SqlCommand cmdQuery;
    private IAsyncResult asyncQueryResult;
    private AsyncCallback asyncCallback;
    // Use in case of true asynchronous task with BeginExecuteReader.    
    public AsyncQueryResult(SqlCommand readerCommand, AsyncCallback asyncCallback, object asyncState)
    {
        state = asyncState;
        cmdQuery = readerCommand;
        this.asyncCallback = asyncCallback;
                
        try
        {
            cmdQuery.Connection.Open();

            // Hook to the BeginExecuteReader() callback,
            // so you can pass it along to the caller.
            asyncQueryResult = cmdQuery.BeginExecuteReader(
                new AsyncCallback(RaiseCallback), null);
        }
        catch (Exception err)
        {
            // Store the error and re-raise it when the
            // result is read.
            cmdQuery.Connection.Close();
            asyncQueryResult = null;
            cmdQuery = null;
            operationException = err;
        }
    }

    private void RaiseCallback(IAsyncResult ar)
    {        
        if (asyncCallback != null)
        {
            asyncCallback(this);
        }
    }

    // Use in the case of data being ready immediately.
    public AsyncQueryResult(DataTable result, AsyncCallback asyncCallback, object asyncState)
    {        
        state = asyncState;
        this.result = result;
        
        // Code that triggers the callback, if it's used.
        if (asyncCallback != null)
        {
            asyncCallback(this);
        }
    }

    // Use in the case of error.
    public AsyncQueryResult(Exception operationException, AsyncCallback asyncCallback, object asyncState)
    {
        state = asyncState;
        this.operationException = operationException;

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
        get
        {
            if (asyncQueryResult != null)
            {
                return asyncQueryResult.AsyncWaitHandle;
            }
            else
            {
                return null;
            }
        }
    }

    bool IAsyncResult.CompletedSynchronously
    {
        get
        {
            if (asyncQueryResult != null)
            {
                return asyncQueryResult.CompletedSynchronously;
            }
            else
            {
                return true;
            }
        }
    }

    bool IAsyncResult.IsCompleted
    {
        get
        {
            if (asyncQueryResult != null)
            {
                return asyncQueryResult.IsCompleted;
            }
            else
            {
                return true;
            }
        }
    }
}

