using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechTree_MVC.Entities.Master
{
    public class TT_M_Category
    {
        public Int32   Id                                    { get; set; }
        [Required]
        [StringLength(200,MinimumLength =2,ErrorMessage ="Minimum 2 characters are required!")]
        public string? Title                                 { get; set; }
        public string? Description                           { get; set; }
        [Required]
        public string? ThumbnailImagePath                    { get; set; }
        [ForeignKey("CategoryId")]
        public ICollection<TT_M_CategoryItem>? CategoryItems { get; set; }
        [ForeignKey("CategoryId")]
        public virtual ICollection<TT_UserCategory>? UserCategory { get; set; }
    }
}
