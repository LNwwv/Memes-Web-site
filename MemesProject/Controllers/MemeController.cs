using System;
using System.Linq;
using System.Web.Mvc;
using MemesProject.Models;
using Microsoft.AspNet.Identity;

namespace MemesProject.Controllers
{
    public class MemeController : Controller
    {
        private ApplicationDbContext _context;

        public MemeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Details(int id)
        {
            var memesInDb = _context.MemeModels.ToList().SingleOrDefault(m => m.Id == id);

            if (memesInDb == null)
            {
                return HttpNotFound();
            }

            return View(memesInDb);
        }

        public ActionResult New()
        {
            var memeModels = _context.MemeModels.ToList();

            var viewmodel = new MemeModel();

            return View("CreateMeme", viewmodel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(MemeModel memeModel)
        {
            
            if (!ModelState.IsValid)
            {
                var viewModel = new MemeModel();
                
                return View("CreateMeme", viewModel);
            }
            if (memeModel.Id == 0)
            {
                memeModel.CreatedBy = User.Identity.GetUserName();
                memeModel.Minus = 0;
                memeModel.Plus = 0;
                memeModel.AddedDate = DateTime.Now;
                _context.MemeModels.Add(memeModel);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        [AllowAnonymous]
        public ActionResult RandomMeme()
        {
            //Wybiera randomowy element z tabeli MemeModels
            var random = _context.MemeModels
                .OrderBy(c => Guid.NewGuid())
                .FirstOrDefault();

            return View(random);
        }

        
    }
}