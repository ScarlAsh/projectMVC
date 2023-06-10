using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projectMVC.Generic_Repository.Interfaces;
using projectMVC.Models;

namespace projectMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BrandController : Controller
    {
        

        private IGenericRepository<Brand> _genericRepository;

        public BrandController(IGenericRepository<Brand> genericRepository)
        {
            _genericRepository = genericRepository;
        }

       
        public IActionResult Index()
        {
            var data = _genericRepository.GetAll().ToList();
            return View(data);
        }

       
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Brand b)
        {
            var data = _genericRepository.Create(b);
            return RedirectToAction("Index");
        }

        

        public IActionResult Edit(int id)
        {
            var Brand = _genericRepository.GetById(id);
            return View(Brand);
        }

        [HttpPost]
        public IActionResult Edit(Brand b, int Id)
        {
            
            var data = _genericRepository.Update(b);
            return RedirectToAction("Index");
        }

        
        public IActionResult Delete(int id)
        {
            var brand = _genericRepository.GetById(id);
            return View(brand);
        }

        [HttpPost]
        public IActionResult Delete(Brand b)
        {
            var brand = _genericRepository.Delete(b);
            return RedirectToAction("Index");
        }

       

        public IActionResult Details(int id)
        {
            var brand = _genericRepository.GetById(id);
            return View(brand);
        }

    }
}
