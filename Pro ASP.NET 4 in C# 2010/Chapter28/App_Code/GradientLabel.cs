using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Drawing;

namespace CustomControls {

    public class GradientLabel : Control {

        public GradientLabel() {
            Text = "";
            TextColor = Color.White;
            GradientColorStart = Color.Blue;
            GradientColorEnd = Color.DarkBlue;
            TextSize = 14;
        }

        public string Text {
            get { return (string)ViewState["Text"]; }
            set { ViewState["Text"] = value; }
        }

        public int TextSize {
            get { return (int)ViewState["TextSize"]; }
            set { ViewState["TextSize"] = value; }
        }

        public Color GradientColorStart {
            get { return (Color)ViewState["ColorStart"]; }
            set { ViewState["ColorStart"] = value; }
        }

        public Color GradientColorEnd {
            get { return (Color)ViewState["ColorEnd"]; }
            set { ViewState["ColorEnd"] = value; }
        }

        public Color TextColor {
            get { return (Color)ViewState["TextColor"]; }
            set { ViewState["TextColor"] = value; }
        }

        protected override void Render(HtmlTextWriter writer) {
            HttpContext context = HttpContext.Current;
            writer.Write("<img src='" + "GradientLabel.aspx?" +
              "Text=" + context.Server.UrlEncode(Text) +
              "&TextSize=" + TextSize.ToString() +
              "&TextColor=" + TextColor.ToArgb() +
              "&GradientColorStart=" + GradientColorStart.ToArgb() +
              "&GradientColorEnd=" + GradientColorEnd.ToArgb() +
              "'>");
        }
    }
}