using FriendsTouch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace FriendsTouch.Web.Models
{
    public class PostSendModel
    {
        public static Expression<Func<Post, PostSendModel>> FromPosts
        {
            get
            {
                return p => new PostSendModel
                {
                    Id = p.Id,
                    Image = p.Image,
                    DateCreated = p.DateCreated,
                    Longitude = p.Longitude,
                    Latitude = p.Latitude,
                    Description = p.Description,
                    Publisher = p.Publisher,
                    Comment = p.Comments.Select(c => new CommentSendModel 
                    { 
                        Author = c.Author,
                        DateCreated = c.DateCreated,
                        Text = c.Text
                    }).ToList()
                };
            }
        }

        public int Id { get; set; }

        public string Image { get; set; }

        public DateTime DateCreated { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }

        public string Description { get; set; }

        public string Publisher { get; set; }

        public ICollection<CommentSendModel> Comment { get; set; }
    }
}