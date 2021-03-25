using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MemesProject.Models;

namespace MemesProject.Controllers.Api
{
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

        public IHttpActionResult Get()
        {
            var memesInDb = _context.MemeModels.ToList();

            return Ok(memesInDb);
        }

        public IHttpActionResult Get(int id)
        {
            var memesInDb = _context.MemeModels.SingleOrDefault(c => c.Id == id);
            if (memesInDb == null)
            {
                return NotFound();
            }
            return Ok(memesInDb);
        }

        [Authorize]
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
            //Ogarnac zeby nie usuwac tego w Details bo wywala blad
            return Ok();
        }
    }
}
