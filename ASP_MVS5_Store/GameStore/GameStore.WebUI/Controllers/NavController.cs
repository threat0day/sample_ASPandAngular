﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GameStore.Domain.Abstract;

namespace GameStore.WebUI.Controllers
{
	public class NavController : Controller
	{
		private IGameRepository repository;

		public NavController(IGameRepository repo)
		{
			repository = repo;
		}

		//public PartialViewResult Menu()
		//{
		//	IEnumerable<string> categories = repository.Games
		//		.Select(game => game.Category)
		//		.Distinct()
		//		.OrderBy(x => x);
		//	return PartialView(categories);
		//}
		//public PartialViewResult Menu(string category = null, bool horizontalNav = false)
		//{
		//	ViewBag.SelectedCategory = category;

		//	IEnumerable<string> categories = repository.Games
		//		.Select(game => game.Category)
		//		.Distinct()
		//		.OrderBy(x => x);

		//	string viewName = horizontalNav ? "MenuHorizontal" : "Menu";
		//	return PartialView(viewName, categories);
		//}
		public PartialViewResult Menu(string category = null)
		{
			ViewBag.SelectedCategory = category;

			IEnumerable<string> categories = repository.Games
				.Select(game => game.Category)
				.Distinct()
				.OrderBy(x => x);

			return PartialView("FlexMenu", categories);
		}
	}
}