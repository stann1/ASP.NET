namespace TwitterApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TwitterApp.Models;

    public sealed class Configuration : DbMigrationsConfiguration<TwitterApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TwitterApp.Models.ApplicationDbContext context)
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

            //context.Tweets.AddOrUpdate
            //    (
            //        new Tweet() {Content = "dnes sum bolno pse", Tag = new Tag(){Name = "#bolno-pse"}, PostDate = DateTime.Now},
            //        new Tweet() {Content = "qdoh bob dnes za obqd, celiq svqt trqbva da znae!", Tag = new Tag(){Name = "#crap"}, PostDate = DateTime.Now}
            //    );
        }
    }
}
