using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

public partial class LinearGradientBrushes : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {

        // Create the in-memory bitmap.
        Bitmap image = new Bitmap(300, 300);
        Graphics g = Graphics.FromImage(image);

        // Paint the background.
        g.FillRectangle(Brushes.White, 0, 0, 300, 300);

        // Show a rectangle with each type of gradient.
        int y = 20;
        foreach (LinearGradientMode gradientStyle in
          System.Enum.GetValues(typeof(LinearGradientMode))) {
            // Configure the brush.
            LinearGradientBrush myBrush = new LinearGradientBrush(new Rectangle(20, y, 100, 60),
            Color.Violet, Color.White, gradientStyle);

            // Draw a small rectangle and add a text label.
            g.FillRectangle(myBrush, 20, y, 100, 60);
            g.DrawString(gradientStyle.ToString(), new Font("Tahoma", 8),
              Brushes.Black, 130, y + 20);

            // Move to the next line.
            y += 70;
        }

        // Render the image to the output stream.
        image.Save(Response.OutputStream,
         System.Drawing.Imaging.ImageFormat.Jpeg);

        g.Dispose();
        image.Dispose();
    }
}