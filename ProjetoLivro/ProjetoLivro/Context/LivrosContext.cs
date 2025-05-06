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
            //string de conexao
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
                    entity.Property(u => u.NomeCompleto)
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
                    .HasForeignKey(u => u.TipoUsuarioId)
                    // cascade apaga um adm apaga todos 
                    //set null ele nao apaga o cliente mas deixa o usuario nulo
                    .OnDelete(DeleteBehavior.Cascade);





                });

            modelBuilder.Entity<TipoUsuario>(entity => 
            {
                entity.HasKey(t => t.TipoUsuarioId);

                entity.Property(t=>t.DescricaoTipo)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

                entity.HasIndex(t=>t.DescricaoTipo)
                .IsUnique();
            });

            modelBuilder.Entity<Livro>(entity =>
            {
                entity.HasKey(t => t.LivroId);

                entity.Property(t => t.Titulo)
               .IsRequired()
               .HasMaxLength(200)
               .IsUnicode(false);

                entity.Property(t => t.Autor)
               .IsRequired()
               .HasMaxLength(200)
               .IsUnicode(false);

                entity.Property(t => t.Descricao)
               .IsRequired()
               .HasMaxLength(100)
               .IsUnicode(false);

                entity.Property(t => t.DataPublicacao)
               .IsRequired();

                entity.HasOne(t => t.Categoria)
                .WithMany(c =>c.Livros)
                .HasForeignKey(t => t.CategoriaId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(c => c.CategoriaId);

                entity.Property(t => t.NomeCategoria)
               .IsRequired()
               .HasMaxLength(200)
               .IsUnicode(false);

            });

            modelBuilder.Entity<Assinaturas>(entity =>
            {
                entity.HasKey(a => a.AssinaturaId);

                entity.Property(a => a.DataInicio)
                .IsRequired();

                entity.Property(a => a.Status)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

                //Assinatura - Usuario
                entity.HasOne(a => a.Usuario)
                .WithMany()
                .HasForeignKey(a => a.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            }


          


           


                
                
              

               
           

            




            );
        }
    }
}
