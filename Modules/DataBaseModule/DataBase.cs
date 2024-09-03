using Microsoft.EntityFrameworkCore;
using PetProjectC_NeuroWeb.Modules.UserModule;
namespace PetProjectC_NeuroWeb.Modules.DataBaseModule
{
    public class UserDataBase : DbContext
    {

        public UserDataBase()
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        protected override OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql();//положить путь к базе данных 
        }

    }
}
