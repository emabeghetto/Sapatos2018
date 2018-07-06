namespace SapatosWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VendaSapatoes", "ClienteVenda_Id", "dbo.Clientes");
            DropForeignKey("dbo.VendaSapatoes", "Modelo_Id", "dbo.ModeloSapatoes");
            DropIndex("dbo.VendaSapatoes", new[] { "ClienteVenda_Id" });
            DropIndex("dbo.VendaSapatoes", new[] { "Modelo_Id" });
            RenameColumn(table: "dbo.VendaSapatoes", name: "ClienteVenda_Id", newName: "ClienteVendaID");
            RenameColumn(table: "dbo.VendaSapatoes", name: "Modelo_Id", newName: "ModeloSapatoID");
            AlterColumn("dbo.VendaSapatoes", "ClienteVendaID", c => c.Int(nullable: false));
            AlterColumn("dbo.VendaSapatoes", "ModeloSapatoID", c => c.Int(nullable: false));
            CreateIndex("dbo.VendaSapatoes", "ClienteVendaID");
            CreateIndex("dbo.VendaSapatoes", "ModeloSapatoID");
            AddForeignKey("dbo.VendaSapatoes", "ClienteVendaID", "dbo.Clientes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.VendaSapatoes", "ModeloSapatoID", "dbo.ModeloSapatoes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VendaSapatoes", "ModeloSapatoID", "dbo.ModeloSapatoes");
            DropForeignKey("dbo.VendaSapatoes", "ClienteVendaID", "dbo.Clientes");
            DropIndex("dbo.VendaSapatoes", new[] { "ModeloSapatoID" });
            DropIndex("dbo.VendaSapatoes", new[] { "ClienteVendaID" });
            AlterColumn("dbo.VendaSapatoes", "ModeloSapatoID", c => c.Int());
            AlterColumn("dbo.VendaSapatoes", "ClienteVendaID", c => c.Int());
            RenameColumn(table: "dbo.VendaSapatoes", name: "ModeloSapatoID", newName: "Modelo_Id");
            RenameColumn(table: "dbo.VendaSapatoes", name: "ClienteVendaID", newName: "ClienteVenda_Id");
            CreateIndex("dbo.VendaSapatoes", "Modelo_Id");
            CreateIndex("dbo.VendaSapatoes", "ClienteVenda_Id");
            AddForeignKey("dbo.VendaSapatoes", "Modelo_Id", "dbo.ModeloSapatoes", "Id");
            AddForeignKey("dbo.VendaSapatoes", "ClienteVenda_Id", "dbo.Clientes", "Id");
        }
    }
}
