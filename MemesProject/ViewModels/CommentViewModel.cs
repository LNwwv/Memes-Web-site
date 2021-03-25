using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MemesProject.Models;

namespace MemesProject.ViewModels
{
    public class CommentViewModel
    {
        public MemeModel MemeModel { get; set; }
        public Comments Comments { get; set; }
    }
}