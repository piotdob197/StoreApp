using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StoreApp.Repository.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using StoreApp.Repository.Interfaces;

namespace StoreApp.Context
{


    public class StoreAppContext : IdentityDbContext,IStoreAppContext
    {
        public StoreAppContext()
            : base("name = StoreAppConnectionString")
        {
        }

        public static StoreAppContext Create()
        {
            return new StoreAppContext();
        }

    

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<IdentityUser>().ToTable("Users").Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<UserModel>().ToTable("Users").Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<UserModel> Users { get; set; }
    }
}