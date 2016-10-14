using System;
using System.Drawing;
using System.Drawing.Drawing2D;

public partial class GradientLabel : System.Web.UI.Page {

    protected void Page_Load(object sender, EventArgs e) {

        string text = Server.UrlDecode(Request.QueryString["Text"]);
        int textSize = Int32.Parse(Request.QueryString["TextSize"]);
        Color textColor = Color.FromArgb(
          Int32.Parse(Request.QueryString["TextColor"]));
        Color gradientColorStart = Color.FromArgb(
          Int32.Parse(Request.QueryString["GradientColorStart"]));
        Color gradientColorEnd = Color.FromArgb(
          Int32.Parse(Request.QueryString["GradientColorEnd"]));

        // Define the font.
        Font font = new Font("Tahoma", textSize, FontStyle.Bold);

        // Use a test image to measure the text.
        Bitmap image = new Bitmap(1, 1);
        Graphics g = Graphics.FromImage(image);
        SizeF size = g.MeasureString(text, font);
        g.Dispose();
        image.Dispose();

        // Using these measurements, try to choose a reasonable bitmap size.
        // If the text is large, cap the size at some maximum to
        // prevent causing a serious server slowdown.
        int width = (int)Math.Min(size.Width + 20, 800);
        int height = (int)Math.Min(size.Height + 20, 800);
        image = new Bitmap(width, height);
        g = Graphics.FromImage(image);

        LinearGradientBrush brush = new LinearGradientBrush(
            new Rectangle(new Point(0, 0), image.Size),
            gradientColorStart, gradientColorEnd, LinearGradientMode.ForwardDiagonal);

        // Draw the gradient background.
        g.FillRectangle(brush, 0, 0, width, height);

        // Draw the label text.
        g.DrawString(text, font, new SolidBrush(textColor), 10, 10);

        // Render the image to the output stream.
        image.Save(Response.OutputStream,
         System.Drawing.Imaging.ImageFormat.Jpeg);

        g.Dispose();
        image.Dispose();
    }
}