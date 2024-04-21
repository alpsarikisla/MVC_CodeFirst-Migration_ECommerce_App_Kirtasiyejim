namespace KirtasiyejimWebApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using KirtasiyejimWebApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<KirtasiyejimWebApp.Models.KirtasiyejimDBModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(KirtasiyejimWebApp.Models.KirtasiyejimDBModel context)
        {
            #region Manager Types

            //Oluşturulan tabloların eğer varsa başlangıç verilerini ekleme için kullandığımız alan
            context.ManagerTypes.AddOrUpdate(x => x.ID, new ManagerType() { ID = 1, Name = "Admin" });
            context.ManagerTypes.AddOrUpdate(x => x.ID, new ManagerType() { ID = 2, Name = "Moderatör" });

            #endregion

            #region Managers

            context.Managers.AddOrUpdate(x => x.ID, new Manager() { ID = 1, Name = "John", Surname = "Doe", Email = "johndoe26@hotmail.com", ManagerType_ID = 1, NickName = "j.doe", Password = "1234", IsActive = true, IsDeleted = false });


            #endregion

            #region Users

            context.Users.AddOrUpdate(x => x.ID, new User() { ID = 1, Name = "Alp", Surname = "Sarıkışla", Email = "alpsarikisla@hotmail.com", Password = "1234", PhoneNumber="5302050200", CreationDate= Convert.ToDateTime("21.04.2024")});

            #endregion
        }
    }
}
