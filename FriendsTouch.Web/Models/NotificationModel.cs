namespace FriendsTouch.Web.Models
{
    using FriendsTouch.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    public class NotificationModel
    {
        public static Expression<Func<Notification, NotificationModel>> FromNotification
        {
            get
            {
                return n => new NotificationModel
                {
                    PostId = n.PostId,
                    Notifier = n.Notifier,
                    DateCreated = n.DateCreated,
                    Description = n.Description
                };
            }
        }

        public int PostId { get; set; }

        public string Notifier { get; set; }

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }
    }
}