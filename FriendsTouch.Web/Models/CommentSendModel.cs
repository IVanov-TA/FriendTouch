using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FriendsTouch.Web.Models
{
    public class CommentSendModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime DateCreated { get; set; }

        public string Author { get; set; }
    }
}