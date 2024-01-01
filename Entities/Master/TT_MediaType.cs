using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechTree_MVC.Entities.Master
{
    public class TT_MediaType
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? ThumbnailImagePath { get; set; }
        [ForeignKey("MediaTypeId")]
        public virtual    ICollection<TT_M_CategoryItem>?   CategoryItems { get; set; }
    }
}