using System.Linq;
using System.Web.Mvc;
using MemesProject.Models;
using Microsoft.AspNet.Identity;
using PagedList;

namespace MemesProject.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext _context;

        public UserController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: User
        public ActionResult Index()
        {
            var user = User.Identity.GetUserName();

            ViewBag.SumOfMemes = _context.MemeModels.Count(m => m.CreatedBy == user);

            ViewBag.SumOfLikes = _context.MemeModels.ToList().Where(m => m.CreatedBy == user).Sum(m => m.Likes);

            ViewBag.SumOfComentary = _context.Comments.Count(m => m.UserId == user);


            return View();
        }

        public ActionResult ShowMyMemes(string sortOrder, string currentFilter, string searchString, int? page)
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

            var user = User.Identity.GetUserName();
            var memesInDb = _context.MemeModels.ToList().Where(m => m.CreatedBy == user);

            int pageSize = 5;
            int pageNumber = (page ?? 1);


            return View(memesInDb.ToPagedList(pageNumber, pageSize));
        }
    }
}