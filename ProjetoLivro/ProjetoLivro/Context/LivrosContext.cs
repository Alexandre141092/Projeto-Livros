using Microsoft.EntityFrameworkCore;
using ProjetoLivro.Models;

namespace ProjetoLivro.Context
{
    public class LivrosContext : DbContext
    {
        //Cada - Tabela -> DbSet
        public DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Assinaturas> Assinaturas { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        public LivrosContext(DbContextOptions<LivrosContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=NOTE36-S28\\SQLEXPRESS;Initial Catalog=Livros;User Id=sa;Password=Senai@134;TrustServerCertificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(
                //Representcao da tabela
                entity =>
                {
                    //Primarykey
                    entity.HasKey(u => u.UsuarioId);

                    //como configura um campo
                    entity.Property(u=> u.NomeCompleto)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                    entity.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                    //Email unico
                    entity.HasIndex(u => u.Email)
                    .IsUnique();

                    entity.Property(u => u.Senha)
                   .IsRequired()
                   .HasMaxLength(255)
                   .IsUnicode(false);

                    entity.Property(u => u.Telefone)
                   .IsRequired()
                   .HasMaxLength(15)
                   .IsUnicode(false);

                    entity.Property(u => u.DataCadstro)
                   .IsRequired();

                    entity.Property(u => u.DataAtualizacao)
                   .IsRequired();

                    entity.HasOne(u => u.TipoUsuario)
                    .WithMany(t => t.Usuarios)
                    .HasForeignKey(u => u.TipoUsuario)
                    // cascade apaga um adm apaga todos 
                    //set null ele nao apaga o cliente mas deixa o usuario nulo
                    .OnDelete(DeleteBehavior.Cascade);
                   




                }


            );
        }
    }
}
