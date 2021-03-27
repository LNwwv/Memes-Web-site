using AutoMapper;
using MemesProject.Dto;
using MemesProject.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace MemesProject.Controllers.Api
{
    [Authorize(Roles = RoleName.AdminRole)]
    public class MemesController : ApiController
    {
        private ApplicationDbContext _context;

        public MemesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var memesInDb = _context.MemeModels.ToList();

            return Ok(memesInDb);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var memesInDb = _context.MemeModels.SingleOrDefault(c => c.Id == id);
            if (memesInDb == null)
            {
                return NotFound();
            }
            return Ok(memesInDb);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var memesInDb = _context.MemeModels.SingleOrDefault(c => c.Id == id);

            if (memesInDb == null)
            {
                return NotFound();
            }

            _context.MemeModels.Remove(memesInDb);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Create(MemeDto memeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var memeToDb = Mapper.Map<MemeDto, MemeModel>(memeDto);
            _context.MemeModels.Add(memeToDb);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + memeToDb.Id), memeDto);
        }

        public IHttpActionResult Put(int id, MemeDto memeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var memeInDb = _context.MemeModels.ToList().SingleOrDefault(m => m.Id == id);

            if (memeInDb == null)
            {
                return NotFound();
            }

            Mapper.Map(memeDto, memeInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
