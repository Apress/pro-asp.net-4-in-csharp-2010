using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;

public partial class CultureInfo_aspx : System.Web.UI.Page
{
    // Page events are wired up automatically to methods 
    // with the following names:
    // Page_Load, Page_AbortTransaction, Page_CommitTransaction,
    // Page_DataBinding, Page_Disposed, Page_Error, Page_Init, 
    // Page_Init Complete, Page_Load, Page_LoadComplete, Page_PreInit
    // Page_PreLoad, Page_PreRender, Page_PreRenderComplete, 
    // Page_SaveStateComplete, Page_Unload

    protected void Page_Load(object sender, EventArgs e)
    {
        CultureInfo ci;
        if ((Request.UserLanguages != null) && (Request.UserLanguages.Length > 0))
        {
            ci = new CultureInfo(Request.UserLanguages[0]);
            System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
            System.Threading.Thread.CurrentThread.CurrentCulture = ci;
        }
        else
        {
            ci = System.Threading.Thread.CurrentThread.CurrentUICulture;
        }

        StringBuilder MessageBuilder = new StringBuilder();
        MessageBuilder.Append("Current culture info: ");
        MessageBuilder.Append("<BR>");
        MessageBuilder.AppendFormat("-) Name: {0}", ci.Name);
        MessageBuilder.Append("<BR>");
        MessageBuilder.AppendFormat("-) ISO Name: {0}", ci.ThreeLetterISOLanguageName);
        MessageBuilder.Append("<BR>");
        MessageBuilder.Append("-) Currency Symbol: " + ci.NumberFormat.CurrencySymbol);
        MessageBuilder.Append("<BR>"); MessageBuilder.Append("-) Long Date Pattern: " + ci.DateTimeFormat.LongDatePattern);

        LegendCI.Text = MessageBuilder.ToString();

        Response.Write("Date format: " + DateTime.Now.ToString());

        if (Request.QueryString["date"] != null)
        {
            try
            {
                DateTime.Parse(Request.QueryString["date"]);
                Response.Write("<br>Parsing succeeded!");
            }
            catch
            {
                Response.Write("<br>Parsing FAILED!");
            }
        }
        else
        {
            Response.Write("<br/>No date supplied in the 'date' query string parameter to be parsed!");
        }
    }

    protected void InsertDate_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CiDb"].ConnectionString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO TestData(EntryDate) VALUES(@MyDate)";
                cmd.Parameters.AddWithValue("@MyDate", DateTime.Parse(DateText.Text));
                cmd.ExecuteNonQuery();
                Response.Write("<br>Insert succeeded!");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<br>Insert FAILED: " + ex.Message);
        }
    }
}
