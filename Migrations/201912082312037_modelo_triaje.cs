namespace XMedicalLite_Windows.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelo_triaje : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Triaje",
                c => new
                    {
                        TriajeID = c.Int(nullable: false, identity: true),
                        Color = c.String(),
                        Codigo = c.Int(nullable: false),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.TriajeID);
            
            AddColumn("dbo.Expediente", "TriajeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Expediente", "TriajeID");
            AddForeignKey("dbo.Expediente", "TriajeID", "dbo.Triaje", "TriajeID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expediente", "TriajeID", "dbo.Triaje");
            DropIndex("dbo.Expediente", new[] { "TriajeID" });
            DropColumn("dbo.Expediente", "TriajeID");
            DropTable("dbo.Triaje");
        }
    }
}
