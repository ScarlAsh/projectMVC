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
    public class CartItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Cart()
        {
            var result = _context.CartItems.Where(c => c.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Include(p => p.Product).ToList();
            var subTotal = _context.CartItems.Where(c => c.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(p => p.Product.Price * p.Quantity).Sum();
            ViewBag.subTotal = subTotal;
            return View(result);
        }
        public IActionResult _UpdateBill(int quantity, int id=0,int shippingMethod=0)
        {
            if (id > 0)
            {
                var cartItem = _context.CartItems.FirstOrDefault(c => c.Id == id && c.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier));
                cartItem.Quantity = quantity;
                _context.CartItems.Update(cartItem);
                _context.SaveChanges();
            }
            var Total = _context.CartItems.Where(c => c.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(p => p.Product.Price * p.Quantity).Sum()+ shippingMethod;
            ViewBag.Total = Total;
            var result = _context.CartItems.Where(c => c.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Include(p => p.Product).ToList();
            var subTotal = _context.CartItems.Where(c => c.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(p => p.Product.Price * p.Quantity).Sum();
            ViewBag.subTotal = subTotal;

            return View(result);
        }
        [HttpPost]
        public IActionResult AddToCart(CartItem model)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == model.ProductId);
            var cart = new CartItem()
            {
                ProductId = product.Id,
                Quantity = model.Quantity

            };
            //u=>u.UserId==User.Identity.Name
            var shopCart = _context.CartItems.FirstOrDefault(u => u.ProductId == model.ProductId);
            if (model.Quantity <= 0)
            {
                model.Quantity = 1;
            }
            if (shopCart == null)
            {
                _context.CartItems.Add(cart);
            }
            else
            {
                shopCart.Quantity += model.Quantity;

            }
            _context.SaveChanges();
            return RedirectToAction("Cart");
        }


        public IActionResult _AddToCart(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            var shopCart = _context.CartItems.FirstOrDefault(u => u.ProductId == id && u.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (shopCart is null)
            {
                _context.CartItems.Add(new CartItem
                {
                    ProductId = product.Id,
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    Quantity = 1
                });
            }
            else
            {
                shopCart.Quantity++;
                _context.CartItems.Update(shopCart);
            }
            _context.SaveChanges();
            var cartCount = _context.CartItems.Where(c => c.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Count();

            return View(cartCount);
        }

        private bool CartItemExists(int id)
        {
            return _context.CartItems.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CartItems == null)
            {
                return NotFound();
            }

            var cartItem = await _context.CartItems
                .Include(c => c.Product)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cartItem == null)
            {
                return NotFound();
            }
            else
            {
				_context.CartItems.Remove(cartItem);
				await _context.SaveChangesAsync();
			}

            return RedirectToAction("Cart");
        }
    }
}