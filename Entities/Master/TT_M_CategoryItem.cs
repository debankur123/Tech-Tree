using System.ComponentModel.DataAnnotations;

namespace TechTree_MVC.Entities.Master
{
    public class TT_M_CategoryItem
    {
        public int      Id                   { get; set; }
        [Required]
        [StringLength(250,MinimumLength =2)]
        public string?  Title                { get; set; }
        public int      CategoryId           { get; set; }
        public int      MediaTypeId          { get; set; }
        public DateTime DateTimeItemReleased { get; set; }
    }
}
