using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseComponent
{
    public class ProductDetails
    {
        private int productID;
        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        private int categoryID;
        public int CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
        }

        private string productName;
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        private decimal unitPrice;
        public decimal UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }

        public ProductDetails()
        {
        }

        public ProductDetails(int productID, string productName, decimal unitPrice, int categoryID)
        {
            ProductID = productID;
            ProductName = productName;
            UnitPrice = unitPrice;
            CategoryID = categoryID;
        }
    }
}
