using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlueFlamePizza.Models;
using BlueFlamePizza.DTOs;
using BlueFlamePizza.ViewModels;
using System.Data.Entity;
using Microsoft.AspNetCore.Http;

namespace BlueFlamePizza.Controllers
{
    public class CartController : Controller
    {
        private BlueFlamePizzaDBContext _context;

        public CartController(BlueFlamePizzaDBContext context)
        {
            _context = context;
        }

        public IActionResult Index(string cart_id)
        {
            CartViewModel mymodel = new CartViewModel();
            //var cartItemList = _context.CartItem.Where(c => c.CartId == long.Parse(cart_id)).ToList();
            var cartItemList = _context.CartItem.Include(x => x.Product).Where(c => c.CartId == long.Parse(cart_id)).ToList();
            if (cartItemList != null)
            {
                mymodel.CartItems = cartItemList;
                
            }
            mymodel.cart_id = cart_id;
            mymodel.Products = _context.Product.ToList();

            return View(mymodel);
        }

        [HttpPost]
        public IActionResult Cart_Submit(string cart_id)
        {
            //problem will show now for returning user back to creating an order

            
            //order doesn't exist
            if (_context.Order.SingleOrDefault(c => c.OrderSessionId == HttpContext.Session.GetString("currentSession")) == null)
            {
                //Create Order
                Order newOrder = new Order
                {
                    OrderId = _context.Order.Count() + 1,
                    OrderSessionId = HttpContext.Session.GetString("currentSession"),
                    OrderStatus = "new",
                    OrderSubtotal = 0,
                    OrderTax = 0,
                    OrderGrandTotal = 0,
                    OrderCreatedAt = DateTime.Now,
                };
                _context.Order.Add(newOrder);
                _context.SaveChanges();

                List<OrderItem> orderItemList = new List<OrderItem>();
                List<CartItem> cartItems = _context.CartItem.Where(c => c.CartId == Convert.ToInt32(cart_id)).ToList();

                //Create OrderItems for Order
                foreach (var item in cartItems)
                {
                    OrderItem newItem = new OrderItem
                    {
                        OrderItemId = _context.OrderItem.Count() + 1,
                        ProductId = item.ProductId,
                        OrderId = newOrder.OrderId,
                        OrderItemPrice = item.CartItemPrice,
                        OrderItemQuantity = item.CartItemQuantity,
                        OrderItemCreatedAt = DateTime.Now,
                        OrderItemSku = item.CartItemSku
                    };
                    _context.OrderItem.Add(newItem);
                    _context.SaveChanges();

                    orderItemList.Add(newItem);
                }

                OrderViewModel OrderVm = new OrderViewModel
                {
                    Orders = newOrder,
                    OrderItems = orderItemList
                };

                return RedirectToAction("Index", "Order", OrderVm);
            }
            else //we already created order. Retrieve and return existing Order and OrderItems
            {
                Order newOrder = _context.Order.SingleOrDefault(c => c.OrderSessionId == HttpContext.Session.GetString("currentSession"));
                List<OrderItem> orderItemList = _context.OrderItem.Where(c => c.OrderId == newOrder.OrderId).ToList();

                OrderViewModel OrderVm = new OrderViewModel
                {
                    Orders = newOrder,
                    OrderItems = orderItemList
                };

                return RedirectToAction("Index", "Order", OrderVm);
            }
        }
    }
}
