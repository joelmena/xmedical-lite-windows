namespace XMedicalLite_Windows.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class primera_migracion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Expediente",
                c => new
                    {
                        ExpedienteID = c.Int(nullable: false, identity: true),
                        PacienteID = c.Int(nullable: false),
                        Aseguradora = c.String(),
                        NumeroNSS = c.String(),
                        MotivoIngreso = c.String(),
                        Antecedentes = c.String(),
                        Pulso = c.Int(nullable: false),
                        FrecuenciaCardiaca = c.Int(nullable: false),
                        PrecionArteriar = c.String(),
                        FrecuenciaRespiratoria = c.Int(nullable: false),
                        ExamenPaciente = c.String(),
                        Diagnostico = c.String(),
                        Conducta = c.String(),
                        Evolucion = c.String(),
                        Recomendacion = c.String(),
                    })
                .PrimaryKey(t => t.ExpedienteID)
                .ForeignKey("dbo.Paciente", t => t.PacienteID, cascadeDelete: true)
                .Index(t => t.PacienteID);
            
            CreateTable(
                "dbo.Paciente",
                c => new
                    {
                        PacienteID = c.Int(nullable: false, identity: true),
                        Nombres = c.String(),
                        Apellidos = c.String(),
                        Sexo = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Cedula = c.String(),
                        EstadoCivil = c.String(),
                        Telefono = c.String(),
                        Direccion = c.String(),
                        Provincia = c.String(),
                        Municipio = c.String(),
                    })
                .PrimaryKey(t => t.PacienteID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expediente", "PacienteID", "dbo.Paciente");
            DropIndex("dbo.Expediente", new[] { "PacienteID" });
            DropTable("dbo.Paciente");
            DropTable("dbo.Expediente");
        }
    }
}
