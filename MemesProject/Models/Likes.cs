using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemesProject.Models
{
    public class Likes
    {
        public int Id { get; set; }
        public string UserID { get; set; }
        public int MemeId { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
    }
}