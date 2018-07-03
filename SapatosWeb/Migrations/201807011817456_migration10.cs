namespace SapatosWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VendaSapatoes", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.VendaSapatoes", new[] { "ClienteId" });
            RenameColumn(table: "dbo.VendaSapatoes", name: "ClienteId", newName: "ClienteVenda_Id");
            AlterColumn("dbo.VendaSapatoes", "ClienteVenda_Id", c => c.Int());
            CreateIndex("dbo.VendaSapatoes", "ClienteVenda_Id");
            AddForeignKey("dbo.VendaSapatoes", "ClienteVenda_Id", "dbo.Clientes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VendaSapatoes", "ClienteVenda_Id", "dbo.Clientes");
            DropIndex("dbo.VendaSapatoes", new[] { "ClienteVenda_Id" });
            AlterColumn("dbo.VendaSapatoes", "ClienteVenda_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.VendaSapatoes", name: "ClienteVenda_Id", newName: "ClienteId");
            CreateIndex("dbo.VendaSapatoes", "ClienteId");
            AddForeignKey("dbo.VendaSapatoes", "ClienteId", "dbo.Clientes", "Id", cascadeDelete: true);
        }
    }
}
