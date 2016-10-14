using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;

[Serializable()]
public class ShoppingCartItem
{
	private int productID;
	private string productName;
	private decimal unitPrice;
	private int units;

	public int ProductID
	{
		get { return productID; }
	}
	public string ProductName
	{
		get { return productName; }
	}
	public decimal UnitPrice
	{
		get { return unitPrice; }
	}
	public int Units
	{
		get { return units; }
		set { units = value; }
	}
	public decimal Total
	{
		get { return Units * UnitPrice; }
	}
	public ShoppingCartItem(int productID,
	  string productName, decimal unitPrice, int units)
	{
		this.productID = productID;
		this.productName = productName;
		this.unitPrice = unitPrice;
		this.units = units;
	}
}

[Serializable()]
public class ShoppingCart : CollectionBase
{
	public ShoppingCartItem this[int index]
	{
		get { return ((ShoppingCartItem)List[index]); }
		set { List[index] = value; }
	}
	public int Add(ShoppingCartItem value)
	{
		return (List.Add(value));
	}
	public int IndexOf(ShoppingCartItem value)
	{
		return (List.IndexOf(value));
	}
	public void Insert(int index, ShoppingCartItem value)
	{
		List.Insert(index, value);
	}
	public void Remove(ShoppingCartItem value)
	{
		List.Remove(value);
	}
	public bool Contains(ShoppingCartItem value)
	{
		return (List.Contains(value));
	}
}