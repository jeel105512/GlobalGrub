﻿using GlobalGrub.Data;
using GlobalGrub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace GlobalGrub.Controllers
{
    public class ShopController : Controller
    {
        // add DbContext to use the database
        private readonly ApplicationDbContext _context;

        // constructor
        public ShopController(ApplicationDbContext context)
        {
            _context = context; // assign incoming db connection so we can use it in any method in this controller
        }

        public IActionResult Index()
        {
            // use Categories DbSet to fetch the list of Categories to display to shoppers
            var categories = _context.Categories.OrderBy(c => c.Name).ToList();
            return View(categories);
        }

        // GET: /Shop/ShopByCategory/5
        public IActionResult ShopByCategory(int id)
        {
            //get products in selected category
            var products = _context.Products.Where(p => p.CategoryId == id).OrderBy(p => p.Name).ToList();
            
            //get the name of selected category for display in page heading
            var category = _context.Categories.Find(id);
            ViewBag.Category = category.Name;

            return View(products);
        }

        // POST: /Shop/AddToCart
        [HttpPost]
        public IActionResult AddToCart(int ProductId, int Quantity)
        {
            // look up the price:
            var product = _context.Products.Find(ProductId);
            var price = product.Price;

            // set UserId of cart item
            var userId = GetUserId();

            // check if item already in user's cart. if so, update quantity insted
            var cartItem = _context.CartItems.SingleOrDefault(c => c.ProductId == ProductId && c.UserId == userId);

            if (cartItem != null)
            {
                cartItem.Quantity += Quantity;
                _context.CartItems.Update(cartItem);
            }
            else
            {
                // insert
                cartItem = new CartItem
                {
                    ProductId = ProductId,
                    Quantity = Quantity,
                    Price = (double)price,
                    UserId = userId
                };

                // save to CartItems table in db
                _context.CartItems.Add(cartItem);
            }

            _context.SaveChanges();

            // load cart page
            return RedirectToAction("Cart");
        }

        private string GetUserId()
        {
            // check session or an existing UserId for this user's cart
            if(HttpContext.Session.GetString("UserId") == null)
            {
                // this is users first cart item
                var userId = "";
                if (User.Identity.IsAuthenticated)
                {
                    // user j\had logged in; use email
                    userId = User.Identity.Name; // user's email address
                }
                else
                {
                    // user anonymous. generate unique identifier
                    userId = Guid.NewGuid().ToString();
                    // or using this: userId = HttpContext.Session.Id;
                }

                // store userId in a session var
                HttpContext.Session.SetString("UserId", userId);
            }

            return HttpContext.Session.GetString("UserId");
        }

        // GET: /Shop/Cart
        public IActionResult Cart()
        {
            // identify the user from the session var
            var userId = HttpContext.Session.GetString("UserId");

            // load the cart items from the user from the db for display
            var cartItems = _context.CartItems
                .Include(c => c.Product) // join statement to get the product
                .Where(c => c.UserId == userId).ToList();

            return View(cartItems);
        }

        // GET: /Shop/RemoveFromCart/5
        public IActionResult RemoveFromCart(int id) { 
            var cartItem = _context.CartItems.Find(id);
            _context.CartItems.Remove(cartItem);
            _context.SaveChanges();
            return RedirectToAction("Cart");

        }

        // GET: /Shop/Checkout
        [Authorize]
        public IActionResult Checkout()
        {
            return View();
        }

        // POST: /Shop/Checkout
        [Authorize]
        [HttpPost]
        public IActionResult Checkout([Bind("FirtName", "LastName", "Address", "City", "Province", "PostalCode", "Phone")] Order order)
        {
            // auto-fill total, date, user
            order.OrderDate = DateTime.Now;
            order.UserId = User.Identity.Name;
            //order.Total = (from c in _context.CartItems
            //               where c.UserId == order.UserId
            //               select c.Quantity * c.Price).Sum();
            // save order to session so we can keep it in memory for saving once payment gets completed
            // using SessionExtensions 3rd party library fo this
            HttpContext.Session.SetObject("Order", order);
            return RedirectToAction("Payment");
        }
    }
}
