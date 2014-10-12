namespace FriendsTouch.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;
    using FriendsTouch.Data;

    public class BaseController: ApiController
    {
        protected IFriendsTouchData data;

        public BaseController(IFriendsTouchData data)
        {
            this.data = data;
        }
    }
}