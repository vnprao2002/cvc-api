using CVC_Project.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CVC_Project.Data
{
    public class ShopDbContext : DbContext
    {
        public DbSet<Product> Products { get; set;}
        public DbSet<Categories> Categories { get; set; }
        public DbSet<SubCategories> SubCategories { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<TypicalCategories> TypicalCategories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server = tcp:cvc.database.windows.net, 1433; Initial Catalog = Db_CVC; Persist Security Info = False; User ID = cvcadmin; Password =f3KUqLRops; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderDetails>().HasKey(e => new {e.OrderId, e.ProductId});
        }
    }
}
