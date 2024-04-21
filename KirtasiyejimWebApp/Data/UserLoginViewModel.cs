using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KirtasiyejimWebApp.Data
{
    public class UserLoginViewModel
    {
        [Display(Name = "E-Posta")]
        [Required(ErrorMessage = "E-Posta alanı boş bırakılamaz")]
        [StringLength(maximumLength: 150, ErrorMessage = "En fazla 150 karakter olmalıdır")]

        public string Email { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Alan boş bırakılamaz")]
        [StringLength(maximumLength: 20, ErrorMessage = "En fazla 20 karakter olmalıdır")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}