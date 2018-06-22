namespace SapatosWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracao3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ModeloSapatoes", "Foto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ModeloSapatoes", "Foto", c => c.String());
        }
    }
}
