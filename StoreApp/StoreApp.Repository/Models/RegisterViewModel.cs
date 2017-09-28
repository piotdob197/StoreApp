using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreApp.Repository.Models
{
        public class RegisterViewModel
        {
            [Required(ErrorMessage = "Adres email nie może być pusty.")]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Nazwa użytkownika nie może być pusta.")]
            [StringLength(30)]
            [Display(Name = "Nazwa użytkownika")]
            public string UserName { get; set; }

            [Required(ErrorMessage = "Hasło nie może być puste.")]
            [StringLength(20), MaxLength(20, ErrorMessage = "Hasło nie może być dłuższę niż 20 znaków.")]
            [RegularExpression(@"^.*(?=.{2,})(?=.*\d)(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$",
                ErrorMessage = "Hasło powinno zawierać minimum jedną wielką literę, jedną cyfrę oraz jeden znak alfanumeryczny.")]
            [DataType(DataType.Password)]
            [Display(Name = "Hasło")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Powtórz hasło")]
            [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Hasła muszą być identyczne.")]
            public string ConfirmPassword { get; set; }
        }
    }
