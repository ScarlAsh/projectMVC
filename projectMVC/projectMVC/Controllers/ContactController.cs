using Microsoft.AspNetCore.Mvc;
using projectMVC.Generic_Repository.Interfaces;
using projectMVC.Generic_Repository.Services;
using projectMVC.Models;

namespace projectMVC.Controllers
{
    public class ContactController : Controller
    {
        private IGenericRepository<Contact> _genericRepository;

        public ContactController(IGenericRepository<Contact> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(Contact C)
        {
            if(ModelState.IsValid)
            {
                _genericRepository.Create(C);
                return RedirectToAction("Contact");
            }
            return View(C);
        }
    }
}
