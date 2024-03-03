namespace KirtasiyejimWebApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KirtasiyejimWebApp.Models.KirtasiyejimDBModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(KirtasiyejimWebApp.Models.KirtasiyejimDBModel context)
        {
            //Oluşturulan tabloların eğer varsa başlangıç verilerini ekleme için kullandığımız alan
            context.ManagerTypes.AddOrUpdate(x => x.ID, new Models.ManagerType() { ID = 1, Name = "Admin" });
            context.ManagerTypes.AddOrUpdate(x => x.ID, new Models.ManagerType() { ID = 2, Name = "Moderatör" });
        }
    }
}
