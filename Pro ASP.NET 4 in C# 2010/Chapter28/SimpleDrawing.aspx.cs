using System;
using System.Drawing;

public partial class SimpleDrawing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Create the in-memory bitmap where you will draw the image.
        // This bitmap is 300 pixels wide and 50 pixels high.
        Bitmap image = new Bitmap(300, 50);

        // get the graphics context
        Graphics g = Graphics.FromImage(image);

        // Draw a solid white rectangle.
        // Start from point (1, 1).
        // Make it 298 pixels wide and 48 pixels high.
        g.FillRectangle(Brushes.White, 1, 1, 298, 48);

        // load a font and use it to draw a string
        Font font = new Font("Impact", 20, FontStyle.Regular);
        g.DrawString("This is a test.", font, Brushes.Blue, 10, 5);

        // write the image to the output stream.
        image.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Gif);

        // dispose of the context and the bitmap
        g.Dispose();
        image.Dispose();
    }
}