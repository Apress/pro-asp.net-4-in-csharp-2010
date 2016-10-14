using System;

namespace Web_Deploy {
    public partial class Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            Label1.Text = System.Environment.Version.Major.ToString();
        }
    }
}