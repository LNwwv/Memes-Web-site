
using System.Linq;
using System.Web.Mvc;
using MemesProject.Models;
using Microsoft.AspNet.Identity;

namespace MemesProject.App_Start
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

            ViewBag.SumOfLikes = _context.MemeModels.ToList().Where(m => m.CreatedBy == user).Sum(m => m.Plus);
            ViewBag.SumOfMinus = _context.MemeModels.ToList().Where(m => m.CreatedBy == user).Sum(m => m.Minus);
            

            return View();
        }
        public ActionResult ShowMyMemes()
        {
            var user = User.Identity.GetUserName();
            var memesInDb = _context.MemeModels.ToList().Where(m => m.CreatedBy == user);

            return View(memesInDb);
        }
        

        
    }
}