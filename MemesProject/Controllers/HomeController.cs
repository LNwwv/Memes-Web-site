using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MemesProject.Models;
using Microsoft.AspNet.Identity;
using PagedList;

namespace MemesProject.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index(string currentFilter , int? page)
        {
            ViewBag.Comments = _context.Comments.ToList().Count;

            var memesInDb = _context.MemeModels.ToList();
            
            // pageSize odpowiada za liczbe elementow widocznych na jednej stronie.

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(memesInDb.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Like(int id)
        {
            var userId = User.Identity.GetUserId();

            var memeInDb =_context.MemeModels.ToList().Find(m => m.Id == id);

            var likeToDb = new Like
            {
                MemeId = id,
                UserId = userId
            };
            
            var order =  _context.Likes.FirstOrDefault(x => x.UserId == userId && x.MemeId == id);
            if (order != null)
            {
                var likeToDelete =  _context.Likes.ToList().Find(m => m.UserId == userId);
                _context.Likes.Remove(likeToDelete);
                memeInDb.Plus -= 1;
            }
            else
            {
                _context.Likes.Add(likeToDb);
                memeInDb.Plus += 1;
            }

            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }
    }
}