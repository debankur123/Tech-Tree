﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechTree_MVC.Entities.Master
{
    public class TT_M_CategoryItem
    {
        public int      Id                                    { get; set; }
        [Required]
        [StringLength(250,MinimumLength =2)]
        public string?  Title                                 { get; set; }
        public string?  Description                           { get; set; }
        public int      CategoryId                            { get; set; }
        public int      MediaTypeId                           { get; set; }
        [NotMapped]
        public virtual ICollection<SelectListItem> MediaTypes { get; set; }
        public DateTime DateTimeItemReleased                  { get; set; }
    }
}
