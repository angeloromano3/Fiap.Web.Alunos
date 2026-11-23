using Fiap.Web.Alunos.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.Alunos.Data
{
    public class DatabaseContext : DbContext
    {

        public virtual DbSet<RepresentanteModel> Representantes { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DatabaseContext()
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RepresentanteModel>( entity => {

                entity.ToTable("Representantes");
                entity.HasKey( e=> e.RepresentanteId);
                entity.Property(e => e.NomeRepresentante).IsRequired();
                entity.HasIndex(e=> e.Cpf).IsUnique();

            }); 




            base.OnModelCreating(modelBuilder);
        }

    }
}
