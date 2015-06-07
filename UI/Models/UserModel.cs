using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class UserModel
        :LoginModel
    {   
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите имя")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите фамилию")]
        [Display(Name = "Фамилия")]
        public string Sirname { get; set; }

        [Required(ErrorMessage = "Укажите адрес электронной почты")]
        [Display(Name = "Электронная почта")]
        public string Email { get; set; }

        public string Info { get; set; }

        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [Required(ErrorMessage = "Повторите пароль")]
        [Display(Name = "Повтор пароля")]
        public string PasswordClone { get; set; }
    }
}