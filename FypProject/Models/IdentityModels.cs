using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FypProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<FypProject.Models.Contact> Contacts { get; set; }

        public System.Data.Entity.DbSet<FypProject.Models.UpdateProfile> UpdateProfiles { get; set; }

       public System.Data.Entity.DbSet<FypProject.Models.Project> Projects { get; set; }

        public System.Data.Entity.DbSet<FypProject.Models.Photo> Photos { get; set; }

        public System.Data.Entity.DbSet<FypProject.Models.Theme> Themes { get; set; }

        public System.Data.Entity.DbSet<FypProject.Models.Texture> Textures { get; set; }

        public System.Data.Entity.DbSet<FypProject.Models.Graphic> Graphics { get; set; }

        public System.Data.Entity.DbSet<FypProject.Models.Plugin> Plugins { get; set; }

        public System.Data.Entity.DbSet<FypProject.Models.More> Mores { get; set; }

        public System.Data.Entity.DbSet<FypProject.Models.WebApi> WebApis { get; set; }

        public System.Data.Entity.DbSet<FypProject.Models.MobApp> MobApps { get; set; }

        public System.Data.Entity.DbSet<FypProject.Models.Order> Orders { get; set; }

        public DbSet<FypProject.Models.AddCart> AddCarts { get; set; }

        public DbSet<FypProject.Models.CartItem> CartItems { get; set; }

    }
}