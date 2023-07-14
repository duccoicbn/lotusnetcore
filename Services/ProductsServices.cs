using System;
using Microsoft.EntityFrameworkCore;
using WebAPI_Final.Entities;
using WebAPI_Final.IServices;

namespace WebAPI_Final.Services
{
	public class ProductsServices : IProductsServices
	{
        private readonly AppDbContext dbContext;
		public ProductsServices()
		{
            dbContext = new AppDbContext();
		}

        public bool AddProducts(Products product)
        {
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
            return true;
        }

        public bool DeleteProductsFromID(int productID)
        {
            var productOld = dbContext.Products.FirstOrDefault(x => x.productID == productID);
            if (productOld != null)
            {
                dbContext.RemoveRange(productOld);
                dbContext.SaveChanges();
                return true;
            }
            else { return false; }
        }

        public IEnumerable<Products> GetProducts()
        {
            var kq = dbContext.Products.Include(x=>x.Properties).ThenInclude(x=>x.PropertyDetails).ToList();
            return kq;
        }

        public bool UpdateProducts(Products product)
        {
            var productOld = dbContext.Products.FirstOrDefault(x => x.productID == product.productID);
            if (productOld != null)
            {
                productOld.productCode = product.productCode;
                productOld.quantity = product.quantity;
                productOld.productName = product.productName;
                productOld.productShowName = product.productShowName;
                dbContext.Update(productOld);
                dbContext.SaveChanges();
                return true;
            }
            else { return false; }
        }
    }
}

