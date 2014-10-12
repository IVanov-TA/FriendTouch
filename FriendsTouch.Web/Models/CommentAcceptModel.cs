using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FriendsTouch.Models;

namespace FriendsTouch.Web.Models
{
    public class CommentAcceptModel
    {
        public string Text { get; set; }

        public string Author { get; set; }

        public int PostId { get; set; }
    }
}