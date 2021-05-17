using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HI_LAB2.Models
{
	public class InitialData
	{
		public static void EnsurePopulated(IApplicationBuilder app)
		{
			ProductContext context = app.ApplicationServices
											.CreateScope().ServiceProvider
											.GetRequiredService<ProductContext>();
			if (context.Database.GetPendingMigrations().Any())
			{
				//context.Database.Migrate();
			}

			if (!context.Categories.Any())
			{
				context.Categories.AddRange(
					new Category
					{
						CategoryName = "Beverages",
					},
					new Category
					{
						CategoryName = "Meats",
					});
				context.SaveChanges();
			}

			if (!context.Products.Any())
			{
				context.Products.AddRange(
					new Product
					{
						ProductName = "Milk",
						Price = 5,
						CategoryId = 1
					},
					new Product
					{
						ProductName = "Water",
						Price = 2,
						CategoryId = 1
					},
					new Product
					{
						ProductName = "Coke",
						Price = 3,
						CategoryId = 1
					},
					new Product
					{
						ProductName = "Chicken",
						Price = 15,
						CategoryId = 2
					},
					new Product
					{
						ProductName = "Beef",
						Price = 20,
						CategoryId = 2
					});
				context.SaveChanges();

			}
		}
	}
}
