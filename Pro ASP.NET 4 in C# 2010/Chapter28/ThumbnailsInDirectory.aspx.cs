using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class ThumbnailsInDirectory : System.Web.UI.Page {

    protected void Page_Load(object sender, EventArgs e) {

    }

    protected void cmdShow_Click(object sender, EventArgs e) {

        // Get a string array with all the image files.
        DirectoryInfo dir = new DirectoryInfo(txtDir.Text);
        gridThumbs.DataSource = dir.GetFiles();

        // Bind the string array.
        gridThumbs.DataBind();
    }

    protected string GetImageUrl(object path) {
        return "ThumbnailViewer.aspx?x=50&y=50&FilePath=" +
          Server.UrlEncode((string)path);
    }


}