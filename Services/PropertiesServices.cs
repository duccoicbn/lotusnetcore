using System;
using WebAPI_Final.Entities;
using WebAPI_Final.IServices;

namespace WebAPI_Final.Services
{
	public class PropertiesServices : IPropertiesServices
	{
		private readonly AppDbContext dbContext;
		public PropertiesServices()
		{
			dbContext = new AppDbContext();
		}

        public bool AddProperties(int productID, Properties property)
        {
			var checkProduct = dbContext.Products.FirstOrDefault(x => x.productID == productID);
			if (checkProduct  != null)
			{
				property.productID = productID;
				dbContext.Properties.Add(property);
				dbContext.SaveChanges();
				return true;
			}
			else
			{
				return false;
			}
        }
    }
}

