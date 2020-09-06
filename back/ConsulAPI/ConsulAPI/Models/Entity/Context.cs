using Microsoft.EntityFrameworkCore;


namespace ConsulAPI.Models
{
    public partial class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
                 : base(options)
        {
        }

        public virtual DbSet<Medico> Medico { get; set; }
        public virtual DbSet<Consultorio> Consultorio { get; set; }
        public virtual DbSet<MedicoConsultorio> MedicoConsultorio { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicoConsultorio>()
                .HasKey(x => new { x.MedicosId, x.ConsultoriosId });

            modelBuilder.Entity<MedicoConsultorio>()
                .HasOne(x => x.Medico)
                .WithMany(y => y.MedicosConsultorios)
                .HasForeignKey(y => y.MedicosId);

            modelBuilder.Entity<MedicoConsultorio>()
                .HasOne(x => x.Consultorio)
                .WithMany(y => y.MedicosConsultorios)
                .HasForeignKey(y => y.ConsultoriosId);

            modelBuilder.HasSequence("sq_medicos");
            modelBuilder.HasSequence("sq_consultorios");
        }
    }
}
