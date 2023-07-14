using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_Final.Entities
{
	public class Properties
	{
		[Key]
		public int propertyID { get; set; }
		
		public string propertyCode { get; set; }
		public string propertyDetail { get; set; }
		public int  propertySort { get; set; }

        public int productID { get; set; }
        [ForeignKey("productID")]
        public Products Products { get; set; }
		public IEnumerable<PropertyDetails> PropertyDetails { get; set; }
	}
}

