using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechTree_MVC.Entities.Master;

namespace TechTree_MVC.Data
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(100)]
        public string? FirstName    { get; set; }
        [StringLength(100)]
        public string? LastName     { get; set; }
        [StringLength(250)]
        public string? AddressLine1 { get; set; }
        [StringLength(250)]
        public string? AddressLine2 { get; set; }
        [StringLength(20)]
        public string? PostCode     { get; set; }
        [ForeignKey("UserId")]
        public virtual ICollection<TT_UserCategory>? UserCategory { get; set; }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TT_Content>        Content       { get; set; }
        public DbSet<TT_M_Category>     Category      { get; set; }
        public DbSet<TT_M_CategoryItem> CategoryItem  { get; set; }
        public DbSet<TT_MediaType>      MediaType     { get; set; }
        public DbSet<TT_UserCategory>   UserCategory  { get; set; }
    }
}
