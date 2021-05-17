using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HI_LAB2.Models
{
	public class EFProductRepository : IProductRepository
	{
		private ProductContext context;
		public EFProductRepository(ProductContext con)
		{
			context = con;
		}

		public IEnumerable<Product> Products => context.Products;

		public Product AddProduct(Product product)
		{
			context.Products.Add(product);
			context.SaveChanges();
			return product;	
		}

		public void DeleteProduct(int id)
		{
			Product product = context.Products.Where(p => p.ProductId == id).FirstOrDefault();
			if (product != null)
			{
				context.Products.Remove(product);
				context.SaveChanges();
			}
		}

		public Product UpdateProduct(Product product)
		{
			Product prod = context.Products.Where(p => p.ProductId == product.ProductId).FirstOrDefault();
			prod.ProductName = product.ProductName;
			prod.Price = product.Price;
			prod.CategoryId = product.CategoryId;
			context.SaveChanges();
			return product;
		}

		public void SaveContextChanges()
		{
			context.SaveChanges();
		}
	}
}
