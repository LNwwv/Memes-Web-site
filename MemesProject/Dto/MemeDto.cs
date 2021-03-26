using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MemesProject.Models;

namespace MemesProject.Dto
{
    public class MemeDto
    {
        [StringLength(255)]
        [Required(ErrorMessage = "Please enter Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter URL source")]
        public string ImgSource { get; set; }
        [Range(0, 9999)]
        public int Plus { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? AddedDate { get; set; }

        public int CategoryId { get; set; }
    }
}