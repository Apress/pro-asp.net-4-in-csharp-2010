using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace CustomServerControlsLibrary
{
	public class RollOverButton : WebControl, IPostBackEventHandler
	{
		public RollOverButton() : base(HtmlTextWriterTag.Img)
		{
			ImageUrl = "";
			MouseOverImageUrl = "";
		}

		public string ImageUrl
		{
			get {return (string)ViewState["ImageUrl"];}
			set {ViewState["ImageUrl"] = value;}
		}

		public string MouseOverImageUrl
		{
			get {return (string)ViewState["MouseOverImageUrl"];}
			set {ViewState["MouseOverImageUrl"] = value;}
		}

		protected override void AddAttributesToRender(HtmlTextWriter output)
		{
			output.AddAttribute("id", ClientID);
			output.AddAttribute("src", ImageUrl);
			output.AddAttribute("onclick", Page.ClientScript.GetPostBackEventReference(new PostBackOptions(this)));
			
			output.AddAttribute("onmouseover",
				"swapImg('" + this.ClientID + "', '" +
				MouseOverImageUrl + "');");

			output.AddAttribute("onmouseout",
				"swapImg('" + this.ClientID + "', '" +
				ImageUrl + "');");
		}

		protected override void OnPreRender(EventArgs e)
		{

			if (!Page.ClientScript.IsClientScriptBlockRegistered("swapImg"))
			{
				string script =
                    "<script type='text/javascript'> " + 
					"function swapImg(id, url) { " + 
					"var elm = document.getElementById(id); " +
					"elm.src = url; }" +
					"</script> ";

				Page.ClientScript.RegisterClientScriptBlock(this.GetType(),
		  "swapImg", script);
			}

            if (!Page.ClientScript.IsStartupScriptRegistered("preload" + this.ClientID))
            {
                string script =
                    "<script type='text/javascript'> " +
                    "var preloadedImage = new Image(); " +
                    "preloadedImage.src = '" + MouseOverImageUrl + "'; " +
					"</script> ";

				Page.ClientScript.RegisterStartupScript(this.GetType(),
          "preload" + this.ClientID, script);
            }

			base.OnPreRender (e);
		}

		public event EventHandler ImageClicked;

		public void RaisePostBackEvent(string eventArgument)
		{
			OnImageClicked(new EventArgs());
		}

		protected virtual void OnImageClicked(EventArgs e)
		{
			// Check for at least one listener and then raise the event.
			if (ImageClicked != null)
				ImageClicked(this, e);
		}

	}
}
