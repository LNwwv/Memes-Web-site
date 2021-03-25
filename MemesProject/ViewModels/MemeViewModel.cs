using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MemesProject.Models;

namespace MemesProject.ViewModels
{
    public class MemeViewModel
    {
        public MemeModel MemeModel { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}