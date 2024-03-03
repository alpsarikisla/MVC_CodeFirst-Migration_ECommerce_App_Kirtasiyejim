using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KirtasiyejimWebApp.Models.Base
{
    public class Entity
    {
        public Entity()
        {
            IsActive = true;
            IsDeleted = false;
        }

        [Display(Name = "No")]
        public int ID { get; set; }

        [Display(Name = "Durum")]
        public bool IsActive { get; set; }

        [Display(Name = "Silinmiş")]
        public bool IsDeleted { get; set; }
    }
}