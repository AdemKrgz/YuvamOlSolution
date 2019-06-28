using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YuvamOl.WebUI.Models.AccountModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Bu alanı doldurmak zorunludur")]
        [MaxLength(20, ErrorMessage = "Bu alan maksimum 20 karakter uzunluğunda olabilir")]
        [Display(Name = "Kullanıcı Adı")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Bu alanı doldurmak zorunludur")]
        [MinLength(6, ErrorMessage = "Bu alan minimum 6 karakter uzunluğunda olabilir")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}