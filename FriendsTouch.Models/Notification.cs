using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsTouch.Models
{
    public class Notification
    {
        public int Id { get; set; }

        public NotificationState State { get; set; }

        public DateTime DateCreated { get; set; }

        public string Description { get; set; }

        public string Notifier { get; set; }

        public string Recipient { get; set; }

        public int PostId { get; set; }
    }
}
