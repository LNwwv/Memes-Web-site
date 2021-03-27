using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MemesProject.Models
{
    public class MemeModel
    {
        public int Id { get; set; }

        [StringLength(255)]
        [Display(Name="Meme Title")]
        [Required(ErrorMessage = "Please enter Title")]
        public string Title { get; set; }
        [Display(Name = "Meme URL source")]
        [Required(ErrorMessage = "Please enter URL source")]
        public string ImgSource { get; set; }
        [Range(0, 9999)]
        public int Plus { get; set; }
        
        public string CreatedBy { get; set; }
        public DateTime? AddedDate { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
       
    }
}