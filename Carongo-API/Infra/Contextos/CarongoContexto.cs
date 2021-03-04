using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infra.Contextos
{
    public class CarongoContexto : DbContext
    {
        public CarongoContexto(DbContextOptions<CarongoContexto> options) : base(options){}

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Turma> Turmas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Usuario

                modelBuilder.Entity<Usuario>().ToTable("Usuarios");

                //PK
                modelBuilder.Entity<Usuario>().Property(u => u.Id); 
                //Nome
                modelBuilder.Entity<Usuario>().Property(u => u.Nome).HasColumnType("VARCHAR(40)");
                modelBuilder.Entity<Usuario>().Property(u => u.Nome).IsRequired();
                //Email
                modelBuilder.Entity<Usuario>().Property(u => u.Email).HasColumnType("VARCHAR(60)");
                modelBuilder.Entity<Usuario>().Property(u => u.Email).IsRequired();
                //Senha
                modelBuilder.Entity<Usuario>().Property(u => u.Senha).HasColumnType("VARCHAR(256)");
                modelBuilder.Entity<Usuario>().Property(u => u.Senha).IsRequired();
                //Data de criação
                modelBuilder.Entity<Usuario>().Property(u => u.DataCriacao).HasColumnType("DATETIME");
                //Tipo
                modelBuilder.Entity<Usuario>().Property(u => u.Tipo).HasColumnType("INT");
                modelBuilder.Entity<Usuario>().Property(u => u.Tipo).IsRequired();

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}