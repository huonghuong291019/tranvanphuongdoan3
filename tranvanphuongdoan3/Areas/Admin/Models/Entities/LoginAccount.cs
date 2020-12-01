using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace tranvanphuongdoan3.Areas.Admin.Models.Entities
{
    public class LoginAccount
    {
        [Required(ErrorMessage = "Mời nhập User Name:")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Mời nhập PassWord")]
        public string PassWord { get; set; }
        public Boolean Remember { get; set; }
    }
}