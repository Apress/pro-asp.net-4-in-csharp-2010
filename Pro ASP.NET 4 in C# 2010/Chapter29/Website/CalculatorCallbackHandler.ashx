<%@ WebHandler Language="C#" Class="CalculatorCallbackHandler" %>

using System;
using System.Web;

public class CalculatorCallbackHandler : IHttpHandler
{   
    public void ProcessRequest (HttpContext context)
    {
        HttpResponse response = context.Response;
        
        // Write ordinary text.
        response.ContentType = "text/plain";
        
        // Get the query string arguments.        
        float value1, value2;
        if (Single.TryParse(context.Request.QueryString["value1"], out value1) &&
            Single.TryParse(context.Request.QueryString["value2"], out value2))
        {
            response.Write(value1 + value2);
            response.Write(",");
            DateTime now = DateTime.Now;
            response.Write(now.ToLongTimeString());
        }
        else
        {
            // Indicate an error.
            response.Write("-");
        }
    }
 
    public bool IsReusable
    {
        get
        {
            return true;
        }
    }

}