using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterApp.Models;

namespace TwitterApp.Repositories
{
    public interface IUowData : IDisposable
    {
        IRepository<Tweet> Tweets { get; }

        IRepository<Tag> Tags { get; }

        IRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}
