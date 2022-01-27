using BlueFlamePizza.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlueFlamePizza.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlueFlamePizza.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        

        private BlueFlamePizzaDBContext _context;

        public CartItemsController(BlueFlamePizzaDBContext context)
        {
            _context = context;
        }

        // GET: api/<CartItemsController>
        [HttpGet]
        public IEnumerable<CartItem> Get()
        {
            return _context.CartItem.ToList();
        }

        // GET api/<CartItemsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CartItemsController>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public void Post([FromBody] CartItemAPIModel model)
        {
            //consolidating multiple items if user clicks add multiple times is a current problem
            //
            //

            var product_id = Convert.ToInt32(model.product_id_str);
            var cart_id = Convert.ToInt32(model.cart_id_str);
            var quantity = Convert.ToInt16(model.quantity_str);

            var cartItemCount = _context.CartItem.Count();
            var cartItemProduct = _context.Product.SingleOrDefault(x => x.ProductId == product_id);
            var cartItemActiveCheck = _context.CartItem.Where(c => c.CartId == cart_id).SingleOrDefault(x => x.ProductId == product_id);

            CartItem cartItem = new CartItem();

            //cart item is not currently active in the cart
            if (cartItemActiveCheck == null || cartItemActiveCheck.CartItemActive != 1)
            {
                cartItem.CartItemId = cartItemCount + 1;
                cartItem.ProductId = product_id;
                cartItem.CartId = cart_id;
                cartItem.CartItemPrice = cartItemProduct.ProductPrice;
                cartItem.CartItemQuantity = quantity;
                cartItem.CartItemCreatedAt = DateTime.Now;
                cartItem.CartItemActive = 1;
                cartItem.CartItemSku = cartItemProduct.ProductSku;
                cartItem.CartItemContent = cartItemProduct.ProductContent;


                _context.CartItem.Add(cartItem);
                _context.SaveChanges();
            }
            else
            {
                //else cart item is already active with value of 1
                cartItem = cartItemActiveCheck;
                cartItem.CartItemQuantity += quantity;
                cartItem.CartItemUpdatedAt = DateTime.Now;

                _context.SaveChanges();
            }
        }

        // PUT api/<CartItemsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CartItemsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
