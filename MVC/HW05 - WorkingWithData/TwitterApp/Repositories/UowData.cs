using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwitterApp.Models;

namespace TwitterApp.Repositories
{
    public class UowData : IUowData
    {
        private readonly ApplicationDbContext context;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public UowData(ApplicationDbContext context)
        {
            this.context = context;
        }

        public UowData() : this (new ApplicationDbContext())
        {

        }

        public IRepository<Models.Tweet> Tweets
        {
            get
            {
                return this.GetRepository<Tweet>();
            }           
        }

        public IRepository<Models.Tag> Tags
        {
            get
            {
                return this.GetRepository<Tag>();
            }           
        }

        public IRepository<Models.ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }           
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}