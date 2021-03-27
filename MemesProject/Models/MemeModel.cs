using System;
using System.ComponentModel.DataAnnotations;

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
        public int Likes { get; set; }
        
        public string CreatedBy { get; set; }
        public DateTime? AddedDate { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
       
    }
}