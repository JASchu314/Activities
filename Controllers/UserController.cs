using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using retake.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace exam.Controllers
{
    public class userController : Controller
    {
        private retakeContext _context;
    public userController(retakeContext context)
    {
         _context = context;

    } 
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult addUser(UserViewModel user){
            if(ModelState.IsValid){
                if(_context.users.SingleOrDefault(a => a.Email== user.Email)!=null){
                    TempData["Error"]="Email already exists";
                    return RedirectToAction("Index");
                }
            PasswordHasher<UserViewModel> Hasher = new PasswordHasher<UserViewModel>();
                user.Password = Hasher.HashPassword(user, user.Password);
                User newUser = new User{
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password,
                };
                _context.Add(newUser);
                _context.SaveChanges();
                User nu = _context.users.SingleOrDefault(u => u.Email == user.Email);
                HttpContext.Session.SetInt32("id", nu.UserId);
                return RedirectToAction("dashboard", "Activity");
            }
            return View("Index");
        }
            public IActionResult Login(loginViewModel user){
                if(ModelState.IsValid){
                    User oneUser = _context.users.SingleOrDefault(u => u.Email == user.Email);
                    if(oneUser != null){
                if(user.Email != null && user.Password != null){
                        var Hasher = new PasswordHasher<loginViewModel>();
                    if(0 != Hasher.VerifyHashedPassword(user, oneUser.Password, user.Password)){
                        HttpContext.Session.SetInt32("id", oneUser.UserId);
                        return RedirectToAction("dashboard", "Activity");
                        }
                     }
                    }
                }
                 TempData["Error"]="User does not exist";
                    return View("Index");
            }
    }
}
