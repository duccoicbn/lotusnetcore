using System;
using WebAPI_Final.Entities;

namespace WebAPI_Final.IServices
{
	public interface IPropertiesServices
	{
		bool AddProperties(int productID, Properties property);
	}
}

