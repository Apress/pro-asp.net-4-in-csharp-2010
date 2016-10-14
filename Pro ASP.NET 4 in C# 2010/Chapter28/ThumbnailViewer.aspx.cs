using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

public partial class ThumbnailViewer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e) {
        if ((String.IsNullOrEmpty(Request.QueryString["X"])) ||
            (String.IsNullOrEmpty(Request.QueryString["Y"])) ||
            (String.IsNullOrEmpty(Request.QueryString["FilePath"]))) {
            // There is missing data, so don't display anything.
            // Other options include choosing reasonable defaults
            // or returning an image with some static error text.
        } else {
            int x = Int32.Parse(Request.QueryString["X"]);
            int y = Int32.Parse(Request.QueryString["Y"]);
            string file = Server.UrlDecode(Request.QueryString["FilePath"]);

            // Create the in-memory bitmap where you will draw the image.
            Bitmap image = new Bitmap(x, y);
            Graphics g = Graphics.FromImage(image);

            // Load the file data.
            System.Drawing.Image thumbnail =
            System.Drawing.Image.FromFile(file);

            // Draw the thumbnail.
            g.DrawImage(thumbnail, 0, 0, x, y);

            // Render the image.
            image.Save(Response.OutputStream, ImageFormat.Jpeg);
            g.Dispose();
            image.Dispose();
        }
    }
}