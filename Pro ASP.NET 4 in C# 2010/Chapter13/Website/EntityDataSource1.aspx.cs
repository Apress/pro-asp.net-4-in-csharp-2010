using System;
using System.Web.UI.WebControls;

public partial class EntityDataSource1 : System.Web.UI.Page {

    protected void Page_Load(object sender, EventArgs e) {

    }

protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e) {
    if (e.Exception != null) {
        EntityDataSourceValidationException ve = e.Exception as EntityDataSourceValidationException;
        if (ve == null) {
            Label1.Text = "Data error";
        } else {
            Label1.Text = ve.Message;
        }
        e.ExceptionHandled = true;
    } else {
        GridView1.DataBind();
    }
}
}