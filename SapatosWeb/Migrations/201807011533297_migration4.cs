namespace SapatosWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LoteVendaSapatoes", "Modelo_Id", "dbo.ModeloSapatoes");
            DropForeignKey("dbo.LoteVendaSapatoes", "VendaSapato_Id", "dbo.VendaSapatoes");
            DropIndex("dbo.LoteVendaSapatoes", new[] { "Modelo_Id" });
            DropIndex("dbo.LoteVendaSapatoes", new[] { "VendaSapato_Id" });
            AddColumn("dbo.VendaSapatoes", "Tamanho", c => c.Int(nullable: false));
            AddColumn("dbo.VendaSapatoes", "Preco", c => c.Double(nullable: false));
            AddColumn("dbo.VendaSapatoes", "Modelo_Id", c => c.Int());
            CreateIndex("dbo.VendaSapatoes", "Modelo_Id");
            AddForeignKey("dbo.VendaSapatoes", "Modelo_Id", "dbo.ModeloSapatoes", "Id");
            DropColumn("dbo.VendaSapatoes", "PrecoTotal");
            DropTable("dbo.LoteVendaSapatoes");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.VendaSapatoes", "PrecoTotal", c => c.Double(nullable: false));
            DropForeignKey("dbo.VendaSapatoes", "Modelo_Id", "dbo.ModeloSapatoes");
            DropIndex("dbo.VendaSapatoes", new[] { "Modelo_Id" });
            DropColumn("dbo.VendaSapatoes", "Modelo_Id");
            DropColumn("dbo.VendaSapatoes", "Preco");
            DropColumn("dbo.VendaSapatoes", "Tamanho");
            CreateIndex("dbo.LoteVendaSapatoes", "VendaSapato_Id");
            CreateIndex("dbo.LoteVendaSapatoes", "Modelo_Id");
            AddForeignKey("dbo.LoteVendaSapatoes", "VendaSapato_Id", "dbo.VendaSapatoes", "Id");
            AddForeignKey("dbo.LoteVendaSapatoes", "Modelo_Id", "dbo.ModeloSapatoes", "Id");
        }
    }
}
