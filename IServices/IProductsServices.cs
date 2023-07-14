using System;
using WebAPI_Final.Entities;

namespace WebAPI_Final.IServices
{
	public interface IProductsServices
	{
		bool AddProducts(Products product);
		IEnumerable<Products> GetProducts();
        bool UpdateProducts(Products product);
        bool DeleteProductsFromID(int productID);
    }
}

