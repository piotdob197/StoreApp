using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreApp.Repository.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Pole nie może być puste.")]
        [StringLength(30)]
        [Display(Name = "Login lub email")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Hasło nie może być puste.")]
        [StringLength(20), MaxLength(20, ErrorMessage = "Hasło nie może być dłuższę niż 20 znaków.")]
        [RegularExpression(@"^.*(?=.{2,})(?=.*\d)(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$",
            ErrorMessage = "Hasło powinno zawierać minimum jedną wielką literę, jedną cyfrę oraz jeden znak alfanumeryczny.")]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Display(Name = "Zapamiętaj mnie?")]
        public bool RememberMe { get; set; }
    }
}