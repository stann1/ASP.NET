namespace MoviesCatalogue.Migrations
{
    using MoviesCatalogue.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<MoviesCatalogue.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MoviesCatalogue.Models.ApplicationDbContext context)
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

            //for (int i = 1; i <= 10; i++)
            //{
            //    Movie movie = new Movie()
            //    {    
            //        Id = i+1,
            //        Title = "Title " + i,
            //        Director = "Director " + (i % 2),
            //        Year = 2000 + (i % 7),
            //        Studio = "Studio " + (i % 2)                    
            //    };
            //    context.Movies.AddOrUpdate(movie);
            //}
            
        }
    }
}
