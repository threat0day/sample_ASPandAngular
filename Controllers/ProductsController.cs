﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using test2Metanit.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace test2Metanit.Controllers
{
	[Route("api/products")]
	public class ProductController : Controller
	{
		ApplicationContext db;
		public ProductController(ApplicationContext context)
		{
			db = context;
			if (!db.Products.Any())
			{
				db.Products.Add(new Product { Name = "iPhone X", Company = "Apple", Price = 79900 });
				db.Products.Add(new Product { Name = "Galaxy S8", Company = "Samsung", Price = 49900 });
				db.Products.Add(new Product { Name = "Pixel 2", Company = "Google", Price = 52900 });
				db.SaveChanges();
			}
		}
		[HttpGet]
		public IEnumerable<Product> Get()
		{
			return db.Products.ToList();
		}

		[HttpGet("{id}")]
		public Product Get(int id)
		{
			Product product = db.Products.FirstOrDefault(x => x.Id == id);
			return product;
		}

		[HttpPost]
		public IActionResult Post([FromBody]Product product)
		{
			if (ModelState.IsValid)
			{
				db.Products.Add(product);
				db.SaveChanges();
				return Ok(product);
			}
			return BadRequest(ModelState);
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody]Product product)
		{
			if (ModelState.IsValid)
			{
				db.Update(product);
				db.SaveChanges();
				return Ok(product);
			}
			return BadRequest(ModelState);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			Product product = db.Products.FirstOrDefault(x => x.Id == id);
			if (product != null)
			{
				db.Products.Remove(product);
				db.SaveChanges();
			}
			return Ok(product);
		}

	}
}
