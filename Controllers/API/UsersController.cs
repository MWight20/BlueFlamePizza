using BlueFlamePizza.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BlueFlamePizza.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly BlueFlamePizzaDBContext _context;

        public UsersController(BlueFlamePizzaDBContext context)
        {
            _context = context;
        }
        
        // GET: api/Users
        [HttpGet]

        public IEnumerable<User> GetUser()
        {
            var usersList = _context.User.ToList();
            var users = _context.User.Include(x => x.UserRole);
            return users.ToList();
        }
    }
}
