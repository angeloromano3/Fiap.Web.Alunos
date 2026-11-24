using Fiap.Web.Alunos.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.Alunos.Data
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<RepresentanteModel> Representantes { get; set; }

        // Novo: DbSet que transforma o ClienteModel na tabela Clientes
        public virtual DbSet<ClienteModel> Clientes { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DatabaseContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RepresentanteModel>(entity =>
            {
                entity.ToTable("Representantes");
                entity.HasKey(e => e.RepresentanteId);
                entity.Property(e => e.NomeRepresentante).IsRequired();
                entity.HasIndex(e => e.Cpf).IsUnique();
            });

            // Novo: regras da tabela Clientes
            modelBuilder.Entity<ClienteModel>(entity =>
            {
                entity.ToTable("Clientes");                                     // nome da tabela
                entity.HasKey(e => e.ClienteId);                                // chave primária
                entity.Property(e => e.Nome).IsRequired();                      // nome obrigatório
                entity.Property(e => e.Email).IsRequired();                     // email obrigatório
                entity.Property(e => e.DataNascimento).HasColumnType("date");   // só a data, sem hora
                entity.Property(e => e.Observacao).HasMaxLength(500);           // até 500 caracteres

                // Relacionamento: cada cliente tem um representante, e um representante tem vários clientes
                entity.HasOne(e => e.Representante)
                      .WithMany()
                      .HasForeignKey(e => e.RepresentanteId)                    // chave estrangeira
                      .IsRequired();                                            // cliente sempre precisa de representante
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}