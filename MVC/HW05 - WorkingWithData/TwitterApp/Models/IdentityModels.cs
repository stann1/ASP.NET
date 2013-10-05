using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace TwitterApp.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : User
    {  
    }

    public class ApplicationDbContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public DbSet<Tweet> Tweets { get; set; }

        public DbSet<Tag> Tags { get; set; }
    }
}