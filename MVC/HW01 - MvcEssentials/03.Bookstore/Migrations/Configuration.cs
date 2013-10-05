namespace _03.Bookstore.Migrations
{
    using _03.Bookstore.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<_03.Bookstore.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(_03.Bookstore.Models.ApplicationDbContext context)
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
            
            for (int i = 1; i <= 10; i++)
            {
                BookModel book = new BookModel()
                {
                    Id = i,
                    Title = "Book " + i,
                    Author = "Author " + i % 3,
                    Description = "Some book description for book " + i
                };
                context.Books.AddOrUpdate(book);
            }
                        
        }
    }
}
