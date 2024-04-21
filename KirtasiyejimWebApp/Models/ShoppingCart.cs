using KirtasiyejimWebApp.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KirtasiyejimWebApp.Models
{
    public class ShoppingCart:Entity
    {
        public int Product_ID { get; set; }
        [ForeignKey("Product_ID")]
        public virtual Product Product { get; set; }

        public int User_ID { get; set; }
        [ForeignKey("User_ID")]
        public virtual User User { get; set; }

        public int Quantity { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AddedDate { get; set; }
    }
}