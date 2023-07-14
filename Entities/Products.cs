using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI_Final.Entities
{
	public class Products
	{
		[Key]
		public int productID { get; set; }
		public string productCode { get; set; }
		public string productName { get; set; }
		public int quantity { get; set; }
		public string productShowName { get; set; }

		public virtual IEnumerable<Properties> Properties { get; set; }
		public virtual IEnumerable<ProductDetaiPropertyDetails> ProductDetaiPropertyDetails { get; set; }
    }
}

