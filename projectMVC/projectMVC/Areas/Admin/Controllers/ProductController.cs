using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using projectMVC.Enums;
using projectMVC.Generic_Repository.Interfaces;
using projectMVC.Models;
using X.PagedList.Mvc;
using X.PagedList;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Authorization;
using projectMVC.ViewModels;


namespace projectMVC.Areas.Admin.Controllers

{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;
        private IGenericRepository<Product> _genericRepository;

        public ProductController(IGenericRepository<Product> genericRepository, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _genericRepository = genericRepository;
            this.hostingEnvironment = hostingEnvironment;
        }


        public IActionResult Index( int? page )
        {
            var data = _genericRepository.GetAll().ToList().ToPagedList(page ?? 1, 3);

                foreach (var item in data)
                {
                    ProductColors pc = (ProductColors)item.Color;
                    ViewBag.Title = pc.ToString();
                }
                return View(data);
           
        }

        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel model)
        {
            var product = new Product();
     

            if (model.Image1 != null)
            {
                string fileExtension1 = Path.GetExtension(model.Image1.FileName);
                string directory = Path.Combine(hostingEnvironment.WebRootPath, "assets", "images", "ourimages");
                if(!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                string File1 = Path.Combine(hostingEnvironment.WebRootPath, "assets", "images", "ourimages", model.Name.Replace(" ", "") + "1" + fileExtension1);
                if (!Directory.Exists(File1))
                {
                    model.Image1.CopyTo(new FileStream( File1 , FileMode.Create));
                    product.Images.Add(new Image { ImageUrl = model.Name.Replace(" ", "") + "1" + fileExtension1 });
                }



            }

            if (model.Image2 != null)
            {
                string fileExtension2 = Path.GetExtension(model.Image2.FileName);
                string directory = Path.Combine(hostingEnvironment.WebRootPath, "assets", "images", "ourimages");
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                string File2 = Path.Combine(hostingEnvironment.WebRootPath, "assets", "images", "ourimages", model.Name.Replace(" ", "") + "2" + fileExtension2);
                if (!Directory.Exists(File2))
                {
                    model.Image2.CopyTo(new FileStream(File2, FileMode.Create));

                    product.Images.Add(new Image { ImageUrl = model.Name.Replace(" ", "") + "2" + fileExtension2 });
                }

            }

            if (model.Image3 != null)
            {
                string fileExtension3 = Path.GetExtension(model.Image3.FileName);
                string directory = Path.Combine(hostingEnvironment.WebRootPath, "assets", "images", "ourimages");
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                string File3 = Path.Combine(hostingEnvironment.WebRootPath, "assets", "images", "ourimages", model.Name.Replace(" ", "") + "3" + fileExtension3);
                if (!Directory.Exists(File3))
                {
                    model.Image3.CopyTo(new FileStream(File3, FileMode.Create));
                    product.Images.Add(new Image { ImageUrl = model.Name.Replace(" ", "") + "3" + fileExtension3 });
                }

            }

            if (model.Image4 != null)
            {
                string fileExtension4 = Path.GetExtension(model.Image1.FileName);
                string directory = Path.Combine(hostingEnvironment.WebRootPath, "assets", "images", "ourimages");
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                string File4 = Path.Combine(hostingEnvironment.WebRootPath, "assets", "images", "ourimages", model.Name.Replace(" ", "") + "4" + fileExtension4);
                if (!Directory.Exists(File4))
                {
                    model.Image4.CopyTo(new FileStream(File4, FileMode.Create));
                    product.Images.Add(new Image { ImageUrl = model.Name.Replace(" ", "") + "4" + fileExtension4 });
                }

            }

            product.Name = model.Name;
            product.Price = model.Price;
            product.Description = model.Description;
            product.BrandId = model.BrandId;
            product.CategoryId = model.CategoryId;
            product.UnitsInStock = model.UnitsInStock;
            product.RealseDate = model.RealseDate;

            foreach(var info in model.info)
            {
                product.ProductInfos.Add(new ProductInfo { Info = info });

            }





            _genericRepository.Create(product);
            return RedirectToAction("Index");
        }


        //Edit//

        public IActionResult Edit(int id)
        {
            var product = _genericRepository.GetById(id);
            ProductColors pc = (ProductColors)product.Color;
            ViewBag.Title = pc.ToString();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product p, int Id)
        {
            var product = _genericRepository.Update(p);
           
            return RedirectToAction("Index");
        }

        
        public IActionResult Delete(int id)
        {
            var product = _genericRepository.GetById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Product p)
        {
            var product = _genericRepository.Delete(p);
            return RedirectToAction("Index");
        }

        
        public IActionResult Details(int id)
        {
            var product = _genericRepository.GetById(id);
                ProductColors pc = (ProductColors)product.Color;
                ViewBag.Title = pc.ToString();
           
            return View(product);
        }

		public ActionResult _Search(string query , int? page )
		{
            IPagedList<Product> products;
            ViewBag.query = query;
            var data = _genericRepository.GetAll().ToList();
            if (!string.IsNullOrEmpty(query))
            {
                 products = data.Where(p => p.Name.Contains(query)).ToPagedList(page ?? 1, 3);
            }
            else
                products = data.ToPagedList();

            return View(products);
		}



	}
}
