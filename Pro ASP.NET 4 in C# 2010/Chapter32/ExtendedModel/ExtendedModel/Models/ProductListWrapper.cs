using System.Web.Mvc;

namespace ExtendedModel.Models {

    public class ProductListWrapper {
        public Product product { get; set; }
        public string SelectedSupplier { get; set; }
        public string SelectedCategory { get; set; }
    }
}