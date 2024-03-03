using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KirtasiyejimWebApp.Models
{
    public class ManagerType
    {
        //Her sınıfın ID Bilgisi Olmalıdır.
        //CodeFirst Yaklaşımında ID isimli Property Otomatik olarak PrimaryKey Yapılır Ve IDentitySpecification Otomatik larak ayarlanır
        public int ID { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz")]
        [StringLength(maximumLength:50, ErrorMessage = "En Fazla 50 karakter olmalıdır")]
        public string Name { get; set; }

        public virtual ICollection<Manager> Managers { get; set; }
    }
}