using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;

public class FindBook
{
	public string GetImageUrl(string isbn)
	{
		try
		{
			// Find the pointer to the book cover image.
			// Amazon.com has the most cover images,
			// so go there to look for it.
			// Start with the book details page.
			isbn = isbn.Replace("-", "");
			string bookUrl = "http://www.amazon.com/exec/obidos/ASIN/" + isbn;

			// Now retrieve the HTML content of the book details page.
			string bookHtml = GetWebPageAsString(bookUrl);

			// Search the page for an image tag for the book.
            // The img url format changes from time to time, so
            // this code is neither guaranteed to get the best
            // picture for the book or continue working in the future.
            // It's for demonstration purposes only.
            // If you need this exact functionality in an application,
            // consider Amazon web services (www.amazon.com/gp/aws/landing.html)
            string imgTagPattern = "<img src=\"(http://ecx.images-amazon.com/images/I/[^\"]+)\"";
			Match imgTagMatch = Regex.Match(bookHtml, imgTagPattern);
            return imgTagMatch.Groups[1].Value;
		}
		catch
		{
			return "";
		}
	}

	public string GetWebPageAsString(string url)
	{
		// Create the request.
		WebRequest requestHtml = WebRequest.Create(url);

		// Get the response.
		WebResponse responseHtml = requestHtml.GetResponse();

		// Read the response stream.
		StreamReader r = new StreamReader(responseHtml.GetResponseStream());
		string htmlContent = r.ReadToEnd();
		r.Close();

		return htmlContent;
	}
}
