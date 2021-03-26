using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemesProject.Models
{
    public class Like
    {
        public int Id { get; set; }
        public int MemeId { get; set; }
        public string UserId { get; set; }
    }
}

