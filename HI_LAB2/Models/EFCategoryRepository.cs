using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HI_LAB2.Models
{
	public class EFCategoryRepository : ICategoryRepository
	{
		private ProductContext context;
		public EFCategoryRepository(ProductContext con)
		{
			context = con;
		}

		public IEnumerable<Category> Categories => context.Categories;

		public Category AddCategory(Category category)
		{
			context.Categories.Add(category);
			context.SaveChanges();
			return category;
		}

		public void DeleteCategory(int id)
		{
			Category category = context.Categories.Where(c => c.CategoryId == id).FirstOrDefault();
			if (category != null)
			{
				context.Categories.Remove(category);
				context.SaveChanges();
			}
		}

		public Category UpdateCategory(Category category)
		{
			Category cate = context.Categories.Where(c => c.CategoryId == category.CategoryId).FirstOrDefault();
			cate.CategoryName = category.CategoryName;
			context.SaveChanges();
			return category;
		}

		public void SaveContextChanges()
		{
			context.SaveChanges();
		}
	}
}
