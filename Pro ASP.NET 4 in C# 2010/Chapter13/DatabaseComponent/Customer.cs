using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace DatabaseComponent.Simplified
{
    [Table(Name="dbo.Customers")]
    public class Customer
    {
        [Column(IsPrimaryKey=true)]
        public string CustomerID { get; set; }

        [Column()]
        public string CompanyName { get; set; }
        
        [Column()]
        public string ContactName { get; set; }
        
        [Column()]
        public string ContactTitle { get; set; }

        private EntitySet<Order> orders;

        [Association(Storage="orders", OtherKey = "CustomerID", ThisKey = "CustomerID")]
        public EntitySet<Order> Orders
        {
            get
            {
                return orders;
            }
            set
            {
                orders.Assign(value);
            }
        }        
    }

    [Table(Name="dbo.Orders")]
    public class Order
    {   
        [Column(IsPrimaryKey=true, IsDbGenerated=true)]
        public int OrderID { get; set; }

        [Column()]
        public string CustomerID { get; set; }

        [Column()]
        public DateTime? OrderDate { get; set; }
            
        private EntityRef<Customer> _Customer;
        [Association(Name = "FK_Orders_Customers", Storage = "_Customer", OtherKey = "CustomerID", ThisKey = "CustomerID", IsForeignKey = true)]
        public Customer Customer
        {
            get
            {
                return this._Customer.Entity;
            }
            set
            {
                if ((this._Customer.Entity != value))
                {
                    
                    if ((this._Customer.Entity != null))
                    {
                        Customer temp = this._Customer.Entity;
                        this._Customer.Entity = null;
                        temp.Orders.Remove(this);
                    }
                    this._Customer.Entity = value;
                    if ((value != null))
                    {
                        value.Orders.Add(this);
                    }                    
                }
            }
        }  
    }        
}
