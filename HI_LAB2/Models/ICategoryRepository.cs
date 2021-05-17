using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HI_LAB2.Models
{
	public interface ICategoryRepository
	{
		IEnumerable<Category> Categories { get; }
		Category AddCategory(Category category);
		Category UpdateCategory(Category category);
		void DeleteCategory(int id);
		void SaveContextChanges();
	}
}
