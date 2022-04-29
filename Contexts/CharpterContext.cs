using Charpter.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Charpter.WebApi.Contexts
{
    public class CharpterContext : DbContext
    {
        public CharpterContext()
        {
        }

        public CharpterContext(DbContextOptions<CharpterContext> options) : base(options)
        {
        }

        //metodo utilizado para configurar o banco de dados

        protected override void

           OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //cada provedor tem sua sintaxe para especificação;
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-MM3CABC\\SQLEXPRESS; initial catalog = Chapter;Integrated Security = true");
            }
        }
        //dbset representa as entidades  que serão utilizadas nas operãções de leitura, criação , atualização e deleção;

        public DbSet<Livro>? Livros { get; set; }

        public DbSet<Usuario>? Usuarios { get; set; }   
    }
}
