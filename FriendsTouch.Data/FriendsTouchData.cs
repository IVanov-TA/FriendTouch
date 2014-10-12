namespace FriendsTouch.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using FriendsTouch.Data.Repositories;
    using FriendsTouch.Models;

    public class FriendsTouchData : IFriendsTouchData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public FriendsTouchData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IRepository<Post> Posts
        {
            get
            {
                return this.GetRepository<Post>();
            }
        }

        public IRepository<Notification> Notitfications
        {
            get
            {
                return this.GetRepository<Notification>();
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                return this.GetRepository<Comment>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T:class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EFRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}
