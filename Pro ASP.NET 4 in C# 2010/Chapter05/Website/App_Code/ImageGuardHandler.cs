using System;
using System.Web;
using System.IO;
using System.Globalization;

public class ImageGuardHandler : IHttpHandler
{
    public void ProcessRequest(System.Web.HttpContext context)
    {
        HttpResponse response = context.Response;
        HttpRequest request = context.Request;

        string imagePath = null;
        if (request.UrlReferrer != null)
        {
            // Perform a case-insensitive comparison.
            if (String.Compare(request.Url.Host, request.UrlReferrer.Host,
                true, CultureInfo.InvariantCulture) == 0)
            {
                // The requesting host is correct.
                // Allow the image (if it exists).
                imagePath = request.PhysicalPath;
                if (!File.Exists(imagePath))
                {
                    response.Status = "Image not found";
                    response.StatusCode = 404;
                    return;
                }
            }
        }

        if (imagePath == null)
        {
            // No valid image was allowed.
            // Use the warning image instead.
            // Rather than hard-code this image, you could
            // retrieve it from the web.config file
            // (using the <appSettings> section or a custom
            // section).                
            imagePath = context.Server.MapPath("~/Images/notAllowed.gif");
        }

        // Serve the image
        // Set the content type to the appropriate image type.
        response.ContentType = "image/" +
            Path.GetExtension(imagePath).ToLower();
        response.WriteFile(imagePath);


        
    }


    public bool IsReusable
    {
        get { return true; }
    }
}