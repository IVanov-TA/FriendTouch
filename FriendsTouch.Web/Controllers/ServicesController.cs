namespace FriendsTouch.Web.Controllers
{
    using FriendsTouch.Data;
    using FriendsTouch.Models;
    using FriendsTouch.Web.Models;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Linq;
    using System.Web.Http;

    [Authorize]
    public class ServicesController : BaseController
    {
        private int Count = 10;

        public ServicesController(IFriendsTouchData data)
            : base(data)
        {
        }

        // paging
        [HttpGet]
        public IHttpActionResult GetPosts(int page = 0)
        {
            var currentUser = this.User.Identity.GetUserId();

            var postsToReturn = this.data.Posts.All()
                                        .Where(p => p.Publisher != currentUser)
                                        .OrderByDescending(p => p.DateCreated)
                                        .Skip(page * Count)
                                        .Take(Count)
                                        .Select(PostSendModel.FromPosts);

            return Ok(postsToReturn);
        }

        public IHttpActionResult GetCustomPosts(int page = 0, int count = 0)
        {
            var currentUser = this.User.Identity.GetUserId();

            var postsToReturn = this.data.Posts.All()
                                        .Where(p => p.Publisher != currentUser)
                                        .OrderByDescending(p => p.DateCreated)
                                        .Skip(page * count)
                                        .Take(count)
                                        .Select(PostSendModel.FromPosts);

            return Ok(postsToReturn);
        }

        // get specific post
        [HttpGet]
        public IHttpActionResult GetPost(int id)
        {
            var currentUser = this.User.Identity.GetUserId();

            var postsToReturn = this.data.Posts.All()
                                        .Where(p => p.Id == id)
                                        .Select(PostSendModel.FromPosts);

            return Ok(postsToReturn);
        }

        [HttpGet]
        public IHttpActionResult GetNotifications()
        {
            var currentUser = this.User.Identity.GetUserId();

            var notifications = this.data.Notitfications.All()
                                                        .Where(n => n.Recipient == currentUser &&
                                                                    n.State == NotificationState.Unreaded)
                                                        .Select(NotificationModel.FromNotification);
            if (notifications != null)
            {
                return Ok(notifications);
            }

            return null;
        }

        // create new post from registered user
        [HttpPost]
        public IHttpActionResult PostTouch(PostAcceptModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Invalid Data");
            }

            var currentUser = this.User.Identity.GetUserId();

            var newPost = new Post()
            {
                Image = model.Image,
                Publisher = model.Publisher,
                DateCreated = DateTime.Now,
                Description = model.Description,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                User = this.data.Users.Find(currentUser)
            };

            this.data.Posts.Add(newPost);
            this.data.SaveChanges();

            var allUsers = this.data.Users.All().Where(u => u.Id != currentUser);

            foreach (var user in allUsers)
            {
                var newNotification = new Notification()
                {
                    Description = model.Description == null ? "No Description" : model.Description,
                    DateCreated = DateTime.Now,
                    Notifier = this.data.Users.Find(currentUser).Email,
                    Recipient = user.Id,
                    State = NotificationState.Unreaded,
                    PostId = newPost.Id
                };

                this.data.Notitfications.Add(newNotification);
            }

            this.data.SaveChanges();

            return Ok();
        }

        // create comment on Touch
        [HttpPost]
        public IHttpActionResult PostComment(CommentAcceptModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Invalid comment");
            }

            var currentUser = this.User.Identity.GetUserId();

            var newComment = new Comment()
            {
                Author = this.data.Users.Find(currentUser).Email,
                DateCreated = DateTime.Now,
                Text = model.Text,
                Post = this.data.Posts.Find(model.PostId),
                User = this.data.Users.Find(currentUser)
            };

            this.data.Comments.Add(newComment);
            this.data.SaveChanges();

            return Ok();
        }
    }
}