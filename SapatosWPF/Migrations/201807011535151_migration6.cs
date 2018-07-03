namespace SapatosWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LoteVendaSapatoes", "VendaSapato_Id", "dbo.VendaSapatoes");
            DropIndex("dbo.LoteVendaSapatoes", new[] { "VendaSapato_Id" });
            AddColumn("dbo.VendaSapatoes", "Tamanho", c => c.Int(nullable: false));
            AddColumn("dbo.VendaSapatoes", "Preco", c => c.Double(nullable: false));
            AddColumn("dbo.VendaSapatoes", "Modelo_Id", c => c.Int());
            CreateIndex("dbo.VendaSapatoes", "Modelo_Id");
            AddForeignKey("dbo.VendaSapatoes", "Modelo_Id", "dbo.ModeloSapatoes", "Id");
            DropColumn("dbo.LoteVendaSapatoes", "VendaSapato_Id");
            DropColumn("dbo.VendaSapatoes", "PrecoTotal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VendaSapatoes", "PrecoTotal", c => c.Double(nullable: false));
            AddColumn("dbo.LoteVendaSapatoes", "VendaSapato_Id", c => c.Int());
            DropForeignKey("dbo.VendaSapatoes", "Modelo_Id", "dbo.ModeloSapatoes");
            DropIndex("dbo.VendaSapatoes", new[] { "Modelo_Id" });
            DropColumn("dbo.VendaSapatoes", "Modelo_Id");
            DropColumn("dbo.VendaSapatoes", "Preco");
            DropColumn("dbo.VendaSapatoes", "Tamanho");
            CreateIndex("dbo.LoteVendaSapatoes", "VendaSapato_Id");
            AddForeignKey("dbo.LoteVendaSapatoes", "VendaSapato_Id", "dbo.VendaSapatoes", "Id");
        }
    }
}
