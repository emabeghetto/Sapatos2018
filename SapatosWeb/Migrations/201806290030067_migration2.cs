namespace SapatosWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VendaSapatoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        PrecoTotal = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.LoteVendaSapatoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tamanho = c.Int(nullable: false),
                        Preco = c.Double(nullable: false),
                        IdLoteVenda = c.Int(nullable: false),
                        Modelo_Id = c.Int(),
                        VendaSapato_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ModeloSapatoes", t => t.Modelo_Id)
                .ForeignKey("dbo.VendaSapatoes", t => t.VendaSapato_Id)
                .Index(t => t.Modelo_Id)
                .Index(t => t.VendaSapato_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoteVendaSapatoes", "VendaSapato_Id", "dbo.VendaSapatoes");
            DropForeignKey("dbo.LoteVendaSapatoes", "Modelo_Id", "dbo.ModeloSapatoes");
            DropForeignKey("dbo.VendaSapatoes", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.LoteVendaSapatoes", new[] { "VendaSapato_Id" });
            DropIndex("dbo.LoteVendaSapatoes", new[] { "Modelo_Id" });
            DropIndex("dbo.VendaSapatoes", new[] { "ClienteId" });
            DropTable("dbo.LoteVendaSapatoes");
            DropTable("dbo.VendaSapatoes");
        }
    }
}
