using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class ShoppingCartTest : System.Web.UI.Page
{
	private NorthwindDB db = new NorthwindDB();
	private DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
		// Update the product list.
		ds = db.GetCategoriesProductsDataSet();
		gridProducts.DataSource = ds.Tables["Products"];
		gridProducts.DataBind();

		// Check for the shopping cart. If it doesn't
		// exist, create a new cart and make it available.
		//if (Profile.Cart == null)
		//{
		//	Profile.Cart = new ShoppingCart();
		//}
	}
	protected void Page_PreRender(object sender, EventArgs e)
	{
		// Show the shopping cart in the grid.
		gridCart.DataSource = Profile.Cart;
		gridCart.DataBind();
    }
	protected void gridProducts_SelectedIndexChanged(object sender, EventArgs e)
	{
		// Get the full record for the one selected row.
		DataRow[] rows = ds.Tables["Products"].Select("ProductID=" + gridProducts.SelectedDataKey.Values["ProductID"].ToString());
		DataRow row = rows[0];

		// Search to see if an item of this type is already in the cart.
		Boolean inCart = false;
		foreach (ShoppingCartItem item in Profile.Cart)
		{
			// Increment the number count.
			if (item.ProductID == (int)row["ProductID"])
			{
				item.Units += 1;
				inCart = true;
				break;
			}
		}

		// If the item isn't in the cart, add it.
		if (!inCart)
		{
			ShoppingCartItem item = new ShoppingCartItem(
				(int)row["ProductID"], (string)row["ProductName"],
				(decimal)row["UnitPrice"], 1);
			Profile.Cart.Add(item);
		}

		// Don't keep the item selected in the product list.
		gridProducts.SelectedIndex = -1;
	}
	
	protected void gridCart_SelectedIndexChanged(object sender, EventArgs e)
	{
		// The text box is the second control.
		// The first control in a template column
		// is always a blank LiteralControl.
		TextBox txt = (TextBox)gridCart.Rows[gridCart.SelectedIndex].Cells[3].Controls[1];
		try
		{
		    // Update the appropriate cart item.
		    int newCount = int.Parse(txt.Text);
		    if (newCount > 0)
		    {
				Profile.Cart[gridCart.SelectedIndex].Units = newCount;
		    }
		    else if (newCount == 0)
		    {
				Profile.Cart.RemoveAt(gridCart.SelectedIndex);
		    }
		}
		catch
		{
		    // Ignore invalid (non-numeric) entries.
		}

		// Clear the selection. (You could also set the selection
		// style so that the selected row doesn't appear to the user.)
		gridCart.SelectedIndex = -1;
	}
}
