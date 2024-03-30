using KirtasiyejimWebApp.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KirtasiyejimWebApp.Models
{
    public class Product: Entity
    {
        [Display(Name ="Kategori")]
        public int Category_ID { get; set; }
        [ForeignKey("Category_ID")]
        public virtual Category category { get; set; }

        public int Brand_ID { get; set; }
        [ForeignKey("Brand_ID")]
        public virtual Brand Brand { get; set; }

        [Display(Name = "Isim")]
        [Required(ErrorMessage = "Alan boş bırakılamaz")]
        [StringLength(maximumLength: 75, ErrorMessage = "En fazla 75 karakter olmalıdır")]
        public string Name { get; set; }

        [Display(Name = "Açıklama")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Fiyat")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [Display(Name = "Stok")]
       
        public double Stock { get; set; }

        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}