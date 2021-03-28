using MemesProject.Models;
using MemesProject.ViewModels;
using Microsoft.AspNet.Identity;
using PusherServer;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

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

        [AllowAnonymous]
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
            var viewModel = new MemeViewModel()
            {
                MemeModel = new MemeModel(),
                Categories = _context.Categories.ToList()
            };

            return View("CreateMeme", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(MemeModel memeModel)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MemeViewModel()
                {
                    MemeModel = memeModel,
                    Categories = _context.Categories.ToList()
                };

                return View("CreateMeme", viewModel);
            }

            if (memeModel.Id == 0)
            {
                memeModel.CreatedBy = User.Identity.GetUserName();
                memeModel.Likes = 0;
                memeModel.AddedDate = DateTime.Now;
                _context.MemeModels.Add(memeModel);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        //Wybiera randomowy element z tabeli MemeModels
        [AllowAnonymous]
        public ActionResult RandomMeme()
        {
            var random = _context.MemeModels
                .OrderBy(c => Guid.NewGuid())
                .FirstOrDefault();
            if (random==null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(random);
        }

        //Sekcja komentarzy
        public ActionResult Comments(int? id)
        {
            var comments = _context.Comments.Where(x => x.MemeId == id).ToArray();
            return Json(comments, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> Comment(Comments data)
        {
            _context.Comments.Add(data);
            _context.SaveChanges();
            var options = new PusherOptions();
            options.Cluster = "XXX_APP_CLUSTER";
            var pusher = new Pusher("XXX_APP_ID", "XXX_APP_KEY", "XXX_APP_SECRET", options);
            ITriggerResult result = await pusher.TriggerAsync("asp_channel", "asp_event", data);
            return Content("ok");
        }
    }
}