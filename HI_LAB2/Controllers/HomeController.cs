using HI_LAB2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HI_LAB2.Controllers
{
	public class HomeController : Controller
	{
		private ICategoryRepository categoryRepository;
		private IProductRepository productRepository;

		public IActionResult Index()
		{
			return View();
		}

		public HomeController(IProductRepository productRepo, ICategoryRepository categoryRepo)
		{
			productRepository = productRepo;
			categoryRepository = categoryRepo;
		}

		public IActionResult ShowProduct()
		{
			return View(productRepository.Products);
		}

		public IActionResult ShowCategory()
		{
			return View(categoryRepository.Categories);
		}

		[HttpPost]
		public IActionResult AddCategory(Category category)
		{
			categoryRepository.AddCategory(category);
			return RedirectToAction("ShowCategory");
		}

		
		[HttpPost]
		public IActionResult AddProduct(Product product)
		{
			productRepository.AddProduct(product);
			return RedirectToAction("ShowProduct");
		}
	}
}
