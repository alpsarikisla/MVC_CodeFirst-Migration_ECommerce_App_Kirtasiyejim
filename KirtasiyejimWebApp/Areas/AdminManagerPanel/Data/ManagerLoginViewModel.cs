using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KirtasiyejimWebApp.Areas.AdminManagerPanel.Data
{
    public class ManagerLoginViewModel
    {

        [Display(Name = "E-Posta")]
        [Required(ErrorMessage = "E-Posta alanı boş bırakılamaz")]
        [StringLength(maximumLength: 150, ErrorMessage = "En fazla 150 karakter olmalıdır")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Alan boş bırakılamaz")]
        [StringLength(maximumLength: 20, ErrorMessage = "En fazla 20 karakter olmalıdır")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}