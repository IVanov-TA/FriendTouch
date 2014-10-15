using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FriendsTouch.Models;
using System.ComponentModel.DataAnnotations;

namespace FriendsTouch.Web.Models
{
    public class CommentAcceptModel
    {
        [Required]
        public string Text { get; set; }
        
        [Required]
        public int PostId { get; set; }
    }
}