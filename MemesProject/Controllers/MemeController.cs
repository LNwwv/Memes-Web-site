using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper.Mappers;
using MemesProject.Models;
using MemesProject.ViewModels;
using Microsoft.AspNet.Identity;
using PusherServer;

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


        //Wybiera randomowy element z tabeli MemeModels
        [AllowAnonymous]
        public ActionResult RandomMeme()
        {
            
            var random = _context.MemeModels
                .OrderBy(c => Guid.NewGuid())
                .FirstOrDefault();

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