using FanSoftStore.UI.Models;
using Microsoft.EntityFrameworkCore;

namespace FanSoftStore.UI.Data
{
    public class DataContext : DbContext
    {
        //GET THE STRING CONNECTION
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB_FANSOFTSTORE;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        //MAP THE TABLE
        public DbSet<ProdutoModel> Produtos { get; set; }
    }
}
