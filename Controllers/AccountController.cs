using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlueFlamePizza.Models;
using BlueFlamePizza.ViewModels;
using System.Net.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using BlueFlamePizza.DTOs;
using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;

namespace BlueFlamePizza.Controllers
{
    public class AccountController : Controller
    {
        private BlueFlamePizzaDBContext _context;

        public AccountController(BlueFlamePizzaDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.username = HttpContext.Session.GetString("username");
            return View();
        }


        //[AllowAnonymous]
        public async Task<IActionResult> Login(LoginUserDTO loginUserDTO)
        {

            //check model status
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Invalid login. Please enter email and corresponding password.";
                return View("Index");
            }

            //check for logged user
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            

            //check user credentials
            var userFormEmail = loginUserDTO.UserEmail;
            var userFormPassword = loginUserDTO.UserPassword;

            var UserDBQuery = _context.User.SingleOrDefault(x => x.UserEmail == userFormEmail);
            string UserRoleDBQuery;
            
            if (UserDBQuery == null)
            {
                ViewBag.Error = "Email does not exist...";
                return View("Index");
            }

            try
            {
                UserRoleDBQuery = _context.Role.SingleOrDefault(x => x.RoleId == UserDBQuery.UserId).RoleName;
            }
            catch (InvalidOperationException)
            {
                ViewBag.Error = "Email does not exist...";
                return View("Index");
            }

            if (UserDBQuery != null)
            {
                var UserDBPaswordHash = UserDBQuery.UserPasswordHash;
                bool verified = BCrypt.Net.BCrypt.Verify(userFormPassword, UserDBPaswordHash);

                ViewBag.verified = verified;


                if (verified == true)
                {

                    var username = UserDBQuery.UserEmail;
                    HttpContext.Session.SetString("username", username);

                    var rolename = UserRoleDBQuery;
                    HttpContext.Session.SetString("rolename", rolename);


                    var user = _context.User.ToList();


                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, UserDBQuery.UserId.ToString()));
                    identity.AddClaim(new Claim(ClaimTypes.Name, username));
                    identity.AddClaim(new Claim(ClaimTypes.Role, rolename));
                    var principal = new ClaimsPrincipal(identity);
                    var AuthProperties = new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        ExpiresUtc = DateTimeOffset.Now.AddDays(1),
                        IsPersistent = true,
                    };

                    await this.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(principal), AuthProperties);

                    return RedirectToAction("Index", "Product");

                }
                else
                {
                    ViewBag.Error = "Incorrect Email and Password combination";
                    return View("Index");
                }

            }

            ViewBag.Error = "Something went wrong...";
            return View("Index");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.Clear();
            HttpContext.Session.SetString("currentSession", null);
            ViewBag.message = "Logout successful!";
            return RedirectToAction("Index", "Account");
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Register(RegisterUserDTO RegisterUserDTO)
        {
            //checks for correct model state
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Please fill in all fields";
                return View("Register", null);
            }

            if (!EmailIsValid(RegisterUserDTO.UserEmail))
            {
                ViewBag.Error = "Email is in an incorrect format.";
                return View("Register", null);
            } 

            if (RegisterUserDTO.UserPassword != RegisterUserDTO.UserConfirmPassword)
            {
                ViewBag.Error = "Passwords do not match.";
                return View("Register", null);
            }

            var userCheck = _context.User.SingleOrDefault(m => m.UserEmail == RegisterUserDTO.UserEmail);
            if (userCheck != null)
            {
                ViewBag.Error = "This Email/Username already exists.";
                return View("Register", null);
            }

            

            //if (RegisterUserDTO.UserPhone != null)
            //{
            //    if (!PhoneIsValid(RegisterUserDTO.UserPhone))
            //    {
            //        ViewBag.Error = "Phone is in an incorrect format";
            //        return View("Register", null);
            //    }
            //}


            //User is new, lets create a user and register it to the database
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(RegisterUserDTO.UserPassword);
            var UserIDIndex = _context.User.Count() + 1;
            var newUser = new User
            {
                UserId = UserIDIndex,
                UserEmail = RegisterUserDTO.UserEmail,
                UserPasswordHash = passwordHash,
                //UserPasswordHint = RegisterUserDTO.UserPasswordHint,
                //UserFirstName = RegisterUserDTO.UserFirstName,
                //UserLastName = RegisterUserDTO.UserLastName,
                //UserPhone = RegisterUserDTO.UserPhone,
                UserRegisteredAt = DateTime.Now,
                UserRoleId = 2,
            };

            try
            {
                _context.User.Add(newUser);
            }
            catch (Exception)
            {
                ViewBag.Error = "Couldn't save new user.";
                return View("Register", null);
            }
            
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                ViewBag.Error = "Something went wrong...";
                return View("Register", null);
            }

            return RedirectToAction("Index", "Account");
        }

        //Helpers
        public static bool EmailIsValid(string email)
        {
            string expression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, expression))
            {
                if (Regex.Replace(email, expression, string.Empty).Length == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool PhoneIsValid(string phone)
        {
            string expression = @"^([\(]{1}[0-9]{3}[\)]{1}[\.| |\-]{0,1}|^[0-9]{3}[\.|\-| ]?)?[0-9]{3}(\.|\-| )?[0-9]{4}$";
            if (Regex.IsMatch(phone, expression))
            {
                if (Regex.Replace(phone, expression, string.Empty).Length == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
