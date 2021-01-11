using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.Admin.Models
{
    public class LoginAccount
    {
        [Required(ErrorMessage = "Please input your email address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { set; get; }
        [Required(ErrorMessage = "Please input password")]
        public string Password { set; get; }
        public string CaptchaCode { get; set; }
        public bool RememberMe { set; get; }
    }
}