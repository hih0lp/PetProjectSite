using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetProjectC_NeuroWeb.Modules.ProductModule.Core;
using PetProjectC_NeuroWeb.Modules.UserModule.Core;

namespace PetProjectC_NeuroWeb
{
    public class DataBase : DbContext
    {
        public DataBase()
        {
            Database.EnsureCreated();               
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        public override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(); //input path
        }
    }
}
