using FriendsTouch.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using FriendsTouch.Data.Migrations;

namespace FriendsTouch.Data
{
    public class FriendsTouchDbContext : IdentityDbContext<User>
    {
        public FriendsTouchDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FriendsTouchDbContext, Configuration>());
        }

        public static FriendsTouchDbContext Create()
        {
            return new FriendsTouchDbContext();
        }

        public IDbSet<Post> Post { get; set; }

        public IDbSet<Notification> Notifications { get; set; }

        public IDbSet<Comment> Comments { get; set; }

    }
}
