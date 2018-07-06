namespace SapatosWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration12 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Estoques",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModeloId = c.Int(nullable: false),
                        QtdDisponivel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ModeloSapatoes", t => t.ModeloId, cascadeDelete: true)
                .Index(t => t.ModeloId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Estoques", "ModeloId", "dbo.ModeloSapatoes");
            DropIndex("dbo.Estoques", new[] { "ModeloId" });
            DropTable("dbo.Estoques");
        }
    }
}
