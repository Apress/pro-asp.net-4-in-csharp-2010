using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BrowserHistory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Page.Title = "Step 1";
        }
    }

    protected void Wizard1_ActiveStepChanged(object sender, EventArgs e)
    {
        if ((ScriptManager1.IsInAsyncPostBack) && (!ScriptManager1.IsNavigating))
        {
            string currentStep = Wizard1.ActiveStepIndex.ToString();
            ScriptManager1.AddHistoryPoint("Wizard1", Wizard1.ActiveStepIndex.ToString(),
                "Step " + (Wizard1.ActiveStepIndex + 1).ToString());
        }
    }
    protected void ScriptManager1_Navigate(object sender, HistoryEventArgs e)
    {
        if (e.State["Wizard1"] == null)
        {
            // Restore default state of page (for exmaple, for first page).
            Wizard1.ActiveStepIndex = 0;
        }
        else
        {
            Wizard1.ActiveStepIndex = Int32.Parse(e.State["Wizard1"]);
        }
        Page.Title = "Step " + (Wizard1.ActiveStepIndex + 1).ToString();
    }
}
