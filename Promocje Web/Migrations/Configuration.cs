using System.Data.Entity.Migrations;
using Promocje_Web.Models;

namespace Promocje_Web.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

          /*  context.Categories.AddOrUpdate(
                new Kategoria() { CategoryId = 1, Name = "Music"},
                new Kategoria() { CategoryId = 2, Name = "Movie" },
                new Kategoria() { CategoryId = 3, Name = "Entertainment" },
                new Kategoria() { CategoryId = 4, Name = "News" },
                new Kategoria() { CategoryId = 5, Name = "Sport" }
                );*/
        }
    }
}
