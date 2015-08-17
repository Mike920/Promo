using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Promocje_Web.Migrations;

namespace Promocje_Web.Models
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

        [ScaffoldColumn(false)]
        public bool Admin { get; set; }
        public virtual ICollection<MediaFile> MediaFiles { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Sklep> Sklepy { get; set; }
        public virtual ICollection<Kategoria> Kategorie { get; set; }
        public virtual ICollection<Ulotka> Ulotki { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
           
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext,Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

       /* protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Migrations.Configuration>());
        }*/


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Comment>()
                        .HasOptional(s => s.Parent)
                        .WithMany(s => s.Children)
                        .HasForeignKey(s => s.ParentId);
        }
        public DbSet<MediaFile> MediaFiles { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public System.Data.Entity.DbSet<Promocje_Web.Models.Kategoria> Kategorias { get; set; }

        public System.Data.Entity.DbSet<Promocje_Web.Models.Sklep> Skleps { get; set; }
    }
}