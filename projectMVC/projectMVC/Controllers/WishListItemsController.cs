using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projectMVC.Data;
using projectMVC.Models;

namespace projectMVC.Controllers
{
    [Authorize]
    public class WishListItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WishListItemsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(WishListItem model)
        {
            var items = _context.WishListItems.Where(w => w.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();
            return View(items);
        }




        public IActionResult AddToWishList(WishListItem model)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == model.ProductId);
            if (!_context.WishListItems.Any(c => c.ProductId == product.Id && c.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                var wishlist = new WishListItem()
                {
                    ProductId = product.Id,
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                };

                _context.WishListItems.Add(wishlist);
            }
            else
            {
                var wishListItem = _context.WishListItems.FirstOrDefault(w => w.ProductId == product.Id && w.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier));
                _context.WishListItems.Remove(wishListItem);


            }

            _context.SaveChanges();

            return RedirectToAction("Details", "Products", new { id = product.Id });
        }


        public IActionResult _AddToWishList(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            var shopWishList = _context.WishListItems.FirstOrDefault(u => u.ProductId == id && u.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (shopWishList is null)
            {
                _context.WishListItems.Add(new WishListItem
                {
                    ProductId = product.Id,
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                });
            }
          
            _context.SaveChanges();
            var wishListCount = _context.WishListItems.Where(c => c.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Count();

            return View(wishListCount);
        }

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id == null || _context.WishListItems == null)
            {
                return NotFound();
            }

            var WishListItem = await _context.WishListItems
                .Include(c => c.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (WishListItem == null)
            {
                return NotFound();
            }
            else
            {
                _context.WishListItems.Remove(WishListItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");

        }
        private bool WishListItemExists(int id)
        {
            return _context.WishListItems.Any(e => e.Id == id);
        }
    }
}
