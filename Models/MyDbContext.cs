using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading.Tasks;

namespace XMedicalLite.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("connectionDB")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Expediente> Expedientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Sexo> Sexos { get; set; }
        public DbSet<EstadoCivil> EstadosCivil { get; set; }
        public DbSet<Triaje> Triajes { get; set; }
    }
}
