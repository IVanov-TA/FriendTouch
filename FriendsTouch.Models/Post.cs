namespace FriendsTouch.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Post
    {
        private ICollection<Comment> comments;

        public Post()
        {
            this.comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        public string Image { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }

        public string Description { get; set; }

        public string Publisher { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Comment> Comments 
        { 
            get
            {
                return this.comments;
            }
            set
            {
                this.comments = value;
            }
        }
    }
}
