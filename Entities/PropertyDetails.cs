using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_Final.Entities
{
	public class PropertyDetails
	{
		[Key]
		public int  propertyDetailID { get; set; }
		public string propertyDetailCode {get; set; }
		public string  propertyDetailDetail {get; set;}
		public int propertyID {get; set;}
        [ForeignKey("propertyID")]
        public Properties Properties {get; set;}
		public  IEnumerable<ProductDetaiPropertyDetails> ProductDetaiPropertyDetails { get; set; }
		public  IEnumerable<ProductDetails> ProductDetails { get; set; }
	}
}

