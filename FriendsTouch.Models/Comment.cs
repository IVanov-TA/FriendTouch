namespace FriendsTouch.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public string Text { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public string Author { get; set; }

        public virtual User User { get; set; }

        public virtual Post Post { get; set; }
    }
}
