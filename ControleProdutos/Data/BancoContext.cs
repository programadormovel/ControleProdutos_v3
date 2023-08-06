using ControleProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleProdutos.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }

        public DbSet<ProdutoModel> Produtos { get; set; }
    }


}
