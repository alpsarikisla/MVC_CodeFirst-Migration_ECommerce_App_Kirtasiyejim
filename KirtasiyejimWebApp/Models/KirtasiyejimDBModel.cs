using System;
using System.Data.Entity;
using System.Linq;

namespace KirtasiyejimWebApp.Models
{
    public class KirtasiyejimDBModel : DbContext
    {
        public KirtasiyejimDBModel()
            : base("name=KirtasiyejimDBModel")
        {
        }

        public DbSet<ManagerType> ManagerTypes { get; set; }
        public DbSet<Manager> Managers { get; set; }
    } 
}