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
	public class ProductController : ControllerBase
	{
		private IProductRepository productRepo;

		public ProductController(IProductRepository productService)
		{
			productRepo = productService;
		}

		[HttpGet]
		public IEnumerable<Product> Get() => productRepo.Products;

		[HttpGet("{id}")]
		public ActionResult<Product> Get(int id)
		{
			if (id == 0)
			{
				return BadRequest("Value must be passed in the request body");
			}
			return Ok(productRepo.Products.FirstOrDefault(p => p.ProductId == id));
		}

		[HttpPost]
		public Product Post([FromBody] Product productPost) =>
			productRepo.AddProduct(new Product
			{
				ProductId = productPost.ProductId,
				ProductName = productPost.ProductName,
				Price = productPost.Price,
				CategoryId = productPost.CategoryId
			});

		[HttpPut]
		public Product Put([FromBody] Product prodPut) =>
			productRepo.UpdateProduct(prodPut);

		[HttpPatch("{id}")]
		public StatusCodeResult Patch(int id, [FromBody] JsonPatchDocument<Product> prodPatch)
		{

			var prod = productRepo.Products.FirstOrDefault(p => p.ProductId == id);

			if (prod != null)
			{
				prodPatch.ApplyTo(prod);
				productRepo.SaveContextChanges();
				return Ok();
			}
			return NotFound();
		}

		[HttpDelete("{id}")]
		public void Delete(int id) => productRepo.DeleteProduct(id);
	}
}
