using HI_LAB2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HI_LAB2.Controllers.APIController
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private ICategoryRepository categoryRepo;

		public CategoryController(ICategoryRepository categoryService)
		{
			categoryRepo = categoryService;
		}

		[HttpGet]
		public IEnumerable<Category> Get() => categoryRepo.Categories;

		[HttpGet("{id}")]
		public ActionResult<Category> Get(int id)
		{
			if (id == 0)
			{
				return BadRequest("Value must be passed in the request body");
			}
			return Ok(categoryRepo.Categories.FirstOrDefault(c => c.CategoryId == id));
		}

		[HttpPost]
		public Category Post([FromBody] Category categoryPost) =>
			categoryRepo.AddCategory(new Category
			{
				CategoryId = categoryPost.CategoryId,
				CategoryName = categoryPost.CategoryName
			});

		[HttpPut]
		public Category Put([FromBody] Category catePut) =>
			categoryRepo.UpdateCategory(catePut);

		[HttpPatch("{id}")]
		public StatusCodeResult Patch(int id, [FromBody] JsonPatchDocument<Category> catePatch)
		{
			var cate = categoryRepo.Categories.FirstOrDefault(c => c.CategoryId == id);

			if (cate != null)
			{
				catePatch.ApplyTo(cate);
				categoryRepo.SaveContextChanges();
				return Ok();
			}
			return NotFound();
		}

		[HttpDelete("{id}")]
		public void Delete(int id) => categoryRepo.DeleteCategory(id);
	}
}
