using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infra.Contextos
{
    public class CarongoContexto : DbContext
    {
        public CarongoContexto(DbContextOptions<CarongoContexto> options) : base(options){}

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioInstituicao> UsuariosInstituicoes { get; set; }
        public DbSet<Instituicao> Instituicoes { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Turma> Turmas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Usuario
            modelBuilder
                .Entity<Usuario>()
                .Property(u => u.Nome)
                .HasColumnType("VARCHAR(40)")
                .IsRequired();

            modelBuilder
                .Entity<Usuario>()
                .Property(u => u.Email)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();
            modelBuilder
                .Entity<Usuario>()
                .HasIndex(u => u.Email)
                    .IsUnique();

            modelBuilder
                .Entity<Usuario>()
                .Property(u => u.Senha)
                .HasColumnType("VARCHAR(60)")
                .IsRequired();
            #endregion

            #region UsuarioInstituicao
            modelBuilder
                .Entity<UsuarioInstituicao>()
                .HasOne(ui => ui.Usuario)
                .WithMany(u => u.UsuariosInstituicoes)
                .HasForeignKey(ui => ui.IdUsuario);

            modelBuilder
                .Entity<UsuarioInstituicao>()
                .HasOne(ui => ui.Instituicao)
                .WithMany(i => i.UsuariosInstituicoes)
                .HasForeignKey(ui => ui.IdInstituicao);

            modelBuilder
                .Entity<UsuarioInstituicao>()
                .Property(ui => ui.Tipo)
                .HasColumnType("INT")
                .IsRequired();
            #endregion

            #region Instituicao
            modelBuilder
                .Entity<Instituicao>()
                .Property(i => i.Nome)
                .HasColumnType("VARCHAR(40)")
                .IsRequired();

            modelBuilder
                .Entity<Instituicao>()
                .Property(i => i.Descricao)
                .HasColumnType("VARCHAR(200)")
                .IsRequired();

            modelBuilder
                .Entity<Instituicao>()
                .Property(i => i.Codigo)
                .HasColumnType("VARCHAR(6)")
                .IsRequired();
            modelBuilder
                .Entity<Instituicao>()
                .HasIndex(i => i.Codigo)
                    .IsUnique();
            #endregion

            #region Turma
            modelBuilder
                .Entity<Turma>()
                .Property(t => t.Nome)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            modelBuilder
                .Entity<Turma>()
                .HasOne(t => t.Instituicao)
                .WithMany(i => i.Turmas)
                .HasForeignKey(t => t.IdInstituicao);
            #endregion

            #region Aluno
            modelBuilder
                .Entity<Aluno>()
                .Property(a => a.Nome)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();
            /*modelBuilder
                .Entity<Aluno>()
                .HasIndex(a => a.Nome)
                    .IsUnique();*/

            modelBuilder
                .Entity<Aluno>()
                .Property(a => a.Email)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();
            /*modelBuilder
                .Entity<Aluno>()
                .HasIndex(a => a.Email)
                    .IsUnique();*/

            modelBuilder
                .Entity<Aluno>()
                .Property(a => a.DataNascimento)
                .HasColumnType("DATETIME")
                .IsRequired();

            modelBuilder
                .Entity<Aluno>()
                .Property(a => a.UrlFoto)
                .HasColumnType("VARCHAR(8000)")
                .IsRequired();
            /*modelBuilder
                .Entity<Aluno>()
                .HasIndex(a => a.UrlFoto)
                    .IsUnique();*/

            modelBuilder
                .Entity<Aluno>()
                .Property(a => a.CPF)
                .HasColumnType("VARCHAR(11)")
                .IsRequired();
            /*modelBuilder
                .Entity<Aluno>()
                .HasIndex(a => a.CPF)
                    .IsUnique();*/

            modelBuilder
                .Entity<Aluno>()
                .HasOne(a => a.Turma)
                .WithMany(t => t.Alunos)
                .HasForeignKey(a => a.IdTurma);
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}