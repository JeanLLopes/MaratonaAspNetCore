using FanSoftStore.UI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FanSoftStore.UI.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _config;

        //INJECTOR DEPENDENCY
        public DataContext(IConfiguration config)
        {
            _config = config;
        }

        //GET THE STRING CONNECTION
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //USING KEY AVAILABLE IN appsetings
            optionsBuilder.UseSqlServer(_config.GetConnectionString("FanStoreConnection"));
        }

        //MAP THE TABLE
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<TipoProdutoModel> TipoProdutos { get; set; }
    }
}
