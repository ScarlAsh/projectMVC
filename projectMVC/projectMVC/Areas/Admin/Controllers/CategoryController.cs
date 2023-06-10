using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projectMVC.Generic_Repository.Interfaces;
using projectMVC.Models;

namespace projectMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private IGenericRepository<Category> _genericRepository;

        public CategoryController(IGenericRepository<Category> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        //Index//////////////////////
        public IActionResult Index()
        {
            var data = _genericRepository.GetAll().ToList();
            return View(data);
        }

        //Create//////////////////////
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category C)
        {
            var data = _genericRepository.Create(C);
            return RedirectToAction("Index");
        }

        //Edit//////////////////////

        public IActionResult Edit(int id)
        {
            var category = _genericRepository.GetById(id);  
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category C , int Id)
        {
            //var x = _genericRepository.GetById(Id);
            //x.Name = C.Name;
            var data = _genericRepository.Update(C);
            return RedirectToAction("Index");
        }

        //Delete//////////////////////
        public IActionResult Delete(int id)
        {
            var category = _genericRepository.GetById(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Category C)
        {
            var category = _genericRepository.Delete(C);
            return RedirectToAction("Index");
        }

        //Details//////////////////////

        public IActionResult Details(int id)
        {
            var category = _genericRepository.GetById(id);
            return View(category);
        }

    }
}
