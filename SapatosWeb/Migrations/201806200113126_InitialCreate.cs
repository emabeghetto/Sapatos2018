namespace SapatosWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ModeloSapatoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Modelo = c.String(),
                        Cadarco = c.Boolean(nullable: false),
                        Cor = c.String(),
                        Material = c.String(),
                        Preco = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ModeloSapatoes");
        }
    }
}
