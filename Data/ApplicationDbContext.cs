using FinxGestaoPacientes.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinxGestaoPacientes.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<HistoricoMedico> HistoricoMedicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(p => p.PacienteId);
                entity.Property(p => p.Nome).IsRequired().HasMaxLength(100);
                entity.Property(p => p.CPF).IsRequired().HasMaxLength(11);
                entity.HasIndex(p => p.CPF).IsUnique();
                entity.Property(p => p.Endereco).HasMaxLength(200);
                // entity.HasMany(p => p.HistoricoMedicos)
                //       .WithOne(h => h.Paciente)
                //       .HasForeignKey(h => h.PacienteId)
                //       .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<HistoricoMedico>(entity =>
            {
                entity.HasKey(h => h.HistoricoMedicoId);
                entity.Property(h => h.DataConsulta).IsRequired();
                entity.Property(h => h.Diagnostico).IsRequired().HasMaxLength(500);
                entity.Property(h => h.Tratamento).HasMaxLength(500);

                entity.HasOne(h => h.Paciente)
                    .WithMany(p => p.HistoricoMedicos)
                    .HasForeignKey(h => h.PacienteId)
                    .IsRequired();
            });
        }
    }
}
