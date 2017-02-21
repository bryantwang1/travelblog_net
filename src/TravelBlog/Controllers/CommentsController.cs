using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelBlog.Models;
using System.Security.Claims;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelBlog.Controllers
{
    public class CommentsController : Controller
    {
        private TravelBlogContext db = new TravelBlogContext();
        
        public IActionResult Create(int id)
        {
            ViewBag.LocationId = id;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Comment comment, int locationId)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser user = db.Users.FirstOrDefault(u => u.Id == userId);
            comment.LocationId = locationId;
            comment.AppUser = user;
            db.Comments.Add(comment);
            db.SaveChanges();
            return RedirectToAction("Details", "Locations", new { id = comment.LocationId });
        }
    }
}
