using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace tranvanphuongdoan3.Areas.Admin.Models.Entities
{
    public class Account
    {
        [Required(ErrorMessage = "ma dang nhap is not empty")]
        [DisplayName("Ma dang nhap: ")]
        public string madangnhap { get; set; }
        [Required(ErrorMessage = "user name is not empty")]
        [DisplayName("User name: ")]
        public string username { get; set; }
        [DisplayName("Pass word: ")]
        [Required(ErrorMessage = "pass word is not empty")]
        public string pass{ get; set; }
    }
}