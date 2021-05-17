using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HI_LAB2.Models
{
	public interface IProductRepository
	{
		IEnumerable<Product> Products { get; }
		Product AddProduct(Product product);
		Product UpdateProduct(Product product);
		void SaveContextChanges();
		void DeleteProduct(int id);
	}
}
