using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_Final.Entities
{
    public class ProductDetaiPropertyDetails
    {
        //[Key]
        //public int productDetailPropertyDetailID { get; set; }
        
        public int productID { get; set; }
        //[ForeignKey("productID")]
        public Products Products { get; set; }
        
        public int productDetailID { get; set; }
        //[ForeignKey("productDetailID")]
        public ProductDetails ProductDetails { get; set; }
        
        public int propertyDetailID { get; set; }
        //[ForeignKey("propertyDetailID")]
        public PropertyDetails PropertyDetails { get; set; }
    }
}