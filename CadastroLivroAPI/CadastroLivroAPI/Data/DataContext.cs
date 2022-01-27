using Microsoft.EntityFrameworkCore;

namespace CadastroLivroAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<CadastroLivro> CadastroLivros { get; set; }

    }
}
