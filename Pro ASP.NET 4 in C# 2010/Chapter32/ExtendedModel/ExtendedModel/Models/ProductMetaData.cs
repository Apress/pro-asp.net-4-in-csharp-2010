using System.ComponentModel.DataAnnotations;

namespace ExtendedModel.Models {

    [MetadataType(typeof(ProductMetaData))]
    public partial class Product {

        public class ProductMetaData {
            [Range(1, 50)]
            
            [OddOrEven(OddOrEvenAttribute.Mode.Even, ErrorMessage="Units In Stock must be even")]
            public object UnitsInStock { get; set; }

        }
    }
}