namespace XMedicalLite_Windows.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actualizacion_modelos : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Expediente", "Pulso");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Expediente", "Pulso", c => c.Int(nullable: false));
        }
    }
}
