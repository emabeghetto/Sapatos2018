namespace SapatosWeb.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SapatosWeb.Models.ContextoBanco>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SapatosWeb.Models.ContextoBanco";
        }

        protected override void Seed(SapatosWeb.Models.ContextoBanco context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
