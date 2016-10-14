using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

[MetadataType(typeof(Order_DetailMetadata))]
public partial class Order_Detail {
}

[DisplayName("Order Details")]
public class Order_DetailMetadata {
}

[MetadataType(typeof(ProductMetadata))]
public partial class Product {

    partial void OnUnitsInStockChanging(System.Nullable<short> value) {
        if (value % 2 == 1) throw new ValidationException("Stock level must be an even number");
    }

}

public class ProductMetadata {

    [DisplayName("In Stock")]
    [Required(ErrorMessage = "You must enter how many items we have in stock")]
    [Range(0, 100)]
    public object UnitsInStock { get; set; }

    [DisplayName("Price")]
    public object UnitPrice {get; set;}

    [ScaffoldColumn(false)]
    public object SupplierID { get; set; }
}

[MetadataType(typeof(CustomerMetadata))]
public partial class Customer {
}

[ScaffoldTable(false)]
public class CustomerMetadata {
}

[MetadataType(typeof(OrderMetadata))]
public partial class Order {
}

public class OrderMetadata {

    [DisplayFormat(DataFormatString = "{0:yy-MM-dd}")]
    public object OrderDate { get; set; }

    [DisplayFormat(DataFormatString = "{0:yy-MM-dd}")]
    public object RequiredDate { get; set; }

    [DisplayFormat(DataFormatString = "{0:yy-MM-dd}")]
    public object ShippedDate{ get; set; }

    [UIHint("REDText")]
    public object ShipName { get; set; }
}


