using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlueFlamePizza.Models;
using BlueFlamePizza.DTOs;
using BlueFlamePizza.ViewModels;
using System.Data.Entity;
using System.Dynamic;

namespace BlueFlamePizza.Controllers
{
    public class ProductController : Controller
    {
        private BlueFlamePizzaDBContext _context;

        public ProductController(BlueFlamePizzaDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //dynamic mymodel = new ExpandoObject();
            ProductViewModel mymodel = new ProductViewModel();

            var productList = _context.Product.ToList();
            var categoryList = _context.Category.ToList();
            mymodel.Products = productList;
            mymodel.Categories = categoryList;

            Cart currentUserCart = new Cart();
            Cart cart = new Cart();
            
            
            // may need to figure a solution for "postback" on creating a new session?
            if (HttpContext.Session.GetString("currentSession") == null)
            {
                HttpContext.Session.Clear();
                HttpContext.Session.SetString("currentSession", HttpContext.Session.Id);
            }

            var currentSession = HttpContext.Session.GetString("currentSession");
            var currentSessionCart = _context.Cart.SingleOrDefault(c => c.CartSessionId == currentSession);

            ViewBag.currentSession = currentSession;

            //find value to display for cartitem count
            int qtyCount = 0;
            ViewBag.CartItemCount = qtyCount;


            // will return a list of carts that belong to the current session and haven't been completed yet
            // Should never have more than one cart with same session that are incomplete...inherently will complete a cart before creating another in same session
            var recentSessionCart = _context.Cart.Where(c => c.CartSessionId == currentSession).OrderByDescending(c => c.CartCreatedAt).ToList();

            //
            // CREATING A CART
            //

            //no Carts exist in DB
            if (_context.Cart.Count() == 0)
            {
                if (User.Identity.IsAuthenticated)
                {
                    var currUser = _context.User.SingleOrDefault(c => c.UserEmail == User.Identity.Name);
                    var currUserId = currUser.UserId;
                    cart.UserId = currUserId;
                }
                cart.CartId = 1;
                cart.CartCreatedAt = DateTime.Now;
                cart.CartSessionId = currentSession;
                cart.CartStatus = "new";
                _context.Cart.Add(cart);
                _context.SaveChanges();

                mymodel.Cart = cart;

                return View(mymodel);
            }

            
            //User is returning in same session
            //If cartStatus is not complete then it is a current running cart and will just be sent as model
            if (currentSessionCart != null && recentSessionCart[0].CartStatus != "complete")
            {
                
                List<CartItem> currentSessionsCartItems = _context.CartItem.Where(c => c.CartId == currentSessionCart.CartId).ToList();
                if (currentSessionsCartItems != null)
                {
                    foreach (var item in currentSessionsCartItems)
                    {
                        qtyCount += item.CartItemQuantity;
                    }
                }
                ViewBag.CartItemCount = qtyCount;

                mymodel.Cart = currentSessionCart;
                ViewBag.currentCartId = currentSessionCart.CartId;
                return View(mymodel);
            }


            //the current session does not exist in any of the current carts in DB OR is a returning user that has completed a cart in the same session and wants to create another
            if (currentSessionCart == null)
            {
                //new cart doesn't exist for user yet
                //create new cart
                if (User.Identity.IsAuthenticated)
                {
                    var currUser = _context.User.SingleOrDefault(c => c.UserEmail == User.Identity.Name);
                    var currUserId = currUser.UserId;
                    cart.UserId = currUserId;
                    cart.CartEmail = User.Identity.Name;
                }
                cart.CartId = _context.Cart.Count() + 1;
                cart.CartCreatedAt = DateTime.Now;
                cart.CartUpdatedAt = DateTime.Now;
                cart.CartSessionId = currentSession;
                cart.CartStatus = "new";

                _context.Cart.Add(cart);
                _context.SaveChanges();

                mymodel.Cart = cart;
                ViewBag.currentCartId = cart.CartId;

                return View(mymodel);
            }

            return View(mymodel);
        }
    
       
    }
}
