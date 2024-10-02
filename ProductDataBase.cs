using Microsoft.EntityFrameworkCore;
using PetProjectC_NeuroWeb.Modules.ProductModule.Core;

namespace PetProjectC_NeuroWeb
{
    public class ProductDataBase : DbContext
    {
        public ProductDataBase()
        {
            Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }
        public override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql();//вставить путь
        }
    }
}
