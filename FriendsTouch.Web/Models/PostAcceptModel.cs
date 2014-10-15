using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FriendsTouch.Web.Models
{
    public class PostAcceptModel
    {
        [Required]
        public string Image { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }
       
        public string Description { get; set; }
        [Required]
        public string Publisher { get; set; }
    }
}