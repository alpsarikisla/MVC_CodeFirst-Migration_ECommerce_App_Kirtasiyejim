using KirtasiyejimWebApp.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KirtasiyejimWebApp.Models
{
    public class Category:Entity
    {
        [Display(Name = "Isim")]
        [Required(ErrorMessage = "Alan boş bırakılamaz")]
        [StringLength(maximumLength: 75, ErrorMessage = "En fazla 75 karakter olmalıdır")]
        public string Name { get; set; }

        [Display(Name = "Açıklama")]
        [StringLength(maximumLength: 500, ErrorMessage = "En fazla 500 karakter olmalıdır")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

    }
}