using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.Admin.Models
{
    [Serializable]
    public class Account
    {
        public Guid UserId { set; get; }
        public string UserName { set; get; }
        public string Email { set; get; }
    }
}