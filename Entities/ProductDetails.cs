using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_Final.Entities
{
    public class ProductDetails
    {
        [Key]
        public int productDetailID { get; set; }
        public string productDetailName { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public double sellPrice { get; set; }
        public int? parentID { get; set; }
        [ForeignKey("parentID")]
        public virtual ProductDetails ParentDetails { get; set; }
        public virtual IEnumerable<ProductDetails> LstParentDetails { get; set; }
        public int propertyDetailID { get; set; }
        [ForeignKey("propertyDetailID")]
        public PropertyDetails PropertyDetails { get; set; }
        public virtual IEnumerable<ProductDetaiPropertyDetails> ProductDetaiPropertyDetails { get; set; }
    }
}