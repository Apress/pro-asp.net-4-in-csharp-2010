using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Net;
using System.Security.Cryptography.X509Certificates;

/// <summary>
/// Summary description for WebRequestCreator
/// </summary>
public static class WebRequestCreator
{
    public static void ExecuteWebRequest(string url)
    {
        X509Certificate2 Certificate = null;

        // Read the certificate from the store
        X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
        store.Open(OpenFlags.ReadOnly);
        try
        {
            // Try to find the certificate
            // based on its common name
            X509Certificate2Collection Results = 
                store.Certificates.Find(
                    X509FindType.FindBySubjectDistinguishedName,
                    "CN=Mario, CN=Szpuszta", false);

            if (Results.Count == 0)
                throw new Exception("Unable to find certificate!");
            else
                Certificate = Results[0];
        }
        finally
        {
            store.Close();
        }

        // Now create the web request
        HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(url);
        Request.ClientCertificates.Add(Certificate);
        HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
        // ...
    }
}
