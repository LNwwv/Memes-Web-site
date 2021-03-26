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

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var memesInDb = _context.MemeModels.ToList();

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(memesInDb.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Like(int id)
        {
            var user = User.Identity.GetUserId();

            var memeModel =_context.MemeModels.ToList().Find(m => m.Id == id);

            var like = new Like
            {
                MemeId = id,
                UserId = user
            };
            
            var order =  _context.Likes.Where(x => x.UserId == user && x.MemeId == id).FirstOrDefault();
            if (order != null)
            {
                var likeToDelete =  _context.Likes.ToList().Find(m => m.UserId == user);
                _context.Likes.Remove(likeToDelete);
                memeModel.Plus -= 1;
            }
            else
            {
                _context.Likes.Add(like);
                memeModel.Plus += 1;
            }


            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }

        public ActionResult Unlike(int id)
        {
            var update = _context.MemeModels.ToList().Find(m => m.Id == id);
            update.Minus--;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}