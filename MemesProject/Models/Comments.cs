using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MemesProject.Models
{
    public class Comments
    {
        [Key]
        public int CommendId { get; set; }

        [Column(TypeName = "ntext")]
        public string Body { get; set; }

        public string UserId { get; set; }

        public int MemeId { get; set; }
    }
}