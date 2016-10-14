using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for SalesDataService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class SalesDataService : System.Web.Services.WebService {

    public SalesDataService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public List<ProductSales> GetSalesData()
    {
        List<ProductSales> productSalesInfo = new List<ProductSales>();
        productSalesInfo.Add(new ProductSales("sfsf", 453));
        return productSalesInfo;
    }
    
}

public class ProductSales
{
    public string Product { get; set; }
    public decimal SalesTotal { get; set; }
    public DateTime DateGenerated { get; set; }

    public ProductSales(string product, decimal salesTotal)
    {
        this.Product = product;
        this.SalesTotal = salesTotal;
        this.DateGenerated = DateTime.Now;
    }

    public ProductSales() { }
}
