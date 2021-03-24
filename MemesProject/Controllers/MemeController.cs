using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Http.Results;
using System.Web.Security;
using AutoMapper;
using MemesProject.Models;


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

        public ActionResult New()
        {
            var memeModels = _context.MemeModels.ToList();

            var viewmodel = new MemeModel();

            return View("CreateMeme", viewmodel);
        }

        //[HttpPost]
        //[Authorize(Roles = RoleName.AdminRole)]
        public ActionResult Save(MemeModel memeModel)
        {
            
            if (!ModelState.IsValid)
            {
                var viewModel = new MemeModel();
                
                return View("CreateMeme", viewModel);
            }
            if (memeModel.Id == 0)
            {
                memeModel.CreatedBy = "Test User";
                memeModel.Minus = 0;
                memeModel.Plus = 0;
                memeModel.AddedDate = DateTime.Now;
                _context.MemeModels.Add(memeModel);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

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