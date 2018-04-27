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

namespace retake.Controllers
{
    public class ActivityController : Controller
    {
        private retakeContext _context;
    public ActivityController(retakeContext context)
    {
         _context = context;

    } 
     
        public IActionResult Dashboard()
        {
        int? userId = HttpContext.Session.GetInt32("id");
        if(userId != null){
            User singleUser = _context.users.SingleOrDefault(u =>u.UserId == userId);
            List<ActivityModel> allActivites = _context.events.Include(a => a.joiners).Include(a => a.User).ToList();
        if(singleUser !=null){
            ViewBag.userId = userId;
            ViewBag.singleUser = singleUser;
            ViewBag.allActivites = allActivites;
            }
        return View("dashboard");
        }
        return RedirectToAction("Index", "User");
        }
            public IActionResult addActivityLink(){
            return View("newActivity");
        }
        public IActionResult addActivity(ActivityModelViewModel m){
                if(ModelState.IsValid){
                ActivityModel newActivity = new ActivityModel{
                    Title = m.Title,
                    Time = m.Time,
                    Date = m.Date,
                    DurationLength = m.DurationLength,
                    DurationString = m.DurationString,
                    description = m.description,
                    UserId =  (int)HttpContext.Session.GetInt32("id"),
                     CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                };
                _context.events.Add(newActivity);               
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View("newActivity");
        }
                  public IActionResult Delete(int id){
            ActivityModel a = _context.events.SingleOrDefault(e => e.ActivityId == id);
            _context.events.Remove(a);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        } 
                public IActionResult Join(int id){
            Joiner query = _context.joiners.SingleOrDefault(a => a.ActivityId == id && a.UserId == (int) HttpContext.Session.GetInt32("id"));
            Joiner i = new Joiner{UserId = (int) HttpContext.Session.GetInt32("id"),
            ActivityId = id};
            _context.joiners.Add(i);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
            }
        public IActionResult UnJoin(int id){
            Joiner j = _context.joiners.SingleOrDefault(u => u.UserId == (int)HttpContext.Session.GetInt32("id") && u.ActivityId == id);
            _context.joiners.Remove(j);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
            public IActionResult singleActivity(int id)
        {
           ActivityModel singleActivity = _context.events.Include(a => a.User).Include(a => a.joiners).ThenInclude(a => a.User).SingleOrDefault(a => a.ActivityId == id);
               int? userId = HttpContext.Session.GetInt32("id");
            User singleUser = _context.users.SingleOrDefault(u =>u.UserId == userId);
            ViewBag.userId = userId;
            ViewBag.singleUser = singleUser;
            ViewBag.singleActivity = singleActivity;
            return View("oneActivity");
        }
        }
    }
    