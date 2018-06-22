namespace SapatosWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracao2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoteVendaSapatoes", "IdLoteVenda", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LoteVendaSapatoes", "IdLoteVenda");
        }
    }
}
