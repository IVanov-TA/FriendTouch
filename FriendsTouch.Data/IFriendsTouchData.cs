namespace FriendsTouch.Data
{
    using FriendsTouch.Models;
    using FriendsTouch.Data.Repositories;

    public interface IFriendsTouchData
    {
        IRepository<User> Users { get; }

        IRepository<Post> Posts { get; }

        IRepository<Notification> Notitfications { get; }

        IRepository<Comment> Comments { get; }

        int SaveChanges();
    }
}
