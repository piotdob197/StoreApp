using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StoreApp.Repository.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace StoreApp.Context
{


    public class StoreAppContext : IdentityDbContext
    {
        public StoreAppContext()
            : base("DefaultConnection")
        {
        }

        public static StoreAppContext Create()
        {
            return new StoreAppContext();
        }

        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}