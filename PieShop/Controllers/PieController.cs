﻿using Microsoft.AspNetCore.Mvc;
using PieShop.Models;
using PieShop.ViewModels;

namespace PieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        //public ActionResult List()
        //{
        //    PieListViewModel pieListViewModel = new PieListViewModel(_pieRepository.AllPies, "All pies");
        //    return View(pieListViewModel);
        //}

        public ViewResult List(string category)
        {
            IEnumerable<Pie> pies;
            string? currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                pies = _pieRepository.AllPies.OrderBy(p => p.PieId);
                currentCategory = "All pies";
            }
            else
            {
                pies = _pieRepository.AllPies.Where(p => p.Category.CategoryName == category).OrderBy(p=> p.PieId);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c=> c.CategoryName == category)?.CategoryName;
            }

            return View(new PieListViewModel(pies,currentCategory));
        }

        public ActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);

            if (pie == null) return NotFound();

            return View(pie);
                   
        }
    }
}
