using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projectMVC.Data;
using projectMVC.Enums;
using projectMVC.Models;

namespace projectMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

       

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            ProductColors pc = (ProductColors)product.Color;
            ViewBag.Title = pc.ToString();
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.WishlistHeart = _context.WishListItems.Where(w => w.ProductId == id.Value && w.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();

           
            ViewBag.CategoryRelated = _context.Products.Where(c => c.CategoryId == product.CategoryId).Take(10).ToList();
            ViewBag.RelatedProducts = _context.Products.Where(p => p.BrandId == product.BrandId).Take(5).ToList();

            return View(product);
        }


        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
